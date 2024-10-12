using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _playerScore;

    private void OnEnable()
    {
        EnemyHealthController.OnEnemyDeath += EnemyHealthController_OnEnemyDeath; ;
    }

    private void EnemyHealthController_OnEnemyDeath(int obj)
    {
        AddScore(obj);
    }

    private void Start()
    {
        _playerScore = 0;
    }

    private void OnDisable()
    {
        EnemyHealthController.OnEnemyDeath -= EnemyHealthController_OnEnemyDeath;
    }

    public void AddScore(int score)
    {
        _playerScore += score;
    }

    public int GetScore()
    {
        return _playerScore;
    }
}
