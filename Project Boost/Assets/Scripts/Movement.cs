using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables

    float mainThrust = 1000f;
    float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngineAudio;

    Rigidbody rb;
    AudioSource audioSource;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            // Debug.Log("Pressed SPACE - Thrusting");
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

            if (!audioSource.isPlaying) {
                audioSource.PlayOneShot(mainEngineAudio);
            }
        } else {
            audioSource.Stop();
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A)) {
            // Debug.Log("rotate left");
            ApplyRotation(rotationThrust);
        } else if (Input.GetKey(KeyCode.D)) {
            // Debug.Log("rotate right");
            ApplyRotation(-rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame) {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
