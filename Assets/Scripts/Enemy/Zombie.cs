using UnityEngine;

public class Zombie : EnemyBase
{
    private void Awake()
    {
        Init(StatManager.ZombieStat);
    }
}
