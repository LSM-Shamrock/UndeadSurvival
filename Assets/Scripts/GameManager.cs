using UnityEngine;

public static class GameManager
{
    public static void BloodParticleEffect(Vector3 position)
    {
        GameObject go = ObjectPoolManager.SpawnObject(ResourceManager.BloodParticle);
        go.transform.position = position;
    }

    public static void DamageCountEffect(Vector3 position, int damage)
    {
        GameObject go = ObjectPoolManager.SpawnObject(ResourceManager.DamageCount);
        DamageCount effectDamageCount = go.GetComponent<DamageCount>();
        effectDamageCount.EffectStart(position, damage);
    }

}
