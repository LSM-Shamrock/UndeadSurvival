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
    public WeaponProjectileStat stat;
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
        _stayEffecctTimers.Clear();
    }

    private void Update()
    {
        transform.Rotate(0f, stat.rotationSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * stat.shootSpeed * Time.deltaTime);

        stat.shootDistanceMax -= stat.shootSpeed * Time.deltaTime;
        if (stat.shootDistanceMax <= 0f) gameObject.SetActive(false);

        stat.lifetimeMax -= Time.deltaTime;
        if (stat.lifetimeMax <= 0f) gameObject.SetActive(false);

        foreach (var enemy in _stayEffecctTimers.Keys)
        {
            _stayEffecctTimers[enemy] -= Time.deltaTime;
            if (_stayEffecctTimers[enemy] <= 0f) _stayEffecctTimers.Remove(enemy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != Enemy.TAG) return;
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy == null) return;
        _stayEffecctTimers.Remove(enemy);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != Enemy.TAG) return;
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy == null) return;
        if (_stayEffecctTimers.ContainsKey(enemy)) return;

        enemy.TakeDamage(stat.hitDamage);
        enemy.Knockback(transform.position, stat.hitKnockback);

        stat.hitPenetrationMax--;
        if (stat.hitPenetrationMax <= 0) gameObject.SetActive(false);

        _stayEffecctTimers[enemy] = stat.hitStayInterval;
    }
}
 