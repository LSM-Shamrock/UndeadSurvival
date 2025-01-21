using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLevelController : MonoBehaviour
{
    [SerializeField]
    private GaugeBar _expBar;
    [SerializeField] 
    private int _currentLevel = 1;
    [SerializeField]
    private int _currentExp;
    public int NextLevelExp
    {
        get { return _currentLevel; }
    }

    private void Awake()
    {
        WeaponData[] weaponDatas = ResourceManager.WeaponDatas;
        foreach (var weaponData in weaponDatas)
            WeaponLauncher.Create(weaponData, transform);
    }

    private void LateUpdate()
    {
        
    }

    public void AddExp(int amount)
    {
        _currentExp += amount;
        if (_currentExp > NextLevelExp)
            Levelup();
    }

    private void Levelup()
    {
        
    }
}