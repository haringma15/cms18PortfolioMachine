using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public GameObject mapsl;
    public GameObject mainCamera;
    public int zoomDurationInFrames = 200;

    private Vector3 zoomPositionMapsl;
    private Vector3 zoomPositionCam;
    private Vector3 neededMapslMovement;
    private Vector3 neededCamMovement;
    private string zoomState = "isles";
    private int zoomDuration;

    void Update() {
        // Zoom
        if (PlayerPrefs.GetInt("zooming") == 1) {
            if (zoomDuration > 0) {
                mapsl.transform.position += neededMapslMovement;
                mainCamera.transform.position += neededCamMovement;
                zoomDuration--;
            } else {
                if (PlayerPrefs.GetString("region") != "") PlayerPrefs.SetInt("toggleUI", 1);
                mapsl.transform.position = zoomPositionMapsl;
                mainCamera.transform.position = zoomPositionCam;
                PlayerPrefs.SetInt("zooming", 0);
            }
        }

        // Zoom into island
        if (PlayerPrefs.GetInt("zooming") == 0 && zoomState == "isles" && PlayerPrefs.GetString("island") != "" && PlayerPrefs.GetInt("isMapslDragged") == 0) {
            zoomDuration = zoomDurationInFrames;
            zoomPositionMapsl = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("island")+"Mapsl");
            zoomPositionCam = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("island")+"Cam");
            neededMapslMovement = new Vector3(zoomPositionMapsl.x - mapsl.transform.position.x, zoomPositionMapsl.y - mapsl.transform.position.y, zoomPositionMapsl.z - mapsl.transform.position.z);
            neededMapslMovement = new Vector3(neededMapslMovement.x / zoomDuration, neededMapslMovement.y / zoomDuration, neededMapslMovement.z / zoomDuration);
            neededCamMovement = new Vector3(zoomPositionCam.x - mainCamera.transform.position.x, zoomPositionCam.y - mainCamera.transform.position.y, zoomPositionCam.z - mainCamera.transform.position.z);
            neededCamMovement = new Vector3(neededCamMovement.x / zoomDuration, neededCamMovement.y / zoomDuration, neededCamMovement.z / zoomDuration);
            PlayerPrefs.SetInt("toggle", 1);
            PlayerPrefs.SetInt("toggleInit", 1);
            PlayerPrefs.SetInt("zooming", 1);
            zoomState = "regions";
        }

        // Zoom into region, soon to be redone
        if (PlayerPrefs.GetInt("zooming") == 0 && zoomState == "regions" && PlayerPrefs.GetString("region") != "" && PlayerPrefs.GetInt("isMapslDragged") == 0) {
            zoomDuration = zoomDurationInFrames;
            zoomPositionMapsl = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("region")+"Mapsl");
            zoomPositionCam = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("region")+"Cam");
            neededMapslMovement = new Vector3(zoomPositionMapsl.x - mapsl.transform.position.x, zoomPositionMapsl.y - mapsl.transform.position.y, zoomPositionMapsl.z - mapsl.transform.position.z);
            neededMapslMovement = new Vector3(neededMapslMovement.x / zoomDuration, neededMapslMovement.y / zoomDuration, neededMapslMovement.z / zoomDuration);
            neededCamMovement = new Vector3(zoomPositionCam.x - mainCamera.transform.position.x, zoomPositionCam.y - mainCamera.transform.position.y, zoomPositionCam.z - mainCamera.transform.position.z);
            neededCamMovement = new Vector3(neededCamMovement.x / zoomDuration, neededCamMovement.y / zoomDuration, neededCamMovement.z / zoomDuration);
            PlayerPrefs.SetInt("zooming", 1);
            zoomState = "projects";
        }

        // Zoom out of portfolio
        if (PlayerPrefs.GetInt("zooming") == 0 && zoomState == "projects" && PlayerPrefs.GetInt("zoomOut") != 0) {
            zoomDuration = zoomDurationInFrames;
            zoomPositionMapsl = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("island")+"Mapsl");
            zoomPositionCam = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("island")+"Cam");
            neededMapslMovement = new Vector3(zoomPositionMapsl.x - mapsl.transform.position.x, zoomPositionMapsl.y - mapsl.transform.position.y, zoomPositionMapsl.z - mapsl.transform.position.z);
            neededMapslMovement = new Vector3(neededMapslMovement.x / zoomDuration, neededMapslMovement.y / zoomDuration, neededMapslMovement.z / zoomDuration);
            neededCamMovement = new Vector3(zoomPositionCam.x - mainCamera.transform.position.x, zoomPositionCam.y - mainCamera.transform.position.y, zoomPositionCam.z - mainCamera.transform.position.z);
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
            zoomPositionMapsl = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("island")+"Mapsl");
            zoomPositionCam = GetComponent<ZoomStorage>().getZoomPosition(PlayerPrefs.GetString("island")+"Cam");
            neededMapslMovement = new Vector3(zoomPositionMapsl.x - mapsl.transform.position.x, zoomPositionMapsl.y - mapsl.transform.position.y, zoomPositionMapsl.z - mapsl.transform.position.z);
            neededMapslMovement = new Vector3(neededMapslMovement.x / zoomDuration, neededMapslMovement.y / zoomDuration, neededMapslMovement.z / zoomDuration);
            neededCamMovement = new Vector3(zoomPositionCam.x - mainCamera.transform.position.x, zoomPositionCam.y - mainCamera.transform.position.y, zoomPositionCam.z - mainCamera.transform.position.z);
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
