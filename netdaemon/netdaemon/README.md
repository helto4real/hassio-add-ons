# This is the dev setup for NetDaemon

This is the development enviroment for NetDaemon.

## Getting started

1. Edit the config.json file to provide details about how to connect to Home Assistant. You will need a long lived token, ip, port.
2. Run dotnet restore in the terminal
3. Add and edit your apps in the apps folder.
4. Copy the edited apps to the folder `netdaemon` under your Hass.io config folder
5. Install the Hass.io add-on by adding the `https://github.com/helto4real/hassio-add-ons` to the add-on store and install NetDaemon
6. Run the add-on and check the log you new apps is intitialized


For detailed information about netdaemon please see [https://helto4real.github.io/netdaemon/](https://helto4real.github.io/netdaemon/).