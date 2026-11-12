// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// #if UNITY_EDITOR
// using UnityEditor;
// [CustomEditor(typeof(DeckManager))]
// public class DeckManagerEditor : Editor
// {
//     public override void OnInspectorGUI()
//     {
//         DrawDefaultInspector();

//         DeckManager deckManager = (DeckManager)target;
//         if (GUILayout.Button("Draw Next Card")){
//             Dealer dealer = FindAnyObjectByType<Dealer>();
//             if (dealer != null){
//                 deckManager.DrawCard(dealer);
//             }
//         }
//     }
// }
// #endif