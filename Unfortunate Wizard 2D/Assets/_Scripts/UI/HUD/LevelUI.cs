using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelNumberText;
    
    [SerializeField] private GameObject finishLevelUIContainer;
    [SerializeField] private TextMeshProUGUI finishLevelText;
    
    private void Awake()
    {
        finishLevelUIContainer.SetActive(false);

        levelNumberText.text = $"Level {LevelManager.Instance.currentLevelNumber} of {LevelManager.Instance.maxLevelNumber}";
    }

    private void OnEnable()
    {
        EventManager.onFinishLevel.Subscribe(ShowFinishLevelUI);
    }

    private void OnDisable()
    {
        EventManager.onFinishLevel.Unsubscribe(ShowFinishLevelUI);
    }

    private void ShowFinishLevelUI()
    {
        finishLevelUIContainer.SetActive(true);
        finishLevelText.text = "Finished Level!";
    }
}
