namespace DolunayYerIstasyonu
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
        private string dosyaAdi = "config.txt";
        private Main main;
        private LoggerConsole console;

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
            }
            catch (Exception ex)
            {
                WriteFileSetting();
                console.Log("Error: " + ex.Message);
                RefreshSettingLabel();
            }
        }
        private void CheckConfFile()
        {
            // Check if the file exists
            string pathLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            pathLog = Path.Combine(pathLog, "DolunayYerIstasyonu\\");
            if (!File.Exists(pathLog+dosyaAdi))
            {
                File.Create(pathLog+dosyaAdi).Close();
            }
        }
        private Dictionary<string, string> ReadFromFileSetting()
        {
            Dictionary<string, string> configValues = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DolunayYerIstasyonu\\"+ dosyaAdi);

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
            string hydrName = "hydrophone")
        {
            if (pathLog == "")
            {
                pathLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                pathLog = Path.Combine(pathLog, "DolunayYerIstasyonu");
                if (!Directory.Exists(pathLog)) // Create the folder if it doesn't exist
                {
                    Directory.CreateDirectory(pathLog);
                }
            }
            CheckConfFile();
            string[] lines = {
            "Ip="+ip,
            "Username="+username,
            "Password="+password,
            "FrontCamName="+fName,
            "DownCamName="+dName,
            "PixhawkName="+pxName,
            "DistanceName="+disName,
            "HydrophoneName="+hydrName,
            "LogPath="+pathLog
            };
            // Write to the file
            File.WriteAllLines(pathLog+"\\"+dosyaAdi, lines);
            console.Log("Settings updated.");
        }
        private void WriteFileFromLabel()
        {
            WriteFileSetting(lblHostIP.Text, lblHostName.Text, lblHostPass.Text, lblFrontName.Text, lblDownName.Text, lblPixhawkName.Text,
                txtBoxLog.Text, lblDistanceName.Text, lblHydrophoneName.Text);
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
            }
            catch (Exception ex)
            {
                WriteFileSetting();
                console.Log("Error: " + ex.Message);
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
