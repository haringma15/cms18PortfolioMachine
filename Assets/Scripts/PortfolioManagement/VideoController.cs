using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public string index;
    public PortfolioController portfolioController;
    public RawImage vidView;
    public GameObject thumbnail = null;
    public int thumbnailHideTime = 4;

    private VideoPlayer vid;
    private string activeProjectIndex;
    private bool playing = false;
    private int thumbnailHideTimer = -1;

    void Start() => vid = GetComponent<VideoPlayer>();

    void Update() {
        activeProjectIndex = portfolioController.getIndex();
        if (!vid.isPrepared) {
            playing = false;
            vid.Prepare();
        }

        if (vid.isPrepared && !playing && activeProjectIndex == index) {
            vidView.texture = vid.texture;
            vid.Play();
            playing = true;
        }
        
        if (playing && activeProjectIndex != index) {
            vid.Pause();
            playing = false;
        }

        if (thumbnail != null) {
            if (!vid.isPrepared && !thumbnail.activeInHierarchy) thumbnail.SetActive(true);
            if (vid.isPrepared && thumbnail.activeInHierarchy && thumbnailHideTimer < 0) thumbnailHideTimer = thumbnailHideTime;
        }

        if (thumbnailHideTimer >= 0) {
            if (thumbnailHideTimer == 0) thumbnail.SetActive(false);
            thumbnailHideTimer--;
        }
    }
}
