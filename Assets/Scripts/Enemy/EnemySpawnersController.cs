using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnersController : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] _enemySpawners;
    [SerializeField] private int _maxActiveEnemySpawners = 1;

    [SerializeField] private int _maxSpawners = 2;

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
        UpdateActiveSpawners();
    }

    public void DecreaseMaxActiveSpawners()
    {
        if (_maxActiveEnemySpawners > 1)
        {
            _maxActiveEnemySpawners--;
        }
    }

    private void OnEnable()
    {
        EnemyBreakpointManager.OnEnemySpawnerBreakPointHappened += EnemyBreakpointManager_OnEnemySpawnerBreakPointHappened;
    }
    private void OnDisable()
    {
        EnemyBreakpointManager.OnEnemySpawnerBreakPointHappened -= EnemyBreakpointManager_OnEnemySpawnerBreakPointHappened;
    }

    private void EnemyBreakpointManager_OnEnemySpawnerBreakPointHappened(object sender, System.EventArgs e)
    {
        if (_maxActiveEnemySpawners < _maxSpawners)
        {
            IncreaseMaxActiveSpawners();
        }
    }
}
