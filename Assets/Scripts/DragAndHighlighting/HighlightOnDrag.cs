using System.Collections.Generic;
using UnityEngine;

// Adds color to all gameobjects with the 'area' tag when Mapsl is dragged.
public class HighlightOnDrag : MonoBehaviour
{
    private GameObject[] allAreas;
    private List<GameObject> areas = new List<GameObject>();
    private bool isAreasSet = false;
    private bool isHighlighted = false;

    void Awake() => allAreas = GameObject.FindGameObjectsWithTag("area");

    void Update() {
        if (PlayerPrefs.GetInt("isMapslDragged") == 1 && !isAreasSet) {
            foreach (GameObject go in allAreas) if (PlayerPrefs.GetString("island") == "" && go.name.Contains("Island") && !go.name.Contains("Init")|| PlayerPrefs.GetString("island") != "" && go.transform.parent.name.Contains(PlayerPrefs.GetString("island")) || PlayerPrefs.GetString("island") != "" && go.name.Contains("Init")) areas.Add(go);
            isAreasSet = true;
        }
        if (PlayerPrefs.GetInt("isMapslDragged") == 1 && !isHighlighted && isAreasSet) {
            foreach (GameObject area in areas) area.GetComponent<HighlightFXController>().enableFX();
            isHighlighted = true;
        }
        if (PlayerPrefs.GetInt("isMapslDragged") == 0 && isHighlighted) {
            foreach (GameObject area in areas) area.GetComponent<HighlightFXController>().disableFX();
            isHighlighted = false;
            areas.Clear();
            isAreasSet = false;
        }
    }
}
