using UnityEngine;

public class PlayerController : ControllerBase
{
    [SerializeField] 
    private float _moveSpeed;

    public void UpdateMovement()
    {
        Vector3 inputVector = Vector3.zero;
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.z = Input.GetAxisRaw("Vertical");
        if (inputVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(inputVector);
            transform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed);
        }
    }
}
