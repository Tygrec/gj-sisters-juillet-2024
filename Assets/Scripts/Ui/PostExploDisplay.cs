using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostExploDisplay : MonoBehaviour
{
    [SerializeField] Transform lootableTransform;
    public void Display(AdventureManager aventure) {
        foreach (var item in aventure.lootables) {

            int nb_loot = 0;
            for (int i = 0; i < 3; i++) {
                if (Random.Range(0, 100) < FromRarity.GetProbabilities(item.Rarity))
                    nb_loot++;
            }

            if (nb_loot > 0) {
                Slot slot = Instantiate(Resources.Load<Slot>("Prefabs/Slot"), lootableTransform);
                slot.inventoryType = InventoryType.Adventure;
                slot.DisplayItem(item, nb_loot);
            }
        }
    }
    public void Clear() {
        foreach (Transform transform in lootableTransform) {
            Destroy(transform.gameObject);
        }
    }
}
