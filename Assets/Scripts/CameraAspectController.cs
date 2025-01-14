using UnityEngine;

[RequireComponent(typeof(CameraController))]
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
        Camera _camera = GetComponent<Camera>();
        float _currentAspect = (float)Screen.width / Screen.height;
        if (_currentAspect < targetAspect)
        {
            Rect _rect = _camera.rect;
            _rect.width = 1.0f;
            _rect.height = _currentAspect / targetAspect;
            _rect.x = 0;
            _rect.y = (1.0f - _rect.height) / 2.0f;
            _camera.rect = _rect;
        }
        else
        {
            Rect _rect = _camera.rect;
            _rect.width = targetAspect / _currentAspect;
            _rect.height = 1.0f;
            _rect.x = (1.0f - _rect.width) / 2.0f;
            _rect.y = 0;
            _camera.rect = _rect;
        }
    }
}