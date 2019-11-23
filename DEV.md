# Building the add-on

make sure you login the dockerhub account
`docker login`

`docker run -ti --rm --privileged -v ~/.docker:/root/.docker -v /[path_to_plugin]/hassio-add-ons/presence:/data homeassistant/amd64-builder -v dev -t /data --all --addon`