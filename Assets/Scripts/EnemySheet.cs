using UnityEngine;

[CreateAssetMenu(fileName = "EnemySheet", menuName = "Scriptable Objects/EnemySheet")]
public class EnemySheet : ScriptableObject
{
    public EnemyData[] enemyDatas;
}
