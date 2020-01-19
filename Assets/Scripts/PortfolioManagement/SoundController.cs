using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public string index;
    public PortfolioController portfolioController;

    private AudioSource vidSound;
    private string activeProjectIndex;
    private bool playing = false;

    void Start() => vidSound = GetComponent<AudioSource>();

    void Update() {
        activeProjectIndex = portfolioController.getIndex();
        
        if (!playing && activeProjectIndex == index) {
            vidSound.Play();
            playing = true;
        }
        
        if (playing && activeProjectIndex != index) {
            vidSound.Pause();
            playing = false;
        }
    }
}
