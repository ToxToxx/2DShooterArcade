using UnityEngine;

public class Bullet : MonoBehaviour
{
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

    public void Initialize(Vector2 direction, float speed)
    {
        _rigidbody2D.velocity = direction * speed;
        Invoke(nameof(ReturnToPool), _bulletLifeTime);
    }

    public void ReturnToPool()
    {
        _bulletPool.ReturnBullet(gameObject);
    }

    private void OnDisable()
    {
        CancelInvoke();
        _rigidbody2D.velocity = Vector2.zero;
    }
}
