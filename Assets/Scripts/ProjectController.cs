using UnityEngine;

public class ProjectController : MonoBehaviour
{
    void OnMouseDown() {
        PlayerPrefs.SetString("project", name);
    }
}
