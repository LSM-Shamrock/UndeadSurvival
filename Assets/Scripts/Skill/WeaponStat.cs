using System;
using UnityEngine;

[Serializable]
public struct WeaponStat
{
    [Tooltip("발사 간격")] public float launchInterval;
    [Tooltip("다중 발사체 수")] public int multipleProjectileCount;
    [Tooltip("반복 발사 횟수")] public int repeatLaunchCount;
    [Tooltip("반복 발사 간격")] public float repeatLaunchInterval;

    [Tooltip("시작 거리")] public float startingDistance;
    [Tooltip("회전 속도")] public float rotationSpeed;

    [Tooltip("발사체 스탯")] public WeaponProjectileStat projectileStat;

    public static WeaponStat operator +(WeaponStat a, WeaponStat b)
    {
        a.launchInterval += b.launchInterval;
        a.multipleProjectileCount += b.multipleProjectileCount;
        a.repeatLaunchCount += b.repeatLaunchCount;
        a.repeatLaunchInterval += b.repeatLaunchInterval;

        a.startingDistance += b.startingDistance;
        a.rotationSpeed += b.rotationSpeed;

        a.projectileStat += b.projectileStat;
        return a;
    }
    public static WeaponStat operator *(WeaponStat a, int b)
    {
        a.launchInterval *= b;
        a.multipleProjectileCount *= b;
        a.repeatLaunchCount *= b;
        a.repeatLaunchInterval *= b;

        a.startingDistance *= b;
        a.rotationSpeed *= b;

        a.projectileStat *= b;
        return a;
    }
}