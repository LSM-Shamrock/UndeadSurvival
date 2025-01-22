using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : SKillData
{
    public GameObject weaponPrefab;
    [Space]
    [Tooltip("발사체 부착 여부")] 
    public bool isProjectileAttached;
    [Space]
    [Tooltip("기본 스탯")]
    public WeaponStat defaultStat;
    [Space]
    [Space]
    [Tooltip("레벨업 스탯 변화량")]
    public WeaponStat levelupStatDelta;
}