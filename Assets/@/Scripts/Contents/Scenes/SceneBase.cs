using UnityEditor;
using UnityEngine;

public abstract class SceneBase : MonoBehaviour
{
    protected GameObject Create(GameObject prefab)
    { return PoolManager.CreateFromPool(prefab); }

    protected void Remove(GameObject target)
    { PoolManager.RemoveToPool(target); }
}
