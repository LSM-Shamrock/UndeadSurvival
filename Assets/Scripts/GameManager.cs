using UnityEngine;

public class GameManager : MonoBehaviour 
{
    private static Player player;
    public static Player Player
    {
        get
        {
            if (player == null)
                player = FindFirstObjectByType<Player>();

            return player;
        }
    }

}