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
    [Tooltip("발사 속도")] public float shootSpeed;
    [Tooltip("회전 속도")] public float rotationSpeed;
    [Tooltip("회전 반지름")] public float rotationRadius;
    [Tooltip("넉백")] public float knockback;
    [Tooltip("피해량")] public int damage;
    [Tooltip("체류 효과 간격")] public float stayEffectInterval;
    [Tooltip("비활성화하지 않을 관통 횟수")] public float penetrationCountToDontDisable;
    [Tooltip("비활성화할 시간")] public float timeToDisable;
    [Tooltip("비활성화할 발사 거리")] public float shootDistanceToDisable;

    public static WeaponProjectileStat operator +(WeaponProjectileStat a, WeaponProjectileStat b)
    {
        a.shootSpeed += b.shootSpeed;
        a.rotationSpeed += b.rotationSpeed;
        a.rotationRadius += b.rotationRadius;
        a.knockback += b.knockback;
        a.damage += b.damage;
        a.stayEffectInterval += b.stayEffectInterval;
        a.penetrationCountToDontDisable += b.penetrationCountToDontDisable;
        a.timeToDisable += b.timeToDisable;
        a.shootDistanceToDisable += b.shootDistanceToDisable;
        return a;
    }
    public static WeaponProjectileStat operator *(WeaponProjectileStat a, int b)
    {
        a.shootSpeed *= b;
        a.rotationSpeed *= b;
        a.rotationRadius *= b;
        a.knockback *= b;
        a.damage *= b;
        a.stayEffectInterval *= b;
        a.penetrationCountToDontDisable *= b;
        a.timeToDisable *= b;
        a.shootDistanceToDisable *= b;
        return a;
    }
}