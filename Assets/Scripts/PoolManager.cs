using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance;
    public static PoolManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindFirstObjectByType<PoolManager>();
            if (instance == null)
            {
                GameObject _go = new GameObject("PoolManager");
                instance = _go.AddComponent<PoolManager>();
            }
            return instance;
        }
    }

    private class ObjectPool
    {
        private GameObject original;
        private List<GameObject> poolObjects = new List<GameObject>();

        public ObjectPool(GameObject original)
        {
            this.original = original;
        }

        public GameObject SpawnObject()
        {
            GameObject _spawnObject = null;
            foreach (GameObject _poolObject in poolObjects)
            {
                if (_poolObject.activeSelf == false)
                {
                    _spawnObject = _poolObject;
                    _spawnObject.SetActive(true);
                    break;
                }
            }
            if (_spawnObject == null)
            {
                _spawnObject = GameObject.Instantiate(original);
                poolObjects.Add(_spawnObject);
            }
            return _spawnObject;
        }
    }

    private Dictionary<GameObject, ObjectPool> pools = new Dictionary<GameObject, ObjectPool>();

    public GameObject SpawnObject(GameObject original)
    {
        if (!pools.ContainsKey(original))
        {
            pools.Add(original, new ObjectPool(original));
        }
        return pools[original].SpawnObject();
    }
}
