using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    private ObjectPool _objectPool;
    public EnemyStatsSO EnemyStats;  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealthController>(out var playerHealth))
        {
            playerHealth.TakeDamage(EnemyStats.Damage);
            Debug.Log($"{EnemyStats.EnemyName} hit the player, dealing {EnemyStats.Damage} damage.");
            _objectPool.ReturnToPool(gameObject);
        }
    }
    public void SetObjectPool(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }

}
