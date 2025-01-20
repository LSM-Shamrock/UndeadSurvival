using System.Collections;
using UnityEngine;

public class WeaponLauncher : MonoBehaviour
{
    public GameObject weaponPrefab;
    public WeaponStat weaponStat;
    public bool isAttachToLauncher;
    private float _activationTimer;

    private void Update()
    {
        Transform playerTransform = GameManager.Player.transform;
        transform.position = playerTransform.position;
    }

    public void LauncherSetup(WeaponData weaponData)
    {
        weaponPrefab = weaponData.prefab;
        weaponStat = weaponData.defaultStat;
        isAttachToLauncher = weaponData.isAttachToLauncher;
        StartCoroutine(ActivationLoop());
    }

    private IEnumerator ActivationLoop()
    {
        while (true)
        {
            yield return Launch();
            yield return new WaitForSeconds(weaponStat.activationInterval);
        }
    }

    private IEnumerator Launch()
    {
        for (int repeat = 1; repeat <= weaponStat.repeatCount; repeat++)
        {

            for (int number = 1; number <= weaponStat.multiple; number++)
            {
                GameObject go = ObjectPoolManager.SpawnObject(weaponPrefab);
                go.transform.position = transform.position;
                if (isAttachToLauncher)
                    go.transform.parent = transform;

                go.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                if (Enemy.nearestEnemy != null)
                    go.transform.LookAt(Enemy.nearestEnemy.transform.position);
                go.transform.Rotate(0f, 360f / weaponStat.multiple * number, 0f);

                Weapon weapon = go.GetComponent<Weapon>() ?? go.AddComponent<Weapon>();
                weapon.Activation(weaponStat);
            }
            if (repeat < weaponStat.repeatCount)
                yield return new WaitForSeconds(weaponStat.repeatInterval);
        }
    }
}
