using UnityEngine;

public class RocketLauncher : Weapon
{
    [SerializeField] private float _maxBulletDistance = 10f;

    protected override void Awake()
    {
        base.Awake();
        SetShootingStrategy(new RifleShootingStrategy(_maxBulletDistance));
    }
}
