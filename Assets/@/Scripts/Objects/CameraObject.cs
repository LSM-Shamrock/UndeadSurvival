using UnityEditor.Rendering;
using UnityEngine;

public class CameraObject : ObjectBase
{
    [SerializeField] 
    private float _speed;
    private Transform _followTarget;
    private Vector3 _offsetVector;

    public void SetFollowTarget(Transform target)
    { 
        _followTarget = target; 
        _offsetVector = transform.position - target.position; 
    }

    public void UpdateFollow()
    { 
        transform.position = Vector3.Lerp(transform.position, _followTarget.position + _offsetVector, Time.deltaTime * _speed); 
    }
}
