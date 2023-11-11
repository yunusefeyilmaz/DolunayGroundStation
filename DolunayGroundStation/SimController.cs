using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolunayGroundStation
{
    public class SimController
    {
        SimulationUpdater updater;
        public SimController() 
        {
            updater = new SimulationUpdater();
        }
        private string SimMainName = "TestExample.py";
        public void StartSim()
        {
            if (checkSimFolder())
            {
                Process.Start("dolunay_sim.exe");
            }
            else
            {
                DownloadSim();
            }
        }
        public void DownloadSim() {
            if (MessageBox.Show("Are you sure to download Dolunay Simulation?",
                        "Simulation Download"
                        , MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (WaitForm wait = new WaitForm(updater.DownloadSimulation))
                {
                    wait.ShowDialog();
                }
            }
        }
        public void UpdateSim()
        {
            if (checkSimFolder())
            {
                updater.UpdateSimulation();
            }
        }
        public void StopSimCode()
        {
            try
            {
                //Kill python process
                foreach (Process process in Process.GetProcesses().Where(p =>
                                                         p.ProcessName == "python"))
                {
                    process.Kill();
                }
                //Kill command line
                foreach (Process process in Process.GetProcesses().Where(p =>
                                                         p.ProcessName == "cmd"))
                {
                    process.Kill();
                }
                //Kill command line
                foreach (Process process in Process.GetProcesses().Where(p =>
                                                         p.ProcessName == "WindowsTerminal"))
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        public void StartSimCode()
        {
            try
            {
                InstallPythonPackage();
                Process pythonProcess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/K cd {SettingsForm.CODESPATH} && python " + SimMainName;
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;
                startInfo.RedirectStandardInput = false;
                startInfo.RedirectStandardOutput = false;
                pythonProcess.StartInfo = startInfo;
                pythonProcess.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        public void EditSimCode()
        {
            try
            {
                //Edit code with notepad
                System.Diagnostics.Process.Start("notepad.exe", SettingsForm.CODESPATH + "\\" + SimMainName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        public bool checkSimFolder()
        {
            return File.Exists("dolunay_sim.exe") ? true : false;
        }
        static void InstallPythonPackage()
        {
            try
            {
                //Check requirements lib.
                Process pipProcess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "pip.exe";
                string requPath = $"{SettingsForm.CODESPATH}\\" + "requirements.txt";
                startInfo.Arguments = $"install -r \"{requPath}\"  ";
                startInfo.UseShellExecute = true;
                pipProcess.StartInfo = startInfo;

                if (pipProcess.Start())
                {
                    pipProcess.WaitForExit();
                }
                else
                {
                    MessageBox.Show($"Failed to install requirements packages.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while installing requirements packages: {ex.Message}");
            }
        }
    }
}
