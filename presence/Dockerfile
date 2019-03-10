ARG BUILD_FROM=hassioaddons/base:2.3.1
FROM ${BUILD_FROM} as build

RUN apk update && \
    apk add --no-cache git make musl-dev go

# Configure Go
ENV GOROOT /usr/lib/go
ENV GOPATH /go
ENV PATH /go/bin:$PATH

RUN mkdir -p "$GOPATH/src" "$GOPATH/bin" && chmod -R 777 "$GOPATH"

ENV ADD_ON_VERSION 1.1.0
RUN go get github.com/helto4real/go-daemon/hassio

WORKDIR /go/src/github.com/helto4real/go-daemon/hassio

RUN go get -d -v ./... && \
    go install -v ./... && \
    cd /go/src/github.com/helto4real/go-daemon/hassio

RUN go build

FROM ${BUILD_FROM} AS runtime

RUN mkdir /hassio
RUN mkdir /hassio/config
COPY --from=build /go/src/github.com/helto4real/go-daemon/hassio/hassio /hassio
COPY --from=build /go/src/github.com/helto4real/go-daemon/hassio/go-daemon.yaml /hassio/config
WORKDIR /hassio
CMD ["/hassio/hassio"]


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
    org.label-schema.description="A better presence, a community app written in golang" \
    org.label-schema.build-date=${BUILD_DATE} \
    org.label-schema.name="Presence" \
    org.label-schema.schema-version="1.0" \
    org.label-schema.url="https://addons.community" \
    org.label-schema.usage="https://github.com/hassio-addons/addon-example/tree/master/README.md" \
    org.label-schema.vcs-ref=${BUILD_REF} \
    org.label-schema.vcs-url="https://github.com/hassio-addons/addon-example" \
    org.label-schema.vendor="Community Hass.io Addons"