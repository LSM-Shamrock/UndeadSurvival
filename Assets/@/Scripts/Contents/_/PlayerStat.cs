using UnityEngine;

public struct PlayerStat
{
    [Tooltip("�̵� �ӵ�")] public float moveSpeed;
    [Tooltip("�ִ� ü��")] public float maxHealth;

    [Tooltip("ȸ�� ����")] public float recoveryInterval;
    [Tooltip("ȸ����")] public int recoveryAmount;

    [Tooltip("������ ȹ�� ����")] public float itemPickupRange;
    [Tooltip("����ġ ȹ�� ����")] public int expGainMultiplier;
}
