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
    [Tooltip("발동 간격")]
    public float activationInterval;

    [Tooltip("동시 생성 개수")]
    public int concurrentCount;

    [Tooltip("연발 횟수")]
    public int volleyCount;

    [Tooltip("연발 간격")]
    public float volleyInterval;

    [Tooltip("사거리")]
    public float range;



    [Tooltip("지속 시간")]
    public float duration;

    [Tooltip("피해량")]
    public int damage;

    [Tooltip("관통 횟수")]
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
