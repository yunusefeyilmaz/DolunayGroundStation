using Renci.SshNet;

namespace DolunayYerIstasyonu
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
                console.Log("Attempting emergency stop. Please wait.");
                var pythonKillCommand = "sudo pkill python && sleep 3 && sudo reboot";
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

        public ShellStream CreateShellStream()
        {
            try
            {
                return client.CreateShellStream("dumb", 80, 24, 800, 600, 1024);
            }
            catch (Exception ex)
            {
                console.Log("SSH console could not be created.");
                return null;
            }
        }

    }
}
