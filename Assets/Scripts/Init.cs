using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    public string firstSceneName = "Map0";
    void Awake() {
        resetPlayerPrefs();
        SceneManager.LoadScene(firstSceneName);
    }

    private void resetPlayerPrefs(){
        PlayerPrefs.SetInt("isMapslDragged", 0);
        PlayerPrefs.SetInt("isMapslOutOfBounds", 0);
        PlayerPrefs.SetInt("loadNext", 0);
        PlayerPrefs.SetInt("loadPrev", 0);
        PlayerPrefs.SetString("island", "");
        PlayerPrefs.SetString("region", "");
        PlayerPrefs.SetString("spot", "");
    }
}
