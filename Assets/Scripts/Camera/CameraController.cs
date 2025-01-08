using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Vector3 offsetVector;

    private void Awake()
    {
        target = GameManager.Player.transform;
        offsetVector = transform.position - target.position;
    }

    private void Update()
    {
        Vector3 _movePosition = target.position + offsetVector;
        transform.position = Vector3.Lerp(transform.position, _movePosition, Time.deltaTime / 0.5f);
    }
}
