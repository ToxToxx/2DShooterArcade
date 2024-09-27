using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D _playerRb;

    [Header("Movement Boundaries")]
    [SerializeField] private float _minX = -40f;
    [SerializeField] private float _maxX = 40f;
    [SerializeField] private float _minY = -30f;
    [SerializeField] private float _maxY = 30f;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 movementInput = InputManager.Movement;
        Vector2 movement = movementInput.normalized * PlayerStatsModel.Instance.PlayerSpeed;
        Vector2 newPosition = _playerRb.position + movement * Time.fixedDeltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, _minX, _maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, _minY, _maxY);
        _playerRb.MovePosition(newPosition);
    }

}
