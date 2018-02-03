#define MyAppName "CRMRevitTools-v2017"
#define MyAppVersion "1.0.2"
#define MyVersionInfoVersion "1.0.2"
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

;CRMRevitTools_Help
Source: "C:\Revit Programming\CRMRevitTools-v2017\CRMRevitTools_Help\*"; DestDir: "{userdocs}\CRMRevitTools\v2017\CRMRevitTools_Help"; Flags: ignoreversion
Source: "C:\Revit Programming\CRMRevitTools-v2017\CRMRevitTools_Help\css\*"; DestDir: "{userdocs}\CRMRevitTools\v2017\CRMRevitTools_Help\css"; Flags: ignoreversion

;Create Revit Sheets
Source: "C:\Revit Programming\CRMRevitTools-v2017\CRMRevitTools_Help\images\create_revit_sheets\*"; DestDir: "{userdocs}\CRMRevitTools\v2017\CRMRevitTools_Help\images\create_revit_sheets"; Flags: ignoreversion

;Shared Parameter Creator
Source: "C:\Revit Programming\CRMRevitTools-v2017\Parameter_Template-v2017.xlsx"; DestDir: "{userdocs}\CRMRevitTools\v2017\"; Flags: ignoreversion
Source: "C:\Revit Programming\CRMRevitTools-v2017\CRMRevitTools_Help\images\shared_parameter_creator\*"; DestDir: "{userdocs}\CRMRevitTools\v2017\CRMRevitTools_Help\images\shared_parameter_creator"; Flags: ignoreversion

;Sheet Renamer
Source: "C:\Revit Programming\CRMRevitTools-v2017\CRMRevitTools_Help\images\sheet_renamer\*"; DestDir: "{userdocs}\CRMRevitTools\v2017\CRMRevitTools_Help\images\sheet_renamer"; Flags: ignoreversion

[UninstallDelete] 
Type: dirifempty; Name: {userdocs}\CRMRevitTools;

[Run]
Filename: {userdocs}\CRMRevitTools\v2017\CRMRevitToolsInit-v2017.exe;

