using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool
{
    private GameObject prefab;
    private List<GameObject> poolObjects = new List<GameObject>();

    public ObjectPool(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public GameObject SpawnObject()
    {
        int index;
        for (index = 0; index < poolObjects.Count; index++)
        {
            if (poolObjects[index] == null)
            {
                poolObjects.RemoveAt(index);
                index--;
                continue;
            }
            if (!poolObjects[index].activeSelf)
                break;
        }
        if (index == poolObjects.Count)
        {
            GameObject newObject = Object.Instantiate(prefab);
            poolObjects.Add(newObject);
        }
        GameObject spawnObject = poolObjects[index];
        spawnObject.SetActive(true);
        return spawnObject;
    }
}
