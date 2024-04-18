using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Hand : MonoBehaviour
{
    [FormerlySerializedAs("singleCardUI")] [SerializeField, Tooltip("Ordered from left to right")] 
    private SingleCardUI[] cards = new SingleCardUI[3];
    private int numberOfCardsInHand;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        EventManager.onDrawCards.Subscribe(DrawNewCards);
        EventManager.onSpawnObject.Subscribe(CardUsed);
        EventManager.onCardSelected.Subscribe(DeselectAllOtherCards);
    }
    private void OnDisable()
    {
        EventManager.onDrawCards.Unsubscribe(DrawNewCards);
        EventManager.onSpawnObject.Unsubscribe(CardUsed);
        EventManager.onCardSelected.Unsubscribe(DeselectAllOtherCards);
    }

    private void Init()
    {
        numberOfCardsInHand = cards.Length;

        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].gameObject.SetActive(false);
        }
    }
    
    private void DrawNewCards(CardInfo[] cardsInfo)
    {
        numberOfCardsInHand = cards.Length;
        if (cardsInfo.Length != cards.Length)
        {
            throw new Exception("CardDrawer created incorrect number of cards");
        }
        for (int i = 0; i < cardsInfo.Length; i++)
        {
            cards[i].SetCardUI(cardsInfo[i]);
            cards[i].gameObject.SetActive(true);
        }
    }
    
    private void CardUsed(CardInfo cardInfo)
    {
        cards[cardInfo.cardId].gameObject.SetActive(false);
        
        numberOfCardsInHand--;
        if (numberOfCardsInHand <= 0)
        {
            DeselectAllCards();
            EventManager.onHandEmpty.Invoke();
            Debug.Log("On hand empty invoked");
        }
    }

    private void DeselectAllOtherCards(CardInfo mostRecentlySelectedCard)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (i != mostRecentlySelectedCard.cardId)
            {
                cards[i].DeselectCard();
            }
        }
    }

    private void DeselectAllCards()
    {
        foreach (var card in cards)
        {
            card.DeselectCard();
        }
    }
}