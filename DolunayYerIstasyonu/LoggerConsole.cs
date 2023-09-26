using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DolunayYerIstasyonu
{
    public class LoggerConsole
    {
        private UIManager _manager;

        public LoggerConsole(UIManager uIManager)
        {
            // Constructor - Initializes the LoggerConsole with a UIManager instance.
            this._manager = uIManager;
        }

        public void Log(string message)
        {
            // Log a message with a timestamp and inform the UIManager.

            string time = DateTime.Now.ToString("HH:mm:ss ");
            string text = Environment.NewLine + time + " : " + message;
            _manager.setInfoTextBox(text);
        }

        public void SaveLogFile()
        {
            // Save the log messages to a log file with a timestamp.

            string time = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

            // Split the text from InfoTxtBox into lines using the Split method.
            string[] lines = _manager.GetInfoTxtBox().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            using (StreamWriter writer = new StreamWriter(SettingsForm.PATHLOG + "\\" + time.ToString() + "-LOG.txt"))
            {
                foreach (string line in lines)
                {
                    // Write each line to the file.
                    writer.WriteLine(line);
                }
                Log("Log file created.");
                writer.Close();
            }
        }

    }
}
