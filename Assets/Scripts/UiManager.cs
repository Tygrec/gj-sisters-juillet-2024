using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] GameObject _moveTextBox;
    [SerializeField] TMPro.TextMeshProUGUI _moveTextBoxText;
    [SerializeField] HudDisplay _hudDisplay;

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
        PlayerController.instance.MoveTo(_currentLocation.transform.position);
    }

    private void Update() {
        _hudDisplay.Display();
    }
}
