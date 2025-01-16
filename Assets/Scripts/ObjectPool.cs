using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> _poolObjects = new List<GameObject>();

    public GameObject SpawnObject()
    {
        int index;
        for (index = 0; index < _poolObjects.Count; index++)
        {
            if (_poolObjects[index] == null)
            {
                _poolObjects.RemoveAt(index);
                index--;
                continue;
            }
            if (!_poolObjects[index].activeSelf)
                break;
        }
        if (index == _poolObjects.Count)
        {
            GameObject newObject = Instantiate(prefab);
            newObject.transform.parent = transform;
            _poolObjects.Add(newObject);
        }
        GameObject spawnObject = _poolObjects[index];
        spawnObject.SetActive(true);
        return spawnObject;
    }
}
