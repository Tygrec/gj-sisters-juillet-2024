using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureDisplay : MonoBehaviour
{
    [SerializeField] PreExploDisplay _preExplo;
    [SerializeField] PostExploDisplay _postExplo;

    private AventureManager _currentAventure;

    public void DisplayPreExplo(AventureManager aventure) {
        _currentAventure = aventure;
        _preExplo.gameObject.SetActive(true);
        _postExplo.gameObject.SetActive(false);

        _preExplo.Display(aventure);
    }

    public void DisplayPostExplo() {
        _preExplo.gameObject.SetActive(false);
        _postExplo.gameObject.SetActive(true);

        _postExplo.Display(_currentAventure);
    }
}
