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
