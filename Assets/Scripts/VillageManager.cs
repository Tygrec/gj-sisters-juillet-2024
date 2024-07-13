using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public enum Specialization {
    Forge,
    Elevage,
    Magie
}
public class VillageManager : MonoBehaviour {

    public Dictionary<ItemType, int> NeedForSpec = new Dictionary<ItemType, int>();
    public Dictionary<ItemType, int> CurrentInventory = new Dictionary<ItemType, int>();
    private int warEffort = 0;
    public string Name;

    public int GetFA() {
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
        print("Ce village est spécialisé en " + type);
    }
}
