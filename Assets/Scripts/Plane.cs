using UnityEngine;

public class Plane : MonoBehaviour
{
    private Transform _player;

    private void Update()
    {
        Vector3 position = transform.position;
        Vector3 playerPosition = _player.transform.position;
        position.x = (int)playerPosition.x;
        position.z = (int)playerPosition.z;
        transform.position = position;
    }

    public void Init(Transform player)
    {
        _player = player;
    }
}
