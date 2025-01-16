using UnityEngine;

public class WeaponActivatorManager : MonoBehaviour
{
    private WeaponData[] _weaponDatas;

    private void Start()
    {
        _weaponDatas = GameManager.WeaponDatas;

        foreach (var weaponData in _weaponDatas)
        {
            Debug.Log(weaponData.name);
            GameObject go = new GameObject($"@{weaponData.name} Activator");
            go.transform.parent = transform;
            WeaponActivator activator = go.AddComponent<WeaponActivator>();
            activator.weaponStat = weaponData.defaultStat;
            activator.weaponType = weaponData.type;
            activator.WeaponPrefab = weaponData.prefab;
            StartCoroutine(activator.ActivationLoop());
        }
    }
}
