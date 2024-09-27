using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponDataSO WeaponDataSO;
    public GameObject Bullet;
    public string WeaponName { get; protected set; }
    public int Damage { get; protected set; }
    public float FireRate { get; protected set; }
    public abstract void Shoot();

    private void Awake()
    {
        try
        {
            WeaponName = WeaponDataSO.WeaponName;
            Damage = WeaponDataSO.Damage;
            FireRate = WeaponDataSO.FireRate;
        }
        catch 
        {
            Debug.LogError($"WeaponDataSO not assigned");
        }
    }
}
