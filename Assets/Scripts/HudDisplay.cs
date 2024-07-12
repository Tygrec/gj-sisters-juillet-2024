using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudDisplay : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI daysLeft;
    [SerializeField] TMPro.TextMeshProUGUI currentFA;

    public void Display() {
        daysLeft.text = "Jours restants : " + GameManager.Instance.GetDaysLeft().ToString();
        currentFA.text = "Forces arm�es : " + GameManager.Instance.GetCurrentFA().ToString();
    }
}
