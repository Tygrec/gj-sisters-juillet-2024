using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Vitesse de d�placement de la cam�ra

    void Update() {
        // Lire les entr�es clavier
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.Z)) {
            moveVertical = 1f;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveVertical = -1f;
        }
        if (Input.GetKey(KeyCode.Q)) {
            moveHorizontal = -1f;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveHorizontal = 1f;
        }

        // Calculer le d�placement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed * Time.deltaTime;

        // Appliquer le d�placement
        transform.Translate(movement, Space.World);
    }
}
