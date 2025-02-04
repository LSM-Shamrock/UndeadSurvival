using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public static Transform nearest;
    public static float nearestDistance;

    public static readonly string TAG = "Enemy";
    public readonly float DESPAWN_DISTANCE = 20f;
    public readonly float COLLISION_DELAY = 0.5f;

    private EnemyStat _stat;
    private int _health;
    private Rigidbody _rigidbody;
    private float _collisionTimer;
    private PlayerHealthController _targetPlayer;

    private void Awake()
    {
        gameObject.tag = TAG;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.linearDamping = 1f;
        _rigidbody.angularDamping = 1f;
        _rigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
        _rigidbody.constraints |= RigidbodyConstraints.FreezeRotationX;
        _rigidbody.constraints |= RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        Vector3 lookDir = Vector3.Normalize(_targetPlayer.transform.position - transform.position);
        transform.rotation = Quaternion.LookRotation(lookDir);
        transform.Translate(Vector3.forward * _stat.moveSpeed * Time.deltaTime);

        float distance = Vector3.Distance(_targetPlayer.transform.position, transform.position);

        if (nearest == null) nearest = transform;
        else if (!nearest.gameObject.activeSelf || distance < nearestDistance) nearest = transform;

        if (nearest == transform) nearestDistance = distance;

        if (distance > DESPAWN_DISTANCE) Despawn();

        if (_collisionTimer > 0) _collisionTimer -= Time.deltaTime;
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (_collisionTimer > 0) return;

        if (collision.gameObject == _targetPlayer.gameObject)
        {
            _collisionTimer = COLLISION_DELAY;
            _targetPlayer.TakeDamage(_stat.collisionDamage);
        }
    }

    public static Enemy Spawn(EnemyData data, Vector3 position, PlayerHealthController targetPlayer)
    {
        GameObject go = ObjectPoolManager.SpawnGameObject(data.prefab, true);
        go.transform.position = position;
        Enemy enemy = go.GetComponent<Enemy>() ?? go.AddComponent<Enemy>();
        enemy._stat = data.stat;
        enemy._health = data.stat.maxHealth;
        enemy._targetPlayer = targetPlayer;
        return enemy;
    }

    private void Despawn()
    {
        ObjectPoolManager.DespawnGameObject(gameObject);
    }

    public void Knockback(Vector3 point, float force)
    {
        Vector3 dir = transform.position - point;
        dir.Normalize();
        _rigidbody.AddForce(dir * force, ForceMode.Impulse);
    }

    public void TakeDamage(int damage)
    {
        EffectManager.BloodParticleEffect(transform.position);
        EffectManager.DamageCountEffect(transform.position, damage);
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

    private void Dead()
    {
        Despawn();
        Exp.DropExp(transform.position, _stat.dropExpAmount);
    }
}
