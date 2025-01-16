using UnityEngine;

public class EnemySpawner : ObjectPoolManager
{
    [SerializeField]
    private float _spawnRange;
    [SerializeField]
    private float _spawnDelay;

    private float _spawnTimer;
    private EnemyData[] _enemyDatas;
    private Transform _player;

    private void Awake()
    {
        _enemyDatas = GameManager.EnemyDatas;
        _player = GameManager.Player.transform;
    }

    private void Update()
    {
        if (_spawnTimer < _spawnDelay)
        {
            _spawnTimer += Time.deltaTime;
        }
        else
        {
            _spawnTimer = 0f;
            EnemySpawn();
        }
    }

    private void EnemySpawn()
    {
        if (_enemyDatas.Length == 0)
            return;

        EnemyData data = _enemyDatas[Random.Range(0, _enemyDatas.Length)];

        float dist = _spawnRange * Random.Range(0.9f, 1.1f);
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector3 dir = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        Vector3 playerPos = _player.position;
        Vector3 pos = playerPos + dir * dist;

        GameObject go = SpawnObject(data.prefab);
        go.transform.position = pos;

        Enemy enemy = go.GetComponent<Enemy>() ?? go.AddComponent<Enemy>();
        enemy.MaxHealth = data.maxHealth;
        enemy.CurHealth = data.maxHealth;
        enemy.MoveSpeed = data.moveSpeed;
        enemy.CollisionDamage = data.collisionDamage;
        enemy.CollisionDelay = 0.5f;
        enemy.DespawnDistance = 20f;
    }
}
