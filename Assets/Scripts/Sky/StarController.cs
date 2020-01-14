using UnityEngine;

public class StarController : MonoBehaviour
{
    public float speed = 0.3f;

    private float startX;
    private float growthX;
    private float growthY;
    private bool isShrinking = true;

    void Start() {
        startX = transform.localScale.x;
        growthX = transform.localScale.x / 100 * speed;
        growthY = transform.localScale.y / 100 * speed;
    } 

    void Update() {
        if (isShrinking) {
            if (transform.localScale.x > 0) transform.localScale -= new Vector3(growthX, growthY, 0);
            else toggleShrinking();
        } else {
            if (transform.localScale.x < startX) transform.localScale += new Vector3(growthX, growthY, 0);
            else toggleShrinking();
        }
    }

    void toggleShrinking() => isShrinking = !isShrinking;
}
