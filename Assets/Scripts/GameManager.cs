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
    [SerializeField] private EnemyData[]    _enemyDatas;
    [SerializeField] private WeaponData[]   _weaponDatas;

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
    public static EnemyData[] EnemyDatas
    {
        get { return Instance._enemyDatas; }
    }
    public static WeaponData[] WeaponDatas
    {
        get { return Instance._weaponDatas; }
    }
}