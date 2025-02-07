using UnityEngine;

public static class EffectManager
{
    public static void BloodParticleEffect(Vector3 position)
    {
        GameObject go = ObjectPoolManager.SpawnFromPool(ResourceManager.BloodParticle, true);
        go.transform.position = position;
    }

    public static void DamageCountEffect(Vector3 position, int damage)
    {
        GameObject go = ObjectPoolManager.SpawnFromPool(ResourceManager.DamageCount, true);
        DamageCount effectDamageCount = go.GetComponent<DamageCount>();
        effectDamageCount.EffectStart(position, damage);
    }

}
