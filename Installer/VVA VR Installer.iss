; -- sync.iss --

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!
#define exePath "D:\Development\Jenks\jenks-vva-vr\VVA Controller\VVA Controller\bin\Release\VVA_Controller.exe"
#define verStr GetFileVersion(exePath)
#define lastDot RPos(".", verStr)
#define verStr Copy(verStr, 0, lastDot-1)
#define verStr_ StringChange(verStr, '.', '-')

;#include "CommonInfo.iss"

[Setup]
AppName=VVA
AppVerName=VVA V{#verStr}
DefaultDirName={commonpf}\Jenks\VVA\V{code:GetVersionString|{#exePath}}
OutputDir = Output
DefaultGroupName=Jenks
AllowNoIcons=yes
OutputBaseFilename=VVA_{#verStr_}
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

[Code]
function GetVersionString(Param: String): String;
var
  major : Word;
  minor : Word;
  revision : Word;
  build : Word;

begin
    GetVersionComponents(Param, major, minor, revision, build); 
    Result := IntToStr(major) + '.' + IntToStr(minor);
    if (revision > 0) then begin
      Result := Result + '.' + IntToStr(revision);
    end;
end;

