using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private void Awake() {
        instance = this;
    }

    public void MoveTo(Vector3 position) {
        _startPosition = transform.position;
        _endPosition = position;

        float distance = Vector3.Distance(_startPosition, _endPosition);
        GameManager.Instance.AddDays((int)distance);

        StartCoroutine(I_MoveTo());
    }

    IEnumerator I_MoveTo() {
        float elapsedTime = 0.0f;
        float travelTime = GameManager.Instance.TRAVEL_TIME;

        while (elapsedTime < travelTime) {
            float fraction = elapsedTime / travelTime;

            transform.position = Vector3.Lerp(_startPosition, _endPosition, fraction);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = _endPosition;
    }
}
