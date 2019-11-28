using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string previousScene;
    public string nextScene;

    void Update() {
        if (PlayerPrefs.GetInt("loadPrev") > 0) {
            PlayerPrefs.SetInt("loadPrev", 0);
            SceneManager.LoadScene(previousScene);
        }
        if (PlayerPrefs.GetInt("loadNext") > 0) {
            PlayerPrefs.SetInt("loadNext", 0);
            SceneManager.LoadScene(nextScene);
        }
    }
}
