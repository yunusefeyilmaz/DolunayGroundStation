namespace DolunayYerIstasyonu
{
    internal class JoystickData
    {
        public bool YButton { get; set; }
        public bool XButton { get; set; }
        public bool AButton { get; set; }
        public bool BButton { get; set; }
        public bool BackButton { get; set; }
        public bool MenuButton { get; set; }
        public float LeftThumbX { get; set; }
        public float LeftThumbY { get; set; }
        public float RightThumbX { get; set; }
        public float RightThumbY { get; set; }
        public JoystickData()
        {
            MenuButton = false;
            BackButton = false;
            YButton = false;
            XButton = false;
            AButton = false;
            BButton = false;
            LeftThumbX = 0f;
            LeftThumbY = 0f;
            RightThumbX = 0f;
            RightThumbY = 0f;
        }
    }
}
