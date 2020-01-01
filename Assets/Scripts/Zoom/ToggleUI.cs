using UnityEngine;

// Controls activeness of the UI that displays a project.
public class ToggleUI : MonoBehaviour
{
    public GameObject UI;

    private bool active = false;

    void Start() => UI.SetActive(active);

    void Update(){
        if (PlayerPrefs.GetInt("toggleUI") != 0) {
            active = !active;
            UI.SetActive(active);
            PlayerPrefs.SetInt("toggleUI", 0);
        }
    }
}
