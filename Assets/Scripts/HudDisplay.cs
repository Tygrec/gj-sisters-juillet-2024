using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI daysLeft;
    [SerializeField] TextMeshProUGUI currentFA;

    public void Display() {
        daysLeft.text = "Jours restants : " + GameManager.Instance.GetDaysLeft().ToString();
        currentFA.text = "Forces arm�es : " + GameManager.Instance.GetCurrentFA().ToString();
    }
}
