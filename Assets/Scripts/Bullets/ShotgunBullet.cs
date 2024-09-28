using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    [SerializeField] private float _bulletLifetime;
    private void OnEnable()
    {
        Destroy(gameObject, _bulletLifetime);
    }
}
