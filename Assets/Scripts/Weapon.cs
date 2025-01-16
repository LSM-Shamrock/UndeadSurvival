using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Weapon : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Transform _player;

    public int number;
    public WeaponStat stat;
    public WeaponType type;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.linearDamping = 1f;
        _rigidbody.angularDamping = 1f;
        _rigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
        _rigidbody.constraints |= RigidbodyConstraints.FreezeRotationX;
        _rigidbody.constraints |= RigidbodyConstraints.FreezeRotationZ;

        _collider = GetComponentInChildren<Collider>();
        _collider.isTrigger = true;

        _player = GameManager.Player.transform;
    }

    private void Update()
    {
        if (stat.lifetime > 0f)
            stat.lifetime -= Time.deltaTime;
        else
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(stat.damage);
            if (stat.pierceCount > 0)
                stat.pierceCount--;
            else
                gameObject.SetActive(false);
        }
    }

    public void Activation()
    {
        StartCoroutine(type.ToString());
    }

    private IEnumerator Shoot()
    {
        yield break;
    }

    private IEnumerator Spin()
    {
        transform.rotation = Quaternion.Euler(0, 360f / stat.multiple * number, 0);
        while (true)
        {
            transform.position = _player.transform.position;
            transform.Translate(Vector3.forward * stat.range);
            yield return null;
            transform.Rotate(0, stat.speed * Time.deltaTime, 0);
        }
    }
}
