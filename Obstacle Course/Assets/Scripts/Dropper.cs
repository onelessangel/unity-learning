using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody rigidbody;
    float timeElapsed;
    [SerializeField] float timeToWait;

    void SetTimeToWait() {
        switch(gameObject.tag) {
            case "1C":
                timeToWait = 9f;
                break;
            case "2C":
                timeToWait = 14f;
                break;
            case "3C":
                timeToWait = 11f;
                break;
            case "4C":
                timeToWait = 19f;
                break;
            case "5C":
                timeToWait = 18f;
                break;
            case "6C":
                timeToWait = 21F;
                break;
            case "7C":
                timeToWait = 22F;
                break;
            case "8C":
                timeToWait = 24F;
                break;
            default:
                timeToWait = 0;
                break;
        }
    }

    // Start is called before the first frame update
    void Start() {
        // caching a reference
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();

        renderer.enabled = false;
        rigidbody.useGravity = false;
        SetTimeToWait();
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
