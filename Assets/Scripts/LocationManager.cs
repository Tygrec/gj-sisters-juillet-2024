using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LocationManager : MonoBehaviour {

    public int id;
    public GameObject virtualCamera;
    public bool AlreadyVisited = false;

    [SerializeField] Transform Canvas;

    public int GetNbDaysFromPlayer() {
        var distance = Vector3.Distance(PlayerController.instance.transform.position, transform.position);
        return (int)distance / 10;
    }

    private void OnMouseDown() {
        if (GameManager.Instance.GameState != GameState.WORLDMAP || EventSystem.current.IsPointerOverGameObject())
            return;

        if (GameManager.Instance.CurrentLocationId == id && GetComponent<VillageManager>() != null) {
            UiManager.instance.DisplayVillage(GetComponent<VillageManager>());
            return;
        }

        if (GameManager.Instance.CurrentLocationId == id && GetComponent<AdventureManager>() != null) {
            UiManager.instance.DisplayAdventure(GetComponent<AdventureManager>());
            return;
        }
        
        UiManager.instance.DisplayMoveTextBox(this);
    }

    private void OnMouseEnter() {
        if (!AlreadyVisited || EventSystem.current.IsPointerOverGameObject() || GameManager.Instance.GameState != GameState.WORLDMAP)
            return;

     
        if (GetComponent<AdventureManager>() != null) {
            UiManager.instance.DisplayTooltipLocation(GetComponent<AdventureManager>());
        }
    }

    private void OnMouseExit() {
        UiManager.instance.ClearTooltipLocation();
    }

    public void ActivateCamera() {
        virtualCamera.SetActive(true);
    }
    public void DeactivateCamera() {
        virtualCamera.SetActive(false);
    }
}
