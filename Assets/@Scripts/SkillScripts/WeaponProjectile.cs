using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(Rigidbody))]
public class WeaponProjectile : MonoBehaviour
{
    [SerializeField]
    private WeaponProjectileStat _stat;
    private float _currentLifetime;
    private float _currentMoveDistance;
    private Dictionary<Enemy, float> _stayEffecctTimers = new Dictionary<Enemy, float>();

    private void Awake()
    {
        Collider collider = GetComponentInChildren<Collider>();
        collider.isTrigger = true;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }

    private void OnEnable()
    {
        _currentLifetime = 0f;
        _currentMoveDistance = 0f;
        _stayEffecctTimers.Clear();
    }

    private void Update()
    {
        _currentLifetime += Time.deltaTime;
        if (_currentLifetime >= _stat.lifetimeMax) Destroy();

        transform.Rotate(0f, _stat.rotationSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * _stat.moveSpeed * Time.deltaTime);
        _currentMoveDistance += _stat.moveSpeed * Time.deltaTime;
        if (_currentMoveDistance >= _stat.moveDistanceMax) Destroy();

        foreach (var enemy in new List<Enemy>(_stayEffecctTimers.Keys))
        {
            _stayEffecctTimers[enemy] -= Time.deltaTime;
            if (_stayEffecctTimers[enemy] <= 0f) _stayEffecctTimers.Remove(enemy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Enemy))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy == null) return;
            _stayEffecctTimers.Remove(enemy);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(Tags.Enemy))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy == null) return;
            if (_stayEffecctTimers.ContainsKey(enemy)) return;

            enemy.TakeDamage(_stat.hitDamage);
            enemy.Knockback(transform.position, _stat.hitKnockback);

            _stat.hitPenetrationMax--;
            if (_stat.hitPenetrationMax <= 0) Destroy();

            _stayEffecctTimers[enemy] = _stat.hitTickInterval;
        }
    }

    public void SetStat(WeaponProjectileStat stat)
    {
        _stat = stat;
    }

    private void Destroy()
    {
        ObjectPoolManager.DespawnGameObject(gameObject);
    }
}
 