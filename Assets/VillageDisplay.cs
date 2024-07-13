using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VillageDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI elevageNeed;
    [SerializeField] TextMeshProUGUI forgeNeed;
    [SerializeField] TextMeshProUGUI magieNeed;
    [SerializeField] TextMeshProUGUI villageName;

    public void Display(VillageManager village) {
        villageName.text = village.Name;
        
        elevageNeed.text = $"Élevage : {village.NeedForSpec[ItemType.Nourriture]} nourriture ({village.CurrentInventory[ItemType.Nourriture]} / {village.NeedForSpec[ItemType.Nourriture]})";
        forgeNeed.text = $"Forge : {village.NeedForSpec[ItemType.Metal]} métal ({village.CurrentInventory[ItemType.Metal]} / {village.NeedForSpec[ItemType.Metal]})";
        magieNeed.text = $"Magie : {village.NeedForSpec[ItemType.Magie]} magie ({village.CurrentInventory[ItemType.Magie]} / {village.NeedForSpec[ItemType.Magie]})";
    }
}
