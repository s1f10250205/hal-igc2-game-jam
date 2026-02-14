using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public SceneChange sceneChange;
    void OnTriggerEnter2D(Collider2D other) {
        sceneChange.EventHandler();
    }
}
