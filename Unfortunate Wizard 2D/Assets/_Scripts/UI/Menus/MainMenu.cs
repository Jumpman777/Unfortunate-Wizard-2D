using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainScreen;
    //[SerializeField] private GameObject OptionsScreen;
    //[SerializeField] private GameObject CreditsScreen;

    public void BackButtonClicked()
    {
        //CreditsScreen.SetActive(false);
        //OptionsScreen.SetActive(false);
        MainScreen.SetActive(true);
    }

    public void GoToCredits()
    {
        //CreditsScreen.SetActive(true);
        MainScreen.SetActive(false);
    }
    public void GoToOptions()
    {
        //OptionsScreen.SetActive(true);
        MainScreen.SetActive(false);
    }
    
    public void StartGame()
    {
        SceneManagerScript.Instance.LoadScene(Scenes.Level1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
