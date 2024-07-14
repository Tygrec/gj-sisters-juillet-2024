using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipLocation : MonoBehaviour
{
    [SerializeField] Transform _lootTransform;
    [SerializeField] TextMeshProUGUI _availability;
    [SerializeField] TextMeshProUGUI _name;

    public void Display(AdventureManager adventure) {
        if (adventure.Available)
            _availability.text = "Disponible";
        else
            _availability.text = $"Revenez dans {adventure.DaysLeftToReset} jours";

        foreach (var lootable in adventure.lootables) {
            var img = Instantiate(Resources.Load<Image>("Prefabs/Image"), _lootTransform);
            img.sprite = Resources.Load<Sprite>($"Sprites/{lootable.name}");
        }

        _name.text = adventure.name;
    }

    public void Clear() {
        foreach (Transform child in _lootTransform) {
            Destroy(child.gameObject);
        }
    }

    private void Update() {
        transform.position = Input.mousePosition;
    }
}
