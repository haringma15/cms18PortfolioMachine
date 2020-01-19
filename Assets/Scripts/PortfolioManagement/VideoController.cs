using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public string index;
    public PortfolioController portfolioController;
    public RawImage vidView;

    private VideoPlayer vid;
    private string activeProjectIndex;
    private bool playing = false;

    void Start() => vid = GetComponent<VideoPlayer>();

    void Update() {
        activeProjectIndex = portfolioController.getIndex();
        if (!vid.isPrepared) vid.Prepare();
        
        if (vid.isPrepared && !playing && activeProjectIndex == index) {
            vidView.texture = vid.texture;
            vid.Play();
            playing = true;
        }
        
        if (playing && activeProjectIndex != index) {
            vid.Pause();
            playing = false;
        }
    }
}
