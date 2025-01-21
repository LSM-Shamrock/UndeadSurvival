using System.Collections;
using UnityEngine;

public class WeaponLauncher : MonoBehaviour
{
    private GameObject _weaponPrefab;
    private WeaponStat _weaponStat;
    private bool _isAttachToLauncher;
    private float _activationTimer;
    private Transform _playerTransform;

    private void Update()
    {
        transform.position = _playerTransform.position;
    }

    public static void Create(WeaponData weaponData, Transform playerTransform)
    {
        GameObject go = new GameObject($"{weaponData.name} Launcher");
        WeaponLauncher launcher = go.AddComponent<WeaponLauncher>();
        launcher._weaponPrefab = weaponData.prefab;
        launcher._weaponStat = weaponData.defaultStat;
        launcher._isAttachToLauncher = weaponData.isAttachToLauncher;
        launcher._playerTransform = playerTransform;
        launcher.StartCoroutine(launcher.ActivationLoop());
    }

    private IEnumerator ActivationLoop()
    {
        while (true)
        {
            yield return Launch();
            yield return new WaitForSeconds(_weaponStat.activationInterval);
        }
    }

    private IEnumerator Launch()
    {
        for (int repeat = 1; repeat <= _weaponStat.repeatCount; repeat++)
        {

            for (int number = 1; number <= _weaponStat.multiple; number++)
            {
                GameObject go = ObjectPoolManager.SpawnObject(_weaponPrefab);
                go.transform.position = transform.position;
                if (_isAttachToLauncher)
                    go.transform.parent = transform;

                go.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                if (Enemy.nearestEnemy != null)
                    go.transform.LookAt(Enemy.nearestEnemy.transform.position);
                go.transform.Rotate(0f, 360f / _weaponStat.multiple * number, 0f);

                Weapon weapon = go.GetComponent<Weapon>() ?? go.AddComponent<Weapon>();
                weapon.Activation(_weaponStat);
            }
            if (repeat < _weaponStat.repeatCount)
                yield return new WaitForSeconds(_weaponStat.repeatInterval);
        }
    }
}
