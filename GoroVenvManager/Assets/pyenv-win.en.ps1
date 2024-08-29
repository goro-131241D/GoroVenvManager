# Clone pyenv-win from git and set environment variables

# Explicitly specify encoding
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

Write-Output "Installing pyenv-win.`r`n"

# Clone pyenv-win from git
git clone https://github.com/pyenv-win/pyenv-win.git "$env:USERPROFILE\.pyenv"

Write-Output "==="

# Set environment variables
$pyenv = "$env:USERPROFILE\.pyenv\pyenv-win"
$pyenvRoot = "$env:USERPROFILE\.pyenv\pyenv-win"
$pyenvHome = "$env:USERPROFILE\.pyenv\pyenv-win"

# Set environment variables

try {
    [Environment]::SetEnvironmentVariable("PYENV", $pyenv, [EnvironmentVariableTarget]::User)
    Write-Output "Environment variable PYENV has been set successfully."
} catch {
    Write-Output "Failed to set environment variable PYENV. Error: $_"
}

try {
    [Environment]::SetEnvironmentVariable("PYENV_ROOT", $pyenvRoot, [EnvironmentVariableTarget]::User)
    Write-Output "Environment variable PYENV_ROOT has been set successfully."
} catch {
    Write-Output "Failed to set environment variable PYENV_ROOT. Error: $_"
}

try {
    [Environment]::SetEnvironmentVariable("PYENV_HOME", $pyenvHome, [EnvironmentVariableTarget]::User)
    Write-Output "Environment variable PYENV_HOME has been set successfully."
} catch {
    Write-Output "Failed to set environment variable PYENV_HOME. Error: $_"
}

function Add-ToPath {
    param (
        [string]$dirPath
    )

    # Retrieve the current user's environment variable Path
    $currentPath = [Environment]::GetEnvironmentVariable("Path", [EnvironmentVariableTarget]::User)

    # Check if the new path is already included in the current path
    if ($currentPath -notlike "*$dirPath*") {
        # Add only if the path is not already included
        $newPath = "$currentPath;$dirPath"
        [Environment]::SetEnvironmentVariable("Path", $newPath, [EnvironmentVariableTarget]::User)
        Write-Output "Added new directory '$dirPath' to Path."
    } else {
        Write-Output "Directory '$dirPath' is already included in Path."
    }
}

$pyenvShims = "$env:USERPROFILE\.pyenv\pyenv-win\shims"
$pyenvBin = "$env:USERPROFILE\.pyenv\pyenv-win\bin"

Add-ToPath($pyenvShims)
Add-ToPath($pyenvBin)

pyenv rehash

Write-Output "==="
