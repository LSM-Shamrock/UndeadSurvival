using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private Vector3 _offsetVector;

    private void LateUpdate()
    {
        Vector3 movePosition = _playerTransform.position + _offsetVector;
        transform.position = Vector3.Lerp(transform.position, movePosition, Time.deltaTime * _speed);
    }
}
