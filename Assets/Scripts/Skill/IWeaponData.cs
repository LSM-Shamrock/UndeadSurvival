using System;
using UnityEngine;

public interface IWeaponData
{
    public string Name { get; }
    public GameObject ProjectilePrefab { get; } 
    public bool IsProjectileAttached { get; }
    public WeaponStat Stat { get; }
}