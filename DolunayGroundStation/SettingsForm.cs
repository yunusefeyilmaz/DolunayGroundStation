using System.Diagnostics;
using System.Reflection;

namespace DolunayGroundStation
{
    public partial class SettingsForm : Form
    {
        public static string HOST = "";
        public static string USERNAME = "";
        public static string PASSWORD = "";
        public static string FRONTCAMNAME = "";
        public static string UNDERCAMNAME = "";
        public static string PIXHAWKNAME = "";
        public static string PATHLOG = "";
        public static string CODESPATH = "";
        public static string DISTANCE = "";
        public static string HYDROPHONE = "";
        public static int PORT = 65432;
        public static bool THEME = true;
        private string configPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DolunayGroundStation\\" + "config.txt";
        public static string VERSIONSIM = "";
        private Main main;
        private LoggerConsole console;
        private bool notValidData = false;
        SimController simController;
        public SettingsForm()
        {

        }
        public SettingsForm(Main main, LoggerConsole console)
        {


            InitializeComponent();

            this.console = console;
            this.main = main;
            WriteFileSetting();
            UpdateSettingsInApp();
            //Simulation
            simController = new SimController();
            checkSimButton();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            UpdateVersionLabel();
            RefreshSettingLabel();
            lblPort.KeyPress += new KeyPressEventHandler(lblPort_KeyPress);

        }
        public Button GetFileExpButton()
        {
            return btnLogFileExplorer;
        }
        public Button GetSimulationButton()
        {
            return btnSimulation;
        }
        public Button GetStartCodeButton()
        {
            return btnStartCode;
        }
        public Button GetStopCodeButton()
        {
            return btnStopCode;
        }
        public Button GetEditCodeButton()
        {
            return btnEditCode;
        }
        public Button GetUpdateSimButton()
        {
            return btnUpdateSim;
        }
        public Button GetCodeFileExpButton()
        {
            return btnCodeFileExplorer;
        }
        private void lblPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece sayılar, boşluk, backspace ve silme tuşlarına izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bu karakteri engelle
            }
        }

        public void checkSimButton()
        {
            if (simController.checkSimFolder())
            {
                btnSimulation.Text = "START SIMULATION";
                btnUpdateSim.Enabled = true;
                btnStartCode.Enabled = true;
                btnStopCode.Enabled = true;
                btnEditCode.Enabled = true;
            }
            else
            {
                btnSimulation.Text = "DOWNLOAD SIMULATION";
                btnUpdateSim.Enabled = false;
                btnStartCode.Enabled = false;
                btnStopCode.Enabled = false;
                btnEditCode.Enabled = false;
            }
        }
        private void RefreshSettingLabel()
        {
            try
            {
                Dictionary<string, string> configValues = ReadFromFileSetting();
                lblHostIP.Text = configValues["Ip"];
                lblHostName.Text = configValues["Username"];
                lblHostPass.Text = configValues["Password"];
                lblFrontName.Text = configValues["FrontCamName"];
                lblDownName.Text = configValues["DownCamName"];
                lblPixhawkName.Text = configValues["PixhawkName"];
                txtBoxLog.Text = configValues["LogPath"];
                lblDistanceName.Text = configValues["DistanceName"];
                lblHydrophoneName.Text = configValues["HydrophoneName"];
                lblPort.Text = configValues["Port"];
                trackTheme.Value = (configValues["Theme"] == "true") ? 1 : 0;
                txtCodePath.Text = configValues["CodesPath"];
            }
            catch (Exception ex)
            {
                WriteFileSetting();
                console.Log("Error: " + ex.Message);
                RefreshSettingLabel();
            }
        }
        private Dictionary<string, string> ReadFromFileSetting()
        {
            Dictionary<string, string> configValues = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(configPath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('=');
                if (parts.Length == 2)
                {
                    configValues[parts[0]] = parts[1];
                }
            }
            return configValues;
        }

        private void WriteFileSetting(string ip = "raspberrypi", string username = "raspberrypi", string password = "123456",
            string fName = "cam1", string dName = "cam2", string pxName = "pixhawkdata", string pathLog = "", string disName = "distance",
            string hydrName = "hydrophone", string port = "65432", string theme = "false", string versionSim = "null", string codesPath = "")
        {
            if (VERSIONSIM != "null" || VERSIONSIM != "")
            {
                versionSim = VERSIONSIM;
            }
            bool write = false;
            if (pathLog == "")
            {
                pathLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DolunayGroundStation";
                if (!Directory.Exists(pathLog)) // Create the folder if it doesn't exist
                {
                    Directory.CreateDirectory(pathLog);
                    write = true;
                }
                else
                {
                    if (!File.Exists(configPath))
                    {
                        File.Create(configPath).Close();
                        write = true;
                    }
                }
                PATHLOG = pathLog;
            }
            else
            {
                if (PATHLOG != pathLog)
                {
                    PATHLOG = pathLog;
                }
                else
                {
                    if (!File.Exists(configPath))
                    {
                        File.Create(configPath).Close();
                    }
                }
                write = true;
            }
            if (codesPath == "")
            {
                string cpath = AppDomain.CurrentDomain.BaseDirectory + "\\Codes";
                Directory.CreateDirectory(cpath);
                codesPath = cpath;
            }
            if (write || notValidData)
            {
                string[] lines = {
                "Ip="+ip,
                "Username="+username,
                "Password="+password,
                "Port="+port,
                "FrontCamName="+fName,
                "DownCamName="+dName,
                "PixhawkName="+pxName,
                "DistanceName="+disName,
                "HydrophoneName="+hydrName,
                "LogPath="+pathLog,
                "Theme="+theme,
                "VersionSim="+versionSim,
                "CodesPath="+codesPath
                };
                // Write to the file
                File.WriteAllLines(configPath, lines);
                console.Log("Settings updated.");
                notValidData = false;
            }

        }
        private void WriteFileFromLabel()
        {
            WriteFileSetting(lblHostIP.Text, lblHostName.Text, lblHostPass.Text, lblFrontName.Text, lblDownName.Text, lblPixhawkName.Text,
                txtBoxLog.Text, lblDistanceName.Text, lblHydrophoneName.Text, lblPort.Text, trackTheme.Value == 1 ? ("true") : ("false"), VERSIONSIM, txtCodePath.Text);
        }

        public void RefreshSettingData()
        {
            WriteFileFromLabel();
            UpdateSettingsInApp();
        }
        private void UpdateSettingsInApp()
        {
            Dictionary<string, string> configValues = ReadFromFileSetting();
            try
            {
                HOST = configValues["Ip"];
                USERNAME = configValues["Username"];
                PASSWORD = configValues["Password"];
                FRONTCAMNAME = configValues["FrontCamName"];
                UNDERCAMNAME = configValues["DownCamName"];
                PIXHAWKNAME = configValues["PixhawkName"];
                PATHLOG = configValues["LogPath"];
                DISTANCE = configValues["DistanceName"];
                HYDROPHONE = configValues["HydrophoneName"];
                PORT = int.Parse(configValues["Port"]);
                THEME = bool.Parse(configValues["Theme"]);
                VERSIONSIM = configValues["VersionSim"];
                CODESPATH = configValues["CodesPath"];
            }
            catch (Exception ex)
            {
                notValidData = true;
                WriteFileSetting();
                console.Log("Error: " + ex.Message);
            }

        }

        private void UpdateVersionLabel()
        {
            lblAppVersion.Text = "Dolunay Ground Station v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        private void btnFileExpoler_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyDocuments;
                folderBrowserDialog1.SelectedPath = Environment.SpecialFolder.MyDocuments.ToString();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtBoxLog.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnSimulation_Click(object sender, EventArgs e)
        {

            simController.StartSim();
            RefreshSettingData();
            checkSimButton();
        }

        private void btnUpdateSim_Click(object sender, EventArgs e)
        {
            simController.UpdateSim();
            RefreshSettingData();
        }

        private void btnCodeFileExplorer_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.SelectedPath = CODESPATH;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtCodePath.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnStartCode_Click(object sender, EventArgs e)
        {
            simController.StartSimCode();
        }

        private void btnStopCode_Click(object sender, EventArgs e)
        {
            simController.StopSimCode();
        }

        private void btnEditCode_Click(object sender, EventArgs e)
        {
            simController.EditSimCode();
        }
        
    }
}
