using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = (int)_playerTransform.position.x;
        position.z = (int)_playerTransform.position.z;
        transform.position = position;
    }
}
