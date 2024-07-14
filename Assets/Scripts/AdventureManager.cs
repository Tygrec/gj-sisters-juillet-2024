using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdventureManager : MonoBehaviour
{
    [SerializeField] public List<Item> lootables;
    [SerializeField] public int nbDaysToDo;
    [SerializeField] public int nbDaysToReset;

    [SerializeField] TextMeshProUGUI NameCanvas;

    public bool Available = true;
    public int DaysLeftToReset;


    private void Start() {
        GameManager.Instance.OnDayPass += HandleDayPass;
        DaysLeftToReset = nbDaysToReset;
    }
    private void OnMouseEnter() {
        if (GetComponent<LocationManager>().AlreadyVisited)
            return;

        NameCanvas.transform.parent.gameObject.SetActive(true);
        NameCanvas.text = gameObject.name;
    }
    private void OnMouseExit() {
        if (GetComponent<LocationManager>().AlreadyVisited)
            return;

        NameCanvas.transform.parent.gameObject.SetActive(false);
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

    public void MakeAdventureUnavailable() {
        Available = false;
        DaysLeftToReset = nbDaysToReset;
    }
}
