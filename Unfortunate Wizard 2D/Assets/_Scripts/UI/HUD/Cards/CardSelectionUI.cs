using System;
using UnityEngine;

public class CardSelectionUI : MonoBehaviour
{
    [SerializeField, Tooltip("Child of this object")] private GameObject selectUI;

    private void Awake()
    {
        ChangeCardSelectionState(false);
    }

    public void ChangeCardSelectionState(bool isSelected)
    {
        selectUI.SetActive(isSelected);
    }
}