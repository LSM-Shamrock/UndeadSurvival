using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [HideInInspector]
    public float moveSpeed = 4f;
    [HideInInspector]
    public Vector3 inputVector = Vector3.zero;

    private void Update()
    {
        inputVector = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) || 
            Input.GetKey(KeyCode.W))
            inputVector.z++;
        if (Input.GetKey(KeyCode.DownArrow) || 
            Input.GetKey(KeyCode.S))
            inputVector.z--;
        if (Input.GetKey(KeyCode.RightArrow) || 
            Input.GetKey(KeyCode.D))
            inputVector.x++;
        if (Input.GetKey(KeyCode.LeftArrow) || 
            Input.GetKey(KeyCode.A))
            inputVector.x--;

        if (inputVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(inputVector);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}


