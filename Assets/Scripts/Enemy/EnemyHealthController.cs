using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyHealthController : MonoBehaviour
{
    public EnemyStatsSO EnemyStats;
    private int _currentHealth;
    private ObjectPool _objectPool;

    [SerializeField] private int _enemyScoreCount;

    public static event Action<int> OnEnemyDeath;

    private void Start()
    {
        _currentHealth = EnemyStats.EnemyMaxHealth; 
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"{EnemyStats.EnemyName} took {damage} damage. Remaining health: {_currentHealth}");

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{EnemyStats.EnemyName} has died!");
        _objectPool.ReturnToPool(gameObject);
        OnEnemyDeath?.Invoke(_enemyScoreCount);
    }

    public void SetObjectPool(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }
}
