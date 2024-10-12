using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    private GameObject _bulletPrefab;
    private ObjectPool<GameObject> _bulletPool;
    private HashSet<GameObject> _activeBullets; 

    public void Initialize(GameObject bulletPrefab, int poolSize)
    {
        _bulletPrefab = bulletPrefab;
        _activeBullets = new HashSet<GameObject>(); 
        _bulletPool = new ObjectPool<GameObject>(() =>
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.SetActive(false);
            return bullet;
        }, bullet =>
        {
            bullet.SetActive(true);
            _activeBullets.Add(bullet); 
        }, bullet =>
        {
            bullet.SetActive(false);
            _activeBullets.Remove(bullet);
        }, bullet => Destroy(bullet), true, poolSize, poolSize);
    }

    public GameObject GetBullet()
    {
        return _bulletPool.Get();
    }

    public void ReturnBullet(GameObject bullet)
    {
        if (_activeBullets.Contains(bullet)) 
        {
            bullet.transform.rotation = Quaternion.identity;
            _bulletPool.Release(bullet);
        }
        else
        {
            Debug.LogWarning("Trying to release a bullet that is already in the pool.");
        }
    }
}
