using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField]
    private Transform _fill;
    private Vector3 _offsetVector =  Vector3.up * 2f;

    private void Awake()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }

    private void Update()
    {
        Quaternion cameraRotation = Camera.main.transform.rotation;
        transform.rotation = cameraRotation * Quaternion.Euler(180f, 0f, 0f);

        Player player = GameManager.Player;
        transform.position = player.transform.position + _offsetVector;

        float fillValue;
        if (player.maxHealth == 0)
            fillValue = 0;
        else
            fillValue = (float)player.curHealth / player.maxHealth;
        _fill.localScale = new Vector3(fillValue, 1f, 1f);
    }
}
