using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private Dictionary<GameObject, ObjectPool> _pools = new Dictionary<GameObject, ObjectPool>();

    public GameObject SpawnObject(GameObject prefab)
    {
        if (!_pools.ContainsKey(prefab))
        {
            GameObject go = new GameObject($"@{prefab.name} Pool");
            go.transform.parent = transform;
            ObjectPool pool = go.AddComponent<ObjectPool>();
            pool.prefab = prefab;
            _pools.Add(prefab, pool);
        }
        return _pools[prefab].SpawnObject();
    }
}
