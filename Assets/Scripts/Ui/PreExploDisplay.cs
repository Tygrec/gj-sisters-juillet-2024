using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreExploDisplay : MonoBehaviour
{
    [SerializeField] Transform lootableTransform;
    public void Display(AventureManager aventure) {
        foreach (var item in aventure.lootables) {
            Image image = Instantiate(Resources.Load<Image>("Prefabs/Image"), lootableTransform);
            image.sprite = Resources.Load<Sprite>($"Sprites/{item.name}");
        }
    }
}
