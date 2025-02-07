using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour 
{
    private static ObjectPoolManager _instance;

    private Dictionary<string, Queue<GameObject>> _pools = new();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameObject SpawnGameObject(GameObject prefab, bool isActive)
    {
        if (!_instance._pools.ContainsKey(prefab.name)) _instance._pools.Add(prefab.name, new());
        GameObject go = _instance._pools[prefab.name].Count > 0 ? _instance._pools[prefab.name].Dequeue() : null;
        if (go == null)
        {
            go = GameObject.Instantiate(prefab);
            go.name = prefab.name;
            go.transform.SetParent(_instance.transform);
        }
        go.SetActive(isActive);
        return go;
    }

    public static void DespawnGameObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.SetParent(_instance.transform);
        if (!_instance._pools.ContainsKey(gameObject.name)) _instance._pools.Add(gameObject.name, new());
        _instance._pools[gameObject.name].Enqueue(gameObject);
    }
}
