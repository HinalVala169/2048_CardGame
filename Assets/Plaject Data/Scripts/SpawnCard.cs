using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnCard : MonoBehaviour
{
    #region PUBLIC_VARS
    public Card cardPrefab;
    public List<CardColor> cardColors = new List<CardColor>();
    #endregion

    #region PRIVATE_VARS
    public List<Card> spawnedCards = new List<Card>();
    [SerializeField]
    private Vector2 cardPos1, cardPos2;
    public float moveDuration = 0f;
    #endregion

    #region UNITY_CALLBACKS
    void Start()
    {
        cardPos1 = spawnedCards[0].transform.localPosition;
        cardPos2 = spawnedCards[1].transform.localPosition;
        spawnedCards[0].cardMovement.isDragging = true;
    }
    #endregion


    #region PUBLIC_FUNCTIONS


    public void ShuffleCards(Card card)
    {
        if (spawnedCards.Count < 2)
        {
            return;
        }

        Card card0 = spawnedCards[1];
        StartCoroutine(MoveCardSmoothly(card0, cardPos2, cardPos1, moveDuration));
        spawnedCards[1] = card0;
        spawnedCards.Remove(card);
        StartCoroutine(SpawnCards(1));
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    private IEnumerator SpawnCards(int spawnCount)
    {
        Debug.Log("count"+cardColors.Count);
        int randomIndex = Random.Range(0, cardColors.Count-1);
        
        Card cardObj = Instantiate(cardPrefab, transform);
        cardObj.transform.SetAsFirstSibling();
        cardObj.cardImage.color = cardColors[randomIndex].col;
        cardObj.cardNo.text = cardColors[randomIndex].index.ToString();
        cardObj.gameObject.transform.localPosition = cardPos2;
        cardObj.gameObject.name += 1;
        Debug.Log(randomIndex);
        spawnedCards.Add(cardObj);
        yield return null;
    }
    private IEnumerator MoveCardSmoothly(Card cardObj, Vector2 startPos, Vector2 targetPos, float duration)
    {
        AudioManager.instance.PlayAudio(AudioName.Merge);
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * duration;
            cardObj.transform.localPosition = Vector2.Lerp(startPos, targetPos, t);
            yield return null;
        }
        cardObj.transform.localPosition = targetPos;
        cardObj.cardMovement.isDragging = true;
        cardObj.cardMovement.boxCollider2D.enabled = true;
        cardObj.cardMovement.initialTransform = targetPos;
    }
    #endregion

    #region CO-ROUTINES

    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    #endregion
}
[System.Serializable]
public class CardColor
{
    public int index;
    public Color col;
}
