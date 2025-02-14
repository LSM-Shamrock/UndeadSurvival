using UnityEditor.Rendering;
using UnityEngine;

public class PlaneObject : ObjectBase
{
    [SerializeField] 
    private int _tileSize;

    public void UpdatePosition()
    {
        var cameraTransform = Camera.main.transform;
        var cameraPos = cameraTransform.position; 
        var cameraDir = cameraTransform.forward;
        var focalPoint = cameraPos + cameraDir * -cameraPos.y / cameraDir.y;
        var position = transform.position;
        position.x = Mathf.Round(focalPoint.x / _tileSize) * _tileSize;
        position.z = Mathf.Round(focalPoint.z / _tileSize) * _tileSize;
        transform.position = position;
    }
}
