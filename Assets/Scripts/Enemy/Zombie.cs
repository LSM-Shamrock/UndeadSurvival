using UnityEngine;

public class Zombie : EnemyBase
{
    private void Awake()
    {
        Stat = GameManager.StatDatas.zombieStat;
    }
}
