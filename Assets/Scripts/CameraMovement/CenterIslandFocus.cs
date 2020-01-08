using UnityEngine;

// Moves the camera along with Mapsl
public class CenterIslandFocus : MonoBehaviour
{
    public GameObject mapsl;

    private Vector3 movement;

    void Update() {
        movement = mapsl.GetComponent<MapslController>().getMapslMovement();
        transform.position += new Vector3(movement.x / 6f, movement.y / 6f, movement.z / 3f);
    }
}
