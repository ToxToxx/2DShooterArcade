using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    private GameObject _bulletPrefab;
    private ObjectPool<GameObject> _bulletPool;

    public void Initialize(GameObject bulletPrefab, int poolSize)
    {
        _bulletPrefab = bulletPrefab;
        _bulletPool = new ObjectPool<GameObject>(() =>
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.SetActive(false);
            return bullet;
        }, bullet => bullet.SetActive(true), bullet => bullet.SetActive(false), bullet => Destroy(bullet), true, poolSize, poolSize);
    }

    public GameObject GetBullet()
    {
        return _bulletPool.Get();
    }

    public void ReturnBullet(GameObject bullet)
    {
        _bulletPool.Release(bullet);
    }
}