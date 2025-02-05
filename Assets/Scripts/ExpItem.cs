using UnityEngine;

public class ExpItem : Item
{
    private int amount;

    public static void DropExp(Vector3 position, int amount)
    {
        if (amount <= 0) return;
        GameObject go = ObjectPoolManager.SpawnGameObject(ResourceManager.Exp, true);
        go.transform.position = position;
        go.transform.localScale = Vector3.one + Vector3.one * amount / 10f;
        ExpItem exp = go.GetComponent<ExpItem>();
        exp.amount = amount;
    }

    protected override void ApplyReward()
    {
        
    }
}
