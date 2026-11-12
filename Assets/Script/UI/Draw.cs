using UnityEngine;

public class Draw : MonoBehaviour{
    public void OnClick(){
        DrawCardGA draw = new (0);
        ActionSystem.Instance.Perform(draw);
        Debug.Log("DrawClick");
    }
}