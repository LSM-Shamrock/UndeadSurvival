using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    [SerializeField] private PlayerHealthController _targetPlayer;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnDelay;
    private float _spawnTimeer;

    private void Update()
    {
        if (_spawnTimeer > 0)
            _spawnTimeer -= Time.deltaTime;
        else
        {
            _spawnTimeer = _spawnDelay;
            Spawn();
        }
    }

    private void Spawn()
    {
        EnemyData[] enemyDatas = ResourceManager.EnemyDatas;
        if (enemyDatas.Length == 0)
            return;
        EnemyData data = enemyDatas[Random.Range(0, enemyDatas.Length)];
        float radius = _spawnRadius * Random.Range(0.9f, 1f);
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        Vector3 spawnPosision = _targetPlayer.transform.position + direction * radius;
        Enemy.Spawn(data, spawnPosision, _targetPlayer);
    }
}
