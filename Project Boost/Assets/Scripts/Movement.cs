using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables

    float mainThrust = 1000f;
    float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngineAudio;

    [SerializeField] ParticleSystem mainBoosterParticles;
    [SerializeField] ParticleSystem leftThrustersFrontParticles;
    [SerializeField] ParticleSystem leftThrustersBackParticles;
    [SerializeField] ParticleSystem rightThrustersFrontParticles;
    [SerializeField] ParticleSystem rightThrustersBackParticles;

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
            StartThrusting();
        } else {
            StopThrusting();
        }
    }

    private void StartThrusting() {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(mainEngineAudio);
        }

        if (!mainBoosterParticles.isPlaying) {
            mainBoosterParticles.Play();
        }
    }

    private void StopThrusting() {
        audioSource.Stop();
        mainBoosterParticles.Stop();
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A)) {
            RotateLeft();
        } else if (Input.GetKey(KeyCode.D)) {
            RotateRight();
        }
    }

    private void RotateLeft() {
        ApplyRotation(rotationThrust);

        mainBoosterParticles.Stop();
        leftThrustersFrontParticles.Stop();
        leftThrustersBackParticles.Stop();

        if (!rightThrustersFrontParticles.isPlaying) {
            rightThrustersFrontParticles.Play();
        }
        
        if (!rightThrustersBackParticles.isPlaying) {
            rightThrustersBackParticles.Play();
        }
    }

    private void RotateRight() {
        ApplyRotation(-rotationThrust);

        mainBoosterParticles.Stop();
        rightThrustersFrontParticles.Stop();
        rightThrustersBackParticles.Stop();

        if (!leftThrustersFrontParticles.isPlaying) {
            leftThrustersFrontParticles.Play();
        }

        if (!leftThrustersBackParticles.isPlaying) {
            leftThrustersBackParticles.Play();
        }
    }

    private void ApplyRotation(float rotationThisFrame) {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
