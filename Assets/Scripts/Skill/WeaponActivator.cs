using System.Collections;
using UnityEngine;

public class WeaponActivator : MonoBehaviour
{
    private IWeaponData _weaponData;

    public static void Create(IWeaponData weaponData, Transform playerTransform)
    {
        GameObject go = new GameObject($"{weaponData.Name} Activator");

        PositionSync positionSync = go.AddComponent<PositionSync>();
        positionSync.targetTransform = playerTransform;

        WeaponActivator launcher = go.AddComponent<WeaponActivator>();
        launcher._weaponData = weaponData;
        launcher.StartCoroutine(launcher.ActivationLoop());
    }

    private IEnumerator ActivationLoop()
    {
        while (true)
            yield return Activation();
    }

    private IEnumerator Activation()
    {
        WeaponStat stat = _weaponData.Stat;
        GameObject prefab = _weaponData.ProjectilePrefab;
        Transform parent = _weaponData.IsProjectileAttached ? transform : null;
        Vector3 position = transform.position;

        for (int i = 1; i <= stat.repeatActivationCount; i++)
        {
            Vector3 direction = Enemy.nearest != null ? Enemy.nearest.position - transform.position : Vector3.forward;
            Quaternion rotation = Quaternion.LookRotation(direction);

            for (int j = 1; j <= stat.multipleProjectileCount; j++)
            {
                rotation *= Quaternion.Euler(0f, 360f / stat.multipleProjectileCount, 0f);
                WeaponProjectile.Spawn(prefab, parent, position, rotation, stat.projectileStat);
            }

            if (i < stat.repeatActivationCount)
                yield return new WaitForSeconds(stat.repeatActivationInterval);
        }

        yield return new WaitForSeconds(stat.activationInterval);
    }
}
