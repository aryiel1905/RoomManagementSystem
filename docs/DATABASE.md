# Database setup

The application uses a Microsoft Access `.mdb` database through `System.Data.OleDb`. The original `AryielResortDB.mdb` is private and is intentionally not published because it may contain user credentials, guest information, and transactions. No sample database or migration script is currently provided, so a fresh clone cannot run all workflows without a compatible database.

## Connection settings

`RoomManagementSystem/App.config` has three settings:

| Key | Default | Meaning |
| --- | --- | --- |
| `DbProvider` | `Microsoft.Jet.OLEDB.4.0` | OLE DB provider used to open the database. |
| `NetworkDbPath` | empty | An optional full path to a shared database. Used only if the file exists. |
| `LocalDbFile` | `AryielResortDB.mdb` | Local filename beside the executable. |

`DbConfig.GetDbPath()` resolves the path, and `DbConfig.GetConnStr()` builds the connection string. Keep machine-specific paths out of committed `App.config` values.

## Schema expectations

The source refers to tables for users, rooms, bookings, stays, payments, stock, and related resort operations. Field names and relationships are defined by the SQL statements in the form code. A compatible database must match those statements; an empty Access file alone is not sufficient. Existing local database exports are not included in this public repository because they have not been prepared as a reproducible, data-free schema migration.

For development, use a separate copy of your database with test accounts and synthetic guest data. Never publish or commit a production database.
