# Better presence add-on (alpha)
This add-on makes a combination of trackers to get better tracking capabilies in home assistant
Checkout 
https://philhawthorne.com/making-home-assistants-presence-detection-not-so-binary/ as inspiration

Basically the state will go:

```
Home->Just left->Away->Zone

Home->Just left->Home

Away->Just arrived->Home

```
# Configuration add-on
For best results recommend using one tracker that is of router typr and one tracker that is of bluetooth type and finally the third tracker that is of gps type. 

You will need **atleast** one of router/bluetooth typo and one of gps type trackers.
 
The name of the device in Home Assistant will be `sensor.[id]_presence`

## Example of two persons and their trackers.
```json
{
    "log_level": "info",
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