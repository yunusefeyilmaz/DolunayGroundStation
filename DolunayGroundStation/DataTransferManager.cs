using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DolunayGroundStation
{
    internal class DataTransferManager
    {
        private TcpListener listener;
        private Thread dataTransferThread;
        private bool isDataTransferRunning;
        private LoggerConsole console;
        private Joystick joystick;
        UIManager uiManager;
        private TcpClient client;

        public DataTransferManager(UIManager ui, LoggerConsole console)
        {
            isDataTransferRunning = false;
            this.uiManager = ui;
            listener = new TcpListener(IPAddress.Any, SettingsForm.PORT);
            joystick = new Joystick();
            this.console = console;
        }

        public void StartDataTransfer()
        {
            if (!isDataTransferRunning)
            {
                listener.Start();
                dataTransferThread = new Thread(DataTransferThread);
                dataTransferThread.Priority = ThreadPriority.Highest;
                dataTransferThread.IsBackground = true;
                isDataTransferRunning = true;
                dataTransferThread.Start();
                console.Log($"Server IP: {console.GetIPAdress()}");
                console.Log("Server successfully started.");
            }
        }
        public void StopDataTransfer()
        {
            if (isDataTransferRunning)
            {
                isDataTransferRunning = false;
                listener.Stop();
                dataTransferThread.Interrupt();
                console.Log("Server successfully closed.");
            }
        }

        private void DataTransferThread()
        {
            try
            {
                // Use TCP listener to receive new data.
                client = listener.AcceptTcpClient();
                using NetworkStream stream = client.GetStream();
                {
                    bool pxCont = true;
                    bool cm1Cont = true;
                    bool cm2Cont = true;
                    bool disCont = true;
                    bool hydroCont = true;
                    IPAddress clientIPAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
                    string clientIP = clientIPAddress.ToString();
                    UIManager.conCheck = true;
                    console.Log("A device connected: " + clientIP);
                    while (isDataTransferRunning)
                    {
                        //Reset
                        byte[] received_data = null;
                        byte[] bufferL = null;
                        //Get Length of Data
                        bufferL = new byte[16];
                        int bytesReadL = stream.Read(bufferL, 0, bufferL.Length);
                        //Send Received
                        string responseMessage = "(received)";
                        byte[] responseBuffer = Encoding.ASCII.GetBytes(responseMessage);
                        stream.Write(responseBuffer, 0, responseBuffer.Length);
                        // Convert the bytes received into an integer to get the length of the data
                        int length = BitConverter.ToInt32(bufferL, 0);
                        //Get Data
                        received_data = new byte[length];
                        var recv = stream.Read(received_data, 0, length);
                        //Convert Byte to String 
                        string jsonData = Encoding.ASCII.GetString(received_data, 0, received_data.Length);
                        // Process JSON data.
                        Dictionary<string, object> data;
                        try
                        {
                            data = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
                            
                        }
                        catch
                        {
                            //IF Not Received continue
                            receiveData(stream);
                            Thread.Sleep(10);
                            continue;
                        }
                        // Check for Pixhawk data.
                        try
                        {
                            // Read and display Pixhawk data from JSON format.
                            Dictionary<string, object> pixhawkdata = JsonConvert.DeserializeObject<Dictionary<string, object>>(data[SettingsForm.PIXHAWKNAME].ToString());
                            uiManager.SetPixhawkDataToLabel(pixhawkdata);
                            pxCont = true;
                        }
                        catch (Exception ex)
                        {
                            if (pxCont)
                            {
                                console.Log("Pixhawk data could not be obtained.");
                                console.Log("Error: " + ex.Message);
                                pxCont = false;
                            }
                        }

                        // Check for distance sensor data.
                        try
                        {
                            // Read and display distance sensor data from JSON format.
                            Dictionary<string, object> distancedata = JsonConvert.DeserializeObject<Dictionary<string, object>>(data[SettingsForm.DISTANCE].ToString());
                            uiManager.SetDistanceDataToLabel(distancedata);
                            disCont = true;
                        }
                        catch (Exception ex)
                        {
                            if (disCont)
                            {
                                console.Log("Distance sensor data could not be obtained.");
                                console.Log("Error: " + ex.Message);
                                disCont = false;
                            }
                        }

                        // Check for hydrophone data.
                        try
                        {
                            // Read and display hydrophone data from JSON format.
                            Dictionary<string, object> hydrophonedata = JsonConvert.DeserializeObject<Dictionary<string, object>>(data[SettingsForm.HYDROPHONE].ToString());
                            uiManager.SetHydrophoneDataToLabel(hydrophonedata);
                            hydroCont = true;
                        }
                        catch (Exception ex)
                        {
                            if (hydroCont)
                            {
                                console.Log("Hydrophone data could not be obtained.");
                                console.Log("Error: " + ex.Message);
                                hydroCont = false;
                            }
                        }

                        // Check for front camera data.
                        try
                        {
                            // Read camera images in JSON format.
                            string frame1Base64 = data[SettingsForm.FRONTCAMNAME].ToString();
                            if (frame1Base64 != null) { uiManager.SetFrontImage(frame1Base64); UIManager.frontCamCheck = true; }
                            cm1Cont = true;
                        }
                        catch (Exception ex)
                        {
                            if (cm1Cont)
                            {
                                console.Log("Front camera data could not be obtained.");
                                console.Log("Error: " + ex.Message);
                                cm1Cont = false;
                            }
                        }

                        // Check for rear camera data.
                        try
                        {
                            // Read camera images in JSON format.
                            string frame2Base64 = data[SettingsForm.UNDERCAMNAME].ToString();
                            if (frame2Base64 != null) { uiManager.SetUnderCameraImage(frame2Base64); UIManager.downCamCheck = true; }
                            cm2Cont = true;
                        }
                        catch (Exception ex)
                        {
                            if (cm2Cont)
                            {
                                console.Log("Rear camera data could not be obtained.");
                                console.Log("Error: " + ex.Message);
                                cm2Cont = false;
                            }
                        }

                        // Update the display labels.
                        uiManager.RefreshConnectionVerificationLabel();
                        receiveData(stream);
                        // Break the loop if the connection is lost.
                        if (!client.Connected)
                        {
                            console.Log("Connection terminated.");
                            break;
                        }
                        stream.Flush();
                    }
                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                console.Log("Error: " + ex.Message);
            }
        }
        private void receiveData(NetworkStream stream)
        {
            // Check if joystick control is enabled.
            if (Main.joystickOn && joystick.getControllerCon())
            {
                string joyData = joystick.GetJoystickData();
                byte[] joyBuffer = Encoding.ASCII.GetBytes(joyData);
                stream.Write(joyBuffer, 0, joyBuffer.Length);
            }
            else
            {
                // Notify the other side that the received data is processed.
                string responseMessage = "(received)";
                byte[] responseBuffer = Encoding.ASCII.GetBytes(responseMessage);
                stream.Write(responseBuffer, 0, responseBuffer.Length);
            }
        }
    }
}
