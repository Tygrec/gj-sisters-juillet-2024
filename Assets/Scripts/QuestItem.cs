using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestItemType {
    Arc,
    Marteau,
    Lampe
}
[CreateAssetMenu(fileName = "Quest Item", menuName = "New Quest Item")]
public class QuestItem : ScriptableObject {
    public QuestItemType type;
}