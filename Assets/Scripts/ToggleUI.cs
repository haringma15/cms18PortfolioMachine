using UnityEngine;

// Controls activeness of the UI that displays a project.
public class ToggleUI : MonoBehaviour
{
    public GameObject UI;

    void Update(){
        if (PlayerPrefs.GetString("project") != "") UI.SetActive(true);
        else UI.SetActive(false);
    }
}
