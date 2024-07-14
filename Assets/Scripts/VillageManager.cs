using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Specialization {
    None,
    Forge,
    Elevage,
    Magie
}
public class VillageManager : MonoBehaviour {

    public Dictionary<ItemType, int> NeedForSpec = new Dictionary<ItemType, int>();
    public Dictionary<ItemType, int> CurrentInventory = new Dictionary<ItemType, int>();
    public Specialization Specialization = Specialization.None;

    [SerializeField] GameObject ElevageGraphics;
    [SerializeField] GameObject MagieGraphics;
    [SerializeField] GameObject ForgeGraphics;

    [SerializeField] TextMeshProUGUI NameCanvas;
    [SerializeField] TextMeshProUGUI NeedCanvas;

    [SerializeField] public Quest quest; 

    private int warEffort = 0;
    public string Name;

    public int GetWarEffort() {
        return warEffort;
    }

    private void Start() {
        foreach (ItemType itemType in Enum.GetValues(typeof(ItemType))) {
            NeedForSpec.Add(itemType, UnityEngine.Random.Range(GameManager.Instance.MIN_ITEM_FOR_SPEC, GameManager.Instance.MAX_ITEM_FOR_SPEC));
            CurrentInventory.Add(itemType, 0);
        }
    }

    private void OnMouseEnter() {
        if (GetComponent<LocationManager>().AlreadyVisited) {
            NeedCanvas.transform.parent.gameObject.SetActive(true);
            NeedCanvas.text = $"Nourriture : {CurrentInventory[ItemType.Nourriture]}/{NeedForSpec[ItemType.Nourriture]}\n\n" +
                $"Métal : {CurrentInventory[ItemType.Metal]}/{NeedForSpec[ItemType.Metal]}\n\n" +
                $"Magie : {CurrentInventory[ItemType.Magie]}/{NeedForSpec[ItemType.Magie]}";
        }
        else
            NeedCanvas.transform.parent.gameObject.SetActive(false);

        NameCanvas.transform.parent.gameObject.SetActive(true);
        NameCanvas.text = Name;
    }
    private void OnMouseExit() {
        NameCanvas.transform.parent.gameObject.SetActive(false);
        NeedCanvas.transform.parent.gameObject.SetActive(false);
    }
    public void AddItemToVillageInventory(Item item, int quantity) {
        CurrentInventory[item.Type] += quantity * item.value;

        if (CurrentInventory[item.Type] >= NeedForSpec[item.Type]) {
            SpecializeVillage(item.Type);
        }
    }

    private void SpecializeVillage(ItemType type) {
        if (type == ItemType.Nourriture) {
            Specialization = Specialization.Elevage;
            warEffort = GameManager.Instance.ELEVAGE_VALUE;
            ElevageGraphics.SetActive(true);
        }
        else if (type == ItemType.Metal) {
            Specialization = Specialization.Forge;
            warEffort = GameManager.Instance.FORGE_VALUE;
            ForgeGraphics.SetActive(true);
        }
        else if (type == ItemType.Magie) {
            Specialization = Specialization.Magie;
            warEffort = GameManager.Instance.MAGIE_VALUE;
            MagieGraphics.SetActive(true);
        }

        UiManager.instance.DisplayVillage(this);
    }
}
