using System;
using UnityEngine;

[Serializable]
public struct WeaponStat
{
    [Tooltip("Ȱ��ȭ ����")] public float activationInterval;
    [Tooltip("���� �߻�ü ��")] public int multipleProjectileCount;
    [Tooltip("�ݺ� Ȱ��ȭ Ƚ��")] public int repeatActivationCount;
    [Tooltip("�ݺ� Ȱ��ȭ ����")] public float repeatActivationInterval;
    [Tooltip("�߻�ü ����")] public WeaponProjectileStat projectileStat;

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
    [Tooltip("Ÿ�� ����")] public int hitDamage;
    [Tooltip("Ÿ�� �˹�")] public float hitKnockback;
    [Tooltip("Ÿ�� ���� �ִ�")] public float hitPenetrationMax;
    [Tooltip("Ÿ�� ���� ����")] public float hitStayInterval;

    [Tooltip("���� �ִ�")] public float lifetimeMax;

    [Tooltip("�߻� �Ÿ� �ִ�")] public float shootDistanceMax;
    [Tooltip("�߻� �ӵ�")] public float shootSpeed;
    [Tooltip("ȸ�� �ӵ�")] public float rotationSpeed;

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