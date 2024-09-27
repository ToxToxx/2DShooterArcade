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

    public static float WeaponChange;

    private InputAction _moveAction;
    private InputAction _shootAction;
    private InputAction _changeWeaponAction;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        _moveAction = PlayerInput.actions["Move"];
        _shootAction = PlayerInput.actions["Shoot"];
        _changeWeaponAction = PlayerInput.actions["ChangeWeapon"];
        
    }

    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();
        WeaponChange = _changeWeaponAction.ReadValue<float>();

        ShootWasPressed = _shootAction.WasPressedThisFrame();
        ShootWasHeld = _shootAction.IsPressed();
        ShootWasReleased = _shootAction.WasReleasedThisFrame();
    }
}
