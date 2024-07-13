using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "New Quest")]
public class Quest : ScriptableObject {
    public Item Item;
    public int Quantity;
    public QuestItem Reward;
}