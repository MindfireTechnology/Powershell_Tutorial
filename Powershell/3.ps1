function New-ReadMe {
    param (
        [Parameter(Mandatory=$True)]
        [string]$Path,

        [Parameter()]
        [string]$FileName
    )

    $fullPath = Join-Path $Path -ChildPath $FileName

    New-Item $fullPath -Force > $null

    $content = "Hello World"
    $content | Out-File $fullPath -Append

    Get-Content $fullPath
}

function Out-HelloWorld {
    Write-Debug "Now executing 'C:\Windows\explorer.exe'"
    Start-Process "C:\Windows\explorer.exe" -ArgumentList "D:\Repositories" -Wait
    Write-Host "Finished"
}