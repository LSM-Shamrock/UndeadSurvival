using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private int maxHealth;
    private int remainHealth;

    [SerializeField]
    private int attackPower;
    [SerializeField]
    private float attackDelay;

    [SerializeField]
    private float despawnDistance;

    private GameObject target;

    private void Awake()
    {
        target = GameManager.Instance.player;
        remainHealth = maxHealth;
    }

    private void Update()
    {
        Vector3 moveDirection = Vector3.Normalize(target.transform.position - transform.position);
        transform.rotation = Quaternion.LookRotation(moveDirection);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(target.transform.position, transform.position) > despawnDistance)
        {
            Despawn();
        }
    }

    private void Despawn()
    {
        gameObject.SetActive(false);
    }
}
