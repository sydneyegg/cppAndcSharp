# Sample C++ with C# Project

This project contains a single Cpp and single C# project combined in a single solution file. Note that these projects are indepedent of each other and do not contain interop code. This repository contains a sample Jenkinsfile.

### Requirements
1. Visual Studio 2022
2. Workloads for C++ development (download and install from Visual Studio installer)

From the SonarQube [C-Family](https://docs.sonarqube.org/latest/analysis/languages/cfamily/) language analyzer documentation:
> ### Solution with a Mix of C# and C++
>
> When you have a Solution made of C++ and C#, in order to both use the _Build Wrapper_ and have an accurate analysis of the C# code, you must use the [SonarScanner for MSBuild](https://github.com/SonarSource/sonar-scanner-msbuild). The SonarScanner for MSBuild does not handle sonar-project.properties files, so the _Build Wrapper_ output directory will have to be set during the MSBuild begin step.
> 
> Note that in this scenario, source code stored in shared folders, not considered as a "Project" by Visual Studio, won't be scanned.
> * Download and install both the [SonarScanner for MSBuild](https://github.com/SonarSource/sonar-scanner-msbuild) and the _Build Wrapper_ (see Prerequisites section).
> * Execute the SonarScanner for MSBuild begin step with the _Build Wrapper_ output parameter /d:sonar.cfamily.build-wrapper-output=<build_wrapper_output_directory>
> * Add execution of Build Wrapper to your normal MSBuild build command
> * Execute the SonarScanner for MSBuild end step to complete the analysis
> 
> For example:
> ```text
> SonarScanner.MSBuild.exe begin /k:"cs-and-cpp-project-key" /n:"My C# and C++ project" /v:"1.0" /d:sonar.cfamily.build-wrapper-output="build_wrapper_output_directory"
> build-wrapper-win-x86-64.exe --out-dir build_wrapper_output_directory MSBuild.exe /t:Rebuild /nodeReuse:False
> SonarScanner.MSBuild.exe end
> ```
