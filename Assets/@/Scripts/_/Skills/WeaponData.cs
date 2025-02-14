using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject, ISkillInfo
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _profileImage;
    [SerializeField] private string _description;
    [SerializeField] private string _levelupDescription;

    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private bool _isProjectileAttached;
    [SerializeField] private WeaponStat _defaultStat;
    [SerializeField] private WeaponStat _levelupStatDelta;

    public string Name { get { return _name; } }
    public Sprite ProfileImage { get { return _profileImage; } }
    public string Description { get { return _description; } }
    public string LevelupDescription { get { return _levelupDescription; } }

    public GameObject ProjectilePrefab { get { return _projectilePrefab; } }
    public bool IsProjectileAttached { get { return _isProjectileAttached; } }
    public WeaponStat DefaultStat { get { return _defaultStat; } }
    public WeaponStat LevelupStatDelta { get { return _levelupStatDelta; } }
}
