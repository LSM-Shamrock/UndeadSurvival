//using UnityEditor;
//using UnityEditor.SceneManagement;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//[InitializeOnLoad]
//public static class ForceStartForFirstScene
//{
//    private static readonly string _startScenePath;
//    private static string _editorOpenedScenePath;

//    static ForceStartForFirstScene()
//    {
//        _startScenePath = EditorBuildSettings.scenes[0].path;
//        _editorOpenedScenePath = EditorSceneManager.GetActiveScene().path;
//        EditorApplication.playModeStateChanged += state =>
//        {
//            if (state == PlayModeStateChange.ExitingEditMode)
//            {
//                _editorOpenedScenePath = EditorSceneManager.GetActiveScene().path;
//                EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
//                if (EditorSceneManager.GetActiveScene().path != _startScenePath)
//                    EditorSceneManager.OpenScene(_startScenePath);
//            }
//            else if (state == PlayModeStateChange.EnteredEditMode)
//            {
//                if (EditorSceneManager.GetActiveScene().path != _editorOpenedScenePath)
//                    EditorSceneManager.OpenScene(_editorOpenedScenePath);
//            }
//        };
//    }
//}
