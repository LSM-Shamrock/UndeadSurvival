using System;
using UnityEngine;

[Serializable]
public struct WeaponProjectileStat
{
    [Tooltip("�߻� �ӵ�")] public float shootSpeed;
    [Tooltip("ȸ�� �ӵ�")] public float rotationSpeed;
    [Tooltip("ȸ�� ������")] public float rotationRadius;
    [Space]
    [Tooltip("���ط�")] public int damage;
    [Tooltip("�˹�")] public float knockback;
    [Tooltip("ü�� ȿ�� ����")] public float stayEffectInterval;
    [Tooltip("��Ȱ��ȭ���� ���� ���� Ƚ��")] public float penetrationCountToDontDisable;
    [Space]
    [Tooltip("��Ȱ��ȭ�� �ð�")] public float timeToDisable;
    [Tooltip("��Ȱ��ȭ�� �߻� �Ÿ�")] public float shootDistanceToDisable;
}
