Imports System.Data.OleDb

Friend Module BookingStateHelpers
    Friend Sub RecomputeRoomStatus(roomId As Integer)
        If roomId <= 0 Then Return

        Using conn As New OleDbConnection(DbConfig.GetConnStr())
            conn.Open()
            RecomputeRoomStatus(roomId, conn, Nothing)
        End Using
    End Sub

    Friend Sub RecomputeRoomStatus(roomId As Integer, conn As OleDbConnection, tx As OleDbTransaction)
        If roomId <= 0 OrElse conn Is Nothing Then Return

        Dim hasCheckedIn As Boolean = False
        Dim hasReserved As Boolean = False

        Using cmdOcc As New OleDbCommand(
            "SELECT COUNT(*) FROM tblBookings " &
            "WHERE RoomID=? AND [Booking Status]='Checked In';",
            conn)
            If tx IsNot Nothing Then cmdOcc.Transaction = tx
            cmdOcc.Parameters.Add("?", OleDbType.Integer).Value = roomId
            hasCheckedIn = SafeCount(cmdOcc.ExecuteScalar()) > 0
        End Using

        If Not hasCheckedIn Then
            Using cmdRes As New OleDbCommand(
                "SELECT COUNT(*) FROM tblBookings " &
                "WHERE RoomID=? AND [Booking Status]='Reserved';",
                conn)
                If tx IsNot Nothing Then cmdRes.Transaction = tx
                cmdRes.Parameters.Add("?", OleDbType.Integer).Value = roomId
                hasReserved = SafeCount(cmdRes.ExecuteScalar()) > 0
            End Using
        End If

        Dim newStatus As String = "Available"
        If hasCheckedIn Then
            newStatus = "Occupied"
        ElseIf hasReserved Then
            newStatus = "Reserved"
        End If

        Using cmdUp As New OleDbCommand(
            "UPDATE tblRooms SET [Room Status]=? " &
            "WHERE RoomID=? AND [Room Status] NOT IN ('Maintenance','Inactive');",
            conn)
            If tx IsNot Nothing Then cmdUp.Transaction = tx
            cmdUp.Parameters.Add("?", OleDbType.VarWChar).Value = newStatus
            cmdUp.Parameters.Add("?", OleDbType.Integer).Value = roomId
            cmdUp.ExecuteNonQuery()
        End Using
    End Sub

    Private Function SafeCount(value As Object) As Integer
        If value Is Nothing OrElse value Is DBNull.Value Then Return 0
        Return Convert.ToInt32(value)
    End Function
End Module
