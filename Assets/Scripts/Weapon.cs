using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Weapon : MonoBehaviour
{
    private WeaponStat _stat;

    private Dictionary<Collider, Coroutine> _collisionCoroutines = new Dictionary<Collider, Coroutine>();

    private void Awake()
    {
        Collider collider = GetComponentInChildren<Collider>();
        collider.isTrigger = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Coroutine coroutine = StartCoroutine(CollisionCoroutine(other));
            _collisionCoroutines[other] = coroutine;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (_collisionCoroutines.TryGetValue(other, out Coroutine coroutine))
                StopCoroutine(coroutine);
        }
    }

    public void Activation(WeaponStat stat)
    {
        _stat = stat;
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

    private IEnumerator CollisionCoroutine(Collider collider)
    {
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();
        if (enemy == null) 
            yield break;

        Action enemyEnebleAction = () => 
        {
            Coroutine coroutine = _collisionCoroutines[collider];
            if (coroutine != null)
                StopCoroutine(coroutine); 
        };
        enemy.enableActions.Add(enemyEnebleAction);

        if (_stat.pierceCount > 0)
            _stat.pierceCount--;
        else
            gameObject.SetActive(false);

        while (true)
        {
            enemy.TakeDamage(_stat.collisionDamage);
            yield return new WaitForSeconds(_stat.tickDamageInterval);
        }
    }
}
