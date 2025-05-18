
[//]: <primary Color: #B59111>
[//]: <secondary Color: #A469A4>
[//]: <tertiary Color: #518ccf>

# Table of Contents(TOC)
1. [Getting Started](#Getting-Started)
- 1-1. [Pre-Requisite](#Pre-Requisite) - please read.
- 1-2. [Steps](#Steps) - running project first time.
- 1-3. [BDPro UpgradeGuide](#Behavior-Designer-Pro-Upgrade-Guide)
2. [Tutorials](#Tutorials) - YT Links and further details.
3. [FAQ](#FAQ)


# Getting Started
## <span style="color:#B59111"> Pre-Requisite </span>
* These packages assume you will use Behavior Designer Pro, and are designed with it in mind. You can still use the UIToolkit packages, by deleting the Scenes/ and Scripts/ with the 'BP-' Prefix.
* These projects were made in Unity 6.0, However I know they work from 2022 and onward at least.
* You can buy (or check) if you have BDPro from the Unity Asset Store Link here: https://assetstore.unity.com/packages/tools/visual-scripting/behavior-designer-pro-dots-powered-behavior-trees-298743

### <span style="color:#A469A4"> Included Packages: </span>
* BDPro : https://assetstore.unity.com/packages/tools/visual-scripting/behavior-designer-pro-dots-powered-behavior-trees-298743
* Unity Asset Store Character Controller (Free) : https://assetstore.unity.com/packages/essentials/starter-assets-character-controllers-urp-267961
* Unity AI Navigation (Free)
### <span style="color:#A469A4"> Not needed, but referenced: </span>
> Note: You don't need these to run the project. However if you have them, you can import them. It just makes things easier to see.

* Hierarchy Folders
* Rainbow Folders 2: https://assetstore.unity.com/packages/tools/utilities/rainbow-folders-2-143526

## <span style="color:#B59111"> Steps: </span>
* In Unity head to `Windows -> Package Management -> Package Manager`.
* Head to `Unity Registry`
* Search for: ```com.unity.ai.navigation```
* Download and import.

## <span style="color:#B59111"> Behavior Designer Pro Upgrade Guide: </span>
* BDPro Task Migration: https://opsive.com/support/documentation/behavior-designer-pro/getting-started/task-migration/
* * This is the upgrade guide. its a fairly short read.


# Tutorials: 
These Tutorials aren't made in any particular order, They are made as a simple way to help you get started, or get familiar w/ different kinds of mechanics in BDPRO or UI Toolkit.

### <span style="color:#A469A4"> UI Dialog </span>
* A quick and simple tutorial on setting up a Dialog Box with UI Toolkit.
* <strong>Unity Dialog System - No Canvas Needed (UI Toolkit Tutorial)</strong>
    * https://www.youtube.com/watch?v=JnlQd04rVok

### <span style="color:#A469A4"> BPWandering </span>
* A quick tutorial on NPC Wandering mechanics using Behavior Designer / Behavior Designer PRO.
* >  NOTE: if you use Behavior Designer, and not the old version, please read the 'Behavior Designer Pro Upgrade Guide' above.
* <strong>Bring Your NPCs to Life! (Unity NPC Wandering Tutorial / BD PRO)</strong>
    * https://youtu.be/KPVc3FcM8FA?si=09F-mhnTgypCPoh9

### <span style="color:#A469A4"> BPNPCChase </span>
* A tutorial on Chasing, and leashing a target using BDPro
* If you would like to follow the YT Tutorial Video from scratch, Delete the BPNPCChase Scene and scripts from your local copy first. The tutorial starts by making a copy from BPWandering, and moving from there.
* <strong>🧠 NPC Chase System in Unity (BDPro Leashing Tutorial) 🎮</strong>
    * https://youtu.be/SSNWUSYufgw



# FAQ:
### <span style="color:#A469A4">I have missing prefabs in my scene, how do I fix this? </span>
* * These are prefab variants from the Unity Asset Store Character Controller. Once you install the *Starter Assets Character Controller* (_link included above_), it should auto resolve when you reload the scene.

### <span style="color:#A469A4">I am getting a handful of script errors when I open the scene. </span>
* * Many of the scripts reference the Included Packages. Install the [IncludedPackages](#Included-Packages) from the package manager and they should self-resolve.