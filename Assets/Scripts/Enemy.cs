using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamageable
{
    public int MaxHealth { get; set; }
    public int CurHealth { get; set; }
    public float MoveSpeed { get; set; }
    public int CollisionDamage { get; set; }
    public float CollisionDelay { get; set; }
    public float DespawnDistance { get; set; }
    private float _collisionTimer;
    private Player _targetPlayer;
    private GameObject _bloodParticle;

    private void Awake()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearDamping = 1f;
        rb.angularDamping = 1f;
        rb.constraints |= RigidbodyConstraints.FreezePositionY;
        rb.constraints |= RigidbodyConstraints.FreezeRotationX;
        rb.constraints |= RigidbodyConstraints.FreezeRotationZ;

        _targetPlayer = GameManager.Player;
        _bloodParticle = GameManager.BloodParticle;
    }

    private void Update()
    {
        Vector3 _playerPos = _targetPlayer.transform.position;
        Vector3 _lookDir = Vector3.Normalize(_playerPos - transform.position);
        transform.rotation = Quaternion.LookRotation(_lookDir);
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);

        if (Vector3.Distance(_playerPos, transform.position) > DespawnDistance)
            gameObject.SetActive(false);

        if (_collisionTimer > 0)
            _collisionTimer -= Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (_collisionTimer <= 0)
        {
            if (collision.transform == _targetPlayer.transform)
            {
                _collisionTimer = CollisionDelay;
                _targetPlayer.TakeDamage(CollisionDamage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        ParticleManager.CreateParticle(_bloodParticle, transform.position);
        if (CurHealth > damage)
            CurHealth -= damage;
        else
        {
            CurHealth = 0;
            gameObject.SetActive(false);
        }
    }
}
