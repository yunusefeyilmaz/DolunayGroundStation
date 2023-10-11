using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;

namespace Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WebClient webClient = new WebClient();
            var client = new WebClient();
            try
            {
                System.Threading.Thread.Sleep(5000);
                File.Delete(@".\DolunayGroundStation.exe");
                client.DownloadFile("https://myspace.eu5.org/UpdateDolunay/DolunayGroundStation.zip", @"DolunayGroundStation.zip");
                string zipPath = @".\DolunayGroundStation.zip";
                string extractPath = @".\";
                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string entryPath = Path.Combine(extractPath, entry.FullName);
                        entry.ExtractToFile(entryPath, true); // Overwrite existing files
                    }
                }
                File.Delete(@".\DolunayGroundStation.zip");
                Process.Start(@".\DolunayGroundStation.exe");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                Process.Start(@".\DolunayGroundStation.exe");
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
