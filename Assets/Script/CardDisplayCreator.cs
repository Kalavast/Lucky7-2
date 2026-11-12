using DG.Tweening;
using UnityEngine;
public class CardDisplayCreator : Singleton<CardDisplayCreator> {
    [SerializeField] private CardDisplay cardPrefab;
    public CardDisplay CreateCardDisplay(Card card,Vector3 position, Quaternion rotation){
        CardDisplay cardDisplay = Instantiate(cardPrefab, position, rotation);
        cardDisplay.transform.localScale = Vector3.zero;
        cardDisplay.transform.DOScale(Vector3.one, 0.15f);
        cardDisplay.Setup(card);
        return cardDisplay;
    }
}

