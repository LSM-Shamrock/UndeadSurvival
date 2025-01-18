using System;
using UnityEngine;

[Serializable]
public struct WeaponStat
{
    [Tooltip("�ߵ� ����")] public float activationInterval;
    [Space]
    [Tooltip("���� �߻� ����")] public int multiple;
    [Tooltip("���� Ƚ��")] public int repeatCount;
    [Tooltip("���� ����")] public float repeatInterval;
    [Space]
    [Tooltip("ȸ�� ������")] public float rotationRadius;
    [Tooltip("ȸ�� �ӵ�")] public float rotationSpeed;
    [Tooltip("�߻� �ӵ�")] public float shootSpeed;
    [Space]
    [Tooltip("�浹 ���ط�")] public int collisionDamage;
    [Tooltip("���� ���� ����")] public float tickDamageInterval;
    [Tooltip("���� Ƚ��")] public float pierceCount;
    [Space]
    [Tooltip("��Ȱ��ȭ�� �ð�")] public float timeToDisable;
    [Tooltip("��Ȱ��ȭ�� �߻� �Ÿ�")] public float shootDistanceToDisable;
}