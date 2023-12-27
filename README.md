DIGITAL ECO MODKIT

Setup Instructions:
1) Install Unity
2) Create Unity Project for DigitalEco modding environment
3) Install Modkit
4) Import Modkit to Unity Project
5) Navigate to Assets folder in Unity Project using CMD or Powershell (or something that can run git)
6) Clone this repo into a folder called DigitalEco "\DigitalEcoUnityProject\Assets\DigitalEco" 
7) Open CMD in Administrator mode and execute the following command where LINK is the path to your ECO game folder's UserCode where your DigitalEco symbolic link will reside (Do not create the folder, let this command do so)
and where TARGET is the DigitalEco directory that the git repo resides within which should be in your Unity project.
GENERAL USE:
    `mklink \D <LINK> <TARGET>`
DESCRIPTIVE USE:
    `mklink \D <EcoGameDirectory\Eco_Data\Server\Mods\UserCode\DigitalEco> <DigitalEcoUnityProject\Assets\DigitalEco>`
EXAMPLE:
    `mklink /D "C:\Program Files (x86)\Steam\steamapps\common\Eco\Eco_Data\Server\Mods\UserCode\Digits" "C:\Users\turkeykittin\Documents\workshop\unity\DigitalEcoUnityProject\Assets\DigitalEco"`
8) 

