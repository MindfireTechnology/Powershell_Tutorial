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
