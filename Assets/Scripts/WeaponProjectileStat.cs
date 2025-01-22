using System;
using UnityEngine;

[Serializable]
public struct WeaponProjectileStat
{
    [Tooltip("발사 속도")] public float shootSpeed;
    [Tooltip("회전 속도")] public float rotationSpeed;
    [Tooltip("회전 반지름")] public float rotationRadius;
    [Space]
    [Tooltip("피해량")] public int damage;
    [Tooltip("넉백")] public float knockback;
    [Tooltip("체류 효과 간격")] public float stayEffectInterval;
    [Tooltip("비활성화하지 않을 관통 횟수")] public float penetrationCountToDontDisable;
    [Space]
    [Tooltip("비활성화할 시간")] public float timeToDisable;
    [Tooltip("비활성화할 발사 거리")] public float shootDistanceToDisable;
}
