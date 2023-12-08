using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscardCards : MonoBehaviour
{
    #region PUBLIC_VARS
    public List<Image> discardedCards = new();
    public Image discardBlock;

    #endregion

    #region PRIVATE_VARS
    public int count;
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_FUNCTIONS
    public void DiscardCard(Card card)
    {
        CardMovement cardMovement = card.GetComponent<CardMovement>();
       // Debug.Log("..$$$.....");
        if (count < 2)
        {
           // Debug.Log("..tyyy.....");
           
            Destroy(card.gameObject);
            CardManager.instance.SpawnCard.ShuffleCards(card);
            count++;
            card.cardMovement.isDestoy = false;
        }
        else
        {
            card.transform.localPosition = cardMovement.initialTransform;
        }
        switch (count)
        {
            case 1: discardedCards[0].enabled = true;
                break;

            case 2: discardedCards[1].enabled = true;
                break;
        }
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion

    #region CO-ROUTINES

    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    #endregion
}
