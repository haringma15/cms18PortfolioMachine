using UnityEngine;

public class HighlightChecker : MonoBehaviour
{
    public HighlightType typeToHighlight;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Mapsl") 
            PlayerPrefs.SetString(typeToHighlight.ToString(), transform.parent.parent.name);
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Mapsl") 
            PlayerPrefs.SetString(typeToHighlight.ToString(), "");
    }
}

public enum HighlightType {
    island,
    region
}
