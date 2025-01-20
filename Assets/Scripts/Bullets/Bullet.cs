using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletLifeTime = 2f;

    private BulletPool _bulletPool;
    private Rigidbody2D _rigidbody2D;
    private float _lifeTimeTimer;
    private int _damage;
    private float _maxDistance;  
    private Vector2 _startPosition;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetBulletPool(BulletPool pool)
    {
        _bulletPool = pool;
    }


    public void Initialize(Vector2 direction, float speed, int damage, BulletPool pool, float maxDistance)
    {
        _rigidbody2D.linearVelocity = direction * speed;
        _damage = damage;
        _bulletPool = pool;
        _maxDistance = maxDistance;  
        _startPosition = transform.position;  
        _lifeTimeTimer = _bulletLifeTime;
    }

    private void Update()
    {
        float distanceTraveled = Vector2.Distance(_startPosition, transform.position);
        if (distanceTraveled >= _maxDistance)
        {
            ReturnToPool(); 
        }

        _lifeTimeTimer -= Time.deltaTime;
        if (_lifeTimeTimer <= 0)
        {
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        _bulletPool.ReturnBullet(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealthController targetHealth))
        {
            targetHealth.TakeDamage(_damage);
        }

        ReturnToPool();
    }

    private void OnDisable()
    {
        _rigidbody2D.linearVelocity = Vector2.zero;
    }
}