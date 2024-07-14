using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureManager : MonoBehaviour
{
    [SerializeField] public List<Item> lootables;
    [SerializeField] public int nbDaysToDo;
    [SerializeField] public int nbDaysToReset;

    public bool Available = true;
    public int DaysLeftToReset;


    private void Start() {
        GameManager.Instance.OnDayPass += HandleDayPass;
        DaysLeftToReset = nbDaysToReset;
    }

    public void HandleDayPass() {
        if (Available)
            return;

        DaysLeftToReset--;

        if (DaysLeftToReset <= 0) {
            DaysLeftToReset = nbDaysToReset;
            Available = true;
        }


    }
}
