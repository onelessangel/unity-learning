using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        // Debug.Log("You've hit a wall!");

        try {
            if (other.gameObject.tag == "Player") {
                GetComponent<MeshRenderer>().material.color = Color.red;
                gameObject.tag = "Hit";
            }            
        } catch (Exception e) {
            Debug.Log(e);
        }
    }
}
