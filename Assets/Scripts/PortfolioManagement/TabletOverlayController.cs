using UnityEngine;

public class TabletOverlayController : MonoBehaviour
{
    public GameObject interactionOrMediaOverlay;
    public GameObject soundOrCommunicationOverlay;

    private bool isBackgroundSet;
    
    void Start() => disableAll();

    void Update() {
        if (PlayerPrefs.GetString("region") != "" && !isBackgroundSet) {
            switch (PlayerPrefs.GetString("island")) {
                case "InteractionIsland":
                    interactionOrMediaOverlay.SetActive(true);
                    soundOrCommunicationOverlay.SetActive(false);
                    break;
                case "SoundIsland":
                    interactionOrMediaOverlay.SetActive(false);
                    soundOrCommunicationOverlay.SetActive(true);
                    break;
                case "CommunicationIsland":
                    interactionOrMediaOverlay.SetActive(false);
                    soundOrCommunicationOverlay.SetActive(true);
                    break;
                case "MediaIsland":
                    interactionOrMediaOverlay.SetActive(true);
                    soundOrCommunicationOverlay.SetActive(false);
                    break;
            }
            isBackgroundSet = true;
        }
    }

    public void disableAll() {
        isBackgroundSet = false;
        interactionOrMediaOverlay.SetActive(false);
        soundOrCommunicationOverlay.SetActive(false);
    }
}
