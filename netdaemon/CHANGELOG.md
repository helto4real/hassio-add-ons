# Changelog

## [0.0.30]

- Support for arm based devices (experimental)

## [0.0.31]

- Support to cancel scheduled tasks. Removed the Async versions och scheduled tasks. Use the result Task property if you want to manage the actual task instead.

## [0.0.32]

- Changed the config.json filename so it wont conflict with Home Assistant add-on config name. It will be breaking change in the dev environment. Please use the new devsetup from
  [https://github.com/helto4real/hassio-add-ons/tree/master/netdaemon/netdaemon](https://github.com/helto4real/hassio-add-ons/tree/master/netdaemon/**netdaemon)
