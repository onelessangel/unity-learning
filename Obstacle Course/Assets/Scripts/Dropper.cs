using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody rigidbody;
    float timeElapsed;
    [SerializeField] float timeToWait = 3f;

    // Start is called before the first frame update
    void Start() {
        // caching a reference
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();

        renderer.enabled = false;
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update() {
        timeElapsed = Time.time;

        if (timeElapsed > timeToWait) {
            renderer.enabled = true;
            rigidbody.useGravity = true;
        }
    }
}
