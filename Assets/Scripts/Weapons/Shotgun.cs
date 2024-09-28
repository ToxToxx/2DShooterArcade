using System.Collections;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private float _maxBulletDistance = 10f;
    [SerializeField] private int _numberOfBullets = 3;
    [SerializeField] private float _angleVariation = 10f; 

    public override void Shoot()
    {
        float bulletSpeed = 10f;

        for (int i = 0; i < _numberOfBullets; i++)
        {

            float randomAngle = Random.Range(-_angleVariation, _angleVariation);
            Vector2 bulletDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.right;

            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = bulletDirection.normalized * bulletSpeed;

            Debug.Log("Raycast shot fired in direction: " + bulletDirection);

            StartCoroutine(DestroyBulletAfterDistance(bullet, bulletDirection, _maxBulletDistance));
        }
    }

    private IEnumerator DestroyBulletAfterDistance(GameObject bullet, Vector2 direction, float maxDistance)
    {
        float traveledDistance = 0f;
        Vector2 initialPosition = bullet.transform.position;

        while (traveledDistance < maxDistance)
        {
            traveledDistance = Vector2.Distance(initialPosition, bullet.transform.position);
            yield return null;
        }

        Destroy(bullet);
    }
}
