using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float reloadDelay = 2.5f;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip successAudio;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) {
        if (isTransitioning) {
            return;
        }

        switch (other.gameObject.tag) {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
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
