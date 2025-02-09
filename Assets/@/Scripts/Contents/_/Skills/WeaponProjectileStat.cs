using System;
using UnityEngine;

[Serializable]
public struct WeaponProjectileStat
{
    [Tooltip("Ÿ�� ����")] public int hitDamage;
    [Tooltip("Ÿ�� �˹�")] public float hitKnockback;
    [Tooltip("Ÿ�� ���� �ִ�")] public float hitPenetrationMax;
    [Tooltip("Ÿ�� ƽ ����")] public float hitTickInterval;

    [Tooltip("���� �ִ�")] public float lifetimeMax;

    [Tooltip("�̵� �Ÿ� �ִ�")] public float moveDistanceMax;
    [Tooltip("�̵� �ӵ�")] public float moveSpeed;
    [Tooltip("ȸ�� �ӵ�")] public float rotationSpeed;

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
