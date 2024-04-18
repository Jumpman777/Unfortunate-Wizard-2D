using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance { get; private set; }
    public bool IsPaused { get; private set; } = false;
    public bool ControlsEnabled { get; private set; } = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PauseToggle()
    {
        if (IsPaused)
            Unpause();
        else
            Pause();
    }
    public void SetPauseState(bool state)
    {
        if (state)
            Pause();
        else
            Unpause();
    }
    private void Pause()
    {
        Time.timeScale = 0;
        IsPaused = true;
        ControlsEnabled = false;
    }
    private void Unpause()
    {
        Time.timeScale = 1;
        IsPaused = false;
        ControlsEnabled = true;
    }

    public void DisableControls() // To disable input before and after race
    {
        ControlsEnabled = false;
    }
    public void EnableControls()
    {
        ControlsEnabled = true;
    }
}
