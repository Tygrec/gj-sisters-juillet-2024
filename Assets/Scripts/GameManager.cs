using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [SerializeField] private int MAX_DAYS;
    [SerializeField] public float TRAVEL_TIME;
    [SerializeField] public float INVENTORY_SIZE;

    private int _daysUsed;
    [SerializeField] private List<VillageManager> _villages;

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
        
    }
}
