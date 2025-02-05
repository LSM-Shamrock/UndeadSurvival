using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _playerTransform;
    private Vector3 _offsetVector;

    private void Awake()
    {
        _offsetVector = transform.position - _playerTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 movePosition = _playerTransform.position + _offsetVector;
        transform.position = Vector3.Lerp(transform.position, movePosition, Time.deltaTime * _speed);
    }
}
