using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    public GameObject prefab;
    public string description;
    public string levelupDescription;

    [Tooltip("���Ŀ� ���� ����")] 
    public bool isAttachToLauncher;

    public WeaponStat defaultStat = new WeaponStat
    {
        activationInterval = 10.5f,

        multiple = 1,
        repeatCount = 1,
        repeatInterval = 0f,

        rotationRadius = 0f,
        rotationSpeed = 0f,
        shootSpeed = 0f,

        damage = 10,
        stayDamageInterval = Mathf.Infinity,
        penetrationCountToDontDisable = Mathf.Infinity,

        timeToDisable = Mathf.Infinity,
        shootDistanceToDisable = Mathf.Infinity,
    };
    [Space]
    [Space]
    public WeaponStat levelupStatDelta;
}
