using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    public GameObject _prefab;
    private List<GameObject> _objects = new List<GameObject>();

    public ObjectPool(GameObject prefab)
    {
        _prefab = prefab;
    }

    public GameObject SpawnObject()
    {
        int index;
        for (index = 0; index < _objects.Count; index++)
        {
            if (_objects[index] == null)
            {
                _objects.RemoveAt(index);
                index--;
                continue;
            }
            if (!_objects[index].activeSelf)
                break;
        }
        if (index == _objects.Count)
        {
            GameObject newObject = GameObject.Instantiate(_prefab);
            _objects.Add(newObject);
        }
        GameObject spawnObject = _objects[index];
        spawnObject.SetActive(true);
        return spawnObject;
    }
}
