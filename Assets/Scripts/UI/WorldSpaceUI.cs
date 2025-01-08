using UnityEngine;

public class WorldSpaceUI : MonoBehaviour
{
    protected virtual void Awake()
    {
        Canvas _canvas = GetComponent<Canvas>();
        _canvas.worldCamera = Camera.main;
    }

    protected virtual void Update()
    {
        Quaternion _cameraRotation = Camera.main.transform.rotation;
        Quaternion _rotation = _cameraRotation * Quaternion.Euler(180f, 0f, 0f);
        transform.rotation = _rotation;
    }
}
