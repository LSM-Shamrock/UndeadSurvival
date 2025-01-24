using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static void Create(WeaponData weaponData, Transform playerTransform)
    {
        GameObject go = new GameObject($"{weaponData.Name} Weapon");
        PositionSync positionSync = go.AddComponent<PositionSync>();
        positionSync.targetTransform = playerTransform;
        Weapon weaponActivator = go.AddComponent<Weapon>();
    }

    public IEnumerator Activation(WeaponData weaponData, int level)
    {
        if (level == 0)
            yield break;

        WeaponStat stat = weaponData.DefaultStat + weaponData.LevelupStatDelta * level;
        GameObject projectilePrefab = weaponData.ProjectilePrefab;
        Transform projectileParent = weaponData.IsProjectileAttached ? transform : null;
        Vector3 projectilePosition = transform.position;

        for (int i = 1; i <= stat.repeatActivationCount; i++)
        {
            Vector3 direction = Enemy.nearest != null ? Enemy.nearest.position - transform.position : Vector3.forward;
            Quaternion rotation = Quaternion.LookRotation(direction);

            for (int j = 1; j <= stat.multipleProjectileCount; j++)
            {
                rotation *= Quaternion.Euler(0f, 360f / stat.multipleProjectileCount, 0f);

                GameObject go = ObjectPoolManager.SpawnObject(projectilePrefab);
                go.transform.parent = projectileParent;
                go.transform.position = projectilePosition;
                go.transform.rotation = rotation;
                WeaponProjectile projectile = (go.GetComponent<WeaponProjectile>() ?? go.AddComponent<WeaponProjectile>());
                projectile.stat = stat.projectileStat;
            }
            if (i < stat.repeatActivationCount)
                yield return new WaitForSeconds(stat.repeatActivationInterval);
        }
        yield return new WaitForSeconds(stat.activationInterval);
    }
}
