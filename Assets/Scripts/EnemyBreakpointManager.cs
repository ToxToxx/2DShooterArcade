using System;
using UnityEngine;

public class EnemyBreakpointManager : MonoBehaviour
{
    [SerializeField] private int[] _breakPoints;
    [SerializeField] private ScoreManager _scoreManager;

    private int i = 0;
    public static event EventHandler OnBreakPointHappened;

    private void Update()
    {
        if (i < _breakPoints.Length && _scoreManager.GetScore() == _breakPoints[i])
        {
            OnBreakPointHappened?.Invoke(this, EventArgs.Empty);
            i++;
        }
    }
}
