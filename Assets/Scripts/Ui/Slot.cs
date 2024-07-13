using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum InventoryType {
    Adventure,
    Player
}

public class Slot : MonoBehaviour, IPointerDownHandler
{
    public InventoryType inventoryType;
    [SerializeField] TextMeshProUGUI _quantityText;
    [SerializeField] Image _itemImage;
    public Item Item = null;
    int _quantity = 0;

    private void Awake() {
        _quantityText.text = "0";
    }

    public void DisplayItem(Item item, int quantity) {
        Item = item;
        _quantity = quantity;
        _itemImage.sprite = Resources.Load<Sprite>($"Sprites/{item.name}");
        _quantityText.text = _quantity.ToString();
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (Item == null || _quantity <= 0)
            return;

        if (inventoryType == InventoryType.Adventure) {
            if (Input.GetMouseButtonDown(0)) {
                GameManager.Instance.AddItemToInventory(Item, 1);
                _quantity--;
            }
            else if (Input.GetMouseButtonDown(1)) {
                GameManager.Instance.AddItemToInventory(Item, _quantity);
                _quantity = 0;
            }
        }

        if (inventoryType == InventoryType.Player) {
            if (Input.GetMouseButtonDown(0)) {
                GameManager.Instance.RemoveItemFromInventory(Item, 1);
                _quantity--;
            }
            else if (Input.GetMouseButtonDown(1)) {
                GameManager.Instance.RemoveItemFromInventory(Item, _quantity);
                _quantity = 0;
            }
        }

        _quantityText.text = _quantity.ToString();
    }
}
