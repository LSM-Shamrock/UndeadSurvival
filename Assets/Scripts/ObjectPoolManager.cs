using System.Collections.Generic;
using UnityEngine;

public static class ObjectPoolManager
{
    private static Dictionary<GameObject, ObjectPool> pools = new Dictionary<GameObject, ObjectPool>();

    private static GameObject poolsParent;

    public static GameObject SpawnObject(GameObject prefab)
    {
        if (poolsParent == null)
            poolsParent = new GameObject("Pool Objects");
        
        if (!pools.ContainsKey(prefab))
            pools.Add(prefab, new ObjectPool(prefab));
        
        GameObject gameObject = pools[prefab].SpawnObject();
        gameObject.transform.SetParent(poolsParent.transform);
        return gameObject;
    }
}
