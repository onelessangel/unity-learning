using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    // Update is called once per frame
    void Update() {
        CheckExitGame();
    }

    static void CheckExitGame() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("You've hit ESCAPE!");
            Debug.Log("Over and Out!");

            Application.Quit();
        }
    }
}
