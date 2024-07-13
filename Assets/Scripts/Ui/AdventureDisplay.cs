using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdventureDisplay : MonoBehaviour
{
    [SerializeField] PreExploDisplay _preExplo;
    [SerializeField] PostExploDisplay _postExplo;
    [SerializeField] TextMeshProUGUI _adventureName;

    private AdventureManager _currentAdventure;

    public void DisplayPreExplo(AdventureManager aventure) {
        _currentAdventure = aventure;
        _preExplo.gameObject.SetActive(true);
        _postExplo.gameObject.SetActive(false);

        _preExplo.Display(aventure);
    }

    public void DisplayPostExplo() {
        _preExplo.Clear();
        _preExplo.gameObject.SetActive(false);
        _postExplo.gameObject.SetActive(true);

        GameManager.Instance.AddDays(_currentAdventure.nbDays);

        _postExplo.Display(_currentAdventure);
    }
    public void QuitDisplay() {
        GameManager.Instance.ChangeState(GameState.WORLDMAP);

        _postExplo.Clear();
        gameObject.SetActive(false);
    }
}
