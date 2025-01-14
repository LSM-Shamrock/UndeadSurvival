using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private GameObject prefab;
    private List<GameObject> poolObjects = new List<GameObject>();

    public void Init(GameObject prefab)
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
            GameObject newObject = Instantiate(prefab);
            newObject.transform.parent = transform;
            poolObjects.Add(newObject);
        }
        GameObject spawnObject = poolObjects[index];
        spawnObject.SetActive(true);
        return spawnObject;
    }
}
