using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public GameObject mapsl;
    public GameObject mainCamera;
    public int zoomDurationInFrames = 200;

    private Vector3 zoomPosition;
    private Vector3 neededMapslMovement;
    private Vector3 neededCamMovement;
    private Vector3 neededCamRotation;
    private string zoomState = "isles";
    private int zoomDuration;

    void Update() {
        if (PlayerPrefs.GetInt("zooming") == 1) {
            if (zoomDuration > 0) {
                mapsl.transform.position += neededMapslMovement;
                mainCamera.transform.position += neededCamMovement;
                mainCamera.transform.Rotate(neededCamRotation);
                zoomDuration--;
            } else {
                PlayerPrefs.SetInt("zooming", 0);
            }
        }
        if (PlayerPrefs.GetInt("zooming") == 0 && zoomState == "isles" && PlayerPrefs.GetString("island") != "" && PlayerPrefs.GetInt("isMapslDragged") == 0) {
            zoomDuration = zoomDurationInFrames;
            zoomPosition = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("island"));
            neededMapslMovement = new Vector3(zoomPosition.x - mapsl.transform.position.x, zoomPosition.y - mapsl.transform.position.y, zoomPosition.z - mapsl.transform.position.z);
            neededMapslMovement = new Vector3(neededMapslMovement.x / zoomDuration, neededMapslMovement.y / zoomDuration, neededMapslMovement.z / zoomDuration);
            neededCamMovement = new Vector3(zoomPosition.x - mainCamera.transform.position.x, zoomPosition.y - mainCamera.transform.position.y + 10, zoomPosition.z - mainCamera.transform.position.z);
            neededCamMovement = new Vector3(neededCamMovement.x / zoomDuration, neededCamMovement.y / zoomDuration, neededCamMovement.z / zoomDuration);
            neededCamRotation = new Vector3(0, 0, 0);
            PlayerPrefs.SetInt("toggleBig", 1);
            PlayerPrefs.SetInt("zooming", 1);
            zoomState = "regions";
        }
        if (PlayerPrefs.GetInt("zooming") == 0 && zoomState == "regions" && PlayerPrefs.GetString("region") != "" && PlayerPrefs.GetInt("isMapslDragged") == 0) {
            zoomDuration = zoomDurationInFrames;
            zoomPosition = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("region"));
            neededMapslMovement = new Vector3(zoomPosition.x - mapsl.transform.position.x, zoomPosition.y - mapsl.transform.position.y, zoomPosition.z - mapsl.transform.position.z);
            neededMapslMovement = new Vector3(neededMapslMovement.x / zoomDuration, neededMapslMovement.y / zoomDuration, neededMapslMovement.z / zoomDuration);
            neededCamMovement = new Vector3(zoomPosition.x - mainCamera.transform.position.x, zoomPosition.y - mainCamera.transform.position.y, zoomPosition.z - mainCamera.transform.position.z);
            neededCamMovement = new Vector3(neededCamMovement.x / zoomDuration, neededCamMovement.y / zoomDuration, neededCamMovement.z / zoomDuration);
            neededCamRotation = new Vector3(90f / zoomDuration * -1, 0, 0);
            PlayerPrefs.SetInt("toggleSmall", 1);
            PlayerPrefs.SetInt("zooming", 1);
            zoomState = "projects";
        }
        if (PlayerPrefs.GetInt("zooming") == 0 && zoomState == "projects" && PlayerPrefs.GetInt("zoomOut") != 0) {
            zoomDuration = zoomDurationInFrames;
            zoomPosition = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("island"));
            neededMapslMovement = new Vector3(zoomPosition.x - mapsl.transform.position.x, zoomPosition.y - mapsl.transform.position.y, zoomPosition.z - mapsl.transform.position.z);
            neededMapslMovement = new Vector3(neededMapslMovement.x / zoomDuration, neededMapslMovement.y / zoomDuration, neededMapslMovement.z / zoomDuration);
            neededCamMovement = new Vector3(zoomPosition.x - mainCamera.transform.position.x, zoomPosition.y - mainCamera.transform.position.y + 10, zoomPosition.z - mainCamera.transform.position.z);
            neededCamMovement = new Vector3(neededCamMovement.x / zoomDuration, neededCamMovement.y / zoomDuration, neededCamMovement.z / zoomDuration);
            neededCamRotation = new Vector3(90 / zoomDuration, 0, 0);
            PlayerPrefs.SetInt("zoomOut", 0);
            PlayerPrefs.SetString("region", "");
            PlayerPrefs.SetInt("toggleSmall", 1);
            PlayerPrefs.SetInt("zooming", 1);
            zoomState = "regions";
        }
        if (PlayerPrefs.GetInt("zooming") == 0 && zoomState == "regions" && PlayerPrefs.GetInt("zoomOut") != 0) {
            zoomDuration = zoomDurationInFrames;
            zoomPosition = GetComponent<ZoomStorage>().getZoomPosition("Init");
            neededMapslMovement = new Vector3(zoomPosition.x - mapsl.transform.position.x, zoomPosition.y - mapsl.transform.position.y, zoomPosition.z - mapsl.transform.position.z);
            neededMapslMovement = new Vector3(neededMapslMovement.x / zoomDuration, neededMapslMovement.y / zoomDuration, neededMapslMovement.z / zoomDuration);
            neededCamMovement = new Vector3(zoomPosition.x - mainCamera.transform.position.x, zoomPosition.y - mainCamera.transform.position.y + 10, zoomPosition.z - mainCamera.transform.position.z);
            neededCamMovement = new Vector3(neededCamMovement.x / zoomDuration, neededCamMovement.y / zoomDuration, neededCamMovement.z / zoomDuration);
            neededCamRotation = new Vector3(0, 0, 0);
            PlayerPrefs.SetInt("zoomOut", 0);
            PlayerPrefs.SetString("island", "");
            PlayerPrefs.SetInt("toggleBig", 1);
            PlayerPrefs.SetInt("zooming", 1);
            zoomState = "isles";
        }
        if (Input.GetKeyUp(KeyCode.Escape)) PlayerPrefs.SetInt("zoomOut", 1);
    }
}
