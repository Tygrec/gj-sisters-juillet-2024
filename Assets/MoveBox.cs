using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _nbDays;
    public void MoveToLocation() {
        UiManager.instance.MoveToLocation();
    }

    public void SetDays(int days) {
        _nbDays.text = days.ToString() + " jours";
    }
}
