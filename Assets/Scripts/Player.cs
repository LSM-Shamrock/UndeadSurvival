using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IDamageable
{
    private Vector3 _movePoint;

    public int maxHealth;
    public int curHealth;
    public float moveSpeed;

    public int Exp { get; private set; }

    private void Awake()
    {
        WeaponLauncherSetup();
    }

    private void Update()
    {
        MoveUpdate();
    }

    public void MoveUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            float infinity = Mathf.Infinity;
            LayerMask layerMask = 1 << GameManager.Plane.layer;
            if (Physics.Raycast(ray, out raycastHit, infinity, layerMask))
                _movePoint = raycastHit.point;
        }

        Vector3 lookVecor = _movePoint - transform.position;
        if (lookVecor != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(lookVecor);

        float distance = Vector3.Distance(_movePoint, transform.position);
        transform.Translate(Vector3.forward * Mathf.Min(distance, moveSpeed * Time.deltaTime));
    }

    public void TakeDamage(int damage)
    {
        GameManager.DamageEffect(transform.position);

        if (curHealth > damage) 
            curHealth -= damage;
        else
        {
            curHealth = 0;
            //gameObject.SetActive(false);
        }
    }

    private void WeaponLauncherSetup()
    {
        WeaponData[] weaponDatas = GameManager.WeaponDatas;

        foreach (var weaponData in weaponDatas)
        {
            GameObject go = new GameObject($"{weaponData.name} Launcher");
            WeaponLauncher launcher = go.AddComponent<WeaponLauncher>();
            launcher.LauncherSetup(weaponData);
        }
    }
}


