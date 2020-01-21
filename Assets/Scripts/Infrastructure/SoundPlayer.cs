using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource pickUpSound;
    public AudioSource dropSound;
    public AudioSource hoverSound;
    public AudioSource ambientOverviewSound;
    public AudioSource ambientIDSound;
    public AudioSource ambientCDSound;
    public AudioSource ambientSDSound;
    public AudioSource ambientMDSound;

    private bool ambientPlaying = false;

    void Update() {
        if (PlayerPrefs.GetInt("playMapslDropSound") == 1) ambientPlaying = false;

        // ambient
        if (!ambientPlaying) {
            switch (PlayerPrefs.GetString("island")) {
                case "":
                    ambientIDSound.Stop();
                    ambientCDSound.Stop();
                    ambientSDSound.Stop();
                    ambientMDSound.Stop();
                    ambientOverviewSound.Play();
                    break;
                case "Init":
                    ambientIDSound.Stop();
                    ambientCDSound.Stop();
                    ambientSDSound.Stop();
                    ambientMDSound.Stop();
                    ambientOverviewSound.Play();
                    break;
                case "InteractionIsland":
                    ambientIDSound.Play();
                    ambientCDSound.Stop();
                    ambientSDSound.Stop();
                    ambientMDSound.Stop();
                    ambientOverviewSound.Stop();
                    break;
                case "CommunicationIsland":
                    ambientIDSound.Stop();
                    ambientCDSound.Play();
                    ambientSDSound.Stop();
                    ambientMDSound.Stop();
                    ambientOverviewSound.Stop();
                    break;
                case "SoundIsland":
                    ambientIDSound.Stop();
                    ambientCDSound.Stop();
                    ambientSDSound.Play();
                    ambientMDSound.Stop();
                    ambientOverviewSound.Stop();
                    break;
                case "MediaIsland":
                    ambientIDSound.Stop();
                    ambientCDSound.Stop();
                    ambientSDSound.Stop();
                    ambientMDSound.Play();
                    ambientOverviewSound.Stop();
                    break;
            }
            ambientPlaying = true;
        }

        // fx
        if (PlayerPrefs.GetInt("playMapslPickUpSound") == 1) {
            pickUpSound.Play();
            PlayerPrefs.SetInt("playMapslPickUpSound", 0);
        }
        if (PlayerPrefs.GetInt("playMapslDropSound") == 1) {
            pickUpSound.Play();
            PlayerPrefs.SetInt("playMapslDropSound", 0);
        }
        if (PlayerPrefs.GetInt("playAreaHoverSound") == 1) {
            pickUpSound.Play();
            PlayerPrefs.SetInt("playAreaHoverSound", 0);
        }
    }
}
