﻿using UnityEngine;

// Adds color to an area when Mapsl is dragged over it.
// Place this script on 2D trigger gameobjects.
public class HighlightController : MonoBehaviour
{
    public AreaType areaType;
    public SpriteRenderer areaToHighlight;
    public Color highlightColor = Color.yellow;

    private string areaName;
    private bool isHighlighted = false;
    private bool isEntered = false;

    void Update() {
        if (PlayerPrefs.GetInt("zooming") == 0){
            if (isEntered && !isHighlighted) {
                if (!(areaType.ToString() == "island" && PlayerPrefs.GetString("island") != "" && name != "Init")) {
                    updateColor(highlightColor);
                    isHighlighted = true;
                }
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
        if (o.gameObject.name == "Mapsl" && PlayerPrefs.GetInt("isMapslDragged") == 1) {
            isEntered = true;
            if (areaType.ToString() == "island") PlayerPrefs.SetInt("playIslandHoverSound", 1);
            else PlayerPrefs.SetInt("playRegionHoverSound", 1);
        }
    } 
    void OnTriggerExit2D(Collider2D o) {
        if (o.gameObject.name == "Mapsl" && PlayerPrefs.GetInt("isMapslDragged") == 1) isEntered = false;
    } 

    private void updateColor(Color c) => areaToHighlight.color += c;
}