using UnityEngine;

public class WorldSpaceUI : MonoBehaviour
{
    protected virtual void Awake()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }

    protected virtual void Update()
    {
        Quaternion cameraRotation = Camera.main.transform.rotation;
        Quaternion rotation = cameraRotation * Quaternion.Euler(180f, 0f, 0f);
        transform.rotation = rotation;
    }
}
