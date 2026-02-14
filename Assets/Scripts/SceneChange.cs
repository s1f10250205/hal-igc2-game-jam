using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string targetScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void EventHandler() {
        SceneManager.LoadScene(targetScene);
    }
}
