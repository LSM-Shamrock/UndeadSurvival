using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlayerLevelController : MonoBehaviour
{
    [SerializeField]
    private GaugeBarFill _expBarFill;
    [SerializeField]
    private SkillChoiceUI _skillChoiceUI;

    private int _level;
    private int _exp;
    public int LevelupExp { get { return _level + 1; } }

    private WeaponData[] _weaponDatas;
    private Dictionary<ISkillInfo, int> _skillLevels = new Dictionary<ISkillInfo, int>();

    private void Awake()
    {
        //_level = 1;
        //_exp = 0;
        //_weaponDatas = ResourceManager.WeaponDatas;
        //foreach (var weaponData in _weaponDatas)
        //    _skillLevels[weaponData] = 0;
    }

    public void AddExp(int amount)
    {
        _exp += amount;
        _expBarFill.SetFill(LevelupExp, _exp);
        if (_exp >= LevelupExp)
        {
            _exp -= LevelupExp;
            Levelup();
        }
    }

    private void Levelup()
    {
        _level++;

        //List<ISkillInfo> randomList = new List<ISkillInfo>();
        //while (randomList.Count < 3)
        //{
        //    int radomIndex = Random.Range(0, _skillDatas.Length);
        //    ISkillInfo radomValue = _skillDatas[radomIndex];
        //    if (!randomList.Contains(radomValue))
        //        randomList.Add(radomValue);
        //}
        //StartCoroutine(_skillChoiceUI.Show(randomList));
    }
}