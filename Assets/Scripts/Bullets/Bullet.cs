using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private float _bulletLifeTime = 2f;

    private BulletPool _bulletPool;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetBulletPool(BulletPool pool)
    {
        _bulletPool = pool;
    }

    private void OnEnable()
    {
        _rigidbody2D.velocity = transform.right * _bulletSpeed;
        Invoke(nameof(ReturnToPool), _bulletLifeTime);
    }

    private void ReturnToPool()
    {
        if (_bulletPool != null)
        {
            _bulletPool.ReturnBullet(gameObject);
        }
        else
        {
            Debug.LogError("Bullet pool is not set!");
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
        _rigidbody2D.velocity = Vector2.zero; 
    }
}
