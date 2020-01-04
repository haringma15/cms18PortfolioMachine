using UnityEngine;

// Toggles activeness of init region 
public class ToggleInit : MonoBehaviour
{
    public GameObject initRegion;

    private bool isActive = false;

    void Start() => setActiveness();

    void Update() {
        if (PlayerPrefs.GetInt("toggleInit") == 1) {
            toggleActiveness();
            setActiveness();
            PlayerPrefs.SetInt("toggleInit", 0);
        }
    }

    private void toggleActiveness() => isActive = !isActive;
    private void setActiveness() => initRegion.SetActive(isActive);
}
