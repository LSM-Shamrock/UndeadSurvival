using System;
using UnityEngine;

[Serializable]
public struct WeaponStat
{
    [Tooltip("활성화 간격")] public float activationInterval;
    [Tooltip("다중 발사체 수")] public int multipleProjectileCount;
    [Tooltip("반복 활성화 횟수")] public int repeatActivationCount;
    [Tooltip("반복 활성화 간격")] public float repeatActivationInterval;
    [Tooltip("발사체 스탯")] public WeaponProjectileStat projectileStat;

    public static WeaponStat operator +(WeaponStat a, WeaponStat b)
    {
        a.activationInterval += b.activationInterval;
        a.multipleProjectileCount += b.multipleProjectileCount;
        a.repeatActivationCount += b.repeatActivationCount;
        a.repeatActivationInterval += b.repeatActivationInterval;
        a.projectileStat += b.projectileStat;
        return a;
    }
    public static WeaponStat operator *(WeaponStat a, int b)
    {
        a.activationInterval *= b;
        a.multipleProjectileCount *= b;
        a.repeatActivationCount *= b;
        a.repeatActivationInterval *= b;
        a.projectileStat *= b;
        return a;
    }
}

[Serializable]
public struct WeaponProjectileStat
{
    [Tooltip("타격 피해")] public int hitDamage;
    [Tooltip("타격 넉백")] public float hitKnockback;
    [Tooltip("타격 관통 최대")] public float hitPenetrationMax;
    [Tooltip("타격 유지 간격")] public float hitStayInterval;

    [Tooltip("수명 최대")] public float lifetimeMax;

    [Tooltip("발사 거리 최대")] public float shootDistanceMax;
    [Tooltip("발사 속도")] public float shootSpeed;
    [Tooltip("회전 속도")] public float rotationSpeed;

    public static WeaponProjectileStat operator +(WeaponProjectileStat a, WeaponProjectileStat b)
    {
        a.hitDamage += b.hitDamage;
        a.hitKnockback += b.hitKnockback;
        a.hitPenetrationMax += b.hitPenetrationMax;
        a.hitStayInterval += b.hitStayInterval;

        a.lifetimeMax += b.lifetimeMax;

        a.shootDistanceMax += b.shootDistanceMax;
        a.shootSpeed += b.shootSpeed;
        a.rotationSpeed += b.rotationSpeed;
        return a;
    }
    public static WeaponProjectileStat operator *(WeaponProjectileStat a, int b)
    {
        a.hitDamage *= b;
        a.hitKnockback *= b;
        a.hitPenetrationMax *= b;
        a.hitStayInterval *= b;

        a.lifetimeMax *= b;

        a.shootDistanceMax *= b;
        a.shootSpeed *= b;
        a.rotationSpeed *= b;
        return a;
    }
}