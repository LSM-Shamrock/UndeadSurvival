using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int MaxHealth { get; private set; }
    public int CurHealth { get; private set; }
    public float MoveSpeed { get; private set; }
    public int AttackPower { get; private set; }

    private Vector3 inputVec;

    private void Awake()
    {
        Init(StatManager.PlayerStat);
    }

    private void Update()
    {
        inputVec = Vector3.zero;
        inputVec.z = Input.GetAxisRaw("Vertical");
        inputVec.x = Input.GetAxisRaw("Horizontal");
        if (inputVec != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(inputVec);
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
    }

    private void Init(PlayerStat stat)
    {
        MaxHealth = stat.maxHealth;
        CurHealth = stat.maxHealth;
        MoveSpeed = stat.moveSpeed;
        AttackPower = stat.attackPower;
    }

    public void TakeDamage(int damage)
    {
        CurHealth -= damage;
        EffectManager.CreateEffect(EffectManager.BloodEffect, transform.position);
    }
}


