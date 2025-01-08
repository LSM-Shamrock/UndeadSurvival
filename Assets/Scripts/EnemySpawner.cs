using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnDelay;
    [SerializeField]
    private float spawnDistance;
    [SerializeField]
    private GameObject[] enemyOriginals;

    private float spawnTimer;
    private ObjectPool[] enemyPools;

    private void Awake()
    {
        enemyPools = new ObjectPool[enemyOriginals.Length];
        for (int i = 0; i < enemyOriginals.Length; i++)
        {
            enemyPools[i] = new ObjectPool(enemyOriginals[i]);
        }
    }

    private void Update()
    {
        if (spawnTimer < spawnDelay)
        {
            spawnTimer += Time.deltaTime;
        }
        else
        {
            spawnTimer = 0f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPools.Length == 0)
            return;

        float _dist = spawnDistance * Random.Range(0.9f, 1.1f);
        float _angle = Random.Range(0f, 360f);
        float _x = Mathf.Cos(_angle * Mathf.Deg2Rad);
        float _z = Mathf.Sin(_angle * Mathf.Deg2Rad);
        Vector3 _dir = new Vector3(_x, 0, _z);
        Vector3 _playerPos = GameManager.Player.transform.position;
        Vector3 _spawnPos = _playerPos + _dir * _dist;

        int _enemyIndex = Random.Range(0, enemyPools.Length);
        GameObject _spawnEnemy = enemyPools[_enemyIndex].SpawnObject();
        _spawnEnemy.transform.parent = transform;
        _spawnEnemy.transform.position = _spawnPos;
    }
}
