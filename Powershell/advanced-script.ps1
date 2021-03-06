﻿<#
    .Description
    Filters items by weekday, and removes if last written to on a weekday


    https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_comment_based_help?view=powershell-6
#>
function Filter-WeekdayItems {
    [CmdletBinding(SupportsShouldProcess=$True)]
    param (
        [Parameter(ValueFromPipeline=$True)]
        [string[]]$Files,

        [Parameter()]
        [switch]$Force
    )

    Begin {
        Write-Host "Filter-WeekdayItems is starting"
    }

    Process {
        Write-Debug "Processing files: $Files"
        
        foreach ($file in $Files) {
            $details = Get-Item $file
            if ($details.LastWriteTime.DayOfWeek -gt 0 -and $details.LastWriteTime.DayOfWeek -lt 6) {
                # Confirm with the user that we want to proceed
                if ($Force -or $PSCmdlet.ShouldProcess($file, "Remove file?")) {
                    Remove-Item $file
                }
            }
        }
    }

    End {
        Write-Host "Filter-WeekdayItems is ending"
    }
}

#Filter-WeekdayItems -Files "
