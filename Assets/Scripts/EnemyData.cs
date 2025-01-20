using System;
using UnityEngine;

[Serializable]
public struct EnemyStat
{
    public int maxHealth;
    public float moveSpeed;
    public int collisionDamage;
    public int dropExpAmount;
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public GameObject prefab;
    public EnemyStat stat;
}

