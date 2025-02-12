using UnityEngine;

public class PlayerObject : ObjectBase
{
    [SerializeField] 
    private float _moveSpeed;

    public void UpdateMovement()
    {
        if (Input.GetMouseButton(0))
        {
            var screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            var screenSurfacePoint = new Vector3(screenPoint.x, screenPoint.y, 0f);
            var inputDir = (Input.mousePosition - screenPoint).normalized;
            var moveDir = new Vector3(inputDir.x, 0f, inputDir.y);
            transform.rotation = Quaternion.LookRotation(moveDir);
            transform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed);
        }
    }
}
