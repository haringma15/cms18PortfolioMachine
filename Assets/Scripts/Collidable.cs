using UnityEngine;

public class Collidable : MonoBehaviour
{
    void OnCollisionEnter(Collision collider) {
        if (collider.gameObject.name == "Mapsl") {
            PlayerPrefs.SetString(tag, name);
            PlayerPrefs.SetInt("loadNext", 1);
        }
    }
}
