using System.Collections;
using UnityEngine;

public class EffectsSystem : MonoBehaviour{

    void OnEnable(){
        ActionSystem.AttachPerformer<PerformEffectGA>(PerformEffectPerformer);
    }
    void OnDisable(){
        ActionSystem.DetachPerformer<PerformEffectGA>();
    }
    private IEnumerator PerformEffectPerformer(PerformEffectGA effect){
        GameAction performAction = effect.effect.GetGameAction();
        ActionSystem.Instance.AddReaction(performAction);
        yield return null;
    }
}