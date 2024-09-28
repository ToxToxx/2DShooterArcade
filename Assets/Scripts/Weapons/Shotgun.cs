using System.Collections;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private float _maxBulletDistance = 10f;
    [SerializeField] private int _numberOfBullets = 3;
    [SerializeField] private float _angleVariation = 10f;

    protected override void Awake()
    {
        base.Awake();
        SetShootingStrategy(new ShotgunShootingStrategy(_angleVariation, _numberOfBullets, _maxBulletDistance));
    }
}
