using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource ambientSound;
    public AudioSource pickUpSound1;
    public AudioSource pickUpSound2;
    public AudioSource dropSound;
    public AudioSource landingSound1;
    public AudioSource landingSound2;
    public AudioSource hoverIslandSound;
    public AudioSource hoverRegionSound;
    public AudioSource printButtonClickSound;

    private bool isAmbientPlaying = false;
    private int randomNumber;

    void Update() {
        // ambient
        if (!isAmbientPlaying && PlayerPrefs.GetString("region") == "") {
            ambientSound.Play();
            isAmbientPlaying = true;
        }
        if (isAmbientPlaying && PlayerPrefs.GetString("region") != "") {
            ambientSound.Stop();
            isAmbientPlaying = false;
        }

        // pick up, drop and land fx
        if (PlayerPrefs.GetInt("playMapslPickUpSound") == 1) {
            randomNumber = Random.Range(0, 10);
            if (randomNumber % 3 == 0) pickUpSound1.Play();
            else pickUpSound2.Play();
            PlayerPrefs.SetInt("playMapslPickUpSound", 0);
        }
        if (PlayerPrefs.GetInt("playMapslDropSound") == 1) {
            dropSound.Play();
            PlayerPrefs.SetInt("playMapslDropSound", 0);
        }
        if (PlayerPrefs.GetInt("playMapslLandingSound") == 1) {
            if (randomNumber % 3 == 0) landingSound1.Play();
            else landingSound2.Play();
            PlayerPrefs.SetInt("playMapslLandingSound", 0);
        }

        // hover fx
        if (PlayerPrefs.GetInt("playIslandHoverSound") == 1) {
            hoverIslandSound.Play();
            PlayerPrefs.SetInt("playIslandHoverSound", 0);
        }
        if (PlayerPrefs.GetInt("playRegionHoverSound") == 1) {
            hoverRegionSound.Play();
            PlayerPrefs.SetInt("playRegionHoverSound", 0);
        }

        // button click
        if (PlayerPrefs.GetInt("playButtonClickSound") == 1) {
            printButtonClickSound.Play();
            PlayerPrefs.SetInt("playButtonClickSound", 0);
        }
    }
}
