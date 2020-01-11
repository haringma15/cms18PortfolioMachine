using System.Collections;
using UnityEngine;

// Stores Zoom position Mapsl will move to eventually.
public class ZoomStorage : MonoBehaviour
{
    public Hashtable zoomPositions = new Hashtable();

    void Start() => fillZoomPositions();

    private void fillZoomPositions() {
        zoomPositions.Add("Init", new Vector3(0, 0, -35));
        zoomPositions.Add("InteractionIsland", new Vector3(-11.9f, 17.8f, 2));
        zoomPositions.Add("CommunicationIsland", new Vector3(4f, -7.3f, -9));
        zoomPositions.Add("SoundIsland", new Vector3(-20.2f, -1.3f, -10));
        zoomPositions.Add("MediaIsland", new Vector3(23.2f, 7.7f, -2));
    }

    public Vector3 getZoomPosition(string zoomKey) => (Vector3)zoomPositions[zoomKey];
}
