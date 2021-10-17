[CmdletBinding()]
param (
        [ValidateNotNullOrEmpty()] 
        [string] $Path,
        [Parameter(Mandatory=$false)]
        [switch] $Detailed
    )

function Get-DirectorySize {
    [CmdletBinding()]
    param (
        [ValidateNotNullOrEmpty()] 
        [string] $Path,
        [Parameter(Mandatory=$false)]
        [bool] $Detailed
    )

    if($Detailed) {
        $total_file_count = 0
        $total_file_size = 0

        Get-ChildItem $Path -recurse |  ?{ $_.PSIsContainer } | %{ 
            try {
                $file_count = [System.IO.Directory]::GetFiles($_.FullName, "*", "AllDirectories").Count
                $file_size = 0

                if($file_count -gt 0) {
                  $file_size = ((Get-ChildItem $_.FullName -recurse | Measure-Object Length -Sum).sum / 1Gb)
                
                  "{0:N2} GB | $file_count files `t $_" -f $file_size   
                }
            }
            catch {
                
            }
        }
    } 

    $total_file_count = [System.IO.Directory]::GetFiles($Path, "*", "AllDirectories").Count
    $total_file_size  = (([System.IO.DirectoryInfo]$Path).EnumerateFiles("*", 'AllDirectories').Length)
    
    "{0:N2} GB | {1:N0} files `t $Path" -f (($total_file_size | Measure-Object -Sum).Sum / 1Gb), $total_file_count
}


Get-DirectorySize -Path $Path -Detailed $Detailed
