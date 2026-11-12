using UnityEngine;

public class DrawCardGA : GameAction{
    public int amount {get;  set;}
    public DrawCardGA(int amount){
        this.amount = amount;
        Debug.Log("DRAWGA");
    }
}
