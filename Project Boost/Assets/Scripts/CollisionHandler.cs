using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
       switch (other.gameObject.tag) {
        case "Friendly":
            Debug.Log("This thing is friendly");
            break;
        case "Finish":
            Debug.Log("Congrats! You finished!");
            break;
        default:
            ReloadLevel();
            break;
        }
    }

    private static void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
