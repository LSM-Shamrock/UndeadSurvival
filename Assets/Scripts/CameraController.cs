using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Transform _targetTransform;
    private Vector3 _offsetVector;

    private void Awake()
    {
        _targetTransform = GameManager.Player.transform;
        _offsetVector = transform.position - GameManager.Player.transform.position;
    }

    private void Update()
    {
        Vector3 movePosition = _targetTransform.position + _offsetVector;
        transform.position = Vector3.Lerp(transform.position, movePosition, Time.deltaTime * _speed);
    }
}
