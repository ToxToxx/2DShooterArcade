using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot()
    {
        if (InputManager.ShootWasHeld)
        {
            Debug.Log($"{WeaponName}: Bang-Bang! Dealt {Damage} damage.");
        }
    }
}
