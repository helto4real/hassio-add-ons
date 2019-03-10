# Better presence add-on (1.1.0)
This add-on makes a combination of trackers to get better tracking capabilies in home assistant
Checkout 
https://philhawthorne.com/making-home-assistants-presence-detection-not-so-binary/ as inspiration


The reason for this is the new person that can only take device_tracker as device, not sensor. Everything else is the same.

Basically the state will go:

```
Home->Just left->Away->Zone

Home->Just left->Home

Away->Just arrived->Home

```
# Add add-on
Go to ADD-ON-STORE and add the https://github.com/helto4real/hassio-add-ons to "Add new repository by URL".

After that helto4real add-ons should show under the title: Helto4Real Hass.io Add-ons

# Configuration add-on
For best results recommend using one tracker that is of router type and one tracker that is of bluetooth type and finally the third tracker that is of gps type. 

You will need **atleast** one of router/bluetooth type and one of gps type trackers.

The name of the device tracker in Home Assistant will be `device_tracker.[id]_presence`

## Example of two persons and their trackers.


```json
{
    "log_level": "info",
    "tracking": {
        "just_arrived_time": 300,
        "just_left_time": 60,
        "home_state": "Home",
        "just_left_state": "Just left",
        "just_arrived_state": "Just arrived",
        "away_state": "Away"
    },
    "persons": [
        {
            "id": "thomas",
            "friendly_name": "Thomas",
            "devices": [
                "device_tracker.thomas_gps_tracker",
                "device_tracker.thomas_bt_tracker",
                "device_tracker.thomas_router_tracker"
            ]
        },
        {
            "id": "dawn",
            "friendly_name": "Dawn",
            "devices": [
                "device_tracker.dawns_gps_tracker",
                "device_tracker.dawns_bt_tracker",
                "device_tracker.dawns_router_tracker"
            ]
        }
    ]
}
```

### Settings

|  Setting |  Description  |
|:--------|:-------------|
| just_arrived_time | Time from just arrived to be considered home (seconds)  |
| just_left_time | Time from just left to be considered away (seconds)       |
| home_state | Value of home state |
| just_left_state | Value of state representing just left |
| just_arrived_state | Value of state representing just arrived |
| away_state | Value of away state |
