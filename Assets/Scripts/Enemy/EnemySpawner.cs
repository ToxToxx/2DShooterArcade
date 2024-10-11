using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool; 
    [SerializeField] private float _spawnInterval = 5f; 
    [SerializeField] private Transform _spawnPoint; 
    [SerializeField] private float _yRange = 3f;

    private void Start()
    {

        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);

            GameObject enemy = _objectPool.GetFromPool();

            float randomY = Random.Range(-_yRange, _yRange);
            enemy.transform.position = new(_spawnPoint.position.x, randomY);

            if (enemy.TryGetComponent<EnemyHealthController>(out var enemyHealth))
            {
                enemyHealth.SetObjectPool(_objectPool);
            }
            Debug.Log("Enemy spawned.");
        }
    }
}
