using UnityEngine;

// Adds color to an area when Mapsl is dragged over it.
// Place this script on "area"-tagged gameobjects.
public class Selectable : MonoBehaviour
{
    public AreaType areaType;
    public Color highlightColor = Color.yellow;

    private string areaName;
    private bool isHighlighted = false;
    private bool isEntered = false;

    void Update() {
        if (PlayerPrefs.GetInt("zooming") == 0){
            if (isEntered && !isHighlighted) {
                updateColor(highlightColor);
                isHighlighted = true;
            }
            if (!isEntered && isHighlighted) {
                updateColor(highlightColor * -1);
                isHighlighted = false;
            }
            if (isEntered && PlayerPrefs.GetInt("isMapslDragged") == 0) {
                PlayerPrefs.SetString(areaType.ToString(), name);
                isEntered = false;
            }
        }
    }

    void OnTriggerEnter(Collider other) => isEntered = true;
    void OnTriggerExit(Collider other) => isEntered = false;

    private void updateColor(Color c) => GetComponent<MeshRenderer>().material.color += c;
}

public enum AreaType {
    island,
    region
}