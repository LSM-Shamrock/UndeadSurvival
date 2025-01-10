using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
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

            for (int i = poolObjects.Count - 1; i >= 0; i--)
            {
                if (poolObjects[i] == null)
                {
                    poolObjects.RemoveAt(i);
                }
                else if (!poolObjects[i].activeSelf)
                {
                    _spawnObject = poolObjects[i];
                    break;
                }
            }

            if (_spawnObject == null)
            {
                _spawnObject = Object.Instantiate(original);
                poolObjects.Add(_spawnObject);
            }

            return _spawnObject;
        }
    }

    private static Dictionary<GameObject, ObjectPool> pools = new Dictionary<GameObject, ObjectPool>();

    public static GameObject SpawnObject(GameObject original)
    {
        if (!pools.ContainsKey(original))
        {
            pools.Add(original, new ObjectPool(original));
        }
        return pools[original].SpawnObject();
    }
}
