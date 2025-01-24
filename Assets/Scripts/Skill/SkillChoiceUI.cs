using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChoiceUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _buttonPrefab;

    [SerializeField]
    private List<SkillChoiceButton> _buttonList;

    public IEnumerator Show(List<ISkillInfo> skillList)
    {
        Time.timeScale = 0f;
        for (int i = _buttonList.Count; i < skillList.Count; i++) 
            _buttonList.Add(Instantiate(_buttonPrefab).GetComponent<SkillChoiceButton>());

        ISkillInfo choiceSkill = null;
        for (int i = 0; i < _buttonList.Count; i++)
        {
            if (i < skillList.Count)
            {
                _buttonList[i].Button.onClick.RemoveAllListeners();
                _buttonList[i].Button.onClick.AddListener(() => { choiceSkill = skillList[i]; });
                //_buttonList[i].Show(skillList[i]);
            }
            else
                _buttonList[i].Hide();
        }
        gameObject.SetActive(true);
        yield return new WaitUntil(() => choiceSkill != null);



        for (int i = 0; i < _buttonList.Count; i++) _buttonList[i].Hide();
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
