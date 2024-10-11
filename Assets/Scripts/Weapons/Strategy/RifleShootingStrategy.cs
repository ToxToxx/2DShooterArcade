using UnityEngine;

public class RifleShootingStrategy : IShootingStrategy
{
    private readonly float _maxBulletDistance;

    public RifleShootingStrategy(float maxBulletDistance)
    {
        _maxBulletDistance = maxBulletDistance;
    }

    public void Shoot(Transform firePoint, GameObject bulletPrefab, float bulletSpeed, int damage, BulletPool bulletPool)
    {
        Vector2 bulletDirection = firePoint.right;

        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.SetActive(true);

        if (bullet.TryGetComponent<Bullet>(out var bulletComponent))
        {
            bulletComponent.Initialize(bulletDirection, bulletSpeed, damage, bulletPool, _maxBulletDistance);
        }
    }
}
