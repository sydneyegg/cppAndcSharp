pipeline {
    agent any
    options {
        // This is required if you want to clean before build with the "Workspace Cleanup Plugin"
        skipDefaultCheckout(true)
    }
    stages {
        stage('SCM') {
            steps {
                // Clean before build using the "Workspace Cleanup Plugin"
                cleanWs()
                checkout scm
            }
        }

        stage('Download Build Wrapper') {
            steps {
                powershell '''
                  $path = ".sonar/build-wrapper-win-x86.zip"
                  New-Item -ItemType directory -Path .sonar -Force
                  [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
                  (New-Object System.Net.WebClient).DownloadFile("https://ee97win-jting-us.ngrok.io/static/cpp/build-wrapper-win-x86.zip", $path)
                  Add-Type -AssemblyName System.IO.Compression.FileSystem
                  [System.IO.Compression.ZipFile]::ExtractToDirectory($path, ".sonar")
                  $env:Path += ";.sonar/build-wrapper-win-x86"
                '''
            }
        }

        stage('SonarQube Analysis and Build') {
            steps {
                script {
                    def scannerHome = tool 'SonarScanner for MSBuild'; // Name of the SonarQube Scanner you created in "Global Tool Configuration" section
                    withSonarQubeEnv('ee97win') {
                        bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"joe-tingsanchali-sonarsource_cplusplusandcsharp_AYSBjwhhn_7q9zqA8JuZ\" /d:\"sonar.cfamily.build-wrapper-output=wrapper-output\""
                        powershell "build-wrapper-win-x86-64.exe --out-dir wrapper-output  MSBuild.exe .\UnrealTest.sln /t:Rebuild /nodeReuse:False"
                        bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
                    }
                }
            }
        }
    }
}
