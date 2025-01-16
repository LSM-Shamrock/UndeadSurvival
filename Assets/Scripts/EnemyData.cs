using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public GameObject prefab;
    public int maxHealth;
    public float moveSpeed;
    public int collisionDamage;
}

