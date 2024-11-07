; -- sync.iss --

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!
#define exePath "D:\Development\Jenks\jenks-vva-vr\VVA Controller\VVA Controller\bin\Release\VVA_Controller.exe"

; Extracts the semantic version from the executable. Only retains the patch number if it is greater than zero.
#define SemanticVersion() \
   GetVersionComponents(exePath, Local[0], Local[1], Local[2], Local[3]), \
   Str(Local[0]) + "." + Str(Local[1]) + ((Local[2]>0) ? "." + Str(Local[2]) : "")
    
; The installer contains the semantic version number, but replaces the dots with dashes so it doesn't look like a file extension.
#define installerName "VVA_" + StringChange(SemanticVersion(), '.', '-')

[Setup]
AppName=VVA
AppVerName=VVA  V{#SemanticVersion()}
DefaultDirName={commonpf}\Jenks\VVA\V{#SemanticVersion()}
OutputDir = Output
DefaultGroupName=Jenks
AllowNoIcons=yes
OutputBaseFilename={#installername}
UsePreviousAppDir=no
UsePreviousGroup=no
UsePreviousSetupType=no
DisableProgramGroupPage=yes
DisableReadyMemo=yes
PrivilegesRequired=admin

[Files]
Source: "D:\Development\Jenks\jenks-vva-vr\VVA VR\Build\*.*"; DestDir: "{app}\VR"; Flags: replacesameversion recursesubdirs;
Source: "D:\Development\Jenks\jenks-vva-vr\VVA Controller\VVA Controller\bin\Release\*.*"; DestDir: "{app}\Controller"; Flags: replacesameversion;
Source: "D:\Development\Jenks\jenks-vva-vr\VVA Controller\VVA Controller\bin\Release\Images\*.ico"; DestDir: "{app}\Controller"; Flags: replacesameversion;

[Icons]
Name: "{commondesktop}\VVA VR Controller"; Filename: "{app}\Controller\VVA_Controller.exe"; IconFilename: "{app}\Controller\VVA.ico"; IconIndex: 0;
;Name: "{commondesktop}\NAVI VR"; Filename: "{app}\NAVI VR\NAVI VR.exe"; IconFilename: "{app}\NAVI VR\NAVI VR.ico"; IconIndex: 0;
