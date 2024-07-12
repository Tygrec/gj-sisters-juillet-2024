using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] GameObject _moveTextBox;
    [SerializeField] TextMeshProUGUI _moveTextBoxText;

    private void Awake() {
        instance = this;
    }

    public void DisplayMoveTextBox(LocationManager location) {
        _moveTextBox.SetActive(true);
        _moveTextBoxText.text = "Voulez-vous vous rendre à " + location.name + " ?";
    }
}
