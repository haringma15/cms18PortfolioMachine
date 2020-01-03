using UnityEngine;

public class Printer : MonoBehaviour {

    public string baseFilePath = "C:\\visitenkarten\\";
    private string filePath = "";

    public PrintingTool printingTool;

    void Update() {
        filePath = baseFilePath + PlayerPrefs.GetString("region");
    }

    public void print()
    {
        printingTool.CmdPrintThreaded(filePath);
        printingTool.StartCheckIsPrintingDone();
    }
}
