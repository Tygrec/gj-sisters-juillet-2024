using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudDisplay : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI daysLeft;
    [SerializeField] TMPro.TextMeshProUGUI currentFA;
    [SerializeField] TMPro.TextMeshProUGUI ennemyFA;

    public void Display() {
        daysLeft.text = "Jours restants : " + GameManager.Instance.GetDaysLeft().ToString();
        currentFA.text = "Forces armées : " + GameManager.Instance.GetCurrentFA().ToString();
        ennemyFA.text = "Forces ennemies : " + GameManager.Instance.ENNEMY_FA.ToString();
    }
}
