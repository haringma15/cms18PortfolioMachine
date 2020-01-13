using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public GameObject mapsl;
    public GameObject mapslHead;
    public GameObject mainCamera;
    public float cameraOffset = -15;
    public int zoomDurationInFrames = 60;

    private Vector3 zoomPosition;
    private Vector3 neededMapslMovement;
    private Vector3 neededCamMovement;
    private string zoomState = "isles";
    private int zoomDuration;

    void Update() {
        // Zoom
        if (PlayerPrefs.GetInt("zooming") == 1) {
            if (zoomDuration > 0) {
                mapsl.transform.position += neededMapslMovement;
                mainCamera.transform.localPosition += neededCamMovement;
                zoomDuration--;
            } else {
                // after zooming, set UI active or adjust mapsl and cam position
                if (PlayerPrefs.GetString("region") != "") {
                    PlayerPrefs.SetInt("toggleUI", 1); 
                } else {
                    mapsl.transform.position = zoomPosition;
                    mainCamera.transform.localPosition = zoomPosition + new Vector3(0, 0, cameraOffset);
                }
                PlayerPrefs.SetInt("zooming", 0);
            }
        }

        // Zoom into island
        if (PlayerPrefs.GetInt("zooming") == 0 && zoomState == "isles" && PlayerPrefs.GetString("island") != "" && PlayerPrefs.GetInt("isMapslDragged") == 0) {
            zoomDuration = zoomDurationInFrames;
            zoomPosition = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("island"));
            neededMapslMovement = new Vector3(zoomPosition.x - mapsl.transform.position.x, zoomPosition.y - mapsl.transform.position.y, zoomPosition.z - mapsl.transform.position.z);
            neededMapslMovement = new Vector3(neededMapslMovement.x / zoomDuration, neededMapslMovement.y / zoomDuration, neededMapslMovement.z / zoomDuration);
            neededCamMovement = new Vector3(zoomPosition.x - mainCamera.transform.localPosition.x, zoomPosition.y - mainCamera.transform.localPosition.y, zoomPosition.z - mainCamera.transform.localPosition.z + cameraOffset);
            neededCamMovement = new Vector3(neededCamMovement.x / zoomDuration, neededCamMovement.y / zoomDuration, neededCamMovement.z / zoomDuration);
            PlayerPrefs.SetInt("toggle", 1);
            PlayerPrefs.SetInt("toggleInit", 1);
            PlayerPrefs.SetInt("zooming", 1);
            zoomState = "regions";
        }

        // Zoom into mapsl
        if (PlayerPrefs.GetInt("zooming") == 0 && zoomState == "regions" && PlayerPrefs.GetString("region") != "" && PlayerPrefs.GetInt("isMapslDragged") == 0) {
            zoomDuration = zoomDurationInFrames;
            zoomPosition = mapslHead.transform.position;
            neededMapslMovement = Vector3.zero;
            neededCamMovement = new Vector3(zoomPosition.x - mainCamera.transform.position.x, zoomPosition.y - mainCamera.transform.position.y, zoomPosition.z - mainCamera.transform.position.z);
            neededCamMovement = new Vector3(neededCamMovement.x / zoomDuration, neededCamMovement.y / zoomDuration, neededCamMovement.z / zoomDuration);
            PlayerPrefs.SetInt("zooming", 1);
            zoomState = "projects";
        }

        // Zoom out of portfolio
        if (PlayerPrefs.GetInt("zooming") == 0 && zoomState == "projects" && PlayerPrefs.GetInt("zoomOut") != 0) {
            zoomDuration = zoomDurationInFrames;
            zoomPosition = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("island"));
            neededMapslMovement = new Vector3(zoomPosition.x - mapsl.transform.position.x, zoomPosition.y - mapsl.transform.position.y, zoomPosition.z - mapsl.transform.position.z);
            neededMapslMovement = new Vector3(neededMapslMovement.x / zoomDuration, neededMapslMovement.y / zoomDuration, neededMapslMovement.z / zoomDuration);
            neededCamMovement = new Vector3(zoomPosition.x - mainCamera.transform.localPosition.x, zoomPosition.y - mainCamera.transform.localPosition.y, zoomPosition.z - mainCamera.transform.localPosition.z + cameraOffset);
            neededCamMovement = new Vector3(neededCamMovement.x / zoomDuration, neededCamMovement.y / zoomDuration, neededCamMovement.z / zoomDuration);
            PlayerPrefs.SetInt("toggleUI", 1);
            PlayerPrefs.SetInt("zoomOut", 0);
            PlayerPrefs.SetString("region", "");
            PlayerPrefs.SetInt("zooming", 1);
            zoomState = "regions";
        }

        // Zoom out of island
        if (PlayerPrefs.GetInt("zooming") == 0 && zoomState == "regions" && PlayerPrefs.GetInt("zoomOut") != 0) {
            zoomDuration = zoomDurationInFrames;
            zoomPosition = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("island"));
            neededMapslMovement = new Vector3(zoomPosition.x - mapsl.transform.position.x, zoomPosition.y - mapsl.transform.position.y, zoomPosition.z - mapsl.transform.position.z);
            neededMapslMovement = new Vector3(neededMapslMovement.x / zoomDuration, neededMapslMovement.y / zoomDuration, neededMapslMovement.z / zoomDuration);
            neededCamMovement = new Vector3(zoomPosition.x - mainCamera.transform.localPosition.x, zoomPosition.y - mainCamera.transform.localPosition.y, zoomPosition.z - mainCamera.transform.localPosition.z + cameraOffset);
            neededCamMovement = new Vector3(neededCamMovement.x / zoomDuration, neededCamMovement.y / zoomDuration, neededCamMovement.z / zoomDuration);
            PlayerPrefs.SetInt("zoomOut", 0);
            PlayerPrefs.SetString("island", "");
            PlayerPrefs.SetInt("toggle", 1);
            PlayerPrefs.SetInt("toggleInit", 1);
            PlayerPrefs.SetInt("zooming", 1);
            zoomState = "isles";
        }

        // Reset everything
        if (PlayerPrefs.GetString("island") == "Init" || Input.GetKeyUp(KeyCode.Escape)) {
            PlayerPrefs.SetString("region", "");
            PlayerPrefs.SetString("island", "Init");
            PlayerPrefs.SetInt("zoomOut", 1);
        }
    }
}
