using System;
using UnityEngine;

[Serializable]
public struct WeaponStat
{
    [Tooltip("발동 간격")] public float activationInterval;
    [Tooltip("다중 발사 개수")] public int multiple;
    [Tooltip("연발 횟수")] public int repeatCount;
    [Tooltip("연발 간격")] public float repeatInterval;
    [Space]
    [Tooltip("발사체 스탯")] public WeaponProjectileStat projectileStat;
}