using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DolunayGroundStation
{
    public class SimulationUpdater
    {
        public SimulationUpdater() 
        {
        }
        public void DownloadSimulation()
        {
            WebClient webClient = new WebClient();
            var client = new WebClient();
            try
            {
                client.DownloadFile("https://myspace.eu5.org/UpdateDolunaySim/DolunaySimulation.zip", @"DolunaySimulation.zip");
                string zipPath = @".\DolunaySimulation.zip";
                string extractPath = @".\";
                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string entryPath = Path.Combine(extractPath, entry.FullName);

                        // İlgili dosya yolunu oluştururken, alt dizini ekleyin
                        string entryDirectory = Path.GetDirectoryName(entryPath);
                        if (!string.IsNullOrEmpty(entryDirectory) && !Directory.Exists(entryDirectory))
                        {
                            Directory.CreateDirectory(entryDirectory);
                        }

                        // Dosyayı ayıklayın
                        entry.ExtractToFile(entryPath, true); // Overwrite existing files

                    }
                }
                File.Delete(@".\DolunaySimulation.zip");
                client.DownloadFile("https://myspace.eu5.org/UpdateDolunaySim/dolunay_sim.zip", @"dolunay_sim.zip");
                zipPath = @".\dolunay_sim.zip";
                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string entryPath = Path.Combine(extractPath, entry.FullName);

                        // İlgili dosya yolunu oluştururken, alt dizini ekleyin
                        string entryDirectory = Path.GetDirectoryName(entryPath);
                        if (!string.IsNullOrEmpty(entryDirectory) && !Directory.Exists(entryDirectory))
                        {
                            Directory.CreateDirectory(entryDirectory);
                        }

                        // Dosyayı ayıklayın
                        entry.ExtractToFile(entryPath, true); // Overwrite existing files
                    }
                }
                string versionSim = webClient.DownloadString("https://myspace.eu5.org/UpdateDolunaySim/updateversion.html");
                SettingsForm.VERSIONSIM = versionSim;
                File.Delete(@".\dolunay_sim.zip");
                Process.Start(@".\dolunay_sim.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        public void UpdateSimulation()
        {
            WebClient webClient = new WebClient();
            var client = new WebClient();
            try
            {
                string versionSim = webClient.DownloadString("https://myspace.eu5.org/UpdateDolunaySim/updateversion.html");
                if (!versionSim.Contains(SettingsForm.VERSIONSIM))
                {
                    if (MessageBox.Show("Dolunay Simulation new version available. Do you want to download?",
                        "Update Simulation"
                        , MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (WaitForm wait = new WaitForm(DownloadSimulation))
                        {
                            wait.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dolunay Simulation is up to date.\nVersion: " + SettingsForm.VERSIONSIM);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }   
        }
    }
    
}
