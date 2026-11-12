using UnityEngine;

public class ButtonDiscard : MonoBehaviour{
    public void OnClick(){
        Discard discard = new();
        EnemyTurnGA draw = new();
        ActionSystem.Instance.Perform(discard);
        ActionSystem.Instance.Perform(draw);
        Debug.Log("iasdfasdf");
    }
}