using UnityEngine;

public class TestButtonController : MonoBehaviour
{
    public void setGreen() => PlayerPrefs.SetString("island", "InteractionDesign");
    public void setYellow() => PlayerPrefs.SetString("island", "");
}
