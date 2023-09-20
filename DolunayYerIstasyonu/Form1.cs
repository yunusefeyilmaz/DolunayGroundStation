using Newtonsoft.Json;
using Renci.SshNet;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace DolunayYerIstasyonu
{
    public partial class Form1 : Form
    {
        public TcpListener listener;
        double roll = 150;
        double tilt = 0;
        double pitch = 0;
        private Thread trd;
        public Form1()
        {
            InitializeComponent();
            pbCompass.Image = Compass.DrawCompass(0, pitch, 80, tilt, 80, roll, 180, pbCompass.Size);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Bütün Ip'lerden gelen sinyalleri dinleme
            listener = new TcpListener(IPAddress.Any, 65432);
            this.Controls.Add(CameraImg);
            this.Controls.Add(CameraDown);
        }
        private void ImageTimerElapsed()
        {
            try
            {
                // Yeni verileri almak için TCP dinleyicisi kullanma.
                using TcpClient client = listener.AcceptTcpClient();
                using NetworkStream stream = client.GetStream();
                {
                    while (true)
                    {
                        byte[] buffer = new byte[300 * 420 * 3 * 2 + 2048];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        string jsonData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        // JSON verisini iþleme.
                        Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
                        // Verilerin boþ gelmediðini onaylama ve baðlantýnýn kurulduðunu kontrol etme.
                        if (data == null) { conCheck = false; continue; }
                        conCheck = true;
                        // Pixhawk verilerini json formatýndan okuma ve ekrana gösterme.
                        Dictionary<string, object> pixhawkdata = JsonConvert.DeserializeObject<Dictionary<string, object>>(data["data"].ToString());
                        setDatatoLbl(pixhawkdata);
                        // Kamera görüntülerinin json formatýndan okunmasý.
                        string frame1Base64 = data["kamera1"].ToString();
                        string frame2Base64 = data["kamera2"].ToString();
                        // Base64 ile kodlanmýþ görüntüyü çözme.
                        byte[] frame1Bytes = Convert.FromBase64String(frame1Base64);
                        byte[] frame2Bytes = Convert.FromBase64String(frame2Base64);
                        // Kameralarýn çalýþýp çalýþmadýðýný analiz etme.
                        if (CameraImg != null) { frontCamCheck = true; }
                        if (CameraDown != null) { downCamCheck = true; }
                        // Görüntüleri PictureBox'larda gösterme.
                        if (frame1Bytes != null) CameraImg.Image = ByteArrayToImage(frame1Bytes);
                        if (frame2Bytes != null) CameraDown.Image = ByteArrayToImage(frame2Bytes);
                        // Ekrandaki yazýlarýn güncellenmesi.
                        RefreshConnectionLabel();
                        // Baðlantý kapatýldýysa cliente kapatma.
                        if (!conCheckBtn) client.Close();
                        // Gelen verilerin alýndýðýný karþý tarafa iletme.
                        string responseMessage = "received";
                        byte[] responseBuffer = Encoding.ASCII.GetBytes(responseMessage);
                        stream.Write(responseBuffer, 0, responseBuffer.Length);

                        Thread.Sleep(10);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Hata oluþtu: " + ex.Message + ex.ToString());
            }
        }
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
        private void setDatatoLbl(Dictionary<string, object> pixhawkdata)
        {
            /* 
             *** DATA FORMAT ***
            "pixhawkdata": {
            "yaw":  ,
            "roll": ,
            "pitch":    ,
            "basinc":   ,
            "servo1":   ,
            "servo2":   ,
            "servo3":   ,
            "servo4":   ,
            "servo5":   ,
            "servo6":   ,   
            "servo7":   ,
            "servo8":   ,
            "mode": ,
            "arm":  
            }
             */
            Invoke((MethodInvoker)delegate
            {

                double deg = Math.Round(float.Parse(pixhawkdata["yaw"].ToString()), 3);
                deg = MapWithNegatives(deg);
                pbCompass.Image = Compass.DrawCompass(deg, pitch, 80, tilt, 80, roll, 80, pbCompass.Size);
                lblYaw.Text = Math.Round(float.Parse(pixhawkdata["yaw"].ToString()), 3).ToString();
                lblRoll.Text = Math.Round(float.Parse(pixhawkdata["roll"].ToString()), 3).ToString();
                lblPitch.Text = Math.Round(float.Parse(pixhawkdata["pitch"].ToString()), 3).ToString();
                lblPressure.Text = Math.Round(float.Parse(pixhawkdata["basinc"].ToString()), 3).ToString() + " M";
                if (float.Parse(pixhawkdata["basinc"].ToString()) == 0) presCheck = false;
                List<Label> servos = new List<Label>() {
                 lblServo1, lblServo2, lblServo3, lblServo4, lblServo5, lblServo6, lblServo7, lblServo8};
                int i = 1;
                foreach (var servo in servos)
                {
                    servo.Text = i.ToString() + " - " + pixhawkdata["servo" + (i++).ToString()].ToString();
                }
                lblMode.Text = pixhawkdata["mode"].ToString();
                lblArm.Text = pixhawkdata["arm"].ToString();
            });
        }
        private void StartDataListen()
        {
            listener.Start();
            trd = new Thread(new ThreadStart(this.ImageTimerElapsed));
            trd.IsBackground = true;
            trd.Start();
        }
        private void CloseDataListen()
        {
            trd.Interrupt();
        }

        bool conCheckBtn = false;
        bool conCheck = false;
        bool presCheck = false;
        bool frontCamCheck = false;
        bool downCamCheck = false;
        private void btnCon_Click(object sender, EventArgs e)
        {
            if (!conCheckBtn)
            {
                // Ethernet üzerinden resim alma iþlemini baþlatýn 
                StartDataListen();
                writeInfo("SERVER BASARIYLA BASLATILDI.", true);
                conCheckBtn = true;
                RefreshConnectionLabel();
            }
            else
            {
                CloseDataListen();
                conCheckBtn = false;
                writeInfo("SERVER BASARIYLA KAPATILDI.", false);
                RefreshConnectionLabel();
            }
        }

        private void RefreshConnectionLabel()
        {
            Invoke((MethodInvoker)delegate
            {
                if (conCheckBtn)
                {
                    if (conCheck) { lblCon.Text = "Baðlandý"; lblCon.ForeColor = Color.LightGreen; }
                    else { lblCon.Text = "Baðlantý Kesildi"; lblCon.ForeColor = Color.Red; }

                    btnCon.BackColor = Color.Red;
                    btnCon.Text = "Baðlantýyý Durdur";

                    if (presCheck) { lblPresText.Text = "Çalýþýyor"; lblPresText.ForeColor = Color.LightGreen; }
                    else { lblPresText.Text = "Çalýþmýyor"; lblPresText.ForeColor = Color.Red; }

                    if (frontCamCheck) { lblFrontCam.Text = "Çalýþýyor"; lblFrontCam.ForeColor = Color.LightGreen; }
                    else { lblFrontCam.Text = "Çalýþmýyor"; lblFrontCam.ForeColor = Color.Red; }

                    if (downCamCheck) { lblUnderCam.Text = "Çalýþýyor"; lblUnderCam.ForeColor = Color.LightGreen; }
                    else { lblUnderCam.Text = "Çalýþmýyor"; lblUnderCam.ForeColor = Color.Red; }
                }
                else
                {
                    btnCon.BackColor = Color.Lime;
                    btnCon.Text = "Baðlantýyý Baþlat";

                    presCheck = false;

                    lblPresText.Text = "Baðlantý Yok";
                    lblPresText.ForeColor = Color.Red;

                    frontCamCheck = false;

                    lblFrontCam.Text = "Baðlantý Yok";
                    lblFrontCam.ForeColor = Color.Red;

                    lblUnderCam.Text = "Baðlantý Yok";
                    lblUnderCam.ForeColor = Color.Red;

                    lblCon.Text = "Baðlantý Kesildi";
                    lblCon.ForeColor = Color.Red;
                }
            });
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARAC ACIL DURDURULACAK EMIN MISINIZ?", "ACIL DURDUR", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string IP = "raspberrypi";
                string username = "dolunay";
                string password = "123456";
                try
                {
                    using (var client = new SshClient(IP, username, password))
                    {
                        client.Connect();
                        // Önce Python iþlemlerini sonlandýr
                        var pythonKillCommand = "sudo pkill python && sleep 3 && sudo reboot";
                        var pythonKillResponse = client.RunCommand(pythonKillCommand);
                        writeInfo(pythonKillResponse.Result);
                        client.Disconnect();
                    }

                    writeInfo("ACIL DURUM KOMUTLARI CALISTIRILDI.", true);
                }
                catch
                {
                    writeInfo("ACIL DURUM KOMUTLARI ILETILEMEDI.", false);
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                writeInfo("ACIL DURUM IPTAL EDILDI.", false);
            }
        }

        private void writeInfo(string text, bool T = true)
        {
            Invoke((MethodInvoker)delegate
            {
                if (T)
                {
                    lblInfo.Text = text;
                    lblInfo.ForeColor = Color.LightGreen;
                }
                else
                {
                    lblInfo.Text = text;
                    lblInfo.ForeColor = Color.Red;
                }
            });
        }

        static double Map(double value, double fromMin, double fromMax, double toMin, double toMax)
        {
            // Girdi deðeri (value) ve girdi aralýðý (fromMin - fromMax) ile çýktý aralýðý (toMin - toMax) arasýnda lineer bir dönüþüm yapar.
            return (value - fromMin) * (toMax - toMin) / (fromMax - fromMin) + toMin;
        }
        static double MapWithNegatives(double value)
        {
            // 0'dan büyük veya eþitse, 0 ile 3.14 arasýndaki dönüþümü uygula
            if (value >= 0) { return Map(value, 0.0, 3.14, 0.0, 180.0); }
            // Negatifse, -3.14 ile 0 arasýndaki dönüþümü uygula
            else { return Map(value, -3.14, 0.0, 181.0, 359.0); }
        }

    }

}
