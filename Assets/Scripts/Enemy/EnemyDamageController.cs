using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    public EnemyStatsSO EnemyStats;  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealthController>(out var playerHealth))
        {
            playerHealth.TakeDamage(EnemyStats.Damage);
            Debug.Log($"{EnemyStats.EnemyName} hit the player, dealing {EnemyStats.Damage} damage.");
            Destroy(gameObject);
        }
    }

}
