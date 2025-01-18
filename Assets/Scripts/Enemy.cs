using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamageable
{
    public static Enemy nearest;

    public float PlayerDistance
    {
        get 
        {
            return Vector3.Distance(GameManager.Player.transform.position, transform.position);
        }
    }

    public List<Action> enableActions = new List<Action>();

    public int MaxHealth { get; set; }
    public int CurHealth { get; set; }
    public float MoveSpeed { get; set; }
    public int CollisionDamage { get; set; }
    public float CollisionDelay { get; set; }
    public float DespawnDistance { get; set; }

    private float _collisionTimer;

    private void Awake()
    {
        tag = "Enemy";
        gameObject.layer = LayerMask.NameToLayer("Enemy");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearDamping = 1f;
        rb.angularDamping = 1f;
        rb.constraints |= RigidbodyConstraints.FreezePositionY;
        rb.constraints |= RigidbodyConstraints.FreezeRotationX;
        rb.constraints |= RigidbodyConstraints.FreezeRotationZ;
    }

    private void OnEnable()
    {
        foreach (var action in enableActions) 
            action();
    }

    private void Update()
    {
        Player player = GameManager.Player;
        Vector3 playerPos = player.transform.position;
        Vector3 lookDir = Vector3.Normalize(playerPos - transform.position);
        transform.rotation = Quaternion.LookRotation(lookDir);
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);

        if (PlayerDistance > DespawnDistance)
            gameObject.SetActive(false);

        if (nearest == null)
            nearest = this;
        else if (!nearest.gameObject.activeSelf)
            nearest = this;
        else if (PlayerDistance < nearest.PlayerDistance)
            nearest = this;

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
            _collisionTimer = CollisionDelay;
            player.TakeDamage(CollisionDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        GameManager.DamageEffect(transform.position, damage);

        if (CurHealth > damage)
            CurHealth -= damage;
        else
        {
            CurHealth = 0;
            Dead();
        }
    }

    private void Dead()
    {
        gameObject.SetActive(false);

    }
}
