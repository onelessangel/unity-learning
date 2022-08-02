using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    float xAngle = 0;
    float yAngle = 0;
    float zAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        switch(gameObject.tag) {
            case "LSpinner":
                yAngle = -1f;
                break;
            case "RSpinner":
                yAngle = 1f;
                break;
        }
    }

    // Update is called once per frame
    void Update() {
        
        transform.Rotate(xAngle, yAngle, zAngle);
    }
}
