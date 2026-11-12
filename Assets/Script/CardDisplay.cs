using UnityEngine;
using UnityEngine.UI;
public class CardDisplay : MonoBehaviour {
   // public Card cardData;
    [SerializeField] public SpriteRenderer image ;
    [SerializeField] public GameObject wrapper;
    [SerializeField] private LayerMask dropArea;
    public Card card { get; private set; }
    private Vector3 dragStartPosition;
    private Quaternion dragStartRotation;
    //public Image[] typeImages;
    public void Setup(Card card){
        this.card = card;
        image.sprite = card.Image;
    }
    // void Start(){
    //     UpdateCardDisplay();
    // }
    // void Update(){
        
    // }
    // public void UpdateCardDisplay(){
        
    // }
      void OnMouseEnter(){
        Debug.Log("open");
        if(!Interactions.Instance.PlayerCanHover()) return;
            Debug.Log("open2");
        wrapper.SetActive(false);
        Vector3 pos = new(transform.position.x, transform.position.y, 0);
        CardView.Instance.Show(card, pos);
    }
    void OnMouseExit(){
        Debug.Log("exit");
        if(!Interactions.Instance.PlayerCanHover()) return;
        Debug.Log("exit2");
        CardView.Instance.Hide();
        wrapper.SetActive(true);
    }
    
    void OnMouseUp(){
        Debug.Log("OnMouseUp");
        if(!Interactions.Instance.PlayerCanInteract()) return;
        Debug.Log("after");
        if(Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 10f, dropArea)){ //play card
            PlayCardGA playCardGA = new (card);
            ActionSystem.Instance.Perform(playCardGA);
            Debug.Log("Raycast hit");
        }
        else{
            transform.position= dragStartPosition;
            transform.rotation = dragStartRotation;
        }
        Interactions.Instance.PlayerIsDragging = false;
        //CardView.Instance.Hide();

        // Handle mouse release on the card display
    }
    void OnMouseDrag(){
        if(!Interactions.Instance.PlayerCanInteract()) return;
        // Handle mouse drag on the card display
        transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);
    }
    void OnMouseDown(){
        if(!Interactions.Instance.PlayerCanInteract()) return;

        Interactions.Instance.PlayerIsDragging = true;
        wrapper.SetActive(true);
        CardView.Instance.Hide();
        dragStartPosition = transform.position;
        dragStartRotation = transform.rotation;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);
        // Handle mouse click on the card display
    }
}