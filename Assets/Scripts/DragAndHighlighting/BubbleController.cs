using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public GameObject[] bubbleParticleSystems;
    public int burstTimeInFrames = 30;

    private GameObject randomBubble;
    private int burstTimer;

    void Start() {
        burstTimer = burstTimeInFrames;
    }

    void Update() {
        burstTimer--;
        if (burstTimer <= 0) {
            randomBubble = bubbleParticleSystems[Random.Range(0, bubbleParticleSystems.Length)];
            Instantiate(randomBubble, transform.position, Quaternion.identity);
            burstTimer = burstTimeInFrames;
        }
    }
}
