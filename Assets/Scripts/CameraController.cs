using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject target;
    private Vector3 offsetVector = new Vector3(0f, 10f, -5f);

    private void Awake()
    {
        target = GameManager.Instance.player;
    }

    private void Update()
    {
        Vector3 movePosition = target.transform.position + offsetVector;
        transform.position = Vector3.Lerp(transform.position, movePosition, Time.deltaTime / 0.5f);
    }
}
