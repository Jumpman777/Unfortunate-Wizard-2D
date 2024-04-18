using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SingleCardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField, Tooltip("In child object")] private CardSelectionUI cardSelectionUI;
    private bool _isSelected;
    private CardInfo _currentCard;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(OnCardClicked);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(OnCardClicked);
    }

    private void OnCardClicked()
    {
        if (_isSelected)
        {
            DeselectCard();
            
            // Only send the event if the card is clicked, not when Hand.cs deselects it
            EventManager.onCardDeselected.Invoke();
            Debug.Log("on Card Deselected invoked");
        }
        else
        {
            SelectCard();
        }
    }

    private void SelectCard()
    {
        EventManager.onCardSelected.Invoke(_currentCard);
        Debug.Log("on Card Selected invoked");
        _isSelected = true;
        cardSelectionUI.ChangeCardSelectionState(_isSelected);
    }

    public void DeselectCard()
    {
        _isSelected = false;
        cardSelectionUI.ChangeCardSelectionState(_isSelected);
    }
    
    
    public void SetCardUI(CardInfo cardInfo)
    {
        _currentCard = cardInfo;
        SummonObjectData data = SummonObjectDataManager.SummonObjectsData.GetSummonObjectData(cardInfo.summonObjectId);
        
        cardName.text = data.name.ReplaceUnderscoreWithSpace();
        
    }
    
}