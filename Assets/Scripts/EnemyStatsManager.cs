using UnityEngine;

public class EnemyStatsManager : MonoBehaviour
{
    #region Singleton
    private static EnemyStatsManager instance;

    public static EnemyStatsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<EnemyStatsManager>();
            }
            return instance;
        }
    }
    #endregion

    public EnemyStats zombieStats;

    private void Awake()
    {
        instance = this;
    }
}
