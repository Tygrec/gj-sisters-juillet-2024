using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    List<Slot> _slots = new List<Slot>();
    [SerializeField] Transform _slotsTransform;

    private void Start() {
        for (int i = 0; i < GameManager.Instance.INVENTORY_SIZE; i++) {
            _slots.Add(Instantiate(Resources.Load<Slot>("Prefabs/Slot"), _slotsTransform));
            _slots[i].inventoryType = InventoryType.Player;
        }
    }

 /*   public void AddItem(Item item, int quantity) {

        Slot slot = _slots.Find(s => s.Item == item);

        if (slot != null) {
            slot.AddQuantity(quantity);
        }
        else {

            foreach (Slot s in _slots) {

                if (s.Item == null) {
                    s.DisplayItem(item, quantity);
                    break;
                }
            }
        }
    } */

    public void Display() {
        int i = 0;

        foreach (var pair in GameManager.Instance.PlayerInventory) {
            if (i >= _slots.Count)
                break;

            _slots[i].DisplayItem(pair.Key, pair.Value);
            i++;
        }
    }

    public void ExitDisplay() {
        if (GameManager.Instance.GameState != GameState.WORLDMAP)
            return;

        gameObject.SetActive(false);
    }
}
