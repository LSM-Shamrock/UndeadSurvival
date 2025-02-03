using UnityEngine;

public static class ManagerLoader
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadManagers()
    {
        GameObject resource = Resources.Load<GameObject>("Managers");
        GameObject.DontDestroyOnLoad(GameObject.Instantiate(resource));
    }
}
