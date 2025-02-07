using UnityEngine;

public class PositionSync : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 offsetVector;

    private void LateUpdate()
    {
        transform.position = targetTransform.position + offsetVector;
    }
}
