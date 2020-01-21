using UnityEngine;

public class TabletOverlayController : MonoBehaviour
{
    public GameObject interactionOrMediaOverlay;
    public GameObject soundOrCommunicationOverlay;

    private bool isBackgroundSet;
    
    void Update() {
        switch (PlayerPrefs.GetString("island")) {
            case "InteractionIsland":
                if (!interactionOrMediaOverlay.activeInHierarchy) interactionOrMediaOverlay.SetActive(true);
                if (soundOrCommunicationOverlay.activeInHierarchy) soundOrCommunicationOverlay.SetActive(false);
                break;
            case "MediaIsland":
                if (!interactionOrMediaOverlay.activeInHierarchy) interactionOrMediaOverlay.SetActive(true);
                if (soundOrCommunicationOverlay.activeInHierarchy) soundOrCommunicationOverlay.SetActive(false);
                break;
            case "SoundIsland":
                if (interactionOrMediaOverlay.activeInHierarchy) interactionOrMediaOverlay.SetActive(false);
                if (!soundOrCommunicationOverlay.activeInHierarchy) soundOrCommunicationOverlay.SetActive(true);
                break;
            case "CommunicationIsland":
                if (interactionOrMediaOverlay.activeInHierarchy) interactionOrMediaOverlay.SetActive(false);
                if (!soundOrCommunicationOverlay.activeInHierarchy) soundOrCommunicationOverlay.SetActive(true);
                break;
        }
    }
}
