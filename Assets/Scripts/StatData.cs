using UnityEngine;

[CreateAssetMenu(fileName="StatDatas")]
public class StatData : ScriptableObject
{
    [Header("Player Stat")]
    public PlayerStat playerStat;
    [Space]
    [Header("Enemy Stat")]
    public EnemyStat zombieStat;
}
