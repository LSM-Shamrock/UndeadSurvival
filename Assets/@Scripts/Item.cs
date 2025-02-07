using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.ItemPickupRange))
            Pickup();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Tags.DespawnRange))
            Remove();
    }

    protected void Remove()
    {
        ObjectPoolManager.DespawnToPool(gameObject);
    }

    protected void Pickup()
    {
        ApplyGain();
        Remove();
    }

    protected abstract void ApplyGain();
}
