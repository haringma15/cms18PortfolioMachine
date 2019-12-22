using UnityEngine;

public class MapslController : MonoBehaviour
{
    public static Vector3 mapslMovement;

    private Vector3 startPosition;
    private Vector3 updatedPosition;

    void Start() => startPosition = transform.position;

    void Update() {
        updatedPosition = transform.position;
        mapslMovement = updatedPosition - startPosition;
        startPosition = updatedPosition;
    }

    public Vector3 getMapslMovement() => mapslMovement;
}
