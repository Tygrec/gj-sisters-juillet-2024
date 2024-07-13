using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
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

    public void AddItemToVillageInventory(Item item, int quantity) {
        CurrentInventory[item.Type] += quantity * item.value;

        if (CurrentInventory[item.Type] >= NeedForSpec[item.Type]) {
            SpecializeVillage(item.Type);
        }
    }

    private void SpecializeVillage(ItemType type) {
        if (type == ItemType.Nourriture) {
            Specialization = Specialization.Elevage;
            warEffort = GameManager.Instance.ELEVAGE_VALUE * (GameManager.Instance.GetDaysLeft() / GameManager.Instance.PRODUCTION_EVERY_X_DAYS);
            ElevageGraphics.SetActive(true);
        }
        else if (type == ItemType.Metal) {
            Specialization = Specialization.Forge;
            warEffort = GameManager.Instance.FORGE_VALUE * (GameManager.Instance.GetDaysLeft() / GameManager.Instance.PRODUCTION_EVERY_X_DAYS);
            ForgeGraphics.SetActive(true);
        }
        else if (type == ItemType.Magie) {
            Specialization = Specialization.Magie;
            warEffort = GameManager.Instance.MAGIE_VALUE * (GameManager.Instance.GetDaysLeft() / GameManager.Instance.PRODUCTION_EVERY_X_DAYS);
            MagieGraphics.SetActive(true);
        }

        UiManager.instance.DisplayVillage(this);
    }
}
