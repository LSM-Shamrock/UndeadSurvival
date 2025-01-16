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

    [Tooltip("피해량")]
    public int damage;

    [Tooltip("속도")]
    public float speed;

    [Tooltip("사거리")]
    public float range;

    [Tooltip("다중 발사 개수")]
    public int multiple;

    [Tooltip("연발 횟수")]
    public int volleyCount;

    [Tooltip("연발 간격")]
    public float volleyInterval;

    [Tooltip("비활성화할 시간")]
    public float lifetime;

    [Tooltip("관통 횟수")]
    public int pierceCount;
}

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    public GameObject prefab;
    public WeaponType type;
    public string description;
    public string levelupDescription;
    public WeaponStat defaultStat = new WeaponStat
    {
        activationInterval = 10f,
        damage = 10,
        speed = 10,
        range = 10f,

        multiple = 1,
        volleyCount = 1,
        volleyInterval = 0f,
        
        lifetime = Mathf.Infinity,
        pierceCount = int.MaxValue,
    };
    public WeaponStat levelupStatDelta;
}
