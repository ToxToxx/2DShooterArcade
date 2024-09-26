using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    public static PlayerInput PlayerInput;

    public static Vector2 Movement;
    public static bool ShootWasPressed;
    public static bool ShootWasHeld;
    public static bool ShootWasReleased;

    private InputAction _moveAction;
    private InputAction _shootAction;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        _moveAction = PlayerInput.actions["Move"];
        _shootAction = PlayerInput.actions["Shoot"];
    }

    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();

        ShootWasPressed = _shootAction.WasPressedThisFrame();
        ShootWasHeld = _shootAction.IsPressed();
        ShootWasReleased = _shootAction.WasReleasedThisFrame();
    }
}
