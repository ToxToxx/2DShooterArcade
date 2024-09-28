using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootingStrategy
{
    void Shoot(Transform firePoint, GameObject bulletPrefab, float bulletSpeed, int damage, BulletPool bulletPool);
}
