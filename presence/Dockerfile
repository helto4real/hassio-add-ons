#
# Multi stage build of add-on container
#

ARG BUILD_FROM=homeassistant/amd64-base:3.10

# STAGE 1: Build the binary
FROM golang:1.13.4-alpine3.10 as build

# Build arguments
ARG BUILD_ARCH

# Add-on version
ENV ADD_ON_VERSION 1.2.0

# Install git for go get command and get the repo
RUN \
    apk add --no-cache git\
    && go get github.com/helto4real/go-daemon/hassio

WORKDIR /go/src/github.com/helto4real/go-daemon/hassio

# Install dependencies and build the binary to target platform
RUN \
    go get -d -v ./... \
    && go install -v ./... \
    && cd /go/src/github.com/helto4real/go-daemon/hassio \
    && \
    if [ "${BUILD_ARCH}" = "armhf" ]; then \
    GOOS=linux GOARCH=arm go build; \
    elif [ "${BUILD_ARCH}" = "armv7" ]; then \
    GOOS=linux GOARM=7 GOARCH=arm go build; \
    elif [ "${BUILD_ARCH}" = "aarch64" ]; then \
    GOOS=linux GOARCH=arm64 go build; \
    elif [ "${BUILD_ARCH}" = "i386" ]; then \
    GOOS=linux GOARCH=386 go build; \
    elif [ "${BUILD_ARCH}" = "amd64" ]; then \
    GOOS=linux GOARCH=amd64 go build; \
    else \
    echo 'NOT VALID BUILD'; exit 1; \
    fi

# STAGE 2: Include binary in target add-on container
FROM ${BUILD_FROM} AS runtime

# Prepare target folders
RUN \
    mkdir /hassio \
    mkdir /hassio/config

# Copy binary and the config from build container
COPY --from=build /go/src/github.com/helto4real/go-daemon/hassio/hassio /hassio
COPY --from=build /go/src/github.com/helto4real/go-daemon/hassio/go-daemon.yaml /hassio/config

WORKDIR /hassio
CMD ["/hassio/hassio"]

#
# LABEL target docker image
#

# Build arguments
ARG BUILD_ARCH
ARG BUILD_DATE
ARG BUILD_REF
ARG BUILD_VERSION

# Labels
LABEL \
    io.hass.name="Better presence" \
    io.hass.description="A smarter presence add-on written in golang" \
    io.hass.arch="${BUILD_ARCH}" \
    io.hass.type="addon" \
    io.hass.version=${BUILD_VERSION} \
    maintainer="Tomas Hellström <tomas.hellstrom@yahoo.se>" \
    org.label-schema.description="A better presence, a community add-on written in golang" \
    org.label-schema.build-date=${BUILD_DATE} \
    org.label-schema.name="Presence" \
    org.label-schema.schema-version="1.0" \
    org.label-schema.url="https://addons.community" \
    org.label-schema.usage="https://github.com/hassio-addons/addon-example/tree/master/README.md" \
    org.label-schema.vcs-ref=${BUILD_REF} \
    org.label-schema.vcs-url="https://github.com/hassio-addons/addon-example" \
    org.label-schema.vendor="Community Hass.io Addons"