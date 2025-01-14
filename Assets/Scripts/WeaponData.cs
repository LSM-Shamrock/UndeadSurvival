using System;
using UnityEngine;

public enum WeaponType
{
    Shoot,
    Spin,
}

[Serializable]
public class WeaponData
{
    public string name;
    public string description;
    public GameObject prefab;
    public WeaponType type;



}
