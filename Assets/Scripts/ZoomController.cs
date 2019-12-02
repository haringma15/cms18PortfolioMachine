using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public GameObject mapsl;
    public GameObject mainCamera;
    public int zoomDurationInFrames = 300;

    private Vector3 zoomPosition;
    private Vector3 neededMovement;
    private string zoomState = "isles";
    private int zoomDuration;
    private bool zooming = false;

    void Update() {
        if (zooming) {
            if (zoomDuration > 0) {
                mapsl.transform.position += neededMovement;
                mainCamera.transform.position += neededMovement;
                zoomDuration--;
            } else {
                zooming = false;
                PlayerPrefs.SetInt("zooming", 0);
            }
        }
        if (!zooming && zoomState == "isles" && PlayerPrefs.GetString("island") != "" && PlayerPrefs.GetInt("isMapslDragged") == 0) {
            zoomDuration = zoomDurationInFrames;
            zoomPosition = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("island"));
            neededMovement = new Vector3(zoomPosition.x - mapsl.transform.position.x, zoomPosition.y - mapsl.transform.position.y, zoomPosition.z - mapsl.transform.position.z);
            neededMovement = new Vector3(neededMovement.x / zoomDuration, neededMovement.y / zoomDuration, neededMovement.z / zoomDuration);
            zooming = true;
            PlayerPrefs.SetInt("toggleBig", 1);
            PlayerPrefs.SetInt("zooming", 1);
            zoomState = "regions";
        }
        if (!zooming && zoomState == "regions" && PlayerPrefs.GetString("regions") != "" && PlayerPrefs.GetInt("isMapslDragged") == 0) {
            zoomState = "spots";
        }
    }
}
