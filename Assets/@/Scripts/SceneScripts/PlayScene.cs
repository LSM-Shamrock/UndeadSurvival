using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayScene : SceneScript
{
    [SerializeField] private PlayerObject _player;
    [SerializeField] private CameraObject _camera;
    [SerializeField] private PlaneObject _plane;
    [SerializeField] private GameObject[] _enemyPrefabs;

    [SerializeField] private float _enemySpawnDistanceMin;
    [SerializeField] private float _enemySpawnDistanceMax;
    [SerializeField] private float _enemySpawnInterval;
    private float _enemySpawnTimer;
    private HashSet<EnemyObject> _enemys = new();

    [SerializeField] private float _despawnDistance;

    private void Start()
    {
        _camera.SetFollowTarget(_player.transform);
    }

    private void Update()
    {
        _player.UpdateMovement();
        _camera.UpdateFollow();
        _plane.UpdatePosition();
        UpdeateEnemySpawn();
        foreach (var enemy in _enemys) enemy.UpdateMovement();
        UpdateDespawn();
    }

    private float GetPlayerDistance(Transform target)
    {
        return Vector3.Distance(_player.transform.position, target.position);
    }

    private void UpdeateEnemySpawn()
    {
        _enemySpawnTimer += Time.deltaTime;
        if (_enemySpawnTimer > _enemySpawnInterval)
        {
            _enemySpawnTimer = 0;
            if (_enemyPrefabs.Length == 0) return;
            var prefab = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)];
            var go = Create(prefab);
            var enemy = go.GetComponent<EnemyObject>();
            var dist = Random.Range(_enemySpawnDistanceMin, _enemySpawnDistanceMax);
            var angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            var dir = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle));
            var pos = _player.transform.position + dir * dist;
            enemy.transform.position = pos;
            enemy.SetTargetPlayer(_player.transform);
            _enemys.Add(enemy);
        }
    }

    private void UpdateDespawn()
    {
        foreach (var enemy in _enemys.ToArray())
        {
            if (GetPlayerDistance(enemy.transform) > _despawnDistance)
            {
                Remove(enemy.gameObject);
                _enemys.Remove(enemy);
            }
        }
    }
}
