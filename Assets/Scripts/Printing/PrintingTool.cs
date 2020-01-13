using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using System.IO;

public class PrintingTool : MonoBehaviour
{

    public string printerName = "BIXOLON SRP-350III";

    public float interval_checkIsPrintingDone = 0.2f;

    Thread m_thread;

    void OnDisable() {
        if (m_thread != null) m_thread.Abort();
    }

    void OnDestroy() {
        if (m_thread != null) m_thread.Abort();
    }

    void OnApplicationQuit() {
        if (m_thread != null) m_thread.Abort();
    }

    public void CmdPrintThreaded(string _filePath) {
        if (File.Exists(_filePath) == false) {
            UnityEngine.Debug.LogError("File Not Exist: " + _filePath);
        } else {
            if (FileIOUtility.IsFileLocked(_filePath) == false) {
                string fullCommand = "C:\\visitenkarten\\PDFtoPrinter.exe " + "\"" + _filePath + "\"" + " " + "\"" + printerName + "\"";
                m_thread = new Thread(delegate () { CmdPrint(fullCommand); });
                m_thread.IsBackground = false;
                m_thread.Start();
            } else {
                UnityEngine.Debug.LogError("File is Locked: " + _filePath);
            }
        }
    }

    public void CmdPrint(string _command) {
        try {
            Process myProcess = new Process();
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = "/c " + _command;
            myProcess.EnableRaisingEvents = true;
            myProcess.Start();
            myProcess.WaitForExit();
        } catch (Exception e) {
            UnityEngine.Debug.Log(e);
        }
    }
}
