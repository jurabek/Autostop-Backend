Param ([string]$SolutionFile = "Autostop.Services.All.sln")

.\run-docker-toolbox.ps1
&"C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\devenv.exe" $SolutionFile