using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Vector3 _startPosition;
    private Vector3 _endPosition;

    [SerializeField] GameObject _graphics;
    [SerializeField] Animator _animator;

    public CameraController camera;

    private void Awake() {
        instance = this;
    }

    public void MoveTo(LocationManager location) {
        // Tourner le joueur en direction de la location
        Vector3 direction = location.transform.position - transform.position;

        // Calculer la rotation cible
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Appliquer instantanément la rotation cible
        transform.rotation = targetRotation;

        _startPosition = transform.position;
        _endPosition = location.transform.position;

        float distance = location.GetNbDaysFromPlayer();

        for (int i = 0; i < distance; i++)
            GameManager.Instance.AddDay();

        _animator.SetBool("running", true);

        StartCoroutine(I_MoveTo(location));
    }

    IEnumerator I_MoveTo(LocationManager location) {
        float elapsedTime = 0.0f;
        float travelTime = Vector3.Distance(_startPosition, _endPosition) / 100;

        while (elapsedTime < travelTime) {
            float fraction = elapsedTime / travelTime;

            transform.position = Vector3.Lerp(_startPosition, _endPosition, fraction);
            camera.transform.position = transform.position;

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = _endPosition;

        GameManager.Instance.EnterLocation(location);

        if (location.gameObject.GetComponent<AdventureManager>() != null) {
            UiManager.instance.DisplayAdventure(location.gameObject.GetComponent<AdventureManager>());
        }
        else if (location.gameObject.GetComponent<VillageManager>() != null) {
            UiManager.instance.DisplayVillage(location.gameObject.GetComponent<VillageManager>());
        }

        _animator.SetBool("running", false);
    }

    public void ShowPlayer(bool show) {
        _graphics.SetActive(show);
    }
}
