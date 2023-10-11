using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Reflection;

namespace DolunayGroundStation
{
    public class Updater
    {
        Main main;
        LoggerConsole console;
        public Updater(Main main,LoggerConsole console) {
            this.main = main;
            this.console = console;
            WebClient webClient = new WebClient();
            try
            {
                if (!webClient.DownloadString("https://myspace.eu5.org/UpdateDolunay/updateversion.html").Contains(Assembly.GetExecutingAssembly().GetName().Version.ToString()))
                {
                    if(MessageBox.Show("New version available. Do you want to download?",
                        "Update"
                        ,MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)==DialogResult.Yes) using (var client = new WebClient())
                    {
                            Process.Start("Updater.exe");
                            main.Close();
                    }
                }
            }
            catch (Exception ex) {
                console.Log("Error: "+ex.Message);
                console.Log("Connect to the internet to check for new versions");
            }
        }    


    }

}
