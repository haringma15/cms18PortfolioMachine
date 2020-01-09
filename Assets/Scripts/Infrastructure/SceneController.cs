using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update() {
        if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene("Main");
        if (Input.GetKey(KeyCode.Q)) Application.Quit();
    }
}
