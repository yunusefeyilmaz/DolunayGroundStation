using System.Diagnostics;

namespace DolunayYerIstasyonu
{
    public class UIManager
    {
        Main main;
        private Image signalResource = Properties.Resources.signal;
        public static bool conCheckBtn = false;
        public static bool conCheck = false;
        public static bool presCheck = false;
        public static bool frontCamCheck = false;
        public static bool downCamCheck = false;
        public UIManager(Main main)
        {
            this.main = main;
            main.GetPbCompass().Image = Compass.DrawCompass(0, 0, 0, main.GetPbCompass().Size);
        }
        public void setInfoTextBox(string text)
        {
            try
            {
                main.Invoke((MethodInvoker)delegate
                {
                    main.GetInfoTxtBox().AppendText(text);
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }
        public string GetInfoTxtBox()
        {
            return main.GetInfoTxtBox().Text;
        }

        bool screenChange = false;
        public void ChangeMiddleScreen()
        {
            if (Main.joystickOn)
            {

            }
            screenChange = Main.joystickOn ? !screenChange : false;
            if (screenChange)
            {
                main.GetControllerImage().Visible = true;
            }
            else
            {
                main.GetControllerImage().Visible = false;
            }
        }
        public void SetUnderCameraImage(string frame)
        {
            main.GetCameraUnder().Image = Base64ToByteArrayToImage(frame);
        }
        public void SetFrontImage(string frame)
        {
            main.GetCameraFront().Image = Base64ToByteArrayToImage(frame);
        }
        private Image Base64ToByteArrayToImage(string frameBase64)
        {
            byte[] byteArray = Convert.FromBase64String(frameBase64);
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
        public void SetPixhawkDataToLabel(Dictionary<string, object> pixhawkdata)
        {
            /* 
              *** DATA FORMAT ***
             "pixhawkdata": {
             "yaw":  ,
             "roll": ,
             "pitch":    ,
             "basinc":   ,
             "servo1":   ,
             "servo2":   ,
             "servo3":   ,
             "servo4":   ,
             "servo5":   ,
             "servo6":   ,   
             "servo7":   ,
             "servo8":   ,
             "mode": ,
             "arm":  
             }
              */
            if (main.InvokeRequired)
            {
                main.Invoke((MethodInvoker)delegate
                {
                    double yaw = double.Parse(pixhawkdata["yaw"].ToString());
                    double roll = double.Parse(pixhawkdata["roll"].ToString());
                    double pitch = double.Parse(pixhawkdata["pitch"].ToString());

                    double degYaw = MapWithNegatives(Math.Round(yaw, 3));
                    double degRoll = Math.Round(roll, 3);
                    double degPitch = Math.Round(pitch, 3);

                    main.GetLblYawText().Text = yaw.ToString("0.###");
                    main.GetLblRoll().Text = roll.ToString("0.###");
                    main.GetLblPitch().Text = pitch.ToString("0.###");

                    double pressure = double.Parse(pixhawkdata["basinc"].ToString());
                    main.GetLblPressure().Text = pressure.ToString("0.###") + " M";
                    presCheck = (pressure != 0);

                    List<Label> servos = new List<Label>() { main.GetLblServo1(), main.GetLblServo2(), main.GetLblServo3(), main.GetLblServo4(),
                main.GetLblServo5(), main.GetLblServo6(), main.GetLblServo7(), main.GetLblServo8() };

                    for (int i = 0; i < servos.Count; i++)
                    {
                        string servoName = "servo" + (i + 1).ToString();
                        servos[i].Text = (i + 1).ToString() + " - " + pixhawkdata[servoName].ToString();
                    }

                    main.GetLblMode().Text = pixhawkdata["mode"].ToString();
                    main.GetLblArm().Text = pixhawkdata["arm"].ToString();

                    main.GetPbCompass().Image = Compass.DrawCompass(degYaw, degPitch, degRoll, main.GetPbCompass().Size);

                });
            }

        }
        public void RefreshConnectionVerificationLabel()
        {
            main.Invoke((MethodInvoker)delegate
            {
                if (conCheckBtn)
                {
                    if (conCheck) { main.GetLblCon().Text = "Connected"; main.GetLblCon().ForeColor = Color.LightGreen; }
                    else { main.GetLblCon().Text = "Connection Lost"; main.GetLblCon().ForeColor = Color.Red; }

                    main.GetBtnCon().BackColor = Color.Red;
                    main.GetBtnCon().Text = "Stop Connection";

                    if (presCheck) { main.GetLblPresText().Text = "Working"; main.GetLblPresText().ForeColor = Color.LightGreen; }
                    else { main.GetLblPresText().Text = "Not Working"; main.GetLblPresText().ForeColor = Color.Red; }

                    if (frontCamCheck) { main.GetLblFrontCam().Text = "Working"; main.GetLblFrontCam().ForeColor = Color.LightGreen; }
                    else { main.GetLblFrontCam().Text = "Not Working"; main.GetLblFrontCam().ForeColor = Color.Red; }

                    if (downCamCheck) { main.GetLblUnderCam().Text = "Working"; main.GetLblUnderCam().ForeColor = Color.LightGreen; }
                    else { main.GetLblUnderCam().Text = "Not Working"; main.GetLblUnderCam().ForeColor = Color.Red; }
                }
                else
                {
                    conCheck = false;

                    main.GetBtnCon().BackColor = Color.Lime;
                    main.GetBtnCon().Text = "Start Connection";

                    presCheck = false;

                    main.GetLblPresText().Text = "No Connection";
                    main.GetLblPresText().ForeColor = Color.Red;

                    frontCamCheck = false;

                    main.GetLblFrontCam().Text = "No Connection";
                    main.GetLblFrontCam().ForeColor = Color.Red;

                    downCamCheck = false;

                    main.GetLblUnderCam().Text = "No Connection";
                    main.GetLblUnderCam().ForeColor = Color.Red;

                    main.GetLblCon().Text = "Connection Lost";
                    main.GetLblCon().ForeColor = Color.Red;

                    main.GetLblArm().Text = "No Connection";
                    main.GetLblMode().Text = "No Connection";
                    main.GetCameraFront().Image = null;
                    main.GetCameraUnder().Image = null;

                    main.GetCameraFront().Image = signalResource;
                    main.GetCameraUnder().Image = signalResource;
                }
            });
        }
        static double Map(double value, double fromMin, double fromMax, double toMin, double toMax)
        {
            // Performs a linear transformation between input value (value) and input range (fromMin - fromMax) to the output range (toMin - toMax).
            return (value - fromMin) * (toMax - toMin) / (fromMax - fromMin) + toMin;
        }
        static double MapWithNegatives(double value)
        {
            // If value is greater than or equal to 0, apply transformation between 0 and 3.14
            if (value >= 0) { return Map(value, 0.0, 3.142, 0.0, 180.0); }
            // If negative, apply transformation between -3.14 and 0
            else { return Map(value, -3.142, 0.0, 181.0, 359.0); }
        }

    }
}
