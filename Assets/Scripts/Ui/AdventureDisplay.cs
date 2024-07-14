using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdventureDisplay : MonoBehaviour
{
    [SerializeField] PreExploDisplay _preExplo;
    [SerializeField] PostExploDisplay _postExplo;
    [SerializeField] TextMeshProUGUI _notAvailable;

    [SerializeField] TextMeshProUGUI _adventureName;

    private AdventureManager _currentAdventure;

    public void DisplayNotAvailable(AdventureManager adventure) {
        _notAvailable.gameObject.SetActive(true);
        _preExplo.gameObject.SetActive(false);
        _postExplo.gameObject.SetActive(false);

        _notAvailable.text = $"Vous pourrez à nouveau explorer cet endroit dans {adventure.nbDaysToReset} jours.";
    }

    public void DisplayPreExplo(AdventureManager adventure) {
        _adventureName.text = adventure.name;
        _currentAdventure = adventure;
        _preExplo.gameObject.SetActive(true);
        _postExplo.gameObject.SetActive(false);
    //    _notAvailable.gameObject.SetActive(false);

        _preExplo.Display(adventure);
    }

    public void DisplayPostExplo() {
        _preExplo.Clear();
        _preExplo.gameObject.SetActive(false);
    //    _notAvailable.gameObject.SetActive(false);
        _postExplo.gameObject.SetActive(true);

        for (int i = 0; i < _currentAdventure.nbDaysToDo; i++)
            GameManager.Instance.AddDay();

        _postExplo.Display(_currentAdventure);
    }

    public void QuitDisplay() {
        GameManager.Instance.ChangeState(GameState.WORLDMAP);

        _postExplo.Clear();
        gameObject.SetActive(false);
    }
}
