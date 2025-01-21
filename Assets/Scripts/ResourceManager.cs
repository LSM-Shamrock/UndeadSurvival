using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager instance;
    private static ResourceManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindFirstObjectByType<ResourceManager>();
            return instance;
        }
    }

    [SerializeField] private GameObject _bloodParticle;
    [SerializeField] private GameObject _damageCount;
    [SerializeField] private GameObject _exp;
    [SerializeField] private EnemyData[] _enemyDatas;
    [SerializeField] private WeaponData[] _weaponDatas;

    public static GameObject BloodParticle
    {
        get { return Instance._bloodParticle; }
    }
    public static GameObject DamageCount
    {
        get { return Instance._damageCount; }
    }
    public static GameObject Exp
    {
        get { return Instance._exp; }
    }
    public static EnemyData[] EnemyDatas
    {
        get { return Instance._enemyDatas; }
    }
    public static WeaponData[] WeaponDatas
    {
        get { return Instance._weaponDatas; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        if (instance == this)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}
