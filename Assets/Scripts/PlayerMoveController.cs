using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private LayerMask _planeLayerMask;
    private Vector3 _movePoint;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, _planeLayerMask))
                _movePoint = raycastHit.point;
        }

        Vector3 lookVecor = _movePoint - transform.position;
        if (lookVecor != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(lookVecor);

        float distance = Vector3.Distance(_movePoint, transform.position);
        transform.Translate(Vector3.forward * Mathf.Min(distance, moveSpeed * Time.deltaTime));
    }
}
