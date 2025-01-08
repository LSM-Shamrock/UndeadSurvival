using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public EnemyStat Stat { get; protected set; }
    public int Health { get; protected set; }

    private float despawnDistance = 20f;
    private float collisionDelay = 0.5f;
    private float collisionTimer;

    private void Update()
    {
        Vector3 _playerPos = GameManager.Player.transform.position;
        Vector3 _lookDir = Vector3.Normalize(_playerPos - transform.position);
        transform.rotation = Quaternion.LookRotation(_lookDir);
        transform.Translate(Vector3.forward * Stat.moveSpeed * Time.deltaTime);

        if (Vector3.Distance(_playerPos, transform.position) > despawnDistance)
            gameObject.SetActive(false);

        if (collisionTimer > 0)
            collisionTimer -= Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collisionTimer <= 0)
        {
            Player _player = collision.gameObject.GetComponent<Player>();
            if (_player != null)
            {
                collisionTimer = collisionDelay;
                _player.TakeDamage(Stat.collisionDamage);
            }
        }
    }
}
