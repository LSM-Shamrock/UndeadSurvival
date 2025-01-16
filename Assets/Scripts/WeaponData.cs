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

    [Tooltip("���ط�")]
    public int damage;

    [Tooltip("�ӵ�")]
    public float speed;

    [Tooltip("��Ÿ�")]
    public float range;

    [Tooltip("���� �߻� ����")]
    public int multiple;

    [Tooltip("���� Ƚ��")]
    public int volleyCount;

    [Tooltip("���� ����")]
    public float volleyInterval;

    [Tooltip("��Ȱ��ȭ�� �ð�")]
    public float lifetime;

    [Tooltip("���� Ƚ��")]
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
