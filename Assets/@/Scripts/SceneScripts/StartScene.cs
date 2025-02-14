using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : SceneScript
{
    [SerializeField] private GameObject[] _dontDestroyOnLoads;

    private void Start()
    {
        foreach (var go in _dontDestroyOnLoads) DontDestroyOnLoad(go);
        //SceneManager.LoadScene();
    }
}
