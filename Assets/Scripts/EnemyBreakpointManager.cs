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
        int currentScore = _scoreManager.GetScore();
        CheckBreakpoints(currentScore);
    }

    private void CheckBreakpoints(int currentScore)
    {
        CheckBreakpoint(currentScore, _enemyIntervalBreakPoints, ref _enemyIntervalCounter, OnEnemyIntervalBreakPointHappened);
        CheckBreakpoint(currentScore, _enemySpawnerBreakPoints, ref _spawnerCounter, OnEnemySpawnerBreakPointHappened);
        CheckBreakpoint(currentScore, _weaponBreakPoints, ref _weaponCounter, OnWeaponBreakPointHappened);
    }

    private void CheckBreakpoint(int currentScore, int[] breakPoints, ref int counter, EventHandler eventHandler)
    {
        if (counter < breakPoints.Length && currentScore == breakPoints[counter])
        {
            eventHandler?.Invoke(this, EventArgs.Empty);
            counter++;
        }
    }
}
