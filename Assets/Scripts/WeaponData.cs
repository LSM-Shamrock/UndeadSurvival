using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : SKillData
{
    public GameObject weaponPrefab;
    [Space]
    [Tooltip("�߻�ü ���� ����")] 
    public bool isProjectileAttached;
    [Space]
    [Tooltip("�⺻ ����")]
    public WeaponStat defaultStat;
    [Space]
    [Space]
    [Tooltip("������ ���� ��ȭ��")]
    public WeaponStat levelupStatDelta;
}