DIGITAL ECO MODKIT

Setup Instructions:
1) Install Unity
2) Create Unity Project for DigitalEco modding environment
3) Install Modkit
4) Import Modkit to Unity Project (Assets/Package/CustomPackage, nav to unity package from within ModKit .zip)
5) Navigate to a high level directory where you will place all assets and code for the modpack into for development using CMD or Powershell (or something that can run git)
6) Clone this repo into said directory. All files should be within a folder named DigitalEco.
7) We're going to have to make 2 symbolic links. One to make Eco see the source files when launching, and another to let your unity project see the unity assets here for bundle building with the Eco Mod Kit.
7.1) Open CMD in /Administrator/ mode and execute the following command where LINK is the path to your ECO game folder's `UserCode/DigitalEco` where your DigitalEco symbolic link will reside (Do not create the folder, let this command do so)
and where TARGET is the `DigitalEco/src` directory that you cloned from the git repo. Make sure to surround both LINK and TARGET individually with `"`
GENERAL USE:
    `mklink \D <LINK> <TARGET>`
EXAMPLE:
    `mklink /D "C:\Program Files (x86)\Steam\steamapps\common\Eco\Eco_Data\Server\Mods\UserCode\Digits" "C:\Modding\Eco\DigitalEco\src"`
7.2) Again, open (or reuse) CMD in /Administrator/ mode and execute the following command where LINK is the path to your Unity Project's Assets folder `Assets/DigitalEco` where your DigitalEco symbolic link will reside (Do not create the folder "DigitalEco", let this command do so) and where TARGET is the `DigitalEco/UnityAssets` directory that you cloned from the git repo. Make sure to surround both LINK and TARGET individually with `"`
EXAMPLE:
    `mklink /D "C:\Users\turkeykittin\Documents\workshop\unity\DigitalEcoUnityProject\Assets\DigitalEco" "C:\Modding\Eco\DigitalEco\UnityAssets"`
8) Now, in unity, open the MainScene under `Assets/DigitalEco/MainScene` and at the top of the window click `ModKit>Build Current Bundle` and export the bundle into the git repo's `DigitalEco/src` directory and call it `DigitalEco.unity3d`. Note, this is supposed to place it within your Eco UserCode folder due to the symbolic link the src directory has.
9) LAUNCH THE GAME AND PLAY
