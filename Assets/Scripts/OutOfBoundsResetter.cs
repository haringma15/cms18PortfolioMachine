using UnityEngine;

public class OutOfBoundsResetter : MonoBehaviour
{
    public GameObject mapsl;
    public GameObject cam;

    private Vector3 mapslSpawnPosition;
    private Vector3 camSpawnPosition;

    void Start() {
        mapslSpawnPosition = mapsl.transform.position;
        camSpawnPosition = cam.transform.position;
    }

    void Update() {
        if (PlayerPrefs.GetInt("isMapslOutOfBounds") > 0) {
            mapsl.transform.position = mapslSpawnPosition;
            cam.transform.position = camSpawnPosition;
            PlayerPrefs.SetInt("isMapslOutOfBounds", 0);
        }
    }
}
