using UnityEngine;

public class EnemyObject : ObjectBase
{
    [SerializeField] 
    private float _moveSpeed;

    private Transform _targetPlayer;

    public void SetTargetPlayer(Transform targetPlayer)
    { _targetPlayer = targetPlayer; }

    public void UpdateMovement()
    {
        transform.LookAt(_targetPlayer.position);
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }
}
