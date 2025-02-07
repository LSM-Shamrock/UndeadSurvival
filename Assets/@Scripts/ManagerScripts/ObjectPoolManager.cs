using System.Collections.Generic;
using UnityEngine;

public static class ObjectPoolManager 
{
    private static Transform _pooledObjectsParent;
    private static Dictionary<string, Queue<GameObject>> _pooledObjects = new();

    private static void SetParentToPool(GameObject target)
    {
        if (_pooledObjectsParent == null)
        {
            GameObject go = new GameObject("Pooled Objects Parent");
            GameObject.DontDestroyOnLoad(go);
            _pooledObjectsParent = go.transform;
        }
        target.transform.parent = _pooledObjectsParent;
    }

    public static GameObject SpawnFromPool(GameObject prefab, bool isActive)
    {
        if (!_pooledObjects.ContainsKey(prefab.name)) _pooledObjects.Add(prefab.name, new());
        GameObject go = _pooledObjects[prefab.name].Count > 0 ? _pooledObjects[prefab.name].Dequeue() : null;
        if (go == null)
        {
            go = GameObject.Instantiate(prefab);
            go.name = prefab.name;
            SetParentToPool(go);
        }
        go.SetActive(isActive);
        return go;
    }

    public static void DespawnToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        SetParentToPool(gameObject);
        if (!_pooledObjects.ContainsKey(gameObject.name)) _pooledObjects.Add(gameObject.name, new());
        _pooledObjects[gameObject.name].Enqueue(gameObject);
    }
}
