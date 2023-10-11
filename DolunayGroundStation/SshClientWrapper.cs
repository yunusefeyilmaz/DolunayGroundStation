using Renci.SshNet;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DolunayGroundStation
{
    internal class SshClientWrapper
    {
        private readonly SshClient client;
        private LoggerConsole console;
        public SshClientWrapper(string ip, string username, string password, LoggerConsole console)
        {
            client = new SshClient(ip, username, password);
            this.console = console;
        }

        public void Connect()
        {
            try
            {
                console.Log("Attempting to establish an SSH connection. Please wait.");
                client.Connect();
                console.Log("SSH connection established.");
            }
            catch (Exception ex)
            {
                console.Log("Unable to establish an SSH connection.");
                console.Log("Error: " + ex.Message);
                throw ex;
            }
        }

        public void Disconnect()
        {
            client.Disconnect();
        }

        public void ExecuteEmergencyStop()
        {
            try
            {
                Connect();
                console.Log("Attempting emergency stop. Please wait.");
                var pythonKillCommand = "sudo pkill python";
                var pythonKillResponse = client.RunCommand(pythonKillCommand);
                console.Log("Emergency stop executed successfully.");
            }
            catch (Exception ex)
            {
                console.Log("Emergency stop commands could not be executed.");
                console.Log("Error: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        public void CreateShellStream()
        {
            try
            {
                Connect();
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/K ssh {SettingsForm.USERNAME}@{SettingsForm.HOST}";
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true; // UseShellExecute'yi true o
                startInfo.RedirectStandardInput = false; 
                startInfo.RedirectStandardOutput = false; 
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Exception ex)
            {
                console.Log("SSH console could not be created.");
                console.Log("Error: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }

        }

    }
}
