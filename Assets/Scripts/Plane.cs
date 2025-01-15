using UnityEngine;

public class Plane : MonoBehaviour
{
    public Transform PlayerTransform { get; private set; }

    private void Awake()
    {
        PlayerTransform = GameManager.Player.transform;
    }

    private void Update()
    {
        Vector3 position = transform.position;
        Vector3 playerPosition = PlayerTransform.transform.position;
        position.x = (int)playerPosition.x;
        position.z = (int)playerPosition.z;
        transform.position = position;
    }
}
