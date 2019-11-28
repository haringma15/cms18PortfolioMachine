using UnityEngine;

public class Background : MonoBehaviour
{
    void OnCollisionEnter(Collision collider) {
        if (collider.gameObject.name == "Mapsl") 
            PlayerPrefs.SetInt("isMapslOutOfBounds", 1);
    }
}
