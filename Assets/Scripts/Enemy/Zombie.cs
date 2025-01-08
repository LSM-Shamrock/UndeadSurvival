using UnityEngine;

public class Zombie : EnemyBase
{
    private void Awake()
    {
        Stat = StatManager.ZombieStat;
    }
}
