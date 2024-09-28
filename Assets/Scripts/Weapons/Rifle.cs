using UnityEngine;
public class Rifle : Weapon
{
    private BulletPool _bulletPool;
    [SerializeField] private int _bulletPoolCount = 20;
    public override void Shoot()
    {
        float bulletSpeed = 20f;
        Vector2 bulletDirection = transform.right;

        GameObject bullet = _bulletPool.GetBullet();
        bullet.transform.position = transform.position;
        bullet.SetActive(true);

        if (bullet.TryGetComponent<Bullet>(out var bulletComponent))
        {
            bulletComponent.SetBulletPool(_bulletPool);
            bulletComponent.Initialize(bulletDirection, bulletSpeed);
        }
    }

    public override void InitializeBulletPool()
    {
        if (_bulletPool == null)
        {
            _bulletPool = gameObject.AddComponent<BulletPool>();
            _bulletPool.Initialize(BulletPrefab, _bulletPoolCount);
        }
    }
}
