using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float reloadDelay = 2.5f;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip successAudio;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    [SerializeField] ParticleSystem mainBoosterParticles;
    [SerializeField] ParticleSystem leftThrustersFrontParticles;
    [SerializeField] ParticleSystem leftThrustersBackParticles;
    [SerializeField] ParticleSystem rightThrustersFrontParticles;
    [SerializeField] ParticleSystem rightThrustersBackParticles;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys() {
        if (Input.GetKey(KeyCode.L)) {
            LoadNextLevel();
        } else if (Input.GetKey(KeyCode.C)) {
            collisionDisabled = !collisionDisabled;   // toggle collision
        }
    }

    void OnCollisionEnter(Collision other) {
        StopEngineParticles();

        if (isTransitioning || collisionDisabled) {
            return;
        }

        switch (other.gameObject.tag) {
            case "Friendly":
                Debug.Log("Ready, Set, GO!");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StopEngineParticles() {
        mainBoosterParticles.Stop();

        leftThrustersFrontParticles.Stop();
        leftThrustersBackParticles.Stop();

        rightThrustersFrontParticles.Stop();
        rightThrustersBackParticles.Stop();
    }

    private void StartSuccessSequence() {
        isTransitioning = true;

        audioSource.Stop();
        audioSource.PlayOneShot(successAudio);

        successParticles.Play();

        GetComponent<Movement>().enabled = false;   // disabling player control after crashing
        delayReload("LoadNextLevel");
    }

    private void StartCrashSequence() {
        isTransitioning = true;

        audioSource.Stop();
        audioSource.PlayOneShot(crashAudio);

        crashParticles.Play();

        GetComponent<Movement>().enabled = false;   // disabling player control after crashing
        delayReload("ReloadLevel");
    }

    private void ReloadLevel() {
        int currentSceneIndex = getCurrentSceneIndex();
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadNextLevel() {
        int currentSceneIndex = getCurrentSceneIndex();
        int nextSceneIndex = ++currentSceneIndex;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    private int getCurrentSceneIndex() {
        return SceneManager.GetActiveScene().buildIndex;
    }

    private void delayReload(string method) {
        Invoke(method, reloadDelay);
    }
}
