using System.Collections.Generic;
using UnityEngine;

public static class ObjectPoolManager
{
    private static Dictionary<GameObject, ObjectPool> _pools = new Dictionary<GameObject, ObjectPool>();

    private static GameObject _poolsParent;

    public static GameObject SpawnObject(GameObject prefab)
    {
        if (_poolsParent == null)
            _poolsParent = new GameObject("Pool Objects");
        
        if (!_pools.ContainsKey(prefab))
            _pools.Add(prefab, new ObjectPool(prefab));
        
        GameObject gameObject = _pools[prefab].SpawnObject();
        gameObject.transform.SetParent(_poolsParent.transform);
        return gameObject;
    }
}
