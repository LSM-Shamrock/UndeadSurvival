using UnityEngine;

public class PlayScene : SceneBase
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private CameraController _camera;
    [SerializeField] private PlaneController _plane;
    [SerializeField] private GameObject[] _enemyPrefabs;

    private void Start()
    {
        _camera.SetFollowTarget(_player.transform);
    }

    private void Update()
    {
        _player.UpdateMovement();
        _camera.UpdateFollow();
        _plane.UpdatePosition(_camera.transform);
    }
}
