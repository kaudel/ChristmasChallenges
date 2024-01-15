https://2022.adventjs.dev/#retos
Bastian: 1, 7, 18, 6, 10, 15, 5, 20
Héctor: 2, 9, 19, 4, 12, 17, 23, 16
Omar: 3, 13, 22, 8, 14, 21, 24, 11

URL for challenges .
https://github.com/mouredev/retos-programacion-2023/tree/main/Retos
https://adventofcode.com/2023/day/1

Ulam numbers: https://es.wikipedia.org/wiki/N%C3%BAmeros_de_Ulam

/* *************************************** */
/* Powershell script to create some empty  */
/* files on each sub folder in the repo    */
/* *************************************** */
#Variable
$BasePath = "C:\src\ChristmasChallenges2022\"
$BaseName = "challenges0"
$BaseNameJS = "\javascript\"
$BaseNameGo = "\go\"
$BaseNameCs = "\cs\"
$BaseFileName = "challenge0"

#Check if Folder exists
for ($x = 1; $x -le 24; $x++) {   
  #Write-Output $x
  #Write-Output   $FolderPath
  $FolderPath = $BasePath + $BaseName + $x + $BaseNameJS
  $FileNameJS = $FolderPath + $BaseFileName + $x + ".js"
  New-Item -ItemType Directory -Path $FolderPath
  New-Item -ItemType File -Path $FileNameJS
  $FolderPath = $BasePath + $BaseName + $x + $BaseNameGo
  $FileNameGo = $FolderPath + $BaseFileName + $x + ".go"
  New-Item -ItemType Directory -Path $FolderPath
  New-Item -ItemType File -Path $FileNameGo
  $FolderPath = $BasePath + $BaseName + $x + $BaseNameCs
  $FileNameCS = $FolderPath + $BaseFileName + $x + ".cs"
  New-Item -ItemType Directory -Path $FolderPath
  New-Item -ItemType File -Path $FileNameCs
  #Remove-Item -Path $FileNameGo
  #If (!(Test-Path -Path $FolderPath)) {
  #powershell create directory
  #Write-Output   $FolderPath
  Write-Output  $FileNameJS
  Write-Output  $FileNameGo
  Write-Output  $FileNameCs
  
  #Remove-Item -Path $FileNameCs
  #Remove-Item -Path $FileNameGo
  
  #Write-Host "New folder created successfully!" -f Green
  #}
  #Else {
  #  Write-Host "Folder already exists!" -f Yellow
  #}
}  

