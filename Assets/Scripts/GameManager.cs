using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CameraController   _cameraController;
    [SerializeField] private Plane              _plane;
    [SerializeField] private HealthBar          _healthBar;
    [SerializeField] private Player             _player;
    [SerializeField] private EnemySpawner       _enemySpawner;
    [SerializeField] private GameObject         _bloodParticle;
    [SerializeField] private EnemySheet         _enemySheet;
    [SerializeField] private WeaponSheet        _weaponSheet;

    private void Awake()
    {
        _cameraController.Init(_player.transform, 2f);

        _plane.Init(_player.transform);

        _healthBar.Init(_player, _player.transform);

        _player.Init(_bloodParticle, _plane.gameObject.layer, 100, 5f);

        _enemySpawner.Init(_player, _bloodParticle, _enemySheet.enemyDatas, 15f, 0.5f);
    }
}