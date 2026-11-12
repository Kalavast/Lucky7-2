using UnityEngine;
public class Test : MonoBehaviour
{
    [SerializeField] private HandView handView;
     [SerializeField] private CardData cardData;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update() {
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     Card card = new Card(cardData);
        //     CardDisplay cardDisplay = CardDisplayCreator.Instance.CreateCardDisplay(card, transform.position, Quaternion.identity);
        //     StartCoroutine(handView.AddCard(cardDisplay));
        // }
    }
}
