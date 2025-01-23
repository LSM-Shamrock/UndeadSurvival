using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject, ISkillData, IWeaponData
{
    [SerializeField] string _name;
    [SerializeField] Sprite _profileImage;
    [SerializeField] string _description;
    [SerializeField] string _levelupDescription;
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] bool _isProjectileAttached;
    [SerializeField] WeaponStat _defaultStat;
    [SerializeField] WeaponStat _levelupStatDelta;

    public int Level { get; set; }
    public string Name { get { return _name; } }
    public Sprite ProfileImage { get { return _profileImage; } }
    public string Description { get { return _description; } }
    public string LevelupDescription { get { return _levelupDescription; } }
    public GameObject ProjectilePrefab { get { return _projectilePrefab; } }
    public bool IsProjectileAttached { get { return _isProjectileAttached; } }
    public WeaponStat Stat { get { return _defaultStat + _levelupStatDelta * Level; } }
}
