using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAspectController : MonoBehaviour
{
    [SerializeField] 
    private float targetAspect = 16f / 9f;

    private void Awake()
    {
        SetCameraAspect(targetAspect);
    }

    private void SetCameraAspect(float targetAspect)
    {
        Camera camera = GetComponent<Camera>();
        float currentAspect = (float)Screen.width / Screen.height;
        if (currentAspect < targetAspect)
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = currentAspect / targetAspect;
            rect.x = 0;
            rect.y = (1.0f - rect.height) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            Rect rect = camera.rect;
            rect.width = targetAspect / currentAspect;
            rect.height = 1.0f;
            rect.x = (1.0f - rect.width) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }
}