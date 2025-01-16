using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private int _planeLayer;
    private GameObject _bloodParticle;
    private Vector3 _movePoint;

    public int MaxHealth { get; private set; }
    public int CurHealth { get; private set; }
    public float MoveSpeed { get; private set; }

    private void Awake()
    {
        _bloodParticle = GameManager.BloodParticle;
        _planeLayer = GameManager.Plane.gameObject.layer;

        MaxHealth = 100;
        CurHealth = 100;
        MoveSpeed = 5f;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            float infinity = Mathf.Infinity;
            LayerMask layerMask = 1 << _planeLayer;
            if (Physics.Raycast(ray, out raycastHit, infinity, layerMask))
                _movePoint = raycastHit.point;
        }

        Vector3 lookVecor = _movePoint - transform.position;
        if (lookVecor != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(lookVecor);

        float distance = Vector3.Distance(_movePoint, transform.position);
        transform.Translate(Vector3.forward * Mathf.Min(distance, MoveSpeed * Time.deltaTime));
    }

    public void TakeDamage(int damage)
    {
        ParticleManager.CreateParticle(_bloodParticle, transform.position);
        if (CurHealth > damage) 
            CurHealth -= damage;
        else
            CurHealth = 0;
    }
}


