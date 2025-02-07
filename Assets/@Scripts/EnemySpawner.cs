using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    [SerializeField] private PlayerHealthController _targetPlayer;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnInterval;
    private float _spawnTimeer;

    private void Update()
    {
        _spawnTimeer += Time.deltaTime;
        if (_spawnTimeer > _spawnInterval) 
        {
            _spawnTimeer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        EnemyData[] enemyDatas = ResourceManager.EnemyDatas;
        if (enemyDatas.Length == 0) return;
        EnemyData data = enemyDatas[Random.Range(0, enemyDatas.Length)];
        float dist = _spawnRadius + Random.Range(0f, 1f);
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        Vector3 spawnPosision = _targetPlayer.transform.position + direction * dist;
        Enemy.Spawn(data, spawnPosision, _targetPlayer);
    }
}
