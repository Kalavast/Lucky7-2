using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Splines;
//using static System.Buffers.ReadOnlySequence<T>;

public class HandView : MonoBehaviour {
    [SerializeField] private SplineContainer splineContainer;
    public readonly List<CardDisplay> cards = new();
    public IEnumerator AddCard(CardDisplay cardView){
        cards.Add(cardView);
        
        yield return UpdateCardPositions(.15f);
    }
    public CardDisplay RemoveCard(Card card){
        CardDisplay cardDisplay = GetCardView(card);
        if(cardDisplay == null) return null;
        cards.Remove(cardDisplay);
        StartCoroutine(UpdateCardPositions(.15f));
        return cardDisplay;
    }
    private CardDisplay GetCardView(Card card){
        return cards.Where(cardView => cardView.card == card).FirstOrDefault();
    }
    private IEnumerator UpdateCardPositions(float duration){
        if(cards.Count == 0) yield break;

        float cardSpacing = 1f /  10;
        float firstCardPosition = 0.55f - (cards.Count - 1) * cardSpacing / 2;

        Spline spline = splineContainer.Spline;

        for(int i = 0; i < cards.Count; ++i){
            float p = firstCardPosition + i * cardSpacing;

            Vector3 splinePos = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
           

            Quaternion rotation = Quaternion.LookRotation(-up, Vector3.Cross(-up,forward).normalized);
            cards[i].transform.DOMove(splinePos + transform.position + 0.01f * i * Vector3.back, duration);
            cards[i].transform.DORotate(rotation.eulerAngles, duration);

            
            //Debug.Log("i=" +i +"cards" + cards[i].transform.position + " P=" + p);
            
            
            
            
        }
        yield return new WaitForSeconds(duration);
    }

}

