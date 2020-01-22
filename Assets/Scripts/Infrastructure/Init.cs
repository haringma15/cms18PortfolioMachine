using UnityEngine;

public class Init : MonoBehaviour
{
    void Awake() {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        resetPlayerPrefs();
    } 

    void Update() {
        if (Application.targetFrameRate > 60) Application.targetFrameRate = 60;
    }

    private void resetPlayerPrefs() {
        PlayerPrefs.SetInt("isMapslDragged", 0);

        // zoom related
        PlayerPrefs.SetInt("toggle", 0);
        PlayerPrefs.SetInt("toggleInit", 0);
        PlayerPrefs.SetInt("toggleUI", 0);
        PlayerPrefs.SetInt("zooming", 0);
        PlayerPrefs.SetInt("zoomOut", 0);
        PlayerPrefs.SetString("island", "");
        PlayerPrefs.SetString("region", "");

        // sound related
        PlayerPrefs.SetInt("playMapslPickUpSound", 0);
        PlayerPrefs.SetInt("playMapslDropSound", 0);
        PlayerPrefs.SetInt("playMapslLandingSound", 0);
        PlayerPrefs.SetInt("playIslandHoverSound", 0);
        PlayerPrefs.SetInt("playRegionHoverSound", 0);
        PlayerPrefs.SetInt("playButtonClickSound", 0);
    }
}
