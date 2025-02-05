using System;
using System.Collections;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private PlayerStatsModel _playerStatsModel;
    [SerializeField] private float _shieldDuration = 5f;         
    [SerializeField] private bool _isShieldActive = false;

    public event EventHandler OnHealthChanged;
    public event EventHandler OnPlayerDeath;

    private void Start()
    {
        if (_playerStatsModel == null)
        {
            _playerStatsModel = PlayerStatsModel.Instance;
        }
        Time.timeScale = 1.0f;
    }

    public void TakeDamage(int damage)
    {
        if (_isShieldActive)
        {
            Debug.Log("Shield is active! No damage taken.");
            return; 
        }

        _playerStatsModel.PlayerHealth -= damage;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);

        ActivateShield();

        Debug.Log($"Player took {damage} damage. Current health: {_playerStatsModel.PlayerHealth}");

        if (_playerStatsModel.PlayerHealth <= 0)
        {
            PlayerDied();
        }
    }

    public void RestoreHealth(int healthAmount)
    {
        _playerStatsModel.PlayerHealth += healthAmount;
        Debug.Log($"Player restored {healthAmount} health. Current health: {_playerStatsModel.PlayerHealth}");
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void ActivateShield()
    {
        if (!_isShieldActive)
        {
            StartCoroutine(ShieldRoutine());
        }
    }

    private IEnumerator ShieldRoutine()
    {
        _isShieldActive = true;
        Debug.Log("Shield activated! Player is invulnerable.");
        yield return new WaitForSeconds(_shieldDuration);
        _isShieldActive = false;
        Debug.Log("Shield deactivated. Player is vulnerable again.");
    }

    private void PlayerDied()
    {
        Time.timeScale = 0;
        Debug.Log("Player has died!");
        OnPlayerDeath?.Invoke(this, EventArgs.Empty);
    }
}
