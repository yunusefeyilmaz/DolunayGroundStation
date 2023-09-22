using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DolunayYerIstasyonu
{
    public partial class SettingsForm : Form
    {
        private string dosyaAdi = "config.txt";
        Main main;
        public SettingsForm(Main main)
        {
            this.main = main;   
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            RefreshSettingLabel();
        }
        private void RefreshSettingLabel()
        {
            Dictionary<string, string> configValues = ReadFromFileSetting();
            lblHostIP.Text = configValues["Ip"];
            lblHostName.Text = configValues["Username"];
            lblHostPass.Text = configValues["Password"];
            lblFrontName.Text = configValues["FrontCamName"];
            lblDownName.Text = configValues["DownCamName"];
            lblPixhawkName.Text = configValues["PixhawkName"];
        }
        public void CheckConfFile()
        {
            // Dosyanın varlığını kontrol edin
            if (!File.Exists(dosyaAdi))
            {
                File.Create(dosyaAdi).Close();
                WriteFileSetting();
            }
        }
        public Dictionary<string, string> ReadFromFileSetting()
        {
            Dictionary<string, string> configValues = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(dosyaAdi);

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
            string fName = "cam1", string dName = "cam2", string pxName = "pixhawkdata")
        {
            string[] lines = {
            "Ip="+ip,
            "Username="+username,
            "Password="+password,
            "FrontCamName="+fName,
            "DownCamName="+dName,
            "PixhawkName="+pxName
        };
            // Dosyayı yazma işlemi
            File.WriteAllLines(dosyaAdi, lines);
            main.writeInfo("Ayarlar güncellendi.");
        }
        public void WriteFileFromLabel()
        {
            WriteFileSetting(lblHostIP.Text, lblHostName.Text, lblHostPass.Text, lblFrontName.Text, lblDownName.Text, lblPixhawkName.Text);
        }
    }
}
