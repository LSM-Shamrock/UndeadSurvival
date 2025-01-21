using System.Collections;
using TMPro;
using UnityEngine;

public class DamageCount : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro _textMeshPro;

    public void EffectStart(Vector3 position, int damage)
    {
        transform.position = position + Vector3.up * 2f;
        StartCoroutine(EffectCoroutine(damage));
    }

    private IEnumerator EffectCoroutine(int damage)
    {
        _textMeshPro.text = damage.ToString("N0");
        _textMeshPro.color = Color.white;

        float upSpeed = 1f;
        float speedDown = 1f;
        while (upSpeed > 0)
        {
            yield return null;
            transform.Translate(Vector3.up * upSpeed * Time.deltaTime);
            upSpeed -= speedDown * Time.deltaTime;
        }
        Color color = _textMeshPro.color;
        float fadeOut = 1f;
        while (color.a > 0)
        {
            _textMeshPro.color = color;
            yield return null;
            color.a -= fadeOut * Time.deltaTime;
        }
        gameObject.SetActive(false);
    }
}
