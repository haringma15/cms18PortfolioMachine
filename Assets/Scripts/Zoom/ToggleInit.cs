using UnityEngine;

// Toggles activeness of init island and region 
public class ToggleInit : MonoBehaviour
{
    public GameObject island;
    public GameObject regions;

    private bool isActive = true;

    void Start() => setActiveness();

    void Update() {
        if (PlayerPrefs.GetInt("toggleInit") == 1) {
            toggleActiveness();
            setActiveness();
            PlayerPrefs.SetInt("toggleInit", 0);
        }
    }

    private void toggleActiveness() => isActive = !isActive;

    private void setActiveness() {
        island.SetActive(isActive);
        regions.SetActive(!isActive);
    }
}
