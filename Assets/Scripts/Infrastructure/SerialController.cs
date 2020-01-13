using UnityEngine;
using System.IO.Ports;

public class SerialController : MonoBehaviour
{
    public string serialPortName = "COM3";
    public int serialPortBaudRate = 9600;
    public static SerialPort serialPort;
 
    void Start() {
        serialPort = new SerialPort(serialPortName, serialPortBaudRate);
        serialPort.Open();
        serialPort.ReadTimeout = 10;
    }
 
    void Update() {
        if (serialPort.IsOpen) {
            try {
                switch (PlayerPrefs.GetString("island")) {
                    case "InteractionIsland":
                        serialPort.Write("1");
                        break;
                    case "CommunicationIsland":
                        serialPort.Write("2");
                        break;
                    case "SoundIsland":
                        serialPort.Write("3");
                        break;
                    case "MediaIsland":
                        serialPort.Write("4");
                        break;
                    default:
                        serialPort.Write("0");
                        break;
                }
            } catch (System.Exception) {}
        }
    } 
 
    void OnApplicationQuit() => serialPort.Close();
}
