using System.Collections;
using UnityEngine;

public class WeaponActivator : MonoBehaviour
{
    private GameObject _weaponPrefab;
    private WeaponStat _weaponStat;
    private bool _isProjectileAttached;
    private float _activationTimer;
    private Transform _playerTransform;

    private void Update()
    {
        transform.position = _playerTransform.position;
    }

    public static void Create(WeaponData weaponData, Transform playerTransform)
    {
        GameObject go = new GameObject($"{weaponData.name} Launcher");
        WeaponActivator launcher = go.AddComponent<WeaponActivator>();
        launcher._weaponPrefab = weaponData.weaponPrefab;
        launcher._weaponStat = weaponData.defaultStat;
        launcher._isProjectileAttached = weaponData.isProjectileAttached;
        launcher._playerTransform = playerTransform;
        launcher.StartCoroutine(launcher.ActivationLoop());
    }

    private IEnumerator ActivationLoop()
    {
        while (true)
        {
            yield return Activation();
            yield return new WaitForSeconds(_weaponStat.activationInterval);
        }
    }

    private IEnumerator Activation()
    {
        for (int repeatCount = 1; repeatCount <= _weaponStat.repeatCount; repeatCount++)
        {
            for (int multipleCount = 1; multipleCount <= _weaponStat.multiple; multipleCount++)
            {
                Transform weaponParent = null;
                if (_isProjectileAttached)
                    weaponParent = transform;

                Vector3 position = transform.position;

                Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
                if (Enemy.nearestEnemy != null)
                {
                    Vector3 direction = Enemy.nearestEnemy.transform.position - transform.position;
                    rotation = Quaternion.LookRotation(direction);
                }
                rotation *= Quaternion.Euler(0f, 360f / _weaponStat.multiple * multipleCount, 0f);

                WeaponProjectile.Spawn(_weaponPrefab, weaponParent, position, rotation, _weaponStat.projectileStat);
            }
            if (repeatCount < _weaponStat.repeatCount)
                yield return new WaitForSeconds(_weaponStat.repeatInterval);
        }
    }
}
