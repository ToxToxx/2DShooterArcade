using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private GameObject _bulletPrefab;
    private Queue<GameObject> _bullets;
    private int _poolSize;

    public void Initialize(GameObject bulletPrefab, int poolSize)
    {
        _bulletPrefab = bulletPrefab;
        _poolSize = poolSize;
        _bullets = new Queue<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.SetActive(false);
            _bullets.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (_bullets.Count > 0)
        {
            return _bullets.Dequeue();
        }
        else
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.SetActive(false);
            return bullet;
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        _bullets.Enqueue(bullet);
    }
}
