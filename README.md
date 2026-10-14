# Room Management System

A Windows Forms desktop application for resort room operations, written in VB.NET. It covers reservations, check-in, guest stays, check-out, room maintenance, payments and charges, dining/bar sales, user accounts, and Crystal Reports output.

## Technology

- VB.NET Windows Forms on .NET Framework 4.8
- Microsoft Access database through OLE DB (`Microsoft.Jet.OLEDB.4.0`)
- NuGet packages listed in `RoomManagementSystem/packages.config`
- SAP Crystal Reports for report design and preview

## Getting started

1. On Windows, install Visual Studio with .NET Framework 4.8 desktop development support.
2. Open `RoomManagementSystem.sln` and restore NuGet packages when prompted.
3. Select the **x86** solution platform. The configured Jet OLE DB provider is 32-bit.
4. Provide an Access database that matches the application's expected tables and fields. This repository does **not** contain the original database, its user accounts, or guest data. See [Database setup](docs/DATABASE.md).
5. Build the solution and run it from Visual Studio. The app opens at the login screen; a valid account in the supplied database is needed to use the application.

Report preview and printing also require a compatible SAP Crystal Reports runtime. See [Development setup](docs/SETUP.md) for details and troubleshooting.

## Project layout

| Path | Purpose |
| --- | --- |
| `RoomManagementSystem.sln` | Visual Studio solution |
| `RoomManagementSystem/` | Application source, forms, resources, and configuration |
| `RoomManagementSystem/DbConfig.vb` | Database path and OLE DB connection settings |
| `RoomManagementSystem/*.rpt` | Crystal Reports designs |
| `RoomManagementSystem/ReportTemplate.xlsx` | Report spreadsheet template |
| `*_User_Manual.txt` | Existing screen-specific user notes |
| `docs/` | Setup and database documentation |

## Current limitations

This is a source code portfolio project, not a ready-to-run installer. A compatible Access database is required, and the original database is intentionally private. The current login code compares passwords with values stored in the database; that design should be replaced with password hashing before using the application with real accounts in a production setting. Application workflows have not been fully automated or tested end to end.

## Verification

The renamed solution was previously built with Visual Studio 2015 MSBuild using `Debug|x86`. The executable opened the Reservations window and connected to a local Access database. This confirms a local build and startup path, not every workflow or a clean-machine install.
