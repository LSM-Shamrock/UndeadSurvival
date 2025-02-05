using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Pickup();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Tags.DespawnRange))
            Remove();
    }

    protected void Remove()
    {
        ObjectPoolManager.DespawnGameObject(gameObject);
    }

    protected void Pickup()
    {
        ApplyReward();
        Remove();
    }

    protected abstract void ApplyReward();
}
