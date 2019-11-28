using UnityEngine;

public class HighlightOnDrag : MonoBehaviour
{
    public Color highlightingColor = Color.blue;
    private GameObject[] areasToHighlight;
    private bool isHighlighted = false;

    void Start() {
        areasToHighlight = GameObject.FindGameObjectsWithTag("area");
    }

    void Update() {
        if (PlayerPrefs.GetInt("isMapslDragged") == 1 && !isHighlighted) {
            foreach (var area in areasToHighlight) changeColor(area, highlightingColor);
            isHighlighted = true;
        }
        if (PlayerPrefs.GetInt("isMapslDragged") == 0 && isHighlighted) {
            foreach (var area in areasToHighlight) changeColor(area, highlightingColor * -1);
            isHighlighted = false;
        }
    }

    private void changeColor(GameObject go, Color c) => go.GetComponent<MeshRenderer>().material.color += c;
    
}
