using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponDataSO WeaponDataSO;
    public GameObject BulletPrefab;
    public string WeaponName { get; protected set; }
    public int Damage { get; protected set; }
    public float FireRate { get; protected set; }

    protected BulletPool BulletPool;
    private float nextFireTime;

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

        BulletPool = gameObject.AddComponent<BulletPool>();
        BulletPool.Initialize(BulletPrefab, 20);
    }

    private void Update()
    {
        if (InputManager.ShootWasHeld && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + FireRate;
            Shoot();
        }
    }

    public abstract void Shoot();
}
