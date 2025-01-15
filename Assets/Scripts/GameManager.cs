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

    [SerializeField] private Plane          _plane;
    [SerializeField] private Player         _player;
    [SerializeField] private GameObject     _bloodParticle;
    [SerializeField] private EnemySheet     _enemySheet;
    [SerializeField] private WeaponSheet    _weaponSheet;

    public static Plane Plane
    {
        get { return Instance._plane; }
    }
    public static Player Player
    {
        get { return Instance._player; }
    }
    public static GameObject BloodParticle
    {
        get { return Instance._bloodParticle; }
    }
    public static EnemySheet EnemySheet
    {
        get { return Instance._enemySheet; }
    }
    public static WeaponSheet WeaponSheet
    {
        get { return Instance._weaponSheet; }
    }

    private void Awake()
    {
        foreach (WeaponData weaponData in _weaponSheet.weaponDatas)
        {
            GameObject go = new GameObject($"{weaponData.name} Activator");
            go.transform.parent = Player.transform;
            go.transform.localPosition = Vector3.zero;
            WeaponActivator weaponActivator = go.AddComponent<WeaponActivator>();
            weaponActivator.Prefab = weaponData.prefab;
            weaponActivator.Type = weaponData.type;
            weaponActivator.Stat = weaponData.defaultStat;
        }
    }
}