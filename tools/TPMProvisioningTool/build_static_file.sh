#!/bin/sh

# linux-x64
# linux-arm
dotnet publish -r "$1" -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true
