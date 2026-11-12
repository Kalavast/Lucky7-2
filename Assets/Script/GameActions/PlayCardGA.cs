using UnityEngine;

public class PlayCardGA : GameAction
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Card card {get; set;}
    public PlayCardGA(Card card){
        this.card = card;
        Debug.Log("PlayCard");
    }
}
