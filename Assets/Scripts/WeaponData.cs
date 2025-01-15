using System;
using UnityEngine;

public enum WeaponType
{
    Shoot,
    Spin,
}

[Serializable]
public struct WeaponStat
{
    [Tooltip("�ߵ� ����")]
    public float activationInterval;

    [Tooltip("���� ���� ����")]
    public int concurrentCount;

    [Tooltip("���� Ƚ��")]
    public int volleyCount;

    [Tooltip("���� ����")]
    public float volleyInterval;

    [Tooltip("��Ÿ�")]
    public float range;



    [Tooltip("���� �ð�")]
    public float duration;

    [Tooltip("���ط�")]
    public int damage;

    [Tooltip("���� Ƚ��")]
    public int pierceCount;
}

[Serializable]
public class WeaponData
{
    public string name;
    public string description;
    public string levelupDescription;
    public GameObject prefab;
    public WeaponType type;
    public WeaponStat defaultStat;
    public WeaponStat levelupStatDelta;
}
