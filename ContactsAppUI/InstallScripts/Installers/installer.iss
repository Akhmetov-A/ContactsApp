#define MyAppName "ContactsApp"
#define MyAppVersion "1.0.0"
#Define MyAppPublisher "MyCompany"
#define MyAppURL "https://github.com/Akhmetov-A/ContactsApp"
#define MyAppExeName "ContactsApp.exe"

[Setup]
AppId={{46521D30-F550-44FE-A353-6BBC957792E9}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableProgramGroupPage=yes
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\User\source\repos\ContactsApp\ContactsAppUI\InstallScripts\Release\*.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\User\source\repos\ContactsApp\ContactsAppUI\InstallScripts\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon