using UnityEngine;
using System.Collections.Generic;
public class GameStart : MonoBehaviour{
    [SerializeField] private List<CardData> StartingDeck;
    [SerializeField] private  int StartingHand;
    void Start(){
        Debug.Log("Game Started");
        Dealer.Instance.Setup(StartingDeck);
        DrawCardGA draw = new (StartingHand);
        ActionSystem.Instance.Perform(draw);
    }
}