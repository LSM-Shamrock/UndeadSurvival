using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    public GameObject prefab;
    public string description;
    public string levelupDescription;

    [Tooltip("런쳐에 연결 여부")] 
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
        knockback = 10.5f,
        stayEffectInterval = Mathf.Infinity,
        penetrationCountToDontDisable = Mathf.Infinity,

        timeToDisable = Mathf.Infinity,
        shootDistanceToDisable = Mathf.Infinity,
    };
    [Space]
    [Space]
    public WeaponStat levelupStatDelta;
}
