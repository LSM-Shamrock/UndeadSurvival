using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particle;

    private void OnEnable()
    {
        _particle.Play();
    }
}
