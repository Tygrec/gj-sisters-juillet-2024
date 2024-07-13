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

    private int _daysUsed;
    [SerializeField] private Transform _villagesTransform;
    [SerializeField] private List<VillageManager> _villages = new List<VillageManager>();

    public int GetDaysLeft() {
        return MAX_DAYS - _daysUsed;
    }
    public void AddDays(int days) {
        _daysUsed += days;
    }
    public int GetCurrentFA() {
        int fa = 0;
        
        foreach (var village in _villages) {
            fa += village.GetFA();
        }

        return fa;
    }

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        foreach(Transform village in _villagesTransform) {
            _villages.Add(village.GetComponent<VillageManager>());
        }
    }

    public void ChangeState(GameState newState) {
        GameState = newState;
    }
}