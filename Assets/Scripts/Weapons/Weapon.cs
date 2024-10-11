using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponDataSO WeaponDataSO;
    public GameObject BulletPrefab;

    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private int _bulletPoolCount = 20;
    [SerializeField] private Transform _firepoint;

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
            Shoot(_firepoint);
        }
    }

    public virtual void InitializeBulletPool()
    {
        if (_bulletPool == null)
        {
            _bulletPool = gameObject.AddComponent<BulletPool>();
            _bulletPool.Initialize(BulletPrefab, _bulletPoolCount);
        }
    }

    public void SetShootingStrategy(IShootingStrategy shootingStrategy)
    {
        _shootingStrategy = shootingStrategy;
    }

    public virtual void Shoot(Transform firepoint)
    {
        _shootingStrategy.Shoot(firepoint, BulletPrefab, _bulletSpeed, Damage, _bulletPool);
    }
}
