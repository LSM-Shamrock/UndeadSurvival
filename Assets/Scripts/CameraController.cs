using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _target;
    private Vector3 _offset;
    private float _speed;

    private void Update()
    {
        Vector3 movePosition = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, movePosition, Time.deltaTime * _speed);
    }

    public void Init(Transform target, float speed)
    {
        _target = target;
        _offset = transform.position - _target.position;
        _speed = speed;
    }
}
