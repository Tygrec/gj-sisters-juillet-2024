using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;  // Vitesse de déplacement de la caméra
    public float zoomSpeed = 2f;       // Vitesse de zoom de la caméra
    public float minZoom = 5f;         // Limite minimale de zoom
    public float maxZoom = 100f;        // Limite maximale de zoom

    void Update() {
        // Lire les entrées clavier
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.W)) {
            moveVertical = 1f;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveVertical = -1f;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveHorizontal = -1f;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveHorizontal = 1f;
        }

        // Calculer le déplacement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed * Time.deltaTime;

        // Appliquer le déplacement
        transform.Translate(movement, Space.World);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float newFieldOfView = Camera.main.fieldOfView - scroll * zoomSpeed;
        Camera.main.fieldOfView = Mathf.Clamp(newFieldOfView, minZoom, maxZoom);
    }
}
