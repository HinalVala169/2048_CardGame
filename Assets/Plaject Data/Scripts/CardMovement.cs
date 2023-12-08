using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMovement : MonoBehaviour, IDragHandler
{
    #region PUBLIC_VARS
    public bool isDragging = false;
    public Vector3 initialTransform;
    public Card card;
    public BoxCollider2D boxCollider2D;
    #endregion

    #region PRIVATE_VARS
    private Vector3 offset;
    private Image Block = null;
    private int index = -1;
    private float lastmaxDis;
    private Card previousCard = null;
    private bool isEmpty;
    public bool isDestoy;
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        initialTransform = transform.localPosition;
    }
    private void OnMouseDown()
    {
        OnDragStart();
    }

    private void OnMouseDrag()
    {
        OnDrag();
    }

    private void OnMouseUp()
    {
        OnDragEnd();
    }

    #endregion

    #region PUBLIC_FUNCTIONS
    public void OnDragStart()
    {
        offset = transform.position - GetMouseWorldPos();
    }

    public void OnDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPos() + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            Drop();
        }
    }

    public void OnDragEnd()
    {
        CardDrop(Block);
    }
    public void CardDrop(Image cardBlock)
    {
        if (card == null)
        {
            return;
        }


        if (cardBlock != null && cardBlock.GetComponent<CardsList>() != null)
        {
            CardsList newCardList = cardBlock.GetComponent<CardsList>();
            if (newCardList.cardList != null && newCardList.cardList.Count > 1)
            {
                Card previousCard = newCardList.cardList[newCardList.cardList.Count - 1];
                // Debug.Log(card.cardNo + "card.cardNo");
                // Debug.Log(previousCard.cardNo + "previousCard");
            }

            if ((newCardList.cardList == null || newCardList.cardList.Count < 8) || (previousCard != null && card.cardNo.text == previousCard.cardNo.text))
            {
                float distance = Vector2.Distance(transform.position, cardBlock.transform.position);

                if (distance <= lastmaxDis)
                {
                    AudioManager.instance.PlayAudio(AudioName.Card);
                    transform.SetParent(cardBlock.transform);
                    if (isEmpty)
                    {
                        transform.localPosition = new Vector2(0, 0);
                    }
                    else
                    {
                        float yPosOffset = -90f;
                        float yPos = previousCard.transform.localPosition.y + yPosOffset;
                        transform.localPosition = new Vector2(0, yPos);
                        if (CardManager.instance.cardMergeAndAddition != null && CardManager.instance.cardMergeAndAddition.MergeCards(card))
                        {
                            CardManager.instance.CheckForGameOver();
                        }
                        else
                        {
                            CardManager.instance.CheckForGameOver();
                        }
                    }

                    if (newCardList.cardList != null)
                    {
                        newCardList.cardList.Add(card);
                    }
                    boxCollider2D.enabled = false;
                    isDragging = false;
                    if (CardManager.instance.SpawnCard != null)
                    {
                        CardManager.instance.SpawnCard.ShuffleCards(card);
                    }
                }

                else
                {
                    transform.localPosition = initialTransform;
                    CardManager.instance.CheckForGameOver();
                }
            }
            else
            {
                transform.localPosition = initialTransform;
                CardManager.instance.CheckForGameOver();
            }
        }
        if (isDestoy && CardManager.instance != null && CardManager.instance.discardCards != null)
        {
            if (card != null)
            {
                CardManager.instance.discardCards.DiscardCard(card);
            }
            else
            {
                Debug.Log("Attempted to discard a null card");
            }
        }
    }
    #endregion

    #region PRIVATE_FUNCTIONS

    private void Drop()
    {
        float maxDistance = 1.5f;
        float minDistance = float.MaxValue;
        for (int i = 0; i < CardManager.instance.cardlists.Count; i++)
        {
            Image cardObj = CardManager.instance.cardlists[i].blockImage;
            float distance = Vector2.Distance(transform.position, cardObj.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                Block = cardObj;
                index = i;
            }
        }

        if (Block != null && minDistance <= maxDistance)
        {
            lastmaxDis = maxDistance;
            CardsList script = Block.GetComponent<CardsList>();

            if (script != null)
            {
                if (script.cardList.Count > 0)
                {
                    Card lastAddedCard = script.cardList[script.cardList.Count - 1];
                    previousCard = lastAddedCard;
                    isEmpty = false;
                }
                else
                {
                    isEmpty = true;
                }
            }
        }
        float maxDistanceDes = 1f;
        float minDistanceDes = float.MaxValue;
        float discardObjDis = Vector2.Distance(transform.position, CardManager.instance.discardCards.discardBlock.transform.position);
        if (discardObjDis < minDistanceDes)
        {
            minDistanceDes = discardObjDis;
        }

        if (CardManager.instance.discardCards.discardBlock != null && minDistanceDes <= maxDistanceDes)
        {

            isDestoy = true;
        }
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    #endregion

    #region CO-ROUTINES

    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    #endregion
}