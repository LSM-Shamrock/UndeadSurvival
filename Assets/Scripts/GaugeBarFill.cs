using UnityEngine;

public class GaugeBarFill : MonoBehaviour
{
    public void SetFill(float maxValue, float fillValue)
    {
        float fillRatio;
        if (maxValue == 0f)
            fillRatio = 0f;
        else
            fillRatio = Mathf.Min(fillValue / maxValue, 1f);

        transform.localScale = new Vector3(fillRatio, 1f, 1f);
    }
}
