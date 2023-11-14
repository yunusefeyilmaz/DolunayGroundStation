namespace DolunayGroundStation
{
    public partial class Main : Form
    {
        private SettingsForm settingsForm;
        private SshClientWrapper sshClient;
        private LoggerConsole console;
        private UIManager uiManager;
        private DataTransferManager dataTransferManager;
        private AppUpdater updater;
        public Main()
        {
            InitializeComponent();

        }
        private void Main_Load(object sender, EventArgs e)
        {
            // Initialize necessary components and forms.
            uiManager = new UIManager(this);
            console = new LoggerConsole(uiManager);
            updater = new AppUpdater(this, console);
            // Initialize the Settings Form and read settings.
            settingsForm = new SettingsForm(this, console);
            dataTransferManager = new DataTransferManager(uiManager, console);
            sshClient = new SshClientWrapper(SettingsForm.HOST, SettingsForm.USERNAME, SettingsForm.PASSWORD, console);
            //Check theme
            uiManager.changeTheme(settingsForm);
            float scalingFactor = GetScalingFactor();
            AdjustControlSizesAndFonts(this, scalingFactor);
        }
        private float GetScalingFactor()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            Graphics g = this.CreateGraphics();
            float dpiFactor = g.DpiX / 96f; // 96 DPI varsayýlan deðerdir.
            g.Dispose();
            return dpiFactor;
        }

        private void AdjustControlSizesAndFonts(Control control, float scalingFactor)
        {
            foreach (Control ctrl in control.Controls)
            {
                ctrl.Font = new Font(ctrl.Font.FontFamily, ctrl.Font.Size * scalingFactor);
                ctrl.Size = new Size((int)(ctrl.Size.Width * scalingFactor), (int)(ctrl.Size.Height * scalingFactor));

                if (ctrl.HasChildren)
                {
                    AdjustControlSizesAndFonts(ctrl, scalingFactor);
                }
            }
        }
        public Panel GetPanel1() { return panel1; }
        public Panel GetPanel2() { return panel2; }
        public Panel GetPanel3() { return panel3; }
        public Label GetLblFrontPicBox()
        {
            return lblFrontPicBox;
        }
        public Label GetLblUnderPicBox()
        {
            return lblDownPicBox;
        }
        public Label GetLblPitch()
        {
            return lblPitch;
        }

        public Label GetLblRoll()
        {
            return lblRoll;
        }

        public Label GetLblServo1()
        {
            return lblServo1;
        }

        public Label GetLblServo2()
        {
            return lblServo2;
        }

        public Label GetLblServo3()
        {
            return lblServo3;
        }

        public Label GetLblServo4()
        {
            return lblServo4;
        }

        public Label GetLblServo5()
        {
            return lblServo5;
        }

        public Label GetLblServo6()
        {
            return lblServo6;
        }

        public Label GetLblServo7()
        {
            return lblServo7;
        }

        public Label GetLblServo8()
        {
            return lblServo8;
        }

        public Label GetLblPressure()
        {
            return lblPressure;
        }

        public Label GetLblRightDis()
        {
            return lblRightDis;
        }

        public Label GetLblLeftDis()
        {
            return lblLeftDis;
        }
        public Label GetLblRightHydro()
        {
            return lblRightHydro;
        }

        public Label GetLblLeftHydro()
        {
            return lblLeftHydro;
        }
        public Label GetLblProgBarLeft()
        {
            return lblprogBarLeft;
        }

        public Label GetLblProgBarRight()
        {
            return lblprogBarRight;
        }

        public Label GetLblCon()
        {
            return lblCon;
        }

        public Label GetLblFrontCam()
        {
            return lblFrontCam;
        }

        public Label GetLblUnderCam()
        {
            return lblUnderCam;
        }

        public Label GetLblPresText()
        {
            return lblPresText;
        }
        public Label GetLblYawText()
        {
            return lblYaw;
        }
        public Label GetLblDisSen()
        {
            return lblDisSen;
        }

        public Label GetLblHydrophone()
        {
            return lblHydrophone;
        }

        public Label GetLblMode()
        {
            return lblMode;
        }

        public Label GetLblArm()
        {
            return lblArm;
        }

        public PictureBox GetCameraFront()
        {
            return CameraImg;
        }

        public PictureBox GetCameraUnder()
        {
            return CameraUnder;
        }

        public PictureBox GetPbCompass()
        {
            return pbCompass;
        }
        public PictureBox GetDisSubImage()
        {
            return pbDisSubImage;
        }

        public PictureBox GetControllerImage()
        {
            return pbControllerImage;
        }

        public Button GetLogButton()
        {
            return btnLog;
        }
        public Button GetSSHButton()
        {
            return btnSSH;
        }
        public Button GetJoystickButton()
        {
            return btnJoystick;
        }
        public Button GetSettingsButton()
        {
            return btnSettings;
        }
        public Button GetBtnCon()
        {
            return btnCon;
        }
        public TextBox GetInfoTxtBox()
        {
            return InfoTxtBox;
        }

        public ProgressBar GetProgBarLeft()
        {
            return progBarLeft;
        }
        public ProgressBar GetProgBarRight()
        {
            return progBarRight;
        }
        private void btnCon_Click(object sender, EventArgs e)
        {
            // Handle the connection button click event to start or stop data transfer.
            if (!UIManager.conCheckBtn)
            {
                dataTransferManager.StartDataTransfer();
                UIManager.conCheckBtn = true;
                uiManager.RefreshConnectionVerificationLabel();
            }
            else
            {
                dataTransferManager.StopDataTransfer();
                UIManager.conCheckBtn = false;
                uiManager.RefreshConnectionVerificationLabel();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // Handle the emergency stop button click event.
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE YOU WANT TO PERFORM AN EMERGENCY STOP?", "EMERGENCY STOP", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                sshClient.ExecuteEmergencyStop();
            }
            else if (dialogResult == DialogResult.No)
            {
                console.Log("Emergency stop canceled.");
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Handle the settings button click event to open the settings form.
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                settingsForm.RefreshSettingData();
                uiManager.changeTheme(settingsForm);
            }
        }

        private void btnSSH_Click(object sender, EventArgs e)
        {
            // Handle the SSH button click event to connect and execute SSH commands.
            try
            {
                sshClient.CreateShellStream();
            }
            catch (Exception ex)
            {
                console.Log("Error: " + ex.Message);
                console.Log("SSH console could not be created.");
            }

        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            // Handle the log button click event to save the log messages to a file.
            console.SaveLogFile();
        }

        bool firstClick = false; // Was the PictureBox clicked?
        private bool changeCam = false;

        private void CameraImg_Click(object sender, EventArgs e)
        {
            if (!firstClick)
            {
                firstClick = true;
            }
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    // Swap between cameras and their labels.
                    changeCam = !changeCam;
                    PictureBox tmpP = new PictureBox();
                    tmpP = CameraImg;
                    CameraImg = CameraUnder;
                    CameraUnder = tmpP;
                    // Swap label positions.
                    Point tempLocation = lblFrontPicBox.Location;
                    lblFrontPicBox.Location = lblDownPicBox.Location;
                    lblDownPicBox.Location = tempLocation;
                    console.Log("Cameras swapped.");
                    // Restore the clickability of the first PictureBox.
                    firstClick = false;
                });
            }
        }

        public static bool joystickOn = false;

        private void btnJoystick_Click(object sender, EventArgs e)
        {
            // Handle the joystick button click event to enable or disable manual control mode.
            joystickOn = !joystickOn;
            if (joystickOn)
            {
                btnChangePanelMiddle.Visible = joystickOn;
                uiManager.ChangeMiddleScreen();
                console.Log("Manual control mode enabled. Please connect your controller.");
            }
            else
            {
                btnChangePanelMiddle.Visible = joystickOn;
                uiManager.ChangeMiddleScreen();
                console.Log("Manual control mode disabled.");
            }
        }

        private void btnChangePanelMiddle_Click(object sender, EventArgs e)
        {
            // Handle the button to change the middle screen.
            uiManager.ChangeMiddleScreen();
        }
    }
}