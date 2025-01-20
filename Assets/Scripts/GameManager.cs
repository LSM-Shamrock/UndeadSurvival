using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindFirstObjectByType<GameManager>();
            return instance;
        }
    }

    [SerializeField] private Player         _player;
    [SerializeField] private GameObject     _plane;
    [SerializeField] private GameObject     _bloodParticle;
    [SerializeField] private GameObject     _damageCount;
    [SerializeField] private GameObject     _exp;
    [SerializeField] private EnemyData[]    _enemyDatas;
    [SerializeField] private WeaponData[]   _weaponDatas;

    public static Player Player
    {
        get { return Instance._player; }
    }
    public static GameObject Plane
    {
        get { return Instance._plane; }
    }
    public static EnemyData[] EnemyDatas
    {
        get { return Instance._enemyDatas; }
    }
    public static WeaponData[] WeaponDatas
    {
        get { return Instance._weaponDatas; }
    }

    public static void DamageEffect(Vector3 position)
    {
        GameObject go = ObjectPoolManager.SpawnObject(Instance._bloodParticle);
        go.transform.position = position;
    }
    public static void DamageEffect(Vector3 position, int damage)
    {
        DamageEffect(position);
        GameObject go = ObjectPoolManager.SpawnObject(Instance._damageCount);
        DamageCount effectDamageCount = go.GetComponent<DamageCount>();
        effectDamageCount.EffectStart(position, damage);
    }
    public static void DropExp(Vector3 position, int amount)
    {
        GameObject go = ObjectPoolManager.SpawnObject(Instance._exp);
        go.transform.position = position;
        Exp exp = go.GetComponent<Exp>();
        exp.amount = amount;
    }
}