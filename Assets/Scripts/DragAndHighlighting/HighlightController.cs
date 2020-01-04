using UnityEngine;

// Adds color to an area when Mapsl is dragged over it.
// Place this script on 2D trigger gameobjects.
public class HighlightController : MonoBehaviour
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
                updateColor(highlightColor * -1);
                isHighlighted = false;
                isEntered = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D o) {
        if (o.gameObject.name == "Mapsl") isEntered = true;
    } 
    void OnTriggerExit2D(Collider2D o) {
        if (o.gameObject.name == "Mapsl") isEntered = false;
    } 

    private void updateColor(Color c) => GetComponent<SpriteRenderer>().color += c;
}