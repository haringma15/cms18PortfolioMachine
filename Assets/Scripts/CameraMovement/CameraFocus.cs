using UnityEngine;

// Moves the camera along with Mapsl
public class CameraFocus : MonoBehaviour
{
    public GameObject mapsl;

    private Vector3 movement;

    void Update() {
        if (PlayerPrefs.GetInt("zooming") == 0) {
            movement = mapsl.GetComponent<MapslController>().getMapslMovement();
            transform.position += new Vector3(movement.x / 1.5f, movement.y / 1.5f, 0);
        }
    }
}
