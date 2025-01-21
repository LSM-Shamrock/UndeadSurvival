using UnityEngine;

public class GaugeBar : MonoBehaviour
{
    [SerializeField]
    private Transform _fill;

    public void SetFill(float fillValue, float maxValue)
    {
        float fillRatio;
        if (maxValue == 0f)
            fillRatio = 0f;
        else
            fillRatio = Mathf.Min(fillValue / maxValue, 1f);

        _fill.localScale = new Vector3(fillRatio, 1f, 1f);
    }
}
