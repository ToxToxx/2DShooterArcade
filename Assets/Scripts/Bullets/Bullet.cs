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
        _rigidbody2D.velocity = direction * speed;
        _damage = damage;
        _bulletPool = pool;
        _maxDistance = maxDistance;  // Устанавливаем максимальную дальность
        _startPosition = transform.position;  // Запоминаем стартовую позицию пули
        _lifeTimeTimer = _bulletLifeTime;
    }

    private void Update()
    {
        // Отслеживаем расстояние, которое прошла пуля
        float distanceTraveled = Vector2.Distance(_startPosition, transform.position);
        if (distanceTraveled >= _maxDistance)
        {
            ReturnToPool();  // Возвращаем пулю, если она превысила максимальную дистанцию
        }

        // Также можем учитывать время жизни пули
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
/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health targetHealth))
        {
            targetHealth.TakeDamage(_damage);
        }
        ReturnToPool();
    }
*/
    private void OnDisable()
    {
        // Сбрасываем состояние пули
        _rigidbody2D.velocity = Vector2.zero;
    }
}