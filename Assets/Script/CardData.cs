using UnityEngine;
using System.Collections.Generic;
using SerializeReferenceEditor;
[CreateAssetMenu(menuName = "Data/Card")]

public class CardData : ScriptableObject {
    [field:SerializeField] public string Description { get;  set; }
    [field:SerializeField] public Sprite Image { get; set; }

    [field:SerializeReference, SR] public List<Effect> Effects { get; private set; }
}