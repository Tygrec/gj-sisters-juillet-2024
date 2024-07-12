using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    private void OnMouseDown() {
        UiManager.instance.DisplayMoveTextBox(this);
    }
}
