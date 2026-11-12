using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;
using DG.Tweening;
public class DrawCard : Singleton<DrawCard> {
    [SerializeField] private HandView handView;
    [SerializeField] private Transform Drawpoint;
    [SerializeField] private Transform Discardpoint;

    [SerializeField] private GameObject cardPrefab;
    // private readonly List<Card> hand = new List<Card>();
    // private readonly List<Card> drawPile = new List<Card>();
    // private readonly List<Card> discardPile = new List<Card>();

//     private void OnEnable(){
//         ActionSystem.AttachPerformer<DrawCardGA>(DrawCard1);
//     }
//     private void OnDisable(){
//         ActionSystem.DetachPerformer<DrawCardGA>();
//     }
//     private IEnumerator DrawCard1(DrawCardGA drawCardGA){
//         Debug.Log("DrawPerformer");
//         GameObject card = Instantiate(cardPrefab, Drawpoint.position, Drawpoint.rotation);
//         Tween tween = card.transform.DOMove(handView.transform.position, 1f);
//         yield return new WaitForSeconds(1f);
//     }
 }
