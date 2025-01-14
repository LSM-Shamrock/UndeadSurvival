using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSheet", menuName = "Scriptable Objects/WeaponSheet")]
public class WeaponSheet : ScriptableObject
{
    public WeaponData[] weaponDatas;
}
