using System.Collections;
using UnityEngine;

public class WeaponLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private bool _isProjectileAttached;
    [SerializeField] private WeaponStat _stat;

    private void Awake()
    {
        StartCoroutine(LaunchLoop());
    }

    private void Update()
    {
        transform.Rotate(0f, _stat.rotationSpeed * Time.deltaTime, 0f);
    }

    public static void Create(WeaponData weaponData, Transform playerTransform)
    {
        GameObject go = new GameObject($"{weaponData.Name} Weapon");
        //PositionSync positionSync = go.AddComponent<PositionSync>();
        //positionSync.targetTransform = playerTransform;
        WeaponLauncher weaponActivator = go.AddComponent<WeaponLauncher>();
    }

    public IEnumerator Launch()
    {
        WaitForSeconds waitForRepeatLaunchInterval = new WaitForSeconds(_stat.repeatLaunchInterval);
        Transform projectileParent = _isProjectileAttached ? transform : null;
        for (int i = 1; i <= _stat.repeatLaunchCount; i++)
        {
            Vector3 firstDir = Enemy.nearest != null ? Enemy.nearest.position - transform.position : Vector3.forward;
            Quaternion rotation = Quaternion.LookRotation(firstDir);
            for (int j = 1; j <= _stat.multipleProjectileCount; j++)
            {
                //rotation *= Quaternion.Euler(0f, 360f / _stat.multipleProjectileCount, 0f);
                //GameObject go = PoolManager.SpawnFromPool(_projectilePrefab, true);
                //go.transform.parent = projectileParent;
                //go.transform.position = transform.position;
                //go.transform.rotation = rotation;
                //go.transform.Translate(Vector3.forward * _stat.startingDistance);
                //WeaponProjectile projectile = (go.GetComponent<WeaponProjectile>() ?? go.AddComponent<WeaponProjectile>());
                //projectile.SetStat(_stat.projectileStat);
            }
            if (i < _stat.repeatLaunchCount)
                yield return waitForRepeatLaunchInterval;
        }
    }

    public IEnumerator LaunchLoop()
    {
        WaitForSeconds waitForLaunchInterval = new WaitForSeconds(_stat.launchInterval);
        while (true)
        {
            yield return Launch();
            yield return waitForLaunchInterval;
        }
    }

    public void Levelup(WeaponStat _levelupStatDelta)
    {
        _stat += _levelupStatDelta;
        StopAllCoroutines();
        foreach (GameObject child in transform) child.SetActive(false);
        StartCoroutine(LaunchLoop());
    }
}
