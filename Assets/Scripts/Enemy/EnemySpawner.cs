using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private EnemyStatsSO _enemyStatsSO;

    private void Start()
    {
        GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        enemy.GetComponent<EnemyHealthController>().EnemyStats = _enemyStatsSO;
        enemy.GetComponent<EnemyMovementController>().EnemyStats = _enemyStatsSO;
        enemy.GetComponent<EnemyDamageController>().EnemyStats = _enemyStatsSO;
    }
}
