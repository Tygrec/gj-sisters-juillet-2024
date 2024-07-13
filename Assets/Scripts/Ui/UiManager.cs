using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] GameObject _moveTextBox;
    [SerializeField] TMPro.TextMeshProUGUI _moveTextBoxText;
    [SerializeField] HudDisplay _hudDisplay;
    [SerializeField] AdventureDisplay _adventureDisplay;
    [SerializeField] VillageDisplay _villageDisplay;

    private LocationManager _currentLocation;

    private void Awake() {
        instance = this;
    }

    public void DisplayMoveTextBox(LocationManager location) {
        _currentLocation = location;
        _moveTextBox.SetActive(true);
        _moveTextBoxText.text = "Voulez-vous vous rendre à " + location.name + " ?";
    }

    public void MoveToLocation() {
        PlayerController.instance.MoveTo(_currentLocation);
    }

    private void Update() {
        _hudDisplay.Display();
    }

    public void DisplayAdventure(AdventureManager adventure) {
        _adventureDisplay.gameObject.SetActive(true);
        _adventureDisplay.DisplayPreExplo(adventure);
    }

    public void DisplayVillage(VillageManager village) {
        _villageDisplay.gameObject.SetActive(true);
        _villageDisplay.Display(village);
    }
}
