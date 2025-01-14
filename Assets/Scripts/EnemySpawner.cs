using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemySpawner : MonoBehaviour
{
    private Player _player;
    private GameObject _bloodParticle;
    private EnemyData[] _enemyDatas;
    private float _spawnDistance;
    private float _spawnDelay;
    private float _spawnTimer;

    private void Update()
    {
        if (_spawnTimer < _spawnDelay)
        {
            _spawnTimer += Time.deltaTime;
        }
        else
        {
            _spawnTimer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        if (_enemyDatas.Length == 0)
            return;

        EnemyData data = _enemyDatas[Random.Range(0, _enemyDatas.Length)];

        float dist = _spawnDistance * Random.Range(0.9f, 1.1f);
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector3 dir = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        Vector3 playerPos = _player.transform.position;
        Vector3 pos = playerPos + dir * dist;

        GameObject go = ObjectPoolManager.SpawnObject(data.prefab);
        go.transform.position = pos;

        Enemy enemy = go.GetComponent<Enemy>() ?? go.AddComponent<Enemy>();
        enemy.Init(_player, _bloodParticle, data.maxHealth, data.moveSpeed, data.collisionDamage);
    }

    public void Init(Player player, GameObject bloodParticle, EnemyData[] enemyDatas, float spawnDistance, float spawnDelay)
    {
        _player = player;
        _bloodParticle = bloodParticle;
        _enemyDatas = enemyDatas;
        _spawnDistance = spawnDistance;
        _spawnDelay = spawnDelay;
    }
}
