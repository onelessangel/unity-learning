using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    MeshRenderer renderer;
    MeshRenderer[] childrenRenderers;

    

    void Start() {
        renderer = GetComponent<MeshRenderer>();
        childrenRenderers = GetComponentsInChildren<MeshRenderer>();
        // children = GetComponentsInChildren<Transform>(); 
    }

    private void OnCollisionEnter(Collision other) {
        // Debug.Log("You've hit a wall!");

        try {
            if (other.gameObject.tag == "Player") {        
                renderer.material.color = Color.red;
                gameObject.tag = "Hit";

                foreach (MeshRenderer mr in childrenRenderers) {
                    mr.material.color = Color.red;
                }
            } 
        } catch (Exception e) {
            Debug.Log(e);
        }
    }
}
