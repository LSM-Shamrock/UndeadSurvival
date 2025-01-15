using System.Collections;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponActivator : MonoBehaviour
{
    public WeaponStat Stat { get; set; }
    public WeaponType Type { get; set; }
    public GameObject Prefab { get; set; }

    private float _activationTimer;
    private bool _isActivation;

    private void Update()
    {
        if (_isActivation)
            return;

        if (_activationTimer > 0)
            _activationTimer -= Time.deltaTime;
        else if (!_isActivation)
        {
            _activationTimer = Stat.activationInterval;
            StartCoroutine(Activation());
        }
    }

    private IEnumerator Activation()
    {
        _isActivation = true;
        for (int i = 1; i <= Stat.volleyCount; i++)
        {
            for (int j = 0; j < Stat.concurrentCount; j++)
                CreateWeapon(j);

            if (i < Stat.volleyCount)
                yield return new WaitForSeconds(Stat.volleyInterval);
        }
        _isActivation = false;
    }

    private void CreateWeapon(int index)
    {
        GameObject go;
        if (index < transform.childCount)
        {
            go = transform.GetChild(index).gameObject;
            go.SetActive(true);
        }
        else
            go = ObjectPoolManager.SpawnObject(Prefab);

        Weapon weapon = go.GetComponent<Weapon>() ?? go.AddComponent<Weapon>();
        weapon.Duration = Stat.duration;
        weapon.Damage = Stat.damage;
        weapon.PierceCount = Stat.pierceCount;

        if (Type == WeaponType.Shoot)
        {

        }
        if (Type == WeaponType.Spin)
        {
            weapon.transform.parent = transform;
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.Euler(0f, 360f / (index + 1), 0f);
            weapon.transform.Translate(Vector3.forward * Stat.range);
        }
    }
}
