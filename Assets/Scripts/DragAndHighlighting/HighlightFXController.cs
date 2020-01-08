using UnityEngine;

public class HighlightFXController : MonoBehaviour
{
    public GameObject highlightFX;

    void Start() => disableFX();

    public void enableFX() => highlightFX.SetActive(true);
    public void disableFX() => highlightFX.SetActive(false);
}
