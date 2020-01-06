using System.Collections;
using UnityEngine;

// Stores Zoom position Mapsl will move to eventually.
public class ZoomStorage : MonoBehaviour
{
    public Hashtable zoomPositions = new Hashtable();

    void Start() => fillZoomPositions();

    private void fillZoomPositions() {
        zoomPositions.Add("Init", new Vector3(0, 0, -20));
        zoomPositions.Add("InteractionIsland", new Vector3(-10.2f, 8.7f, 0));
        zoomPositions.Add("CommunicationIsland", new Vector3(10.2f, -4.6f, 0));
    }

    public Vector3 getZoomPosition(string zoomKey) => (Vector3)zoomPositions[zoomKey];
}
