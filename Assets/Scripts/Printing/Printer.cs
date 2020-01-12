using UnityEngine;

public class Printer : MonoBehaviour {

    public string baseFilePath = "C:\\visitenkarten\\";
    private string filePath = "";

    public PrintingTool printingTool;

    public void print()
    {
        filePath = baseFilePath + PlayerPrefs.GetString("region") + ".pdf";
        printingTool.CmdPrintThreaded(filePath);
        printingTool.StartCheckIsPrintingDone();
    }
}
