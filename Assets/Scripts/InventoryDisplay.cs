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
        }
    }
}
