using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SkillChoiceButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private Image _profileImage;
    [SerializeField] private Image[] _skillLevelMarks;

    public Button Button { get { return _button; } }

    public void Show(ISkillInfo skillInfo, int level)
    {
        _nameText.text = skillInfo.Name;
        _profileImage.sprite = skillInfo.ProfileImage;
        _descriptionText.text = level == 0 ? skillInfo.Description : skillInfo.LevelupDescription;
        for (int i = 0; i < _skillLevelMarks.Length; i++)
        {
            if (1 + i <= level)
                _skillLevelMarks[i].color = new Color(1f, 1f, 0f);
            else if (1 + i == level + 1)
                _skillLevelMarks[i].color = new Color(0.5f, 0.5f, 0f);
            else
                _skillLevelMarks[i].color = new Color(0f, 0f, 0f);
        }
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}