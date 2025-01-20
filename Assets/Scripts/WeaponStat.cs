using System;
using UnityEngine;

[Serializable]
public struct WeaponStat
{
    [Tooltip("발동 간격")] public float activationInterval;
    [Space]
    [Tooltip("다중 발사 개수")] public int multiple;
    [Tooltip("연발 횟수")] public int repeatCount;
    [Tooltip("연발 간격")] public float repeatInterval;
    [Space]
    [Tooltip("회전 반지름")] public float rotationRadius;
    [Tooltip("회전 속도")] public float rotationSpeed;
    [Tooltip("발사 속도")] public float shootSpeed;
    [Space]
    [Tooltip("피해량")] public int damage;
    [Tooltip("체류 피해 간격")] public float stayDamageInterval;
    [Tooltip("비활성화하지 않을 관통 횟수")] public float penetrationCountToDontDisable;
    [Space]
    [Tooltip("비활성화할 시간")] public float timeToDisable;
    [Tooltip("비활성화할 발사 거리")] public float shootDistanceToDisable;
}