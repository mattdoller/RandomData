function Get-Git-Commit
{
  $gitLog = git log --oneline -1
  return $gitLog.Split(' ')[0]
}

function Get-Git-Branch
{
  $branch = git rev-parse --symbolic-full-name --abbrev-ref HEAD
  return $branch
}

function Generate-Assembly-Info
{
  param(
    [string]$clsCompliant = "true",
    [string]$title,
    [string]$description,
    [string]$authors,
    [string]$product,
    [string]$version,
    [string]$internalsVisibleTo = "",
    [string]$file = $(throw "file is a required parameter.")
  )

  $copyright = Copyright-Span
  $commit = Get-Git-Commit
  $asmInfo = "using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: CLSCompliantAttribute($clsCompliant )]
[assembly: ComVisibleAttribute(false)]
[assembly: AssemblyTitleAttribute(""$title"")]
[assembly: AssemblyDescriptionAttribute(""$description"")]
[assembly: AssemblyCompanyAttribute(""$authors"")]
[assembly: AssemblyProductAttribute(""$product"")]
[assembly: AssemblyCopyrightAttribute(""$copyright"")]
[assembly: AssemblyVersionAttribute(""$version"")]
[assembly: AssemblyInformationalVersionAttribute(""$version / $commit"")]
[assembly: AssemblyFileVersionAttribute(""$version"")]
[assembly: AssemblyDelaySignAttribute(false)]
"

  if ($internalsVisibleTo -ne "") {
    $asmInfo += "[assembly: InternalsVisibleTo(""$internalsVisibleTo"")]"
  }

  $dir = [System.IO.Path]::GetDirectoryName($file)
  if ([System.IO.Directory]::Exists($dir) -eq $false)
  {
    [System.IO.Directory]::CreateDirectory($dir)
  }
  out-file -filePath $file -encoding UTF8 -inputObject $asmInfo
}

function Generate-Nuspec {
  param(
    [string]$id,
    [string]$version,
    [string]$authors,
    [string]$description,
    [string]$file = $(throw "file is a required parameter.")
  )

  $copyright = Copyright-Span

  $nuspec = "<?xml version=""1.0""?>
<package>
  <metadata>
    <id>$id</id>
    <version>$version</version>
    <authors>$authors</authors>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <description>$description</description>
    <copyright>$authors, $copyright</copyright>
  </metadata>
</package>
"
  $dir = [System.IO.Path]::GetDirectoryName($file)
  if ([System.IO.Directory]::Exists($dir) -eq $false)
  {
    [System.IO.Directory]::CreateDirectory($dir)
  }
  Out-File -filePath $file -encoding UTF8 -inputObject $nuspec
}

function Copyright-Span {
  $start = 2014
  $now = Get-Date -Format yyyy

  if ($start -eq $now) {
    return "$start"
  }
  return "$start - $now"
}