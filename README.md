# SteamKiosk
SteamKiosk is an app I made for helping Steam run as a shell instead of explorer on Windows.
Please note that you will have to install steam to C:\Users\YourKioskUserNameGoesHere\Steam instead of the regular install directory. This is you can have a seperate Steam install for the kiosk.

There are currently graphical glitches with text rendering.

This program does NOT manage users breaking out of the kiosk and running explorer; please modify the kiosk user's NTUSER.DAT to prevent this.

I recommend automatically starting steam in Big Picture as well if you want to mainly use this with controllers. You can also disable updates using steam.cfg so you don't have to wait for the client to update.

.NET Framework 4 is required for this app to run.

## Screenshots
![Kiosk](https://github.com/Thomasluigi07/SteamKiosk/blob/master/.readmeimgs/kiosk.png?raw=true)
- Kiosk screen (auto resizes to the screen resolution)
![Logout Screen](https://github.com/Thomasluigi07/SteamKiosk/blob/master/.readmeimgs/logout.png?raw=true)
- Logout screen