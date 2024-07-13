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

public static class FromRarity {
    public static Color GetColor(Rarity rarity) {
        if (rarity == Rarity.Common)
            return Color.gray;
        if (rarity == Rarity.Uncommon)
            return Color.green;
        if (rarity == Rarity.Rare)
            return Color.blue;
        if (rarity == Rarity.Legendary) {
            Color color = new Color(255, 165, 0);
            color.a = 1;
            return color;
        }

        Debug.LogError("La rareté n'a pas été trouvée");
        return Color.black;
    }

    public static int GetProbabilities(Rarity rarity) {
        if (rarity == Rarity.Common)
            return 80;
        if (rarity == Rarity.Uncommon)
            return 50;
        if (rarity == Rarity.Rare)
            return 20;
        if (rarity == Rarity.Legendary)
            return 5;

        Debug.LogError("La rareté n'a pas été trouvée");
        return 0;
    }
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class Item : ScriptableObject
{
    public ItemType Type;
    public int value;
    public Rarity Rarity;
    public string Description;
}
