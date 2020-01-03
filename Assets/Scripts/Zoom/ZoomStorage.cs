using System.Collections;
using UnityEngine;

// Stores Zoom position Mapsl will move to eventually.
public class ZoomStorage : MonoBehaviour
{
    public Hashtable zoomPositions = new Hashtable();

    void Start() => fillZoomPositions();

    private void fillZoomPositions() {
        zoomPositions.Add("Init", new Vector3(0, 0, -20));
        zoomPositions.Add("InteractionIsland", new Vector3(15.5f, 6, -10));
        zoomPositions.Add("MartinHaring", new Vector3(6, 11, -0.1f));
    }

    public Vector3 getZoomPosition(string zoomKey) => (Vector3)zoomPositions[zoomKey];
}
