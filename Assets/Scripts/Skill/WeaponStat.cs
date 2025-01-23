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
    [Tooltip("�߻� �ӵ�")] public float shootSpeed;
    [Tooltip("ȸ�� �ӵ�")] public float rotationSpeed;
    [Tooltip("ȸ�� ������")] public float rotationRadius;
    [Tooltip("�˹�")] public float knockback;
    [Tooltip("���ط�")] public int damage;
    [Tooltip("ü�� ȿ�� ����")] public float stayEffectInterval;
    [Tooltip("��Ȱ��ȭ���� ���� ���� Ƚ��")] public float penetrationCountToDontDisable;
    [Tooltip("��Ȱ��ȭ�� �ð�")] public float timeToDisable;
    [Tooltip("��Ȱ��ȭ�� �߻� �Ÿ�")] public float shootDistanceToDisable;

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