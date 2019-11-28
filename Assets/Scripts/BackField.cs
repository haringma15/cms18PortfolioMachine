using UnityEngine;

public class BackField : MonoBehaviour
{
    void OnCollisionEnter(Collision collider) {
        if (collider.gameObject.name == "Mapsl") PlayerPrefs.SetInt("loadPrev", 1);
    }
}
