﻿using UnityEngine;

// Makes Mapsl able to be dragged.
public class Draggable : MonoBehaviour
{
    private Vector3 screenPoint;
	private Vector3 offset;
		
	void OnMouseDown() {
		PlayerPrefs.SetInt("isMapslDragged", 1);
		PlayerPrefs.SetInt("playMapslPickUpSound", 1);
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
		
	void OnMouseDrag() {
		if (PlayerPrefs.GetInt("zooming") == 0) {
			Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
			transform.position = cursorPosition;
		}
	}

	void OnMouseUp() => PlayerPrefs.SetInt("isMapslDragged", 0);
}
