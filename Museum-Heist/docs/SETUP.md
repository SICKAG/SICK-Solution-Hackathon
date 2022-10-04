# Setup

In order to work with the provided resources you need the Unity-Hub and the Unity Editor (version 2022.1.0).
Additionally you need a python environment (preferably python 3.9.x) which contains pytorch (version 1.8.0) and mlagents (version 0.29.0).
See also below for additional instructions concerning the Python environment.
Having git installed is optional but simplifes cloning this repository.

In order to speed-up the installation of these components we provide a (Windows) PowerShell script `museum-heist-dependencies.ps1` at the root of this repo.
The script uses Chocolatey (which is installed first) to download most of the other programs and uses pyenv to control the python version and poetry for managing the virtual python environment.
If you already have parts of these programs installed, make sure to delete/comment out the respective lines from the script.
Feel free to use the script and execute it (in the directory where you have saved the script) using `powershell -executionpolicy bypass -File .\museum-heist-dependencies.ps1` from a PowerShell with admin rights.
If you are on a different OS than Windows or if you prefer/are used to using different python versioning or python virtual environement tools, feel free to use those and install the rest yourself.

Once everything is set-up `git clone` this repository.

## Unity

You additionally need a Unity account, create that [here](https://id.unity.com/en/).
Once you have done this, inform one of the Hack-coaches who will provide you with a (temporary) Unity licence via the email you have signed up with.

Open the Unity-Hub.
When opening the Unity-Hub for the first time you have to sign in to your Unity account. Additionally the Unity editor you have installed might not have been automatically recognized by the Hub.
For this choose "Locate existing installation" on the pop-up that opens in the beginning and locate the Unity.exe of the 2022.1.0 editor (probably located at `C:\Program Files\Unity 2022.1.0f1\Editor`).
Finally, activate the licence by clicking on your avatar (top left corner in the hub, probably your initials) -> manage licences -> add -> activate with serial number -> enter the licence key you have been sent via email.

You should now be ready to open the Unity project located in `museum-heist/museum-heist`.
Do this in the Unity Hub by clicking on Open Project and navigate there.

## Python Environment

We provide a simple setup using poetry:
Go to museum-heist-agent-training and in your favourite terminal execute `poetry install`.
When this has successfully finished install pytorch by running `poetry run poe install-torch`.
These two steps could take a while but now you should be all set for training your thief.

If you want to use something else (e.g. conda or pip), make sure that you set-up your python 3.9.x environment with pytorch (1.8.0) and mlagents (0.29.0).
