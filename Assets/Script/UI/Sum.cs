using TMPro;
using UnityEngine;


public class Sum : MonoBehaviour{
    [SerializeField] private TMP_Text sumText;

    public void SetSum(int value){
        sumText.text = value.ToString();
    }
}