using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField]
    private GaugeBarFill _healthBarFill;
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private int _currentHealth;

    private void LateUpdate()
    {
        _healthBarFill.SetFill(_maxHealth, _currentHealth);
    }

    public void TakeDamage(int damage)
    {
        GameManager.BloodParticleEffect(transform.position);

        if (_currentHealth > damage)
            _currentHealth -= damage;
        else
        {
            _currentHealth = 0;
            Dead();
        }
    }

    private void Dead() 
    {
        //Debug.Log("PlayerDead!");
    }
}
