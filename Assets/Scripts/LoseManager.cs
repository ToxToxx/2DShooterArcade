using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseManager : MonoBehaviour
{
    [SerializeField] private PlayerHealthController _healthController;
    [SerializeField] private GameObject _loseCanvas;

    private void OnEnable()
    {
        _loseCanvas.SetActive(false);
        _healthController.OnPlayerDeath += _healthController_OnPlayerDeath;
    }

    private void _healthController_OnPlayerDeath(object sender, System.EventArgs e)
    {
        _loseCanvas.SetActive(true);
    }

    private void OnDisable()
    {
        _healthController.OnPlayerDeath -= _healthController_OnPlayerDeath;
    }
}
