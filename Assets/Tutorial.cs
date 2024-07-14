using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TUTO_STATE {
    TUTO1,
    TUTO2, 
    TUTO3, 
    TUTO4,
    TUTO5
}
public class Tutorial : MonoBehaviour
{
    [SerializeField] List<GameObject> _tutorials;
    TUTO_STATE STATE = TUTO_STATE.TUTO1;

    private void Start() {
        GameManager.Instance.GameState = GameState.TUTORIAL;

    }

    public void ProcessTutorial() {
        Destroy(_tutorials[(int)STATE]);
        STATE++;
        _tutorials[(int)STATE].SetActive(true);
    }

    public void EndTuto() {
        GameManager.Instance.GameState = GameState.WORLDMAP;
        Destroy(gameObject);
    }
}
