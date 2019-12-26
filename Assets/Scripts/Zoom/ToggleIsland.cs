using UnityEngine;

// Toggles activeness of island and region gameobjects.
public class ToggleIsland : MonoBehaviour
{
    public GameObject island;
    public GameObject regions;

    private bool isActive = true;

    void Start() => setActiveness();

    void Update() {
        if (PlayerPrefs.GetInt("toggle") == 1) {
            toggleActiveness();
            setActiveness();
            PlayerPrefs.SetInt("toggle", 0);
        }
    }

    private void toggleActiveness() => isActive = !isActive;

    private void setActiveness() {
        island.SetActive(isActive);
        regions.SetActive(!isActive);
    }
}
