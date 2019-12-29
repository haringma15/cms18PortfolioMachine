using UnityEngine;

// Controls activeness of the UI that displays a project.
public class ToggleUI : MonoBehaviour
{
    public GameObject UI;

    void Update(){
        if (PlayerPrefs.GetInt("toggleUI") != 0) {
            UI.SetActive(true);
            PlayerPrefs.SetInt("toggleUI", 0);
        }
        else if (PlayerPrefs.GetString("region") == "" && PlayerPrefs.GetInt("destroyProject") == 0) UI.SetActive(false);
    }
}
