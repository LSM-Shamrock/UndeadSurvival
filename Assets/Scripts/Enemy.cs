using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public static Enemy nearestEnemy;
    public static float nearestEnemyDistance;

    public static readonly string TAG = "Enemy";
    public static readonly string LAYER = "Enemy";
    public static readonly float DESPAWN_DISTANCE = 20f;
    public static readonly float COLLISION_DELAY = 0.5f;

    public List<Action> onDisableEvents = new List<Action>();

    private float _collisionTimer;
    private Rigidbody _rigidbody;
    private EnemyStat _stat;
    private int _health;

    private void Awake()
    {
        gameObject.tag = TAG;
        gameObject.layer = LayerMask.NameToLayer(LAYER);
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.linearDamping = 1f;
        _rigidbody.angularDamping = 1f;
        _rigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
        _rigidbody.constraints |= RigidbodyConstraints.FreezeRotationX;
        _rigidbody.constraints |= RigidbodyConstraints.FreezeRotationZ;
    }
    private void OnDisable()
    {
        foreach (var action in onDisableEvents)
            action();
        onDisableEvents.Clear();
    }
    private void Update()
    {
        Player player = GameManager.Player;
        Vector3 playerPos = player.transform.position;
        Vector3 lookDir = Vector3.Normalize(playerPos - transform.position);
        transform.rotation = Quaternion.LookRotation(lookDir);
        transform.Translate(Vector3.forward * _stat.moveSpeed * Time.deltaTime);


        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (nearestEnemy == null)
            nearestEnemy = this;
        else if (!nearestEnemy.gameObject.activeSelf)
            nearestEnemy = this;
        else if (distance < nearestEnemyDistance)
            nearestEnemy = this;
        if (nearestEnemy == this)
            nearestEnemyDistance = distance;

        if (distance > DESPAWN_DISTANCE)
            gameObject.SetActive(false);

        if (_collisionTimer > 0)
            _collisionTimer -= Time.deltaTime;
    }
    private void OnCollisionStay(Collision collision)
    {
        Player player = GameManager.Player;
        if (_collisionTimer > 0)
            return;
        if (collision.transform == player.transform)
        {
            _collisionTimer = COLLISION_DELAY;
            player.TakeDamage(_stat.collisionDamage);
        }
    }

    public static void Spawn(EnemyData data, Vector3 position)
    {
        GameObject go = ObjectPoolManager.SpawnObject(data.prefab);
        go.transform.position = position;
        Enemy enemy = go.GetComponent<Enemy>() ?? go.AddComponent<Enemy>();
        enemy._stat = data.stat;
        enemy._health = data.stat.maxHealth;
    }

    private void Dead()
    {
        gameObject.SetActive(false);
        GameManager.DropExp(transform.position, _stat.dropExpAmount);
    }
    public void Knockback(Vector3 point, float force)
    {

    }
    public void TakeDamage(int damage)
    {
        GameManager.DamageEffect(transform.position, damage);
        if (_health > damage)
        {
            _health -= damage;
        }
        else
        {
            _health = 0;
            Dead();
        }
    }
}
