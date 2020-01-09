using System.Collections;
using UnityEngine;

// Stores Zoom position Mapsl will move to eventually.
public class ZoomStorage : MonoBehaviour
{
    public Hashtable zoomPositions = new Hashtable();

    void Start() => fillZoomPositions();

    private void fillZoomPositions() {
        zoomPositions.Add("Init", new Vector3(0, 0, -35));
        zoomPositions.Add("InteractionIsland", new Vector3(-9, 18, 2));
        zoomPositions.Add("CommunicationIsland", new Vector3(3.75f, -7.5f, -12));
        zoomPositions.Add("SoundIsland", new Vector3(-20.4f, -1, -10));
        zoomPositions.Add("MediaIsland", new Vector3(22.5f, 7.5f, -2));
    }

    public Vector3 getZoomPosition(string zoomKey) => (Vector3)zoomPositions[zoomKey];
}
