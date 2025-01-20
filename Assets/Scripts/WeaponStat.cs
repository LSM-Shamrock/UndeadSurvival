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
    [Tooltip("���ط�")] public int damage;
    [Tooltip("ü�� ���� ����")] public float stayDamageInterval;
    [Tooltip("��Ȱ��ȭ���� ���� ���� Ƚ��")] public float penetrationCountToDontDisable;
    [Space]
    [Tooltip("��Ȱ��ȭ�� �ð�")] public float timeToDisable;
    [Tooltip("��Ȱ��ȭ�� �߻� �Ÿ�")] public float shootDistanceToDisable;
}