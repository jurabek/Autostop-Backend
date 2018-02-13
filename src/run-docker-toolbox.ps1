Write-Host "Starting docker-vm"
docker-machine start default

Write-Host "docker-machine env default into powershell"
docker-machine env --shell powershell default | Invoke-Expression