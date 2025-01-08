using UnityEngine;

public class StatManager : MonoBehaviour
{
    private static StatManager instance;
    private static StatManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<StatManager>();
            }
            return instance;
        }
    }

    public static PlayerStat PlayerStat { get { return Instance.playerStat; } }
    public static EnemyStat ZombieStat { get { return Instance.zombieStat; } }

    [Header("Player Stat")]
    public PlayerStat playerStat;
    [Space]
    [Header("Enemy Stat")]
    public EnemyStat zombieStat;
}
