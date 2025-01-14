using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int MaxHealth { get; set; }
    public int CurHealth { get; set; }
    public float MoveSpeed { get; set; }
    public int PlaneLayer { get; set; }
    public GameObject BloodParticle { get; set; }
    public Vector3 MovePoint { get; set; }

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

    public void Init(GameObject bloodParticle, int planeLayer, int maxHealth, float moveSpeed)
    {
        BloodParticle = bloodParticle;
        PlaneLayer = planeLayer;
        MaxHealth = maxHealth;
        CurHealth = maxHealth;
        MoveSpeed = moveSpeed;
    }
}


