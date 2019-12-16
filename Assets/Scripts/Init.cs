using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    void Awake() => resetPlayerPrefs();

    private void resetPlayerPrefs() {
        PlayerPrefs.SetInt("isMapslDragged", 0);
        PlayerPrefs.SetInt("toggle", 0);
        PlayerPrefs.SetInt("zooming", 0);
        PlayerPrefs.SetInt("zoomOut", 0);
        PlayerPrefs.SetInt("destroyProject", 0);
        PlayerPrefs.SetString("island", "");
        PlayerPrefs.SetString("region", "");
    }
}
