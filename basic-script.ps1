
function Get-DotNet {
    param (
        [Parameter(Mandatory=$True)]
        [string]$DownloadLocation
    )

    if (!(Test-Path $DownloadLocation)) {
        New-Item -Path $DownloadLocation -ItemType Directory
    }

    Write-Host "Downloading DotNet installer..."
    $file = Join-Path -Path $DownloadLocation -ChildPath "dotnetinstaller.exe"
    Write-Debug "Saving file to $file"
    Invoke-WebRequest -Uri "https://go.microsoft.com/fwlink/?linkid=853017" -OutFile $file > $null
    Write-Host "Done."

    Write-Host "Installing DotNet..."
    Start-Process -Wait -FilePath $file -ArgumentList "/install"
    Write-Host "Done."
}

function Get-VSCode {
    param (
        [Parameter(Mandatory=$True)]
        [string]$DownloadLocation
    )

    if (!(Test-Path $DownloadLocation)) {
        New-Item -Path $DownloadLocation -ItemType Directory
    }

    Write-Host "Downloading VS Code installer..."
    $file = Join-Path -Path $DownloadLocation -ChildPath "codeinstaller.exe"
    Write-Debug "Saving file to $file"
    Invoke-WebRequest -Uri "https://aka.ms/win32-x64-user-stable" -OutFile $file > $null
    Write-Host "Done."

    Write-Host "Installing VS Code..."
    Start-Process -Wait -FilePath $file -ArgumentList "/install"
    Write-Host "Done."
}

Get-DotNet -DownloadLocation "$HOME\Downloads"
Get-VSCode -DownloadLocation "$HOME\Downloads"