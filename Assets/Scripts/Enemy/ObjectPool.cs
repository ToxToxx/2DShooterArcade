using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _poolSize = 10; 

    private readonly Queue<GameObject> _pool = new();

    private void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefab);
            enemy.SetActive(false);
            _pool.Enqueue(enemy);
        }
    }

    public GameObject GetFromPool()
    {
        if (_pool.Count > 0)
        {
            GameObject enemy = _pool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        else
        {
            GameObject newEnemy = Instantiate(_enemyPrefab);
            return newEnemy;
        }
    }

    public void ReturnToPool(GameObject enemy)
    {
        enemy.SetActive(false);
        _pool.Enqueue(enemy);
    }
}
