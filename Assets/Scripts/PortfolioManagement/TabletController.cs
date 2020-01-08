using UnityEngine;
using UnityEngine.UI;

public class TabletController : MonoBehaviour
{
    public GameObject rightSidedTablet;
    public GameObject rightSidedTabletBackground;
    public GameObject leftSidedTablet;
    public GameObject leftSidedTabletBackground;
    public Sprite interactionBackground;
    public Sprite soundBackground;
    public Sprite communicationBackground;
    public Sprite mediaBackground;

    private bool isBackgroundSet;
    
    void Start() => disableAll();

    void Update() {
        if (PlayerPrefs.GetString("region") != "" && !isBackgroundSet) {
            switch (PlayerPrefs.GetString("island")) {
                case "InteractionIsland":
                    setRight(interactionBackground);
                    break;
                case "SoundIsland":
                    setRight(soundBackground);
                    break;
                case "CommunicationIsland":
                    setLeft(communicationBackground);
                    break;
                case "MediaIsland":
                    setLeft(mediaBackground);
                    break;
            }
            isBackgroundSet = true;
        }
    }

    public void disableAll() {
        isBackgroundSet = false;
        rightSidedTablet.SetActive(false);
        leftSidedTablet.SetActive(false);
    }

    private void setRight(Sprite background) {
        rightSidedTabletBackground.GetComponent<Image>().sprite = background;
        rightSidedTablet.SetActive(true);
        leftSidedTablet.SetActive(false);
    }

    private void setLeft(Sprite background) {
        leftSidedTabletBackground.GetComponent<Image>().sprite = background;
        leftSidedTablet.SetActive(true);
        rightSidedTablet.SetActive(false);
    }
}
