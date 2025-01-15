using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Weapon : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    public float Duration { get; set; }
    public int Damage { get; set; }
    public int PierceCount { get; set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.linearDamping = 1f;
        _rigidbody.angularDamping = 1f;
        _rigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
        _rigidbody.constraints |= RigidbodyConstraints.FreezeRotationX;
        _rigidbody.constraints |= RigidbodyConstraints.FreezeRotationZ;

        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    private void Update()
    {
        if (Duration > 0f)
            Duration -= Time.deltaTime;
        else
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
            if (PierceCount > 0)
                PierceCount--;
            else
                gameObject.SetActive(false);
        }
    }
}
