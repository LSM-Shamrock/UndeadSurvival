using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private Transform _character;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private LayerMask _planeLayerMask;
    private Vector3 _movePoint;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, _planeLayerMask))
                _movePoint = raycastHit.point;
        }
        Vector3 moveDir = (_movePoint - transform.position).normalized;
        if (moveDir != Vector3.zero) _character.rotation = Quaternion.LookRotation(moveDir);
        transform.Translate(moveDir * Mathf.Min(_moveSpeed * Time.deltaTime, Vector3.Distance(_movePoint, transform.position)));
    }
}
