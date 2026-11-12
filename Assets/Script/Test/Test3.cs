using System.Collections.Generic;
using UnityEngine;

public class TestSystem : MonoBehaviour {
    [SerializeField] private List<CardData> deckData;

    private void Start(){
        
        // Dealer.Instance.Setup(deckData);
        // Dealer.Instance.DrawCard();
    }
}