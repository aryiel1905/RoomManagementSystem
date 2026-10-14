# Development setup

## Prerequisites

- Windows and Visual Studio with .NET Framework 4.8 desktop development tools
- A 32-bit Microsoft Jet OLE DB provider for the default `.mdb` database connection
- NuGet package restore access for the packages listed in `RoomManagementSystem/packages.config`
- SAP Crystal Reports for Visual Studio and a compatible runtime to design, preview, or print `.rpt` reports
- A private Access database with the schema expected by the source code

## Build and run

1. Open `RoomManagementSystem.sln`.
2. Restore NuGet packages. The `packages/` folder is generated locally and is not committed.
3. Choose `Debug|x86` in Configuration Manager.
4. Put your private `AryielResortDB.mdb` next to the built `RoomManagementSystem.exe`, or configure a valid `NetworkDbPath` in `RoomManagementSystem/App.config` before building.
5. Build and start the application. Sign in with an account from your own database.

The executable is usually under `RoomManagementSystem/bin/x86/Debug/`. The `.mdb` filename can be changed with the `LocalDbFile` application setting. The app uses `NetworkDbPath` only when that file exists; otherwise it falls back to `LocalDbFile` next to the executable.

## Common problems

| Symptom | Check |
| --- | --- |
| `Microsoft.Jet.OLEDB.4.0` is not registered | Run with the x86 target and ensure the 32-bit provider is installed. |
| Database file cannot be found | Check the path beside the executable or the configured `NetworkDbPath`. |
| Login fails | Use an account present in the supplied database; this repository does not include default credentials. |
| Crystal Reports reference or preview errors | Install a compatible Crystal Reports developer integration and runtime. |
| NuGet references are missing | Restore packages before building. |

Do not commit `.mdb` or `.accdb` files, credentials, customer records, or local build output. The `.gitignore` excludes these files from normal staging.
