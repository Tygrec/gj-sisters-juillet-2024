using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipDisplay : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemType;
    [SerializeField] TextMeshProUGUI itemDescription;

    public void Display(Item item) {
        if (item == null)
            return;

        itemName.text = item.name;
        itemImage.sprite = Resources.Load<Sprite>($"Sprites/{item.name}");
        itemType.text = $"Type : {item.Type}\n" +
            $"Valeur : {item.value}";

        GetComponent<UnityEngine.UI.Outline>().effectColor = FromRarity.GetColor(item.Rarity);
        itemName.color = FromRarity.GetColor(item.Rarity);
    }

    private void Update() {
        transform.position = Input.mousePosition;
    }
}
