using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseOver : MonoBehaviour {

    bool touched;
    public Color mainColor = new Color(13,11,13);
    public Color highlightColor = new Color(241,137,113);



    private void Start()
    {
        touched = false;    
    }

    void  Update()
    {
        if (touched) {
            OnMouseOver(); 
        }

        if (!touched)
        {
            OnMouseExit(); 
        }
    }

    void OnMouseOver()
    {
        touched = true; 
        gameObject.GetComponent<SpriteRenderer>().color = highlightColor; 
       // Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        touched = false; //The mouse is no longer hovering over the GameObject so output this message each frame
        gameObject.GetComponent<SpriteRenderer>().color = mainColor; 
       // Debug.Log("Mouse is no longer on GameObject.");

    }

}
