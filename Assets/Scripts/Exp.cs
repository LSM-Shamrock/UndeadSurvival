using UnityEngine;

public enum Tag
{
    Player,
    Enemy,
    WeaponProjectile,
}


public class Exp : MonoBehaviour
{
    [SerializeField]
    public LayerMask _planeLayerMask;

    private int amount;

    private void Update()
    {
        if (!Physics.Raycast(transform.position + Vector3.up, Vector3.down, Mathf.Infinity, _planeLayerMask))
            Remove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //player.AddExp(amount);
            Remove();
        }
    }

    public static void DropExp(Vector3 position, int amount)
    {
        if (amount <= 0)
            return;

        GameObject go = ObjectPoolManager.SpawnGameObject(ResourceManager.Exp, true);
        go.transform.position = position;
        go.transform.localScale = Vector3.one + Vector3.one * amount / 10f;
        Exp exp = go.GetComponent<Exp>();
        exp.amount = amount;
    }

    public void Remove()
    {
        ObjectPoolManager.DespawnGameObject(gameObject);
    }
}
