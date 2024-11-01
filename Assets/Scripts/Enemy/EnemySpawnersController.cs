using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnersController : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] _enemySpawners;
    [SerializeField] private int _maxActiveEnemySpawners = 1;

    private void Start()
    {
        UpdateActiveSpawners();
    }

    private void UpdateActiveSpawners()
    {
        for (int i = 0; i < _enemySpawners.Length; i++)
        {
            _enemySpawners[i].gameObject.SetActive(i < _maxActiveEnemySpawners);
        }
    }

    private void OnValidate()
    {
        UpdateActiveSpawners();
    }

    public void IncreaseMaxActiveSpawners()
    {
        _maxActiveEnemySpawners++;
    }

    public void DecreaseMaxActiveSpawners()
    {
        if (_maxActiveEnemySpawners > 1)
        {
            _maxActiveEnemySpawners--;
        }
    }
}
