using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource pickUpSound;
    public AudioSource dropSound;
    public AudioSource hoverSound;

    void Update() {
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
