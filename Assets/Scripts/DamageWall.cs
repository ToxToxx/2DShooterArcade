using UnityEngine;

public class DamageWall : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private PlayerHealthController _playerHealthController;
    [SerializeField] private int _damageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsInLayerMask(collision.gameObject, _enemyLayer))
        {
            _playerHealthController.TakeDamage(_damageAmount);
        }
    }

    private bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return (layerMask.value & (1 << obj.layer)) != 0;
    }
}
