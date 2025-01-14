using UnityEngine;

public class Particle : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        particle.Play();
    }

    public static void Create(GameObject prefab, Vector3 position)
    {
        Transform particle = ObjectPoolManager.SpawnObject(prefab).transform;
        particle.position = position;
    }
}
