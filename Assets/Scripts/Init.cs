using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    public string firstSceneName = "Map";

    void Awake() {
        resetPlayerPrefs();
        SceneManager.LoadScene(firstSceneName);
    }

    private void resetPlayerPrefs(){
        PlayerPrefs.SetInt("isMapslDragged", 0);
        PlayerPrefs.SetInt("toggleBig", 0);
        PlayerPrefs.SetInt("toggleSmall", 0);
        PlayerPrefs.SetInt("zooming", 0);
        PlayerPrefs.SetInt("zoomOut", 0);
        PlayerPrefs.SetInt("destroyProject", 0);
        PlayerPrefs.SetString("island", "");
        PlayerPrefs.SetString("region", "");
        PlayerPrefs.SetString("project", "");
    }
}
