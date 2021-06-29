# Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
# Licensed under the Apache License, Version 2.0.

param (
    [string]$library,
    [string]$pfxPassword = '',
    [string]$version = $env:NuGetVersion,
    [string]$commit = $env:GitCommitId,
    [parameter(mandatory=$true)][string]$destination
)

. $PSScriptRoot\..\tools\windows\utils.ps1
. $PSScriptRoot\publish.shared.ps1

function createMagickNetLibraryNuGetPackage($library, $version, $commit, $pfxPassword) {
    $xml = loadAndInitNuSpec $library $version $commit

    if ($library -eq "Magick.NET.SystemWindowsMedia") {
        addLibrary $xml $library "" "AnyCPU" "net40"
        addLibrary $xml $library "" "AnyCPU" "netcoreapp3.1"
    } else {
        if ($library -eq "Magick.NET.SystemDrawing") {
            addLibrary $xml $library "" "AnyCPU" "net40"
        } else {
            addLibrary $xml $library "" "AnyCPU" "net20"
        }
        addLibrary $xml $library "" "AnyCPU" "netstandard20"
        addLibrary $xml $library "" "AnyCPU" "netstandard21"
    }

    createAndSignNuGetPackage $xml $library $version $pfxPassword
}

createMagickNetLibraryNuGetPackage $library $version $commit $pfxPassword
copyNuGetPackages $destination