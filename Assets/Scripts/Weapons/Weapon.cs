using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponDataSO WeaponDataSO;
    public GameObject BulletPrefab;

    public string WeaponName { get; protected set; }
    public int Damage { get; protected set; }
    public float FireRate { get; protected set; }

    private float _nextFireTime;

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

    public virtual void InitializeBulletPool() { }
    public abstract void Shoot();
}
