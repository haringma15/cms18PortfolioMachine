using UnityEngine;

public class ProjectDestroyer : MonoBehaviour
{
    void Update() {
        if (PlayerPrefs.GetInt("destroyProject") == 1) {
            PlayerPrefs.SetInt("destroyProject", 0);
            Destroy(this.gameObject);
        }
    }
}
