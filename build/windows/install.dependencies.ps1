# Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
# Licensed under the Apache License, Version 2.0.

param (
    [string]$pfxUri = ''
)

Write-Host "Downloading NuGet"
$sourceNugetExe = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
$targetNugetExe = "$PSScriptRoot\..\..\tools\windows\nuget.exe"
Invoke-WebRequest $sourceNugetExe -OutFile $targetNugetExe

Write-Host "Downloading Ghostscript 10.00.0"
$sourceGhostscriptExe = "https://github.com/ArtifexSoftware/ghostpdl-downloads/releases/download/gs1000/gs1000w32.exe"
$targetGhostscriptExe = "$PSScriptRoot\..\..\tools\windows\gs1000w32.exe"
Invoke-WebRequest $sourceGhostscriptExe -OutFile $targetGhostscriptExe

Write-Host "Downloading FFmpeg 4.2.3"
$sourceFFmpegExe = "https://github.com/ImageMagick/ImageMagick-Windows/releases/download/20200615/ffmpeg-4.2.3-win64.exe"
$targetFFmpegExe = "c:\vcpkg\ffmpeg.exe"
Invoke-WebRequest $sourceFFmpegExe -OutFile $targetFFmpegExe

if ($pfxUri.Length -gt 0) {
    Write-Host "Downloading code signing certificate"
    Invoke-WebRequest $pfxUri -OutFile "$PSScriptRoot\ImageMagick.pfx"
}
