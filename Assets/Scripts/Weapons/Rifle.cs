using UnityEngine;
public class Rifle : Weapon
{
    [SerializeField] private float _maxBulletDistance = 10f;
    protected override void Awake()
    {
        base.Awake();
        SetShootingStrategy(new RifleShootingStrategy(_maxBulletDistance));
    }
}
