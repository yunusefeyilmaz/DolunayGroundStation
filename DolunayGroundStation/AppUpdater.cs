using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace DolunayGroundStation
{
    public class AppUpdater
    {
        Main main;
        LoggerConsole console;
        public AppUpdater(Main main, LoggerConsole console)
        {
            this.main = main;
            this.console = console;
            WebClient webClient = new WebClient();
            try
            {
                if (!webClient.DownloadString("https://myspace.eu5.org/UpdateDolunay/updateversion.html").Contains(Assembly.GetExecutingAssembly().GetName().Version.ToString()))
                {
                    if (MessageBox.Show("New version available. Do you want to download?",
                        "Update"
                        , MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes) 
                        using (var client = new WebClient())
                        {
                            Process.Start("Updater.exe");
                            main.Close();
                        }
                }
            }
            catch (Exception ex)
            {
                console.Log("Error: " + ex.Message);
                console.Log("Connect to the internet to check for new versions");
            }
        }


    }

}
