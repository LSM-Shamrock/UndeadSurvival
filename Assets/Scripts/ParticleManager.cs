using UnityEngine;

public class ParticleManager : ObjectPoolManager
{
    private static ParticleManager instance;
    private static ParticleManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindFirstObjectByType<ParticleManager>();
            return instance;
        }
    }

    public static void CreateParticle(GameObject prefab, Vector3 position)
    {
        Instance.SpawnObject(prefab).transform.position = position;
    }
}
