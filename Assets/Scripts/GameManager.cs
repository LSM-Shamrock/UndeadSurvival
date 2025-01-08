using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManager>();
            }
            return instance;
        }
    }

    public static Player Player { get { return Instance.player; } }

    public Player player;
}
