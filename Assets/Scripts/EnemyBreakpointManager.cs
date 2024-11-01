using System;
using UnityEngine;

public class EnemyBreakpointManager : MonoBehaviour
{
    [SerializeField] private int[] _enemyIntervalBreakPoints;
    [SerializeField] private int[] _weaponBreakPoints;
    [SerializeField] private int[] _enemySpawnerBreakPoints;
    [SerializeField] private ScoreManager _scoreManager;

    private int _enemyIntervalCounter = 0;
    private int _weaponCounter = 0;
    private int _spawnerCounter = 0;

    public static event EventHandler OnEnemyIntervalBreakPointHappened;
    public static event EventHandler OnEnemySpawnerBreakPointHappened;
    public static event EventHandler OnWeaponBreakPointHappened;

    private void Update()
    {
        CheckIfEnemyIntervalBreakpointHappened();
        CheckIfEnemySpawnBreakpointHappened();
        CheckIfWeaponBreakpointHappened();
    }

    private void CheckIfEnemyIntervalBreakpointHappened()
    {
        if (_enemyIntervalCounter < _enemyIntervalBreakPoints.Length && _scoreManager.GetScore() == _enemyIntervalBreakPoints[_enemyIntervalCounter])
        {
            OnEnemyIntervalBreakPointHappened?.Invoke(this, EventArgs.Empty);
            _enemyIntervalCounter++;
        }
    }

    private void CheckIfEnemySpawnBreakpointHappened()
    {
        if (_spawnerCounter < _enemySpawnerBreakPoints.Length && _scoreManager.GetScore() == _enemySpawnerBreakPoints[_spawnerCounter])
        {
            OnEnemySpawnerBreakPointHappened?.Invoke(this, EventArgs.Empty);
            _spawnerCounter++;
        }
    }

    private void CheckIfWeaponBreakpointHappened()
    {
        if (_weaponCounter < _weaponBreakPoints.Length && _scoreManager.GetScore() == _weaponBreakPoints[_weaponCounter])
        {
            OnWeaponBreakPointHappened?.Invoke(this, EventArgs.Empty);
            _weaponCounter++;
        }
    }

}
