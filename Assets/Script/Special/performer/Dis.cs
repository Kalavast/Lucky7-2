using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class Unity : MonoBehaviour {
    private IEnumerator PerformDiscard(){
        Discard discard = new();
        ActionSystem.Instance.Perform(discard);
        yield return null;
    }
}