using UnityEngine;

// Moves the camera along with Mapsl
public class CameraFocus : MonoBehaviour
{
    public GameObject mapsl;
    public float xLimit = 4f;
    public float zLimit = 4f;

    private Vector3 movement;
    private Vector3 nextPos;

    void Update() {
        if (PlayerPrefs.GetInt("zooming") == 0) {
            movement = mapsl.GetComponent<MapslController>().getMapslMovement();
            nextPos = transform.position + movement;

            if (nextPos.x < xLimit && nextPos.x > -xLimit && nextPos.z < zLimit && nextPos.z > -zLimit) 
                transform.position += new Vector3(movement.x / 2, movement.y, movement.z / 2);
        }
    }
}
