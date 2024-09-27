using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponDataSO : ScriptableObject
{
    public string WeaponName;
    public int Damage;
    public float FireRate;
}
