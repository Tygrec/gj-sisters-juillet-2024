using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private void Awake() {
        instance = this;
    }

    public void MoveTo(LocationManager location) {
        _startPosition = transform.position;
        _endPosition = location.transform.position;

        float distance = Vector3.Distance(_startPosition, _endPosition);
        GameManager.Instance.AddDays((int)distance);

        StartCoroutine(I_MoveTo(location));

        
    }

    IEnumerator I_MoveTo(LocationManager location) {
        float elapsedTime = 0.0f;
        float travelTime = GameManager.Instance.TRAVEL_TIME;

        while (elapsedTime < travelTime) {
            float fraction = elapsedTime / travelTime;

            transform.position = Vector3.Lerp(_startPosition, _endPosition, fraction);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = _endPosition;

        if (location.gameObject.GetComponent<AventureManager>() != null) {
            UiManager.instance.DisplayAdventure(location.gameObject.GetComponent<AventureManager>());
        }
    }
}
