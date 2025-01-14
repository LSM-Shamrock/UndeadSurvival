using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager
{
    private static Dictionary<GameObject, ObjectPool> pools = new Dictionary<GameObject, ObjectPool>();

    private static Transform parent;

    public static GameObject SpawnObject(GameObject prefab)
    {
        if (!pools.ContainsKey(prefab))
        {
            GameObject gameObject = new GameObject($"@{prefab.name} Pool");
            if (parent == null)
                parent = new GameObject("@Pools").transform;
            gameObject.transform.parent = parent;

            ObjectPool objectPool = gameObject.AddComponent<ObjectPool>();
            objectPool.Init(prefab);
            pools.Add(prefab, objectPool);
        }
        return pools[prefab].SpawnObject();
    }
}
