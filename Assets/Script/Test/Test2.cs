using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Splines;
//using static System.Buffers.ReadOnlySequence<T>;

public class Test2 : MonoBehaviour {
    [SerializeField] private SplineContainer splineContainer;
     [SerializeField] public SpriteRenderer image ;
    [SerializeField] public GameObject cardPrefab;
    [SerializeField] public Transform spawnPoint;
    public readonly List<GameObject> handcards = new();
    private void Update(){
         if(Input.GetKeyDown(KeyCode.Space)){
            //CardDisplay cardDisplay = CardDisplayCreator.Instance.CreateCardDisplay(transform.position, Quaternion.identity);
            AddCard();
        }
    }
    public void AddCard(){
        if(handcards.Count >= 5) return;
        
        GameObject card = Instantiate(cardPrefab, spawnPoint.transform.position, Quaternion.identity);
        handcards.Add(card);
        UpdateCardPositions();
    }
    private void UpdateCardPositions(){
        if(handcards.Count == 0) return;

        float cardSpacing = 1f / handcards.Count;
        float firstCardPosition = 0.5f - (handcards.Count - 1) * cardSpacing / 2;

        Spline spline = splineContainer.Spline;

        for(int i = 0; i < handcards.Count; ++i){
            float p = firstCardPosition + i * cardSpacing;

            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Debug.Log("i=" +i +" up" + up + " forward=" + forward + " firstCardPosition" + firstCardPosition) ;
            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);
            handcards[i].transform.DOMove(splinePosition, .25f);
            handcards[i].transform.DORotate(rotation.eulerAngles, .25f);
           // Debug.Log("i=" +i +"cards" + cards[i].transform.position + " P=" + p);
            
            
            
            
        }
      //  yield return new WaitForSeconds(.25f);
    }
}