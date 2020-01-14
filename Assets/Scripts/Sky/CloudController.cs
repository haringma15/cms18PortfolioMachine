using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float speed = 1;
    public float endXPos;

    private Vector3 endPos;

    void Start() {
        endPos = new Vector3(endXPos, transform.position.y, transform.position.z);
    }

    void Update() {
        transform.Translate(-speed, 0, 0);
        if (transform.localPosition.x < endXPos) transform.localPosition -= new Vector3(endXPos*2, 0, 0);
    }
}
