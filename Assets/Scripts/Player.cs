using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int PlaneLayer { get; private set; }
    public GameObject BloodParticle { get; private set; }
    public Vector3 MovePoint { get; private set; }

    public int MaxHealth { get; private set; }
    public int CurHealth { get; private set; }
    public float MoveSpeed { get; private set; }

    private void Awake()
    {
        BloodParticle = GameManager.BloodParticle;
        PlaneLayer = GameManager.Plane.gameObject.layer;

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
            LayerMask layerMask = 1 << PlaneLayer;
            if (Physics.Raycast(ray, out raycastHit, infinity, layerMask))
                MovePoint = raycastHit.point;
        }

        Vector3 lookVecor = MovePoint - transform.position;
        if (lookVecor != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(lookVecor);

        float distance = Vector3.Distance(MovePoint, transform.position);
        transform.Translate(Vector3.forward * Mathf.Min(distance, MoveSpeed * Time.deltaTime));
    }

    public void TakeDamage(int damage)
    {
        Particle.Create(BloodParticle, transform.position);
        if (CurHealth > damage) 
            CurHealth -= damage;
        else
            CurHealth = 0;
    }
}


