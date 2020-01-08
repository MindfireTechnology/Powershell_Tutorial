$fileName = "README.md"
$filePath = "."
$path = "$filePath\$fileName"

New-Item $path -Force

$contents = "# Basic Script$([System.Environment]::NewLine)Script that creates this README, outputs this content, and then shows the content on the screen"

$contents | Out-File $path -Append

Get-Content $path