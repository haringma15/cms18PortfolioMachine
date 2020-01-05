using UnityEngine;

// Adds color to all gameobjects with the 'area' tag when Mapsl is dragged.
public class HighlightOnDrag : MonoBehaviour
{
    public Color highlightingColor = Color.blue;
    private GameObject[] areasToHighlight;
    private bool isHighlighted = false;

    void Awake() => areasToHighlight = GameObject.FindGameObjectsWithTag("area");

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

    private void changeColor(GameObject go, Color c) => go.GetComponent<SpriteRenderer>().color += c;
}
