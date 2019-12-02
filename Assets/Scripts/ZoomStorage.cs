﻿using System.Collections;
using UnityEngine;

// Stores Zoom position Mapsl will move to eventually.
public class ZoomStorage : MonoBehaviour
{
    public Hashtable zoomPositions = new Hashtable();

    void Start() => fillZoomPositions();

    private void fillZoomPositions() {
        zoomPositions.Add("InteractionIsland", new Vector3(15.5f, 10, 6));
        zoomPositions.Add("MartinHaring", new Vector3(6, 0.1f, 11));
    }

    public Vector3 getZoomPosition(string zoomKey) => (Vector3)zoomPositions[zoomKey];
}