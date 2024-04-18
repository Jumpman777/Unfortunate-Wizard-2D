using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityUtils;

public class LevelManager : Singleton<LevelManager>
{
    [field: SerializeField] public int maxLevelNumber { get; private set; } = 5;
    [field: SerializeField] public int currentLevelNumber { get; private set; } = 1;

    protected override void Awake()
    {
        base.Awake();
        SummonObjectDataManager.LoadDataForCurrentLevel(currentLevelNumber);
        
        EventManager.onKillPlayer.Subscribe(RestartLevel);
        EventManager.onFinishLevel.Subscribe(GoToNextLevel);
    }

    private void OnDestroy()
    {
        EventManager.onKillPlayer.Unsubscribe(RestartLevel);
        EventManager.onFinishLevel.Unsubscribe(GoToNextLevel);
    }

    private void GoToNextLevel()
    {
        StopAllCoroutines();
        StartCoroutine(WaitBeforeGoingToNextLevel());
    }
    
    private IEnumerator WaitBeforeGoingToNextLevel()
    {
        yield return new WaitForSeconds(3f);
        currentLevelNumber++;
        if (currentLevelNumber > maxLevelNumber)
        {
            SceneManagerScript.Instance.LoadScene(Scenes.MainMenu);
        }
        else
        {
            SceneManagerScript.Instance.LoadNextLevel();
        }
    }

    private void RestartLevel()
    {
        StopAllCoroutines();
        StartCoroutine(WaitBeforeRestartLevel());
    }

    private IEnumerator WaitBeforeRestartLevel()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManagerScript.Instance.RestartCurrentScene();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            RestartLevel();
        }
    }
}