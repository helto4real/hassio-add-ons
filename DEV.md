# Building the add-on

make sure you login the dockerhub account
`docker login`

`docker run --rm --privileged -v ~/.docker:/root/.docker -v /[path_to_plugin]/hassio-add-ons/presence:/data homeassistant/amd64-builder -v dev -t /data --all `

**Windows machine example**
`docker run --rm --privileged -v D:/Applikationer/Docker:/root/.docker -v d:/git/hassio-add-ons/presence:/data homeassistant/amd64-builder --all -t /data`