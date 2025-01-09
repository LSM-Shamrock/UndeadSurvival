using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStat Stat { get; private set; }
    public int Health { get; private set; }

    private Vector3 inputVec;

    private void Awake()
    {
        Stat = GameManager.StatDatas.playerStat;
        Health = Stat.maxHealth;
    }

    private void Update()
    {
        inputVec = Vector3.zero;
        inputVec.z = Input.GetAxisRaw("Vertical");
        inputVec.x = Input.GetAxisRaw("Horizontal");
        if (inputVec != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(inputVec);
            transform.Translate(Vector3.forward * Stat.moveSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}


