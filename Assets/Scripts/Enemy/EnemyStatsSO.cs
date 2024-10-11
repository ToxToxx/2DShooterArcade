using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
public class EnemyStatsSO : ScriptableObject
{
    public string EnemyName;
    public int EnemyMaxHealth;
    public int EnemySpeed;
    public int Damage;
}
