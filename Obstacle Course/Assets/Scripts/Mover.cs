using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start() {
        // transform.Translate(1, 0, 0);   // add to initial position
        PrintInstructions();
    }

    // Update is called once per frame
    void Update() {
        MovePlayer();
    }

    void PrintInstructions() {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arrow keys");
        Debug.Log("Don't hit the walls!");
    }

    void MovePlayer() {
        float xValue = -Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; // a-d
        float zValue = -Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;   // w-s

        transform.Translate(xValue, 0, zValue);
    }
}
