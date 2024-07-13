using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _quantityText;
    [SerializeField] Image _itemImage;
    public Item Item = null;
    int _quantity = 0;

    public void DisplayItem(Item item, int quantity) {
        Item = item;
        _quantity = quantity;
        _itemImage.sprite = Resources.Load<Sprite>($"Sprites/{item.name}");
        _quantityText.text = quantity.ToString();
    }

    public void AddQuantity(int quantity) {
        _quantity += quantity;
        _quantityText.text = quantity.ToString();
    }

    public void RemoveQuantity(int quantity) {
        _quantity -= quantity;
        _quantityText.text = quantity.ToString();

        if (quantity <= 0) {
            Item = null;
            _itemImage.sprite = null;
            _quantityText.text = "";
        }
    }
}
