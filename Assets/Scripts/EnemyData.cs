using System;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public string name;
    public GameObject prefab;
    public int maxHealth;
    public float moveSpeed;
    public int collisionDamage;
}

