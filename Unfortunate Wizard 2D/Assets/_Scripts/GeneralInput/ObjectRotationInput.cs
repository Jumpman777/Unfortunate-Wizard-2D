using System;
using UnityEngine;

public class ObjectRotationInput : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.onCardSelected.Subscribe(CardSelected);
        EventManager.onCardDeselected.Subscribe(CardDeselected);
    }

    private void OnDisable()
    {
        EventManager.onCardSelected.Unsubscribe(CardSelected);
        EventManager.onCardDeselected.Unsubscribe(CardDeselected);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            EventManager.onIndicatorRotate.Invoke();
        }
    }
    
    private void CardSelected(CardInfo cardInfo)
    {
        enabled = true;
    }
    private void CardDeselected()
    {
        enabled = false;
    }
}