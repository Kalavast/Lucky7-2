using System.Collections;
using UnityEngine;


public class EnemySystem : MonoBehaviour {
    void OnEnable(){
        ActionSystem.AttachPerformer<EnemyTurnGA>(enemyTurnPerformer);
    }
    void OnDisable(){
        ActionSystem.DetachPerformer<EnemyTurnGA>();
    }
    private IEnumerator enemyTurnPerformer(EnemyTurnGA enemyTurnGA){
        // Implement the enemy turn logic here
        Debug.Log("Enemy Turn");
        yield return null;
    }
}