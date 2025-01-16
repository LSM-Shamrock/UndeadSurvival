using System.Collections;
using UnityEngine;

public class WeaponActivator : ObjectPool
{
    public WeaponStat weaponStat;
    public WeaponType weaponType;

    public GameObject WeaponPrefab
    {
        get { return prefab; }
        set { prefab = value; }
    }

    public IEnumerator ActivationLoop()
    {
        while (true)
        {
            for (int volley = 1; volley <= weaponStat.volleyCount; volley++)
            {
                for (int number = 1; number <= weaponStat.multiple; number++)
                {
                    GameObject go = SpawnObject();
                    Weapon weapon = go.GetComponent<Weapon>() ?? go.AddComponent<Weapon>();
                    weapon.number = number;
                    weapon.stat = weaponStat;
                    weapon.type = weaponType;
                    weapon.Activation();
                }
                if (volley < weaponStat.volleyCount)
                    yield return new WaitForSeconds(weaponStat.volleyInterval);
            }
            yield return new WaitForSeconds(weaponStat.activationInterval);
        }
    }
}
