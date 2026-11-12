using UnityEngine;
using SerializeReferenceEditor;

public class DrawCardsEffect : Effect {
    [SerializeField] private int drawAmount;
    public override GameAction GetGameAction() {
        DrawCardGA drawCardsGA = new (drawAmount);
        return drawCardsGA;
    }
}