using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponDataSO WeaponDataSO;
    public GameObject BulletPrefab;

    [SerializeField] private float _bulletSpeed = 20f;  // Скорость пули задается в классе Weapon
    [SerializeField] private int _bulletPoolCount = 20; // Размер пула пуль также задается в классе Weapon

    public string WeaponName { get; protected set; }
    public int Damage { get; protected set; }
    public float FireRate { get; protected set; }

    private float _nextFireTime;
    protected IShootingStrategy _shootingStrategy;
    private BulletPool _bulletPool;

    protected virtual void Awake()
    {
        if (WeaponDataSO != null)
        {
            WeaponName = WeaponDataSO.WeaponName;
            Damage = WeaponDataSO.Damage;
            FireRate = WeaponDataSO.FireRate;
        }
        else
        {
            Debug.LogError("WeaponDataSO is not assigned.");
        }

        InitializeBulletPool();
    }

    private void Update()
    {
        if (InputManager.ShootWasHeld && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + FireRate;
            Shoot();
        }
    }

    public virtual void InitializeBulletPool()
    {
        if (_bulletPool == null)
        {
            _bulletPool = gameObject.AddComponent<BulletPool>();
            _bulletPool.Initialize(BulletPrefab, _bulletPoolCount);  // Используем поле _bulletPoolCount
        }
    }

    public void SetShootingStrategy(IShootingStrategy shootingStrategy)
    {
        _shootingStrategy = shootingStrategy;
    }

    public virtual void Shoot()
    {
        _shootingStrategy.Shoot(transform, BulletPrefab, _bulletSpeed, Damage, _bulletPool);  // Используем поле _bulletSpeed
    }
}
