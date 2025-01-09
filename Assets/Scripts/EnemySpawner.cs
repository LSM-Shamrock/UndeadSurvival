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
        if (enemyOriginals.Length == 0)
            return;

        float _Dist = spawnDistance * Random.Range(0.9f, 1.1f);
        float _Angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector3 _Dir = new Vector3(Mathf.Cos(_Angle), 0, Mathf.Sin(_Angle));
        Vector3 _PlayerPos = GameManager.Player.transform.position;
        Vector3 _SpawnPos = _PlayerPos + _Dir * _Dist;

        int _EnemyIndex = Random.Range(0, enemyOriginals.Length);
        GameObject _SpawnEnemy = PoolManager.Instance.SpawnObject(enemyOriginals[_EnemyIndex]);
        _SpawnEnemy.transform.parent = transform;
        _SpawnEnemy.transform.position = _SpawnPos;
    }
}
