using UnityEngine;

// Moves the camera along with Mapsl
public class CameraFocus : MonoBehaviour
{
    public GameObject mapsl;

    private Vector3 movement;
    private Vector3 nextPos;

    void Update() {
        if (PlayerPrefs.GetInt("zooming") == 0) {
            movement = mapsl.GetComponent<MapslController>().getMapslMovement();
            transform.position += new Vector3(movement.x / 2, movement.y, movement.z / 2);
        }
    }
}
