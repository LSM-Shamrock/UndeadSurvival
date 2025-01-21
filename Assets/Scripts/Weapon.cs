using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(Rigidbody))]
public class Weapon : MonoBehaviour
{
    private WeaponStat _stat;
    private List<Enemy> _stayEffectWaitingEnemys = new List<Enemy>();
    private WaitForSeconds _waitForStayEffectInterval;

    private void Awake()
    {
        Collider collider = GetComponentInChildren<Collider>();
        collider.isTrigger = true;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag != Enemy.TAG)
            return;

        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy == null)
            return;

        if (_stayEffectWaitingEnemys.Contains(enemy))
            return;

        StartCoroutine(StayEffectApply(enemy));
    }

    public void Activation(WeaponStat stat)
    {
        _stat = stat;
        _stayEffectWaitingEnemys.Clear();
        _waitForStayEffectInterval = new WaitForSeconds(stat.stayEffectInterval);
        StartCoroutine(Shoot());
        StartCoroutine(Rotation());
        StartCoroutine(TimeToDisable());
    }
    private IEnumerator Shoot()
    {
        float shootDistance = 0f;
        while (shootDistance < _stat.shootDistanceToDisable)
        {
            yield return null;
            transform.Translate(Vector3.forward * _stat.shootSpeed * Time.deltaTime);
            shootDistance += _stat.shootSpeed * Time.deltaTime;
        }
        gameObject.SetActive(false);
    }
    private IEnumerator Rotation()
    {
        while (true)
        {
            transform.Translate(Vector3.forward * _stat.rotationRadius);
            yield return null;
            transform.Translate(Vector3.forward * -_stat.rotationRadius);
            transform.Rotate(0, _stat.rotationSpeed * Time.deltaTime, 0);
        }
    }
    private IEnumerator TimeToDisable()
    {
        yield return new WaitForSeconds(_stat.timeToDisable);
        gameObject.SetActive(false);
    }
    private IEnumerator StayEffectApply(Enemy enemy)
    {
        _stayEffectWaitingEnemys.Add(enemy);

        enemy.TakeDamage(_stat.damage);
        enemy.Knockback(transform.position, _stat.knockback);

        if (_stat.penetrationCountToDontDisable > 0)
            _stat.penetrationCountToDontDisable--;
        else
            gameObject.SetActive(false);
        
        yield return _waitForStayEffectInterval;
        _stayEffectWaitingEnemys.Remove(enemy);
    }
}
