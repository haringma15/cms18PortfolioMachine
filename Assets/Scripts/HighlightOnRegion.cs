using UnityEngine;

public class HighlightOnRegion : MonoBehaviour
{
    public Color highlightColor = Color.yellow;
    private MeshRenderer rend;
    private Color startColor;

    void Start() {
        rend = transform.GetComponent<MeshRenderer>();
        startColor = rend.material.color;
    } 

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Mapsl") 
            rend.material.color += highlightColor;
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Mapsl") 
            rend.material.color -= highlightColor;
    }
}
