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
    [SerializeField] TooltipLocation _tooltipLocation;

    private LocationManager _currentLocation;
    private MoveBox _moveBox;

    private void Awake() {
        instance = this;
    }

    public void DisplayMoveTextBox(LocationManager location) {
        if (_moveBox != null) {
            Destroy(_moveBox.gameObject);
        }

        _currentLocation = location;
        _moveBox = Instantiate(Resources.Load<MoveBox>("Prefabs/MoveBox"), transform);
        _moveBox.transform.position = Input.mousePosition;
        _moveBox.SetDays(location.GetNbDaysFromPlayer());
    }

    public void MoveToLocation() {
        PlayerController.instance.MoveTo(_currentLocation);

        Destroy(_moveBox.gameObject);
    }

    private void Update() {
        _hudDisplay.Display();
    }

    public void DisplayAdventure(AdventureManager adventure) {
        _adventureDisplay.gameObject.SetActive(true);

        if (adventure.Available)
            _adventureDisplay.DisplayPreExplo(adventure);
        else
            _adventureDisplay.DisplayNotAvailable(adventure);

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

    public void DisplayTooltipLocation(AdventureManager adventure) {
        _tooltipLocation.gameObject.SetActive(true);
        _tooltipLocation.Display(adventure);
    }
    public void ClearTooltipLocation() {
        _tooltipLocation.gameObject.SetActive(false);
        _tooltipLocation.Clear();
    }

}
