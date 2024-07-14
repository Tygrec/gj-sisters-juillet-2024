using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] HudDisplay _hudDisplay;

    [SerializeField] AdventureDisplay _adventureDisplay;
    [SerializeField] VillageDisplay _villageDisplay;
    [SerializeField] InventoryDisplay _inventoryDisplay;

    [SerializeField] TooltipDisplay _tooltipDisplay;

    private LocationManager _currentLocation;
    private GameObject _moveBox;

    private void Awake() {
        instance = this;
    }

    public void DisplayMoveTextBox(LocationManager location) {
        if (_moveBox != null) {
            Destroy(_moveBox);
        }

        _currentLocation = location;
        _moveBox = Instantiate(Resources.Load<GameObject>("Prefabs/MoveBox"), transform);
        _moveBox.transform.position = Input.mousePosition;
    }

    public void MoveToLocation() {
        if (GameManager.Instance.CurrentLocationId == _currentLocation.id)
            return;

        PlayerController.instance.MoveTo(_currentLocation);

        Destroy(_moveBox);
    }

    private void Update() {
        _hudDisplay.Display();
    }

    public void DisplayAdventure(AdventureManager adventure) {
        _adventureDisplay.gameObject.SetActive(true);
        _adventureDisplay.DisplayPreExplo(adventure);

        _inventoryDisplay.Display();
    }

    public void DisplayVillage(VillageManager village) {
        _villageDisplay.gameObject.SetActive(true);
        _villageDisplay.Display(village);
        
        _inventoryDisplay.Display();
    }

    public void DisplayInventory() {
        _inventoryDisplay.Display();
    }

    public void DisplayTooltip(Item item) {
        _tooltipDisplay.gameObject.SetActive(true);
        _tooltipDisplay.Display(item);
    }
    public void HideTooltip() {
        _tooltipDisplay?.gameObject.SetActive(false);
    }

}
