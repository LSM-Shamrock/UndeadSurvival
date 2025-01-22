using System;
using UnityEngine;

[Serializable]
public struct WeaponStat
{
    [Tooltip("�ߵ� ����")] public float activationInterval;
    [Tooltip("���� �߻� ����")] public int multiple;
    [Tooltip("���� Ƚ��")] public int repeatCount;
    [Tooltip("���� ����")] public float repeatInterval;
    [Space]
    [Tooltip("�߻�ü ����")] public WeaponProjectileStat projectileStat;
}