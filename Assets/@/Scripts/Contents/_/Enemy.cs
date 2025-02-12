using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public static Transform nearest;
    public static float nearestDistance;

    private EnemyStat _stat;
    private int _health;
    private Rigidbody _rigidbody;
    private float _collisionTimer;
    private PlayerHealthController _targetPlayer;

    private void Awake()
    {
        //gameObject.tag = Tags.Enemy;
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
        if (!nearest.gameObject.activeSelf || distance < nearestDistance) nearest = transform;
        if (nearest == transform) nearestDistance = distance;

        _collisionTimer -= Time.deltaTime;
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (_collisionTimer > 0) return;
        if (collision.gameObject == _targetPlayer.gameObject)
        {
            _collisionTimer = _stat.collisionInterval;
            _targetPlayer.TakeDamage(_stat.collisionDamage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag(Tags.DespawnRange)) Despawn();
    }

    //public static Enemy Spawn(EnemyData data, Vector3 position, PlayerHealthController targetPlayer)
    //{
    //    GameObject go = PoolManager.SpawnFromPool(data.prefab, true);
    //    go.transform.position = position;
    //    Enemy enemy = go.GetComponent<Enemy>() ?? go.AddComponent<Enemy>();
    //    enemy._stat = data.stat;
    //    enemy._health = data.stat.maxHealth;
    //    enemy._targetPlayer = targetPlayer;
    //    return enemy;
    //}

    private void Despawn()
    {
        PoolManager.RemoveToPool(gameObject);
    }

    public void Knockback(Vector3 point, float force)
    {
        Vector3 dir = transform.position - point;
        dir.Normalize();
        _rigidbody.AddForce(dir * force, ForceMode.Impulse);
    }

    public void TakeDamage(int damage)
    {
        //EffectManager.BloodParticleEffect(transform.position);
        //EffectManager.DamageCountEffect(transform.position, damage);
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
        ExpItem.DropExp(transform.position, _stat.dropExpAmount);
    }
}
