using UnityEngine;
using System.Collections.Generic;

public class PlayerLevelController : MonoBehaviour
{
    [SerializeField]
    private GaugeBarFill _expBarFill;
    [SerializeField]
    private SkillChoiceUI _skillChoiceUI;

    private int _level;
    private int _exp;

    public int LevelupExp
    {
        get { return _level + 1; }
    }

    private void Awake()
    {
        _level = 1;
        _exp = 0;

        WeaponData[] weaponDatas = ResourceManager.WeaponDatas;
        if (weaponDatas == null)
            return;
        foreach (IWeaponData weaponData in weaponDatas)
            WeaponActivator.Create(weaponData, transform);
    }

    private void LateUpdate()
    {
        _expBarFill.SetFill(LevelupExp, _exp);

        if (_exp >= LevelupExp)
        {
            _exp -= LevelupExp;
            Levelup();
        }
    }

    public void AddExp(int amount)
    {
        _exp += amount;
    }

    private void Levelup()
    {
        _level++;
        //_skillChoiceUI.Show();
    }
}