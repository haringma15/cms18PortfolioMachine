using UnityEngine;

public class HighlightOnIsland : MonoBehaviour
{
    public Color highlightColor = Color.yellow;

    private Transform[] islandShapes;
    private Color startColor;

    void Start() {
        islandShapes = gameObject.GetComponentsInChildren<Transform>();
        startColor = islandShapes[0].GetComponent<MeshRenderer>().material.color;
    } 

    void Update() {
        if (PlayerPrefs.GetString("island") == transform.parent.name) updateColor(highlightColor);
        else updateColor(startColor);
    }

    void updateColor(Color c) {
        //foreach (Transform t in islandShapes) t.GetComponent<MeshRenderer>().material.color = c;
    }
}
