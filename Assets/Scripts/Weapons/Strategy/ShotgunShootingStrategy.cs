using UnityEngine;

public class ShotgunShootingStrategy : IShootingStrategy
{
    private readonly float _angleVariation;
    private readonly int _numberOfBullets;
    private readonly float _maxBulletDistance;

    public ShotgunShootingStrategy(float angleVariation, int numberOfBullets, float maxBulletDistance)
    {
        _angleVariation = angleVariation;
        _numberOfBullets = numberOfBullets;
        _maxBulletDistance = maxBulletDistance;  // Оставляем этот параметр для использования в стрельбе
    }

    public void Shoot(Transform firePoint, GameObject bulletPrefab, float bulletSpeed, int damage, BulletPool bulletPool)
    {
        for (int i = 0; i < _numberOfBullets; i++)
        {
            float randomAngle = Random.Range(-_angleVariation, _angleVariation);
            Vector2 bulletDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.right;

            GameObject bullet = bulletPool.GetBullet();
            bullet.transform.position = firePoint.position;
            bullet.SetActive(true);

            if (bullet.TryGetComponent<Bullet>(out var bulletComponent))
            {
                // Передаем максимальную дальность пули при инициализации
                bulletComponent.Initialize(bulletDirection, bulletSpeed, damage, bulletPool, _maxBulletDistance);
            }

            Debug.Log("Shotgun fired in direction: " + bulletDirection);
        }
    }
}
