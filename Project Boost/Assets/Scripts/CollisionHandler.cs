using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float reloadDelay = 2f;

    void OnCollisionEnter(Collision other) {
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
        GetComponent<Movement>().enabled = false;   // disabling player control after crashing
        delayReload("LoadNextLevel");
    }

    private void StartCrashSequence() {
        // TODO add SFX upon crash
        // TODO add particle effect upon crash
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
