using System.Collections.Generic;
using UnityEngine;

public static class PoolManager 
{
    private static Transform _poolParent;
    private static Dictionary<string, Queue<GameObject>> _pool = new();

    private static Transform GetPoolParent()
    {
        if (_poolParent == null)
        {
            GameObject go = new GameObject("Pool Parent");
            GameObject.DontDestroyOnLoad(go);
            go.SetActive(false);
            _poolParent = go.transform;
        }
        return _poolParent;
    }

    public static GameObject SpawnFromPool(GameObject prefab)
    {
        var key = prefab.name;
        if (_pool.ContainsKey(key)) _pool.Add(key, new());
        var pool = _pool[key];
        var go = pool.Count > 0 ? pool.Dequeue() : null;
        if (go == null)
        {
            go = GameObject.Instantiate(prefab, GetPoolParent());
            go.name = key;
        }
        go.transform.SetParent(null);
        return go;
    }

    public static void DespawnToPool(GameObject target)
    {
        target.transform.SetParent(GetPoolParent());
        var key = target.name;
        if (!_pool.ContainsKey(key)) _pool.Add(key, new());
        _pool[key].Enqueue(target);
    }
}
