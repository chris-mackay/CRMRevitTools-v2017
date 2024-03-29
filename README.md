# CRMRevitTools-v2017

#### This repository is meant to be a template for creating your own Revit tab menu with custom commands.
*Cloning this entire repository is required to build the (.exe) installer in the Inno Setup folder*
### See folder content descriptions below


### CRMRevitTools_Help
* Contains a folder structure for creating `.html` instruction pages that simply open in a browser. These instruction pages are opened using the Help (?) button in the Titlebar of the running command.
  * *css*: Cascading Style Sheet for `.html` files
  *  *images*: Contains all images for `.html` files

### Inno Setup
 * **CRMRevitTools**
   * *Addin File*: The Revit `ADDIN File` that is placed in `C:\ProgramData\Autodesk\Revit\Addins\2017`. This file does not need to be edited to build the installer.
   * *Commands*: Location where the latest `command_name.dll` files need to be placed to build the installer
   * *MenuCreator*: Location where the latest `CRMTools.dll` file needs to be placed to build the installer
   * *RevitIcons*: Location where all the referenced `image_name.bmp` files for `CRMTools.dll` need to be placed to build the installer 
     * There is a directory for both 16x16 and 32x32 size images. Revit requires images to be `Bitmap image` files.
 * `CRMRevitTools-v2017-v1.0.2 Setup.exe`. The file that is produced after compiling `Setup Script-v2017.iss`. The version number is determined by the `MyAppVersion` and `MyVersionInfoVersion` `#define` directives in Inno Setup.
 * `CRMRevitToolsInit-v2017.exe`: A simple console application that runs at the end of the installation to replace `REPLACEUSERNAME` in the `ADDIN File` to `System.Environment.UserName`.
 * `LICENSE.txt`: Inno Setup license file
 * `Setup Script-v2017.iss`: Inno Setup Script file

### RevitAPI-v2017
 * Contains the Revit API references for both **v2017** and **v2017.2**. This is where Visual Studio references the API. `Copy Local` should be set to `False` in Properties.

### Visual Studio
 * This folder contains the project directories created by Visual Studio
 * CRMTools is the menu creator. This is where the menu and buttons are created. Each command is separated with a `Region`.

### LICENSE
 * The GPL-3.0 License that is attached to this repository and all it's contents

### Parameter_Template-v2017.xlsx
 * The template that is used with the **Shared Parameter Creator** command.