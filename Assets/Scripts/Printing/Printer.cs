using UnityEngine;

public class Printer : MonoBehaviour {

    public string baseFilePath = "C:\\visitenkarten\\";

    public PrintingTool printingTool;

    public void print() => printingTool.CmdPrintThreaded(baseFilePath + PlayerPrefs.GetString("region") + ".pdf");
}
