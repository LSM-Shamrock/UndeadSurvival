using UnityEngine;

public class _Test : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;

    private void Awake()
    {
        Debug.Log($"prefab1 {(prefab1 == prefab2 ? '=' : '!')}= prefab2");
    }
}
