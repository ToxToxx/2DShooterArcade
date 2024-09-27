using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot()
    {
        GameObject bullet = BulletPool.GetBullet();
        bullet.transform.position = transform.position;
        bullet.SetActive(true);

        if (bullet.TryGetComponent<Bullet>(out var bulletComponent))
        {
            bulletComponent.SetBulletPool(BulletPool);
        }
        else
        {
            Debug.LogError("Bullet prefab does not have a Bullet component attached.");
        }
    }
}
