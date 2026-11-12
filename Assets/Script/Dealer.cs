using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;
using DG.Tweening;
public class Dealer : Singleton<Dealer> {
    [SerializeField] private HandView handView;
    [SerializeField] private Transform Drawpoint;
    [SerializeField] private Transform Discardpoint;
    private readonly List<Card> hand = new List<Card>();
    private readonly List<Card> drawPile = new List<Card>();
    private readonly List<Card> discardPile = new List<Card>();
    void OnEnable(){
        ActionSystem.AttachPerformer<DrawCardGA>(drawCardsPerformer);
        ActionSystem.AttachPerformer<Discard>(discardCardsPerformer);
        ActionSystem.AttachPerformer<PlayCardGA>(playCardPerformer);
        //ActionSystem.AttachPerformer<EnemyTurnGA>(drawCardsPerformer);
    }
    void OnDisable(){
        ActionSystem.DetachPerformer<DrawCardGA>();
        ActionSystem.DetachPerformer<Discard>();
        ActionSystem.DetachPerformer<PlayCardGA>();
    }
    public void Setup(List<CardData> deckData){
        foreach(var cardData in deckData){
            Card card = new(cardData);
            drawPile.Add(card);
        }
    }
    private IEnumerator drawCardsPerformer(DrawCardGA drawCardsGA){
        int drawcount = Mathf.Min(drawCardsGA.amount, drawPile.Count);
        int notDrawnAmount = drawCardsGA.amount - drawcount;
        for (int i = 0; i < drawcount; i++){ 
            yield return DrawCard();
        }
        if(notDrawnAmount > 0){
            
        }
        //yield return DrawCard();
        

    }
    private IEnumerator playCardPerformer(PlayCardGA playCardGA){ //plays card effects
        hand.Remove(playCardGA.card);
        CardDisplay cardDisplay = handView.RemoveCard(playCardGA.card);
        Debug.Log("Paycard Performer");
        yield return DiscardCard(cardDisplay);
        foreach(var effect in playCardGA.card.Effects){
            PerformEffectGA performEffectGA = new (effect);
            ActionSystem.Instance.AddReaction(performEffectGA);
        }

    }
    


    private IEnumerator discardCardsPerformer(Discard discard ){
        foreach(var card in hand){
            discardPile.Add(card);
            CardDisplay cardDisplay = handView.RemoveCard(card);
            yield return DiscardCard(cardDisplay);
        }
        hand.Clear();
    }
    public IEnumerator DrawCard(){
        Card card = drawPile.Draw();
        hand.Add(card);
        CardDisplay cardDisplay = CardDisplayCreator.Instance.CreateCardDisplay(card,Drawpoint.position, Discardpoint.rotation);
        yield return handView.AddCard(cardDisplay);
    }

    private void RefillDeck(){
        drawPile.AddRange(discardPile);
        discardPile.Clear();
    }
    private IEnumerator DiscardCard(CardDisplay cardDisplay){
       cardDisplay.transform.DOScale(Vector3.zero, 0.5f);
       Tween tween = cardDisplay.transform.DOMove(Discardpoint.position, 0.15f);
       yield return tween.WaitForCompletion();
       Destroy(cardDisplay.gameObject);
    }
}
