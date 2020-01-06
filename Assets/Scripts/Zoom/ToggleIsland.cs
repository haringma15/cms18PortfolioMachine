using UnityEngine;

// Toggles activeness of island and region gameobjects: true = overview, false = details
public class ToggleIsland : MonoBehaviour
{
    public string islandName;
    public GameObject island;
    public GameObject regions;

    void Start() => toggleIslandActiveness(true);

    void Update() {
        if (PlayerPrefs.GetInt("toggle") == 1) {
            if (PlayerPrefs.GetString("island") == islandName) {
                toggleIslandActiveness(false);
                PlayerPrefs.SetInt("toggle", 0);
            }
            if (PlayerPrefs.GetString("island") == "") {
                if (!island.activeInHierarchy) {
                    toggleIslandActiveness(true);
                    PlayerPrefs.SetInt("toggle", 0);
                }
            }
        }
    }
    
    private void toggleIslandActiveness(bool islandActive) {
        island.SetActive(islandActive);
        regions.SetActive(!islandActive);
    }
}
