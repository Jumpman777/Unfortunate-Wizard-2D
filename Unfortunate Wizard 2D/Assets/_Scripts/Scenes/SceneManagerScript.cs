using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Array = System.Array;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript Instance { get; private set; }

    [SerializeField] private ScenesSO scenes;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void LoadScene(Scenes sceneName)
    {
        Scene targetScene;
        try
        {
            targetScene = Array.Find(scenes.ScenesArray, x => x.SceneName == sceneName);
        }
        catch
        {
            Debug.LogError($"Didn't find scene: {sceneName}");
            return;
        }

        SceneManager.LoadScene(targetScene.BuildIndex);
    }
    

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    private Scenes GetCurrentSceneName()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        return (Scenes)currentSceneIndex;
    }
    
    public void RestartCurrentScene()
    {
        LoadScene(GetCurrentSceneName());
    }

}
