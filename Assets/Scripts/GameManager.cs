using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    WORLDMAP,
    ADVENTURE,
    VILLAGE
}
public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public GameState GameState = GameState.WORLDMAP;

    [SerializeField] private int MAX_DAYS;
    [SerializeField] public float TRAVEL_TIME;
    [SerializeField] public float INVENTORY_SIZE;
    [SerializeField] public int MAX_ITEM_FOR_SPEC;
    [SerializeField] public int MIN_ITEM_FOR_SPEC;
    [SerializeField] public int FORGE_VALUE;
    [SerializeField] public int ELEVAGE_VALUE;
    [SerializeField] public int MAGIE_VALUE;
    [SerializeField] public int PRODUCTION_EVERY_X_DAYS;

    private int _daysUsed;
    [SerializeField] private Transform _adventuresTransform;
    [SerializeField] private Transform _villagesTransform;
    [SerializeField] private List<VillageManager> _villages = new List<VillageManager>();

    public Dictionary<Item, int> PlayerInventory = new Dictionary<Item, int>();

    public int CurrentLocationId = -1;
    public VillageManager CurrentVillage = null;

    public int GetDaysLeft() {
        return MAX_DAYS - _daysUsed;
    }
    public void AddDays(int days) {
        _daysUsed += days;
    }
    public int GetCurrentFA() {
        int fa = 0;
        
        foreach (var village in _villages) {
            fa += village.GetWarEffort();
        }

        return fa;
    }

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        int i = 0;
        foreach (Transform village in _villagesTransform) {
            _villages.Add(village.GetComponent<VillageManager>());
            village.GetComponent<LocationManager>().id = i;
            i++;
        }

        foreach (Transform adventure in _adventuresTransform) {
            adventure.GetComponent<LocationManager>().id = i;
            i++;
        }

        ChangeState(GameState.WORLDMAP);
    }

    public void ChangeState(GameState newState) {
        GameState = newState;

        if (newState == GameState.WORLDMAP) {
            SoundManager.Instance.Play("018-Field01");
        } else if (newState == GameState.VILLAGE) {
            SoundManager.Instance.Play("029-Town07");
        } else if (newState == GameState.ADVENTURE) {
            SoundManager.Instance.Play("035-Dungeon01");
        }
    }

    public void AddItemToInventory(Item item, int quantity) {
        if (PlayerInventory.ContainsKey(item)) {
            PlayerInventory[item] += quantity;
        }
        else { 
            PlayerInventory.Add(item, quantity);
        }

        UiManager.instance.DisplayInventory();
    }

    public void RemoveItemFromInventory(Item item, int quantity) {
        PlayerInventory[item] -= quantity;

        if(PlayerInventory[item] <= 0) {
            PlayerInventory.Remove(item);
        }

     //   UiManager.instance.DisplayInventory();
    }
}