using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityUtils;

public class CardDrawer : Singleton<CardDrawer>
{
    private void Start()
    {
        DrawCards();
    }
    
    private void DrawCards(int numberOfCards = 3)
    {
        CardInfo[] cardsInfo = new CardInfo[numberOfCards];
        for (int currentCard = 0; currentCard < numberOfCards; currentCard++)
        {
            cardsInfo[currentCard] = new CardInfo(SummonObjectDataManager.CurrentLevelSummonObjects.GetRandomSummonObject(), currentCard);
        }
        EventManager.onDrawCards.Invoke(cardsInfo);
        Debug.Log("on Draw Cards invoked");
    }
    
    private void HandEmpty()
    {
        DrawCards();
    }

    private void OnEnable()
    {
        EventManager.onHandEmpty.Subscribe(HandEmpty);
    }

    private void OnDisable()
    {
        EventManager.onHandEmpty.Unsubscribe(HandEmpty);
    }
}