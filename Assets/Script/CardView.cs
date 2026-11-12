using UnityEngine;

public class CardView : Singleton<CardView> {
    [SerializeField] private CardDisplay cardDisplay;
    public void Show(Card card, Vector3 position){
        cardDisplay.gameObject.SetActive(true);
        cardDisplay.Setup(card);
        cardDisplay.transform.position = position;
       
    }
    public void Hide(){
        cardDisplay.gameObject.SetActive(false);
    }
}

