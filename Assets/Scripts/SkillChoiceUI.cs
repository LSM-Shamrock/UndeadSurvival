using UnityEngine;

public class SkillChoiceUI : MonoBehaviour
{
    [SerializeField]
    private SkillChoiceButton[] skillChoiceButtons;

    public void Show()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }
}
