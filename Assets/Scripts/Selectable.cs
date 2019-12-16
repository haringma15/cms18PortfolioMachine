using UnityEngine;

// Adds color to an area when Mapsl is dragged over it.
// Place this script on "area"-tagged gameobjects.
public class Selectable : MonoBehaviour
{
    public AreaType areaType;
    public Color highlightColor = Color.yellow;

    private string areaName;
    private bool isHighlighted = false;

    void Start() {
        switch (areaType) {
            case AreaType.island:
                areaName = transform.parent.name;
                break;
            case AreaType.region:
                areaName = name;
                break;
        }
    }

    void Update() {
        if (PlayerPrefs.GetInt("zooming") == 0){
            if (PlayerPrefs.GetString(areaType.ToString()) == areaName && !isHighlighted) {
                updateColor(highlightColor);
                isHighlighted = true;
            }
            if (PlayerPrefs.GetString(areaType.ToString()) != areaName && isHighlighted) {
                updateColor(highlightColor * -1);
                isHighlighted = false;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Mapsl") 
            PlayerPrefs.SetString(areaType.ToString(), areaName);
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Mapsl") 
            PlayerPrefs.SetString(areaType.ToString(), "");
    }

    private void updateColor(Color c) => GetComponent<MeshRenderer>().material.color += c;
}

public enum AreaType {
    island,
    region
}