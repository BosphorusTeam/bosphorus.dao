$assemblyVersionPattern = 'AssemblyVersion\(\"(?<major>\d{1,3})\.(?<minor>\d{1,3})\.(?<build>\d{1,3})\.(?<revision>\d{1,3})\"\)'
$assemblyFileVersionPattern = 'AssemblyFileVersion\(\"(?<major>\d{1,3})\.(?<minor>\d{1,3})\.(?<build>\d{1,3})\.(?<revision>\d{1,3})\"\)'
[regex]$assemblyVersionRegex = $assemblyVersionPattern
[regex]$assemblyFileVersionRegex = $assemblyFileVersionPattern

function MatchAndReplaceFileContent($file, $matchPattern, $replacement)
{
	(Get-Content -Raw $file.FullName) | ForEach-Object {$_ -replace $matchPattern, $replacement } | Set-Content -Encoding UTF8 $file.FullName
}

function IncrementAssemblyAndAssemblyFileVersion
{
    foreach ($file in $input) 
    {
        Write-Host "Processing $file"
        $content = get-content $file
        $match = $assemblyVersionRegex.Match($content)
	    $currentRevision = $match.Groups["revision"].Value
	    $newRevision = ([int]$currentRevision) + 1
	    
        $assemblyVersionReplacement = 'AssemblyVersion("${major}.${minor}.${build}.' + $newRevision + '")'
        MatchAndReplaceFileContent $file $assemblyVersionPattern $assemblyVersionReplacement
        
        $assemblyFileVersionReplacement = 'AssemblyFileVersion("${major}.${minor}.${build}.' + $newRevision + '")'
        MatchAndReplaceFileContent $file $assemblyFileVersionPattern $assemblyFileVersionReplacement
    }
}

Get-ChildItem -Recurse AssemblyInfo.cs | IncrementAssemblyAndAssemblyFileVersion