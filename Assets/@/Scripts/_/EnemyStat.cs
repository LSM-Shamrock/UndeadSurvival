using System;

[Serializable]
public struct EnemyStat
{
    public int maxHealth;
    public float moveSpeed;

    public int collisionDamage;
    public float collisionInterval;

    public int dropExpAmount;
}
