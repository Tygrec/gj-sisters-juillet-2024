using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour {

    public int id;
    private void OnMouseDown() {
        if (GameManager.Instance.GameState != GameState.WORLDMAP)
            return;
        
        if (GameManager.Instance.CurrentLocationId == id)
            return;

        UiManager.instance.DisplayMoveTextBox(this);
    }
}
