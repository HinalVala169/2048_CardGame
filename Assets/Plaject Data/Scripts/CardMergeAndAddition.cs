using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardMergeAndAddition : MonoBehaviour
{
    #region PUBLIC_VARS
    #endregion

    #region PRIVATE_VARS
    private int mergedNumber;
    private Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f);
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_FUNCTIONS
    public bool MergeCards(Card newCard)
    {
        int currentCardNo = int.Parse(newCard.cardNo.text);
        CardsList currentList = newCard.transform.parent.GetComponent<CardsList>();

        if (currentList != null && currentList.cardList.Count > 0)
        {
            Card lastAddedCard = currentList.cardList[currentList.cardList.Count - 1];
            int lastCardNo = int.Parse(lastAddedCard.cardNo.text);

            if (currentCardNo == lastCardNo && currentList != null)
            {
                Debug.Log("lastCardNo:" + lastCardNo );
                mergedNumber = currentCardNo * 2;
                newCard.transform.DOScale(targetScale, 0.1f).SetEase(Ease.InOutBounce);
                StartCoroutine(MoveCardSmoothly(newCard.transform, newCard.transform.localPosition, lastAddedCard.transform.localPosition, 0.5f, () =>
                {
                    Destroy(newCard.gameObject);
                    currentList.cardList.Remove(newCard);
                    lastAddedCard.cardNo.text = mergedNumber.ToString();
                    lastAddedCard.transform.localScale = Vector3.one;
                    UpdateMergedCardColor(lastAddedCard);
                    MergeAgain(lastAddedCard);
                }));

                return true;
            }
            return false;
        }

        return false;
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    private void MergeAgain(Card cardToMerge)
    {
        CardsList currentList = cardToMerge.transform.parent.GetComponent<CardsList>();
        int currentCardNo = int.Parse(cardToMerge.cardNo.text);
        int mergedNumber = 0;
        int index = currentList.cardList.IndexOf(cardToMerge);
        if (index > 0)
        {
            Card previousCard = currentList.cardList[index - 1];
            int previousCardNo = int.Parse(previousCard.cardNo.text);
            
            if (currentCardNo == previousCardNo)
            {
                Debug.Log("lastCardNo:" + previousCardNo );
                mergedNumber = currentCardNo * 2;
                cardToMerge.transform.DOScale(targetScale, 0.1f).SetEase(Ease.InOutBounce);
                StartCoroutine(MoveCardSmoothly(cardToMerge.transform, cardToMerge.transform.localPosition, previousCard.transform.localPosition, 0.5f, () =>
                {
                    currentList.cardList.Remove(cardToMerge);
                    Destroy(cardToMerge.gameObject);
                    previousCard.transform.localScale = Vector3.one;
                    previousCard.cardNo.text = mergedNumber.ToString();
                    UpdateMergedCardColor(previousCard);
                    MergeAgain(previousCard);
                }));
            }
        }
    }


    private void UpdateMergedCardColor(Card card)
    {
        int mergeNumber = int.Parse(card.cardNo.text);
        CardColor cardColor = FindCardColorByIndex(mergeNumber);

        if (cardColor != null)
        {
            card.cardImage.color = cardColor.col;
        }
    }

    private CardColor FindCardColorByIndex(int index)
    {
        foreach (CardColor color in CardManager.instance.SpawnCard.cardColors)
        {
            if (color.index == index)
            {
                return color;
            }
        }

        return null;
    }
    #endregion

    #region CO-ROUTINES
    private IEnumerator MoveCardSmoothly(Transform cardTransform, Vector3 startPos, Vector3 targetPos, float duration, Action onComplete)
    {
        float startTime = Time.time;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            if (cardTransform == null)
            {
                yield break;
            }
            float t = elapsedTime / duration;
            cardTransform.localPosition = Vector3.Lerp(startPos, targetPos, t);
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        if (cardTransform != null)
        {
            cardTransform.localPosition = targetPos;
        }

        if (onComplete != null)
        {
            onComplete.Invoke();
        }
    }
    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    #endregion
}