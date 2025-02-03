using UnityEngine;

public static class GameManager
{
    public static void BloodParticleEffect(Vector3 position)
    {
        GameObject go = ObjectPoolManager.SpawnGameObject(ResourceManager.BloodParticle, true);
        go.transform.position = position;
    }

    public static void DamageCountEffect(Vector3 position, int damage)
    {
        GameObject go = ObjectPoolManager.SpawnGameObject(ResourceManager.DamageCount, true);
        DamageCount effectDamageCount = go.GetComponent<DamageCount>();
        effectDamageCount.EffectStart(position, damage);
    }

}
