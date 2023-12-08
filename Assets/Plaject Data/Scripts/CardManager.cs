using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    #region PUBLIC_VARS
    public static CardManager instance;
    public List<CardsList> cardlists = new();
    public SpawnCard SpawnCard;
    public CardMergeAndAddition cardMergeAndAddition;
    public DiscardCards discardCards;
    #endregion

    #region PRIVATE_VARS
    bool allListsFull = false;
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        instance = this;
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS
    public void CheckForGameOver()
    {
        foreach (var cardList in cardlists)
        {
            if (cardList.cardList.Count > 8)
            {
                allListsFull = true;
                break;
            }
        }

        if (allListsFull && discardCards.count > 2)
        {
            
            if (IsFirstSpawnedCardEqualToListElement())
            {
                Debug.Log("Game Over");
                ScreenManager.instance.SwitchScreen(Screentype.PauseScreen);
            }
        }
    }
    private bool IsFirstSpawnedCardEqualToListElement()
    {
        Debug.Log("Noo");
        foreach (var cardList in cardlists)
        {
            Debug.Log("cardlists.cardno" + cardList.cardList[7].cardNo);
            Debug.Log("SpawnCard.spawnedCards" + SpawnCard.spawnedCards[0].cardNo);
            if (cardList.cardList.Count >= 8 && cardList.cardList[7].cardNo != SpawnCard.spawnedCards[0].cardNo)
            {
                return true;
            }
        }
        return false;
    }

    #endregion

    #region CO-ROUTINES

    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    #endregion
}
