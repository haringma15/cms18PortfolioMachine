using System.Collections;
using UnityEngine;

// Stores Zoom position Mapsl will move to eventually.
public class ZoomStorage : MonoBehaviour
{
    public Hashtable zoomPositions = new Hashtable();

    void Start() => fillZoomPositions();

    private void fillZoomPositions() {
        zoomPositions.Add("InitMapsl", new Vector3(0, 0, -20));
        zoomPositions.Add("InitCam", new Vector3(0, 0, -30));
        zoomPositions.Add("InteractionIslandMapsl", new Vector3(-26.5f, 21.8f, 0));
        zoomPositions.Add("InteractionIslandCam", new Vector3(-10.2f, 8.4f, -10));
    }

    public Vector3 getZoomPosition(string zoomKey) => (Vector3)zoomPositions[zoomKey];
}
