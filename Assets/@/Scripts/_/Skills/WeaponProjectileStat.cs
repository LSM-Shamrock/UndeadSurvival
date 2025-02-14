using System;
using UnityEngine;

[Serializable]
public struct WeaponProjectileStat
{
    [Tooltip("타격 피해")] public int hitDamage;
    [Tooltip("타격 넉백")] public float hitKnockback;
    [Tooltip("타격 관통 최대")] public float hitPenetrationMax;
    [Tooltip("타격 틱 간격")] public float hitTickInterval;

    [Tooltip("수명 최대")] public float lifetimeMax;

    [Tooltip("이동 거리 최대")] public float moveDistanceMax;
    [Tooltip("이동 속도")] public float moveSpeed;
    [Tooltip("회전 속도")] public float rotationSpeed;

    public static WeaponProjectileStat operator +(WeaponProjectileStat a, WeaponProjectileStat b)
    {
        a.hitDamage += b.hitDamage;
        a.hitKnockback += b.hitKnockback;
        a.hitPenetrationMax += b.hitPenetrationMax;
        a.hitTickInterval += b.hitTickInterval;

        a.lifetimeMax += b.lifetimeMax;

        a.moveDistanceMax += b.moveDistanceMax;
        a.moveSpeed += b.moveSpeed;
        a.rotationSpeed += b.rotationSpeed;

        return a;
    }
    public static WeaponProjectileStat operator *(WeaponProjectileStat a, int b)
    {
        a.hitDamage *= b;
        a.hitKnockback *= b;
        a.hitPenetrationMax *= b;
        a.hitTickInterval *= b;

        a.lifetimeMax *= b;

        a.moveDistanceMax *= b;
        a.moveSpeed *= b;
        a.rotationSpeed *= b;

        return a;
    }
}
