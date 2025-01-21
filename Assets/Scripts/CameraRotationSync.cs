using UnityEngine;

public class CameraRotationSync : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
