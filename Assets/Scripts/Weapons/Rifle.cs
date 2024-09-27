using UnityEngine;
public class Rifle : Weapon
{
    public override void Shoot()
    {
        if (InputManager.ShootWasHeld)
        {
            Debug.Log($"{WeaponName}: Bang-Bang! Dealt {Damage} damage.");
        }
    }
}
