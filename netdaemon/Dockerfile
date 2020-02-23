
ARG BUILD_FROM=hassioaddons/base-amd64:5.0.3
#ARG BUILD_FROM=alpine

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine as build

# Avoid warnings by switching to noninteractive
#ENV DEBIAN_FRONTEND=noninteractive

# Build arguments
ARG BUILD_ARCH
# Add-on version
ENV ADDON_VERSION 0.0.27

# Configure apt and install packages
RUN \
    apk add --no-cache git \
    && git clone https://github.com/helto4real/netdaemon.git \
    && cd netdaemon \
    && git checkout master

RUN cd netdaemon/src/Service/ \
    && dotnet publish -c Release


# /netdaemon/src/Service/bin/Release/netcoreapp3.1/publish
# Switch back to dialog for any ad-hoc use of apt-get
#ENV DEBIAN_FRONTEND=noninteractive

# STAGE 2: Include binary in target add-on container
FROM ${BUILD_FROM} AS runtime

# # Prepare target folders
# RUN \
#     mkdir /daemon

# Copy binary and the config from build container
COPY --from=build /netdaemon/src/Service/bin/Release/netcoreapp3.1/publish /daemon

# Install .net core runtime deps
RUN apk add --no-cache \
    ca-certificates \
    \
    # .NET Core dependencies
    krb5-libs \
    libgcc \
    libintl \
    libssl1.1 \
    libstdc++ \
    zlib

# Configure web servers to bind to port 80 when present
ENV ASPNETCORE_URLS=http://+:80 \
    # Enable detection of running in a container
    DOTNET_RUNNING_IN_CONTAINER=true \
    # Set the invariant mode since icu_libs isn't included (see https://github.com/dotnet/announcements/issues/20)
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true \
    dotnet_version=3.1.1

# Install .NET Core
RUN wget -O dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Runtime/$dotnet_version/dotnet-runtime-$dotnet_version-linux-musl-x64.tar.gz \
    && dotnet_sha512='73a29e7f6c662beabd70d20bb4331c7a4d3fe4096002cb802f2db08946fd918681151e1cfcda537210231883852364a5c7707e11bbc28d8613ff4ec1a8e98015' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -C /usr/share/dotnet -oxzf dotnet.tar.gz \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet \
    && rm dotnet.tar.gz

ENV HASS_DAEMONAPPFOLDER /config/netdaemon

CMD [ "/daemon/Service" ]

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
    io.hass.name="Netdaemon" \
    io.hass.description="An application daemon for c# and .NET core 3.1" \
    io.hass.arch="${BUILD_ARCH}" \
    io.hass.type="addon" \
    io.hass.version=${BUILD_VERSION} \
    maintainer="Tomas Hellström <tomas.hellstrom@yahoo.se>" \
    org.label-schema.description="Netdaemon, a community add-on written in .NET core 3.1" \
    org.label-schema.build-date=${BUILD_DATE} \
    org.label-schema.name="Netdaemon" \
    org.label-schema.schema-version="1.0" \
    org.label-schema.url="https://addons.community" \
    org.label-schema.usage="https://helto4real.github.io/netdaemon/" \
    org.label-schema.vcs-ref=${BUILD_REF} \
    org.label-schema.vcs-url="https://helto4real.github.io/netdaemon/" \
    org.label-schema.vendor="Community Hass.io Addons"