using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager
{
    private static Dictionary<GameObject, ObjectPool> _pools = new Dictionary<GameObject, ObjectPool>();

    public static GameObject SpawnObject(GameObject prefab)
    {
        if (!_pools.ContainsKey(prefab))
            _pools.Add(prefab, new ObjectPool(prefab));
        
        return _pools[prefab].SpawnObject();
    }
}
