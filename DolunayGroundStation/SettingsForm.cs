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
        public static string DISTANCE = "";
        public static string HYDROPHONE = "";
        public static int PORT = 65432;
        public static bool THEME = true;
        private string dosyaAdi = "config.txt";
        private Main main;
        private LoggerConsole console;
        private bool notValidData = false;
        public SettingsForm()
        {

        }
        public SettingsForm(Main main, LoggerConsole console)
        {

            this.console = console;
            InitializeComponent();
            this.main = main;
            WriteFileSetting();
            UpdateSettingsInApp();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            RefreshSettingLabel();
            lblPort.KeyPress += new KeyPressEventHandler(lblPort_KeyPress);
        }
        private void lblPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece sayılar, boşluk, backspace ve silme tuşlarına izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bu karakteri engelle
            }
        }
        public Button GetFileExpButton()
        {
            return btnFileExpoler;
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
            string[] lines = File.ReadAllLines(PATHLOG + "\\" + dosyaAdi);

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
            string hydrName = "hydrophone", string port = "65432", string theme = "false")
        {
            bool write = false;
            if (pathLog == "")
            {
                pathLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DolunayGroundStation";
                if (!Directory.Exists(pathLog)) // Create the folder if it doesn't exist
                {
                    Directory.CreateDirectory(pathLog);
                    File.Create(pathLog + "\\" + dosyaAdi).Close();
                    write = true;
                }
                else
                {
                    if (!File.Exists(pathLog + "\\" + dosyaAdi))
                    {
                        File.Create(pathLog + "\\" + dosyaAdi).Close();
                        write = true;
                    }
                }
                PATHLOG = pathLog;
            }
            else
            {
                if (PATHLOG != pathLog)
                {
                    File.Create(pathLog + "\\" + dosyaAdi).Close();
                    PATHLOG = pathLog;
                }
                else
                {
                    if (!File.Exists(pathLog + "\\" + dosyaAdi))
                    {
                        File.Create(pathLog + "\\" + dosyaAdi).Close();
                    }
                }
                write = true;
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
                "Theme="+theme
                };
                // Write to the file
                File.WriteAllLines(pathLog + "\\" + dosyaAdi, lines);
                console.Log("Settings updated.");
                notValidData = false;
            }

        }
        private void WriteFileFromLabel()
        {
            WriteFileSetting(lblHostIP.Text, lblHostName.Text, lblHostPass.Text, lblFrontName.Text, lblDownName.Text, lblPixhawkName.Text,
                txtBoxLog.Text, lblDistanceName.Text, lblHydrophoneName.Text, lblPort.Text, trackTheme.Value == 1 ? ("true") : ("false"));
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
            }
            catch (Exception ex)
            {
                WriteFileSetting();
                console.Log("Error: " + ex.Message);
                notValidData = true;
            }

        }

        private void btnFileExpoler_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyDocuments;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBoxLog.Text = folderBrowserDialog1.SelectedPath;
            }
        }

    }
}
