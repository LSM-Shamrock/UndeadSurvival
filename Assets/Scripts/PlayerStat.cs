using UnityEngine;

public struct PlayerStat
{
    [Tooltip("이동 속도")] public float moveSpeed;
    [Tooltip("최대 체력")] public float maxHealth;

    [Tooltip("회복 간격")] public float recoveryInterval;
    [Tooltip("회복량")] public int recoveryAmount;

    [Tooltip("아이템 획득 범위")] public float itemPickupRange;
    [Tooltip("경험치 획득 배율")] public int expGainMultiplier;
}
