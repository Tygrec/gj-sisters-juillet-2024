using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VillageDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI elevageNeed;
    [SerializeField] TextMeshProUGUI forgeNeed;
    [SerializeField] TextMeshProUGUI magieNeed;
    [SerializeField] TextMeshProUGUI villageName;
    [SerializeField] TextMeshProUGUI specializationText;
    [SerializeField] TextMeshProUGUI warEffortText;

    // POUR LA QUETE
    [SerializeField] Image rewardImage;
    [SerializeField] TextMeshProUGUI questText;
    [SerializeField] GameObject noQuest;

    [SerializeField] GameObject noSpe;
    [SerializeField] GameObject okSpe;

    [SerializeField] GameObject villageUIRoot;

    public void Display(VillageManager village) {
        villageUIRoot.SetActive(true);

        villageName.text = village.Name;

        bool isSpecialized = village.Specialization != Specialization.None;

        noSpe.SetActive(!isSpecialized);
        okSpe.SetActive(isSpecialized);

        if (!isSpecialized) {
            elevageNeed.text = $"�levage : {village.NeedForSpec[ItemType.Nourriture]} nourriture ({village.CurrentInventory[ItemType.Nourriture]} / {village.NeedForSpec[ItemType.Nourriture]})";
            forgeNeed.text = $"Forge : {village.NeedForSpec[ItemType.Metal]} m�tal ({village.CurrentInventory[ItemType.Metal]} / {village.NeedForSpec[ItemType.Metal]})";
            magieNeed.text = $"Magie : {village.NeedForSpec[ItemType.Magie]} magie ({village.CurrentInventory[ItemType.Magie]} / {village.NeedForSpec[ItemType.Magie]})";
        }
        else {
            specializationText.text = village.Specialization.ToString();
            warEffortText.text = "Effort de guerre total : " + village.GetWarEffort().ToString();
        }

        noQuest.SetActive(village.quest == null);

        if (village.quest != null) {
            rewardImage.sprite = Resources.Load<Sprite>($"Sprites/{village.quest.Reward}");
            questText.text = $"Qu�te\n" +
                $"Les villageois ont besoin de {village.quest.Quantity} {village.quest.Item}.\n" +
                $"En �change, ils fourniront un {village.quest.Reward}.";
        }
    }

    public void QuitDisplay() {
        GameManager.Instance.ChangeState(GameState.WORLDMAP);
        villageUIRoot.SetActive(false);
    }
}
