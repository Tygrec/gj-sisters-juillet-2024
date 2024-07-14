using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    List<Slot> _slots = new List<Slot>();
    [SerializeField] Transform _slotsTransform;
    [SerializeField] GameObject button;

    private void Start() {
        for (int i = 0; i < GameManager.Instance.INVENTORY_SIZE; i++) {
            _slots.Add(Instantiate(Resources.Load<Slot>("Prefabs/Slot"), _slotsTransform));
            _slots[i].inventoryType = InventoryType.Player;
        }
    }

    public void Display() {
        button.SetActive(false);
        gameObject.SetActive(true);

        int i = 0;
        foreach (var pair in GameManager.Instance.PlayerInventory) {

            if (i >= _slots.Count)
                break;

            _slots[i].DisplayItem(pair.Key, pair.Value);
            i++;
        }

        for (int j = i ; j < _slots.Count; j++) {
            _slots[j].Clear();
        }
    }

    public void ExitDisplay() {
        if (GameManager.Instance.GameState != GameState.WORLDMAP && GameManager.Instance.GameState != GameState.TUTORIAL)
            return;

        gameObject.SetActive(false);
        button.SetActive(true);
    }
}
