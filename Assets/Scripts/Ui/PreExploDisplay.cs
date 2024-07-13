using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreExploDisplay : MonoBehaviour
{
    [SerializeField] Transform lootableTransform;
    [SerializeField] TextMeshProUGUI nbDaysText;
    public void Display(AdventureManager adventure) {

        nbDaysText.text = $"Il vous faudra {adventure.nbDays} jours pour explorer cet endroit.";
        foreach (var item in adventure.lootables) {
            Image image = Instantiate(Resources.Load<Image>("Prefabs/Image"), lootableTransform);
            image.sprite = Resources.Load<Sprite>($"Sprites/{item.name}");
        }
    }

    public void Clear() {
        foreach (Transform transform in lootableTransform) {
            Destroy(transform.gameObject);
        }
    }
}
