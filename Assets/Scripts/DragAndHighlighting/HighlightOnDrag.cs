using System.Collections.Generic;
using UnityEngine;

// Adds color to all gameobjects with the 'area' tag when Mapsl is dragged.
public class HighlightOnDrag : MonoBehaviour
{
    public Color highlightingColor = Color.blue;
    private GameObject[] allAreas;
    private List<GameObject> areas = new List<GameObject>();
    private bool isAreasSet = false;
    private bool isHighlighted = false;

    void Awake() => allAreas = GameObject.FindGameObjectsWithTag("area");

    void Update() {
        if (PlayerPrefs.GetInt("isMapslDragged") == 1 && !isAreasSet) {
            foreach (GameObject go in allAreas) if (PlayerPrefs.GetString("island") == "" && go.name.Contains("Island") || PlayerPrefs.GetString("island") != "" && !go.name.Contains("Island")) areas.Add(go);
            isAreasSet = true;
        }
        if (PlayerPrefs.GetInt("isMapslDragged") == 1 && !isHighlighted && isAreasSet) {
            foreach (var area in areas) changeColor(area, highlightingColor);
            isHighlighted = true;
        }
        if (PlayerPrefs.GetInt("isMapslDragged") == 0 && isHighlighted) {
            foreach (var area in areas) changeColor(area, highlightingColor * -1);
            isHighlighted = false;
            areas.Clear();
            isAreasSet = false;
        }
    }

    private void changeColor(GameObject go, Color c) => go.GetComponent<SpriteRenderer>().color += c;
}
