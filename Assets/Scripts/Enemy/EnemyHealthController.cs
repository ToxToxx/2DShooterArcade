using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public EnemyStatsSO EnemyStats;
    private int _currentHealth;
    private ObjectPool _objectPool;

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
    }

    public void SetObjectPool(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }
}
