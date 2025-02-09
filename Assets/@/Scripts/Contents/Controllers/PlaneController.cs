using UnityEditor.Rendering;
using UnityEngine;

public class PlaneController : ControllerBase
{
    [SerializeField] 
    private int _tileSize;

    public void UpdatePosition(Transform camera)
    {
        Vector3 cameraPos = camera.position; 
        Vector3 cameraDir = camera.forward;
        Vector3 focalPoint = cameraPos + cameraDir * -cameraPos.y / cameraDir.y;
        Vector3 position = transform.position;
        position.x = Mathf.Round(focalPoint.x / _tileSize) * _tileSize;
        position.z = Mathf.Round(focalPoint.z / _tileSize) * _tileSize;
        transform.position = position;
    }
}
