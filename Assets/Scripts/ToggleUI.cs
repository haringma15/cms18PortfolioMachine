using UnityEngine;

// Controls activeness of the UI that displays a project.
public class ToggleUI : MonoBehaviour
{
    public GameObject UI;

    void Update(){
        if (PlayerPrefs.GetString("project") != "") UI.SetActive(true);
        else if (PlayerPrefs.GetString("project") == "" && PlayerPrefs.GetInt("destroyProject") == 0) UI.SetActive(false);
    }
}
