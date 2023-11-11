# DolunayGroundStation

**The User Interface of the Dolunay Ground Station :**

![Screenshot 2023-11-11 132958](https://github.com/yunusefeyilmaz/dolunay-ground-station/assets/89478740/b87dae05-7b32-4faf-9ae6-e39c1603c830)

This application is built using .NET 6, with the purpose of enabling communication and control between the surface computer and the underwater vehicle. Communication is established via Ethernet, and the network port number used by the ground station is 65432.

### HOW TO DOWNLOAD
**Only the installation wizard has the updater.**
- The portable version works on any Windows device.
- [Click here](https://github.com/yunusefeyilmaz/dolunay-ground-station/releases/download/v2.2.0/DolunayGroundStationSetup.zip) to download setup wizard.(Run "RunThisForSetup.exe" for setup.)(Recommended)
- [Click here](https://github.com/yunusefeyilmaz/DolunayGroundStation/releases/download/v2.2.0/DolunayGroundStation-portable.zip) to download the portable version. (Recommended)
- To download the single-file Win64 version, [click here](https://github.com/yunusefeyilmaz/DolunayGroundStation/releases/download/v2.2.0/DolunayGroundStation-win64bit.zip). ([Requires .NET Desktop RunTime.](https://dotnet.microsoft.com/en-us/download/dotnet/6.0))
- To download the single-file Win32 version, [click here](https://github.com/yunusefeyilmaz/DolunayGroundStation/releases/download/v2.2.0/DolunayGroundStation-win32bit.zip). ([Requires .NET Desktop RunTime.](https://dotnet.microsoft.com/en-us/download/dotnet/6.0))

### HOW IT WORKS

1. The ground station starts a server on the network.
2. The server waits until any client connects.
3. The client sends data in the specified JSON format.
4. When a client connects, it receives data in JSON format.
5. The received data is parsed based on keywords and displayed on the screen.
6. If desired, you can create an SSH connection by changing the IP and Host name of the connected device in the settings.
7. Emergency vehicle shutdown can be performed via the SSH connection.
8. The manual control mode allows the vehicle to be controlled using a gamepad.

### WHERE IT RUNS
- It operates by connecting to small systems like Raspberry Pi, Jetson, etc.
- It works with Pixhawk data.
- Incoming image data should be encoded with base64.
- Default port value 65432.

## USED PACKAGES
- SSH.NET - Renci - Version: 2020.0.2
- SharpDX.XInput - Alexandre Mutel - Version: 4.2.0
- Newtonsoft.Json - James Newton-King - Version: 13.0.3"
