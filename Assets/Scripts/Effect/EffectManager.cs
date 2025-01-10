using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private static EffectManager instance;
    private static EffectManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindFirstObjectByType<EffectManager>();

            return instance;
        }
    }

    public GameObject bloodEffect;
    public static GameObject BloodEffect { get { return Instance.bloodEffect; } }

    public static void CreateEffect(GameObject effect, Vector3 position)
    {
        GameObject _effect = PoolManager.SpawnObject(effect);
        _effect.transform.parent = Instance.transform;
        _effect.transform.position = position;
    }
}
