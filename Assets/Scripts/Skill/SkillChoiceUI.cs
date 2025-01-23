using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChoiceUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _buttonPrefab;

    [SerializeField]
    private List<SkillChoiceButton> _buttons;

    public IEnumerator Show(List<ISkillData> skillDatas)
    {
        Time.timeScale = 0f;
        for (int i = _buttons.Count; i < skillDatas.Count; i++) 
            _buttons.Add(Instantiate(_buttonPrefab).GetComponent<SkillChoiceButton>());

        ISkillData choiceSkillData = null;
        for (int i = 0; i < _buttons.Count; i++)
        {
            if (i < skillDatas.Count)
            {
                _buttons[i].Show(skillDatas[i]);
                _buttons[i].Button.onClick.RemoveAllListeners();
                _buttons[i].Button.onClick.AddListener(() =>
                {
                    choiceSkillData = skillDatas[i];
                });
            }
            else
                _buttons[i].Hide();
        }
        gameObject.SetActive(true);
        yield return new WaitUntil(() => choiceSkillData != null);




        for (int i = 0; i < _buttons.Count; i++) _buttons[i].Hide();
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
