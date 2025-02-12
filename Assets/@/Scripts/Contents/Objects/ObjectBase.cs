using UnityEngine;

public abstract class ObjectBase : MonoBehaviour
{
    protected void Remove()
    {
        PoolManager.RemoveToPool(gameObject);
    }
}
