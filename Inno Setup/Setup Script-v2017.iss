#define MyAppName "CRMRevitTools-v2017"
#define MyAppVersion "1.0.1"
#define MyVersionInfoVersion "1.0.1"
#define MyAppPublisher "Christopher Ryan Mackay"

[Setup]
AppId={{D6B84482-E92A-438A-8CB1-C826A3AA9B3A}
AppName={#MyAppName}
AppCopyright=Copyright © 2018 Christopher Ryan Mackay
AppVersion={#MyAppVersion}
VersionInfoVersion={#MyVersionInfoVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={userdocs}\{#MyAppName}
DisableDirPage=yes
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
OutputDir=C:\Revit Programming\CRMRevitTools-v2017\Inno Setup
OutputBaseFilename=CRMRevitTools-v2017-v{#MyAppVersion} Setup
Compression=lzma
SolidCompression=yes
LicenseFile=C:\Revit Programming\CRMRevitTools-v2017\Inno Setup\LICENSE.txt
PrivilegesRequired=lowest

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "C:\Revit Programming\CRMRevitTools-v2017\Inno Setup\CRMRevitTools\Commands\*"; DestDir: "{userdocs}\CRMRevitTools\v2017\Commands"; Flags: ignoreversion
Source: "C:\Revit Programming\CRMRevitTools-v2017\Inno Setup\CRMRevitTools\MenuCreator\*"; DestDir: "{userdocs}\CRMRevitTools\v2017\MenuCreator"; Flags: ignoreversion
Source: "C:\Revit Programming\CRMRevitTools-v2017\Inno Setup\CRMRevitTools\RevitIcons\16x16\*"; DestDir: "{userdocs}\CRMRevitTools\v2017\RevitIcons\16x16\"; Flags: ignoreversion
Source: "C:\Revit Programming\CRMRevitTools-v2017\Inno Setup\CRMRevitTools\RevitIcons\32x32\*"; DestDir: "{userdocs}\CRMRevitTools\v2017\RevitIcons\32x32\"; Flags: ignoreversion
Source: "C:\Revit Programming\CRMRevitTools-v2017\Inno Setup\CRMRevitTools\RevitIcons\32x32\*"; DestDir: "{userdocs}\CRMRevitTools\v2017\RevitIcons\32x32\"; Flags: ignoreversion
Source: "C:\Revit Programming\CRMRevitTools-v2017\Inno Setup\CRMRevitTools\Addin File\*"; DestDir: "C:\ProgramData\Autodesk\Revit\Addins\2017"; Flags: ignoreversion
Source: "C:\Revit Programming\CRMRevitTools-v2017\Inno Setup\CRMRevitToolsInit-v2017.exe"; DestDir: "{userdocs}\CRMRevitTools\v2017"; Flags: ignoreversion
Source: "C:\Revit Programming\CRMRevitTools-v2017\Inno Setup\LICENSE.txt"; DestDir: "{userdocs}\CRMRevitTools\v2017"; Flags: ignoreversion

[UninstallDelete] 
Type: dirifempty; Name: {userdocs}\CRMRevitTools;

[Run]
Filename: {userdocs}\CRMRevitTools\v2017\CRMRevitToolsInit-v2017.exe;

