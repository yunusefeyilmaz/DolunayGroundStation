using Renci.SshNet;
using System.Diagnostics;

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
                var rebootCommand = "sleep 3 && sudo reboot";
                var rebootResponse = client.RunCommand(rebootCommand);
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
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                };
                Process process = new Process { StartInfo = psi };
                process.Start();
                StreamWriter sw = process.StandardInput;
                StreamReader sr = process.StandardOutput;

                sw.WriteLine($"ssh -t {SettingsForm.USERNAME}@{SettingsForm.HOST}");
                sw.WriteLine(SettingsForm.PASSWORD);
                process.Close();
            }
            catch (Exception ex)
            {
                console.Log("SSH console could not be created.");
            }
            finally
            {
                Disconnect();
            }
        }

    }
}
