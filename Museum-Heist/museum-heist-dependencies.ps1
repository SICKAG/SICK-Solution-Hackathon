# Check if Chocolatey is installed, install it, if is not already there
If(Test-Path -Path "$env:ProgramData\Chocolatey") {
  # Chocolatey already installed  
  write-host "Choco already installed, proceed with installation of other packages"
}
Else {
  # Choco not installed, install it
  write-host "Chocolatey not installed, installing Choco..." 
  Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
}

# Use Chocolatey to install necessary packages
# Simply use '#' to comment out lines that are not needed on your system

# install git
write-host "Installing git"
choco install git -y

# install pyenv
write-host "Installing pyenv"
choco install pyenv-win -y

# Refresh Environment variables such that the script can immediately use pyenv
$env:Path = [System.Environment]::GetEnvironmentVariable("Path","Machine") + ";" + [System.Environment]::GetEnvironmentVariable("Path","User")

#Install python 3.9 and make it the global python version
write-host "Installing python 3.9"
pyenv install 3.9.13
# Remove some stupid Windows pre-setting that opens the Windows Store instead of python 
Remove-Item $env:USERPROFILE\AppData\Local\Microsoft\WindowsApps\python*.exe
pyenv global 3.9.13

# update environment variables again
$env:Path = [System.Environment]::GetEnvironmentVariable("Path","Machine") + ";" + [System.Environment]::GetEnvironmentVariable("Path","User")

# install poetry
write-host "Installing poetry"
(Invoke-WebRequest -Uri https://install.python-poetry.org -UseBasicParsing).Content | python -

#add poetry to path and update environment variables
[Environment]::SetEnvironmentVariable("Path", [Environment]::GetEnvironmentVariable("Path", "User") + ";%APPDATA%\pypoetry\venv\Scripts", "User")
$env:Path = [System.Environment]::GetEnvironmentVariable("Path","Machine") + ";" + [System.Environment]::GetEnvironmentVariable("Path","User")

# Finally install unity and the unity hub
write-host "Installing Unity Hub"
choco install unity-hub -y
write-host "Installing Unity Editor"
choco install unity --version=2022.1.0 -y # best use this exact version