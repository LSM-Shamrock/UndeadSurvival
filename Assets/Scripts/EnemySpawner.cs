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

        float dist = spawnDistance * Random.Range(0.9f, 1.1f);
        float angle = Random.Range(0f, 360f);
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        float z = Mathf.Sin(angle * Mathf.Deg2Rad);
        Vector3 dir = new Vector3(x, 0, z);
        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 spawnPos = playerPos + dir * dist;

        int enemyIndex = Random.Range(0, enemyPools.Length);
        GameObject spawnEnemy = enemyPools[enemyIndex].SpawnObject();
        spawnEnemy.transform.position = spawnPos;
    }
}
