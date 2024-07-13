using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LocationManager : MonoBehaviour {

    public int id;
    public GameObject virtualCamera;

    private void OnMouseDown() {
        if (GameManager.Instance.GameState != GameState.WORLDMAP || EventSystem.current.IsPointerOverGameObject())
            return;

        if (GameManager.Instance.CurrentLocationId == id && GetComponent<VillageManager>() != null) {
            UiManager.instance.DisplayVillage(GetComponent<VillageManager>());
            return;
        }

        if (GameManager.Instance.CurrentLocationId == id)
            return;

        UiManager.instance.DisplayMoveTextBox(this);
    }

    public void ActivateCamera() {
        virtualCamera.SetActive(true);
    }
    public void DeactivateCamera() {
        virtualCamera.SetActive(false);
    }
}
