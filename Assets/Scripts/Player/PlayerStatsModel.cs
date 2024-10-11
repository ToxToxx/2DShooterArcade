using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsModel : MonoBehaviour 
{
    public static PlayerStatsModel Instance { get; private set; }

    [SerializeField] private int _playerMaxHealth = 100;
    [SerializeField] private int _playerHealth = 100;
    [SerializeField] private float _playerSpeed = 5f;

    public int PlayerHealth
    {
        get => _playerHealth;
        set
        {
            _playerHealth = Mathf.Clamp(value, 0, PlayerMaxHealth);
        }
    }

    public int PlayerMaxHealth
    {
        get => _playerMaxHealth;
        set => _playerMaxHealth = Mathf.Max(0, value);
    }

    public float PlayerSpeed
    {
        get => _playerSpeed;
        set => _playerSpeed = Mathf.Max(0f, value);
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

}
