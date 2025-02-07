using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager _instance;

    [SerializeField] private GameObject _bloodParticle;
    [SerializeField] private GameObject _damageCount;
    [SerializeField] private GameObject _exp;
    [SerializeField] private EnemyData[] _enemyDatas;
    [SerializeField] private WeaponData[] _weaponDatas;

    public static GameObject BloodParticle
    {
        get { return _instance._bloodParticle; }
    }
    public static GameObject DamageCount
    {
        get { return _instance._damageCount; }
    }
    public static GameObject Exp
    {
        get { return _instance._exp; }
    }
    public static EnemyData[] EnemyDatas
    {
        get { return _instance._enemyDatas; }
    }
    public static WeaponData[] WeaponDatas
    {
        get { return _instance._weaponDatas; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(_instance);
        }
    }
}
