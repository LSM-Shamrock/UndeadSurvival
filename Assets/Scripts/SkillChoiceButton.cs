using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillChoiceButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private Image _profileImage;
    [SerializeField] private Image[] _skillLevelMarks;

    public void SetSkill(SKillData sKillData, int currentSkillLevel)
    {
        _nameText.text = sKillData.skillName;
        if (currentSkillLevel == 0)
        {
            _descriptionText.text = sKillData.skillDescription;
        }
        else
        {
            _descriptionText.text = sKillData.skillLevelupDescription;
        }
        _profileImage.sprite = sKillData.skillProfileImage;
        for (int i = 0; i < _skillLevelMarks.Length; i++)
        {

        }
    }
}
