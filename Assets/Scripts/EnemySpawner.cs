using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float _spawnRange;
    [SerializeField]
    private float _spawnDelay;

    private float _spawnTimer;
    private Player _player;
    private GameObject _bloodParticle;
    private EnemyData[] _enemyDatas;

    private void Awake()
    {
        _player = GameManager.Player;
        _bloodParticle = GameManager.BloodParticle;
        _enemyDatas = GameManager.EnemySheet.enemyDatas;
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
        Vector3 playerPos = _player.transform.position;
        Vector3 pos = playerPos + dir * dist;

        GameObject go = ObjectPoolManager.SpawnObject(data.prefab);
        go.transform.parent = transform;
        go.transform.position = pos;

        Enemy enemy = go.GetComponent<Enemy>() ?? go.AddComponent<Enemy>();
        enemy.TargetPlayer = _player;
        enemy.BloodParticle = _bloodParticle;
        enemy.MaxHealth = data.maxHealth;
        enemy.CurHealth = data.maxHealth;
        enemy.MoveSpeed = data.moveSpeed;
        enemy.CollisionDamage = data.collisionDamage;
        enemy.CollisionDelay = 0.5f;
        enemy.DespawnDistance = 20f;
    }
}
