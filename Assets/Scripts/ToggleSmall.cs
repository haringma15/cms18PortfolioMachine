using UnityEngine;

// Toggles activeness of spot gameobjects in a region.
public class ToggleSmall : MonoBehaviour
{
    public GameObject projects;

    private bool isActive = false;

    void Start() => setActiveness();

    void Update() {
        if (PlayerPrefs.GetInt("toggleSmall") == 1) {
            toggleActiveness();
            setActiveness();
            PlayerPrefs.SetInt("toggleSmall", 0);
        }
    }

    private void toggleActiveness() => isActive = !isActive;
    private void setActiveness() =>  projects.SetActive(isActive);
}
