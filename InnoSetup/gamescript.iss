#define MyAppName "Dungeon Fragments"
#define MyAppVersion "1.0"
#define MyAppExeName "Dungeon-Fragments.exe"

[Setup]
AppName={#MyAppName}
AppVersion={#MyAppVersion}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputBaseFilename=DungeonFragments_Setup
Compression=lzma
SolidCompression=yes

[Files]
Source: "C:\Users\Belousov\Desktop\Game\*"; DestDir: "{app}"; Flags: recursesubdirs

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Launch {#MyAppName}"; Flags: postinstall