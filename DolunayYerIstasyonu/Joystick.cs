using Newtonsoft.Json;
using SharpDX.XInput;



namespace DolunayGroundStation
{
    internal class Joystick
    {
        Controller controller = new Controller(UserIndex.One);
        public Joystick()
        {
            // Constructor - Initializes the joystick.
        }

        private JoystickData ListenUserInput()
        {
            // Listen to user input and retrieve joystick data.
            State state = controller.GetState();
            JoystickData joystickData = new JoystickData
            {
                // Check buttons
                YButton = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y),
                XButton = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X),
                AButton = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A),
                BButton = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B),
                BackButton = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back),
                MenuButton = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start),

                // Left Analog Joystick (Left Stick)
                LeftThumbX = NormalizeValue(state.Gamepad.LeftThumbX),
                LeftThumbY = NormalizeValue(state.Gamepad.LeftThumbY),

                // Right Analog Joystick (Right Stick)
                RightThumbX = NormalizeValue(state.Gamepad.RightThumbX),
                RightThumbY = NormalizeValue(state.Gamepad.RightThumbY)
            };
            return joystickData;
        }

        public string GetJoystickData()
        {
            // Get joystick data in JSON format.
            try
            {
                JoystickData joystickData = ListenUserInput();
                string jsonData = JsonConvert.SerializeObject(joystickData);
                return jsonData;
            }
            catch (Exception ex)
            {
                return "Gamepad not connected";
            }

        }
        public bool getControllerCon()
        {
            return controller.IsConnected;
        }
        private float NormalizeValue(short value)
        {
            // Normalize a value between -32768 and 32767 to the range -1000 to 1000
            // Normalize a value between -32768 and 32767 to the range -1000 to 1000 with 100-unit increments

            float normalizedValue = (float)value / 32768f * 1000f;

            // Round to 100-unit increments
            normalizedValue = (float)Math.Round(normalizedValue / 100) * 100;

            return normalizedValue;
        }

    }
}
