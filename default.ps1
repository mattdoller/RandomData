properties {
  $authors = "Matt Doller"
  $description = "A library for generating random data to help with testing"
  $version = "0.1.0"

  $project_name = "RandomData"
  $test_project_name = "$project_name.Tests"

  $base_dir = resolve-path .
  $packages_config = "$base_dir\packages.config"
  $packages_dir = "$base_dir\packages"
  $build_dir = "$base_dir\build"
  $release_dir = "$base_dir\release"
  $project_src_dir = "$base_dir\$project_name"
  $project_csproj = "$project_src_dir\$project_name.csproj"
  $project_test_dir = "$base_dir\$test_project_name"
  $nuspec = "$base_dir\$project_name.nuspec"

  $sln = "$base_dir\$project_name.sln"

  $nunit_tools = "$packages_dir\NUnit.Runners.2.6.3\tools"
  $nunit_console = "$nunit_tools\nunit-console.exe"
}

include .\psake_ext.ps1

task default -depends Release

task Clean {
  remove-item -force -recurse $build_dir -ErrorAction SilentlyContinue
  remove-item -force -recurse $release_dir -ErrorAction SilentlyContinue
}

task Init-Dependencies -depends Clean {
  & nuget install $packages_config -OutputDirectory $packages_dir -Verbosity quiet
  if ($lastExitCode -ne 0) {
    throw "Error: Failure installing packages"
  }
}

task Init -depends Init-Dependencies {
  Generate-Assembly-Info `
    -file "$project_src_dir\Properties\AssemblyInfo.cs" `
    -title "$project_name $version" `
    -description "$description" `
    -product "$project_name $version" `
    -version "$version" `
    -authors "$authors" `
    -internalsVisibleTo "$test_project_name"

  Generate-Assembly-Info `
    -file "$project_test_dir\Properties\AssemblyInfo.cs" `
    -title "$test_project_name $version" `
    -description "$description" `
    -product "$test_project_name $version" `
    -version "$version" `
    -authors "$authors"
}

task Compile -depends Init {
  & msbuild "$sln" "/p:OutDir=$build_dir\\" /p:Configuration=Release /verbosity:quiet /m /nologo /maxcpucount
  if ($lastExitCode -ne 0) {
    throw "Error: Compile failure"
  }
}

task Test -depends Compile {
  & $nunit_console /nologo "$build_dir\$test_project_name.dll"
  if ($lastExitCode -ne 0) {
    throw "Error: Test failure"
  }
}

task Init-PackageDependencies {
  Generate-Nuspec `
    -file "$base_dir\$project_name.nuspec" `
    -id "$project_name" `
    -version "$version" `
    -authors "$authors" `
    -description "$description"
}

task Release -depends Init-PackageDependencies, Test {
  New-Item -Path $release_dir -ItemType directory | Out-Null
  & nuget pack $project_csproj -outputdirectory $release_dir -Verbosity quiet
}