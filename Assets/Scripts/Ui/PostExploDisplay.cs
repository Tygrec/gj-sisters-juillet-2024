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
            slot.DisplayItem(item, 1);
        }
    }
    public void Clear() {
        foreach (Transform transform in lootableTransform) {
            Destroy(transform.gameObject);
        }
    }
}
