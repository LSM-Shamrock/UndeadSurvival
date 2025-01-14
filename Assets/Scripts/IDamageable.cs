using UnityEngine;

public interface IDamageable
{
    public int MaxHealth { get; }
    public int CurHealth { get; }

    public void TakeDamage(int damage);
}
