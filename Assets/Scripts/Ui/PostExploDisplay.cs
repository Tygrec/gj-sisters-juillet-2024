using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostExploDisplay : MonoBehaviour
{
    [SerializeField] Transform lootableTransform;
    public void Display(AdventureManager aventure) {
        foreach (var item in aventure.lootables) {
            Slot slot = Instantiate(Resources.Load<Slot>("Prefabs/Slot"), lootableTransform);
            slot.inventoryType = InventoryType.Adventure;
            slot.DisplayItem(item, 3);
            // TODO : faire le loot d'objets et la quantité aléatoire en fonction de l'aventure et la rareté
        }
    }
    public void Clear() {
        foreach (Transform transform in lootableTransform) {
            Destroy(transform.gameObject);
        }
    }
}
