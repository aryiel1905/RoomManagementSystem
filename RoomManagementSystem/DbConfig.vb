Imports System.Configuration
Imports System.IO

Public Module DbConfig
    Public Function GetDbPath() As String
        Dim networkPath = ConfigurationManager.AppSettings("NetworkDbPath")
        Dim localFile = ConfigurationManager.AppSettings("LocalDbFile")

        If Not String.IsNullOrWhiteSpace(networkPath) AndAlso File.Exists(networkPath) Then
            Return networkPath
        End If

        If String.IsNullOrWhiteSpace(localFile) Then
            localFile = "AryielResortDB.mdb"
        End If

        Return Path.Combine(Application.StartupPath, localFile)
    End Function

    Public Function GetConnStr() As String
        Dim provider = ConfigurationManager.AppSettings("DbProvider")
        If String.IsNullOrWhiteSpace(provider) Then
            provider = "Microsoft.Jet.OLEDB.4.0"
        End If

        Dim dbPath = GetDbPath()
        Return "Provider=" & provider & ";Data Source=" & dbPath & ";Persist Security Info=False;"
    End Function
End Module
