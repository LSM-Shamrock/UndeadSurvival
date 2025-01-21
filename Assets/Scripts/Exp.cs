using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField]
    public LayerMask _planeLayerMask;

    private int amount;

    private void Update()
    {
        if (!Physics.Raycast(transform.position + Vector3.up, Vector3.down, Mathf.Infinity, _planeLayerMask))
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerLevelController player = other.GetComponent<PlayerLevelController>();
        if (player != null)
        {
            player.AddExp(amount);
            gameObject.SetActive(false);
        }   
    }

    public static void DropExp(Vector3 position, int amount)
    {
        if (amount <= 0)
            return;

        GameObject go = ObjectPoolManager.SpawnObject(ResourceManager.Exp);
        go.transform.position = position;
        go.transform.localScale = Vector3.one + Vector3.one * amount / 10f;
        Exp exp = go.GetComponent<Exp>();
        exp.amount = amount;
    }
}
