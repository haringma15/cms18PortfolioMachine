using UnityEngine;

public class FishController : MonoBehaviour
{
    public float yRotSpeed = 1;
    public float zRotSpeed = 1;
    public float yRotLimit = 30;
    public float zRotLimit = 30;

    void Update() {
        transform.eulerAngles += new Vector3(0, yRotSpeed, zRotSpeed);
        if (transform.eulerAngles.y > yRotLimit - 1 && transform.eulerAngles.y < yRotLimit + 1 || transform.eulerAngles.y > 360 - yRotLimit - 1 && transform.eulerAngles.y < 360 - yRotLimit + 1) yRotSpeed = inverseRot(yRotSpeed);
        if (transform.eulerAngles.z > zRotLimit - 1 && transform.eulerAngles.z < zRotLimit + 1 || transform.eulerAngles.z > 360 - zRotLimit - 1 && transform.eulerAngles.z < 360 - zRotLimit + 1) zRotSpeed = inverseRot(zRotSpeed);
    }

    private float inverseRot(float rot) => -rot;
}
