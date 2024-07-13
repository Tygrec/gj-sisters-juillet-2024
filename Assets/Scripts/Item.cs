using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    Nourriture,
    Metal,
    Magie
}

public enum Rarity {
    Common,
    Uncommon,
    Rare,
    Legendary
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class Item : ScriptableObject
{
    public ItemType Type;
    public int value;
    public Rarity Rarity;
}
