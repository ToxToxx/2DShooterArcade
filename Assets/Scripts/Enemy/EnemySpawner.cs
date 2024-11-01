using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool; 
    [SerializeField] private float _spawnInterval = 5f; 
    [SerializeField] private Transform _spawnPoint; 
    [SerializeField] private float _yRange = 3f;

    [SerializeField] private float _spawnDecreaser;
    [SerializeField] private int _maxDecreasing = 3;
    [SerializeField] private int _currentDecreasing = 0;

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

            enemy.GetComponent<EnemyHealthController>().SetObjectPool(_objectPool);
            enemy.GetComponent<EnemyDamageController>().SetObjectPool(_objectPool);

            Debug.Log("Enemy spawned.");
        }
    }

    private void DecreaseSpawn()
    {
        _spawnInterval -= _spawnDecreaser;
    }

    private void OnEnable()
    {
        _currentDecreasing = 0;
        EnemyBreakpointManager.OnEnemyIntervalBreakPointHappened += EnemyBreakpointManager_OnBreakPointHappened;
    }

    private void OnDisable()
    {
        EnemyBreakpointManager.OnEnemyIntervalBreakPointHappened -= EnemyBreakpointManager_OnBreakPointHappened;
    }

    private void EnemyBreakpointManager_OnBreakPointHappened(object sender, System.EventArgs e)
    {
        if (_currentDecreasing < _maxDecreasing)
        {
            DecreaseSpawn();
            _currentDecreasing++;
        }
    }
}
