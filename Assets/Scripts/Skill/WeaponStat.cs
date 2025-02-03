using System;
using UnityEngine;

[Serializable]
public struct WeaponStat
{
    [Tooltip("�߻� ����")] public float launchInterval;
    [Tooltip("���� �߻�ü ��")] public int multipleProjectileCount;
    [Tooltip("�ݺ� �߻� Ƚ��")] public int repeatLaunchCount;
    [Tooltip("�ݺ� �߻� ����")] public float repeatLaunchInterval;

    [Tooltip("���� �Ÿ�")] public float startingDistance;
    [Tooltip("ȸ�� �ӵ�")] public float rotationSpeed;

    [Tooltip("�߻�ü ����")] public WeaponProjectileStat projectileStat;

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