using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private GameObject original;
    private List<GameObject> poolObjects = new List<GameObject>();

    public ObjectPool(GameObject original)
    {
        this.original = original;
    }

    public GameObject SpawnObject()
    {
        GameObject spawnObject = null;
        foreach (GameObject poolObject in poolObjects)
        {
            if (poolObject.activeSelf == false)
            {
                spawnObject = poolObject;
                spawnObject.SetActive(true);
                break;
            }
        }
        if (spawnObject == null)
        {
            spawnObject = GameObject.Instantiate(original);
            poolObjects.Add(spawnObject);
        } 
        return spawnObject;
    }
}
