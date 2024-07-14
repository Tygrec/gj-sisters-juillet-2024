using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum InventoryType {
    Adventure,
    Player
}

public class Slot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public InventoryType inventoryType;
    [SerializeField] TextMeshProUGUI _quantityText;
    [SerializeField] Image _itemImage;
    public Item Item = null;
    int _quantity = 0;

    public int GetQuantity() {
        return _quantity;
    }

    private void Awake() {
        _quantityText.text = "0";
    }

    public void DisplayItem(Item item, int quantity) {
        _itemImage.gameObject.SetActive(true);
        _quantityText.transform.parent.gameObject.SetActive(true);
        Item = item;
        _quantity = quantity;
        _itemImage.sprite = Resources.Load<Sprite>($"Sprites/{item.name}");
        _quantityText.text = _quantity.ToString();
    }

    public void Clear() {
        this.Item = null;
        _quantity = 0;
        _quantityText.transform.parent.gameObject.SetActive(false);
        _itemImage.sprite = null;
        _itemImage.gameObject.SetActive(false);
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
                PutItemInPlayerInventory();
            }
        }

        if (GameManager.Instance.GameState == GameState.VILLAGE && inventoryType == InventoryType.Player && GameManager.Instance.CurrentVillage.Specialization == Specialization.None) {

            if (Input.GetMouseButtonDown(0)) {
                GameManager.Instance.CurrentVillage.AddItemToVillageInventory(Item, 1);
                GameManager.Instance.RemoveItemFromInventory(Item, 1);
            }
            else if (Input.GetMouseButtonDown(1)) {
                GameManager.Instance.CurrentVillage.AddItemToVillageInventory(Item, _quantity);
                GameManager.Instance.RemoveItemFromInventory(Item, _quantity);
            }
            
            if (!GameManager.Instance.PlayerInventory.ContainsKey(Item))
                _quantity = 0;
            else
                _quantity = GameManager.Instance.PlayerInventory[Item];

            UiManager.instance.DisplayVillage(GameManager.Instance.CurrentVillage);
        }

        UiManager.instance.DisplayInventory();
        _quantityText.text = _quantity.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        UiManager.instance.DisplayTooltip(Item);
    }

    public void OnPointerExit(PointerEventData eventData) {
        UiManager.instance.HideTooltip();
    }
    public void PutItemInPlayerInventory() {
        GameManager.Instance.AddItemToInventory(Item, _quantity);
        _quantity = 0;

        UiManager.instance.DisplayInventory();
        _quantityText.text = _quantity.ToString();
    }
}
