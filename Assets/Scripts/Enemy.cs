using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamageable
{
    public int MaxHealth { get; private set; }
    public int CurHealth { get; private set; }
    public float MoveSpeed { get; set; }
    public int CollisionDamage { get; set; }
    private float _despawnDistance = 20f;
    private float _collisionDelay = 0.5f;
    private float _collisionTimer;

    private Player _player;
    private GameObject _bloodParticle;

    private void Awake()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearDamping = 1f;
        rb.angularDamping = 1f;
        rb.constraints |= RigidbodyConstraints.FreezePositionY;
        rb.constraints |= RigidbodyConstraints.FreezeRotationX;
        rb.constraints |= RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        Vector3 _playerPos = _player.transform.position;
        Vector3 _lookDir = Vector3.Normalize(_playerPos - transform.position);
        transform.rotation = Quaternion.LookRotation(_lookDir);
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);

        if (Vector3.Distance(_playerPos, transform.position) > _despawnDistance)
            gameObject.SetActive(false);

        if (_collisionTimer > 0)
            _collisionTimer -= Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (_collisionTimer <= 0)
        {
            if (collision.transform == _player.transform)
            {
                _collisionTimer = _collisionDelay;
                _player.TakeDamage(CollisionDamage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Particle.Create(_bloodParticle, transform.position);
        if (CurHealth > damage)
            CurHealth -= damage;
        else
        {
            CurHealth = 0;
            gameObject.SetActive(false);
        }
    }

    public void Init(Player player, GameObject bloodParticle, int maxHealth, float moveSpeed, int collisionDamage)
    {
        _bloodParticle = bloodParticle;
        _player = player;
        MaxHealth = maxHealth;
        CurHealth = maxHealth;
        MoveSpeed = moveSpeed;
        CollisionDamage = collisionDamage;
    }
}
