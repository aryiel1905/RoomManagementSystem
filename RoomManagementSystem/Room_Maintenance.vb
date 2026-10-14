Imports System.Data.OleDb
Imports System.Globalization
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms


Public Class frmRooms

    Private IsDirty As Boolean = False
    Private SuppressPhotoRefresh As Boolean = False
    Private SuppressFilterChange As Boolean = False
    Private LastStatusValue As String = ""

    Public ReadOnly ConnStr As String = DbConfig.GetConnStr()


    Private ReadOnly PH As CultureInfo = CultureInfo.GetCultureInfo("en-PH")


    ' ==== Button Theme Colors ====
    Private ReadOnly BtnEnabledBack As Color = Color.Teal   ' change to Color.Azure if you want
    Private ReadOnly BtnEnabledFore As Color = Color.White

    Private ReadOnly BtnDisabledBack As Color = Color.Gray
    Private ReadOnly BtnDisabledFore As Color = Color.White

    Private Sub InitActionButtonsStyle()
        Dim buttons = New Button() {btnAdd, btnSave, btnEdit, btnCancel, btnDelete}

        For Each b In buttons
            b.UseVisualStyleBackColor = False
            b.FlatAppearance.BorderSize = 0
            b.FlatAppearance.MouseOverBackColor = BtnEnabledBack
            b.FlatAppearance.MouseDownBackColor = BtnEnabledBack
        Next

        RefreshActionButtonsStyle()
    End Sub

    Private Sub frmRooms_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        dgvRooms.Focus()
    End Sub

    Private Sub AnyInputChanged(sender As Object, e As EventArgs) Handles _
      txtRoomNo.TextChanged, txtRoomType.TextChanged, txtRoomClass.TextChanged,
      nudIncludedPax.ValueChanged, nudBaseRate.ValueChanged,
  nudExtraPaxRate.ValueChanged,
      nudExtraMattressRate.ValueChanged, cboStatus.SelectedIndexChanged,
  cboStatus.TextChanged
        If CurrentMode = FormMode.Adding OrElse CurrentMode = FormMode.Editing Then
            IsDirty = True
        End If
    End Sub

    Private Sub FillPriceCombo()
        Dim dt As New DataTable()
        dt.Columns.Add("PriceValue", GetType(Decimal))
        dt.Columns.Add("PriceText", GetType(String))

        ' Optional: first row (no filter)
        dt.Rows.Add(DBNull.Value, "All Prices")

        Using conn As New OleDbConnection(ConnStr)
            conn.Open()
            Using cmd As New OleDbCommand("SELECT DISTINCT [Base Rate] FROM tblRooms ORDER BY [Base Rate];", conn)
                Using rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        If Not IsDBNull(rdr("Base Rate")) Then
                            Dim v As Decimal = CDec(rdr("Base Rate"))
                            dt.Rows.Add(v, v.ToString("C2", PH)) ' ₱ formatted
                        End If
                    End While
                End Using
            End Using
        End Using

        cboPrice.DataSource = dt
        cboPrice.DisplayMember = "PriceText"
        cboPrice.ValueMember = "PriceValue"
        cboPrice.SelectedIndex = 0
    End Sub

    Private Sub RefreshActionButtonsStyle()
        Dim buttons = New Button() {btnAdd, btnSave, btnEdit, btnCancel, btnDelete}

        For Each b In buttons
            If b.Enabled Then
                b.BackColor = BtnEnabledBack
                b.ForeColor = BtnEnabledFore
            Else
                b.BackColor = BtnDisabledBack
                b.ForeColor = BtnDisabledFore
            End If
        Next
    End Sub


    Private Enum FormMode
        ViewMode
        Adding
        Editing
    End Enum

    Private CurrentMode As FormMode = FormMode.ViewMode
    Private SelectedRoomID As Integer = -1

    Private Sub frmRooms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCombos()
        LoadRooms()
        LoadFilterCombosFromDB()
        InitActionButtonsStyle()
        SetMode(FormMode.ViewMode)
        gbRooms.Font = New Font(gbRooms.Font, FontStyle.Bold)
        gbRoomDetails.Font = New Font(gbRooms.Font, FontStyle.Bold)
        gbFilter.Font = New Font(gbRooms.Font, FontStyle.Bold)
        ApplyRoomsGridLayout_Fixed()
        MigrateRoomPhotoNames()


    End Sub

    Private Sub FillCombos()
        Dim statuses = New String() {"Available", "Reserved", "Occupied", "Maintenance", "Inactive"}
        cboStatus.Items.Clear()
        cboStatus.Items.AddRange(statuses)

        cboFilterType.SelectedIndex = -1
        cboFilterClass.SelectedIndex = -1
    End Sub

    Private Sub LoadFilterCombosFromDB()
        SuppressFilterChange = True
        Try
            cboFilterType.Items.Clear()
            cboFilterClass.Items.Clear()
            cboFilterStatus.Items.Clear()

            cboFilterType.Items.Add("All Types")
            cboFilterClass.Items.Add("All Classes")
            cboFilterStatus.Items.Add("All Status")

            Try
                Using conn As New OleDbConnection(ConnStr)
                    conn.Open()

                    Using cmd As New OleDbCommand("SELECT DISTINCT [Room Type] FROM tblRooms WHERE [Room Type] Is Not Null ORDER BY [Room Type];", conn),
                          reader = cmd.ExecuteReader()
                        While reader.Read()
                            cboFilterType.Items.Add(reader(0).ToString())
                        End While
                    End Using

                    Using cmd As New OleDbCommand("SELECT DISTINCT [Class] FROM tblRooms WHERE [Class] Is Not Null ORDER BY [Class];", conn),
                          reader = cmd.ExecuteReader()
                        While reader.Read()
                            cboFilterClass.Items.Add(reader(0).ToString())
                        End While
                    End Using

                    Using cmd As New OleDbCommand("SELECT DISTINCT [Room Status] FROM tblRooms WHERE [Room Status] Is Not Null ORDER BY [Room Status];", conn),
                          reader = cmd.ExecuteReader()
                        While reader.Read()
                            cboFilterStatus.Items.Add(reader(0).ToString())
                        End While
                    End Using

                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error loading filters")
            End Try

            FillPriceCombo()

            cboFilterType.SelectedIndex = 0
            cboFilterClass.SelectedIndex = 0
            cboFilterStatus.SelectedIndex = 0
            cboPrice.SelectedIndex = 0
        Finally
            SuppressFilterChange = False
        End Try
    End Sub

    Private Sub LoadRooms()
        Dim dt As New DataTable()

        Dim selectRooms As String =
    "SELECT RoomID, [Room No], [Room Type], [Class], [Included Pax], [Base Rate], [Extra Pax Rate], [Extra Mattress Rate], [Room Status], RoomPhotoPath " &
    "FROM tblRooms ORDER BY [Room No];"



        Try
            Using conn As New OleDbConnection(ConnStr),
              cmd As New OleDbCommand(selectRooms, conn),
              da As New OleDbDataAdapter(cmd)

                da.Fill(dt)
            End Using

            dgvRooms.DataSource = dt

            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvRooms.MultiSelect = False
            dgvRooms.ReadOnly = True
            dgvRooms.AllowUserToAddRows = False
            dgvRooms.RowHeadersVisible = False



            If dgvRooms.Columns.Contains("RoomID") Then dgvRooms.Columns("RoomID").Visible = False

            FormatGrid()
            ApplyRoomsGridLayout_Fixed()

            dgvRooms.DefaultCellStyle.Font = New Font(dgvRooms.Font.FontFamily, 12.0F)
            dgvRooms.ColumnHeadersDefaultCellStyle.Font = New Font(dgvRooms.Font.FontFamily, 11.0F, FontStyle.Bold)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error loading rooms")
        End Try

        If dgvRooms.Columns.Contains("RoomPhotoPath") Then
            dgvRooms.Columns("RoomPhotoPath").Visible = False
        End If
    End Sub

    Private Sub ApplyRoomsGridLayout_Fixed()
        dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvRooms.AllowUserToResizeColumns = False

        dgvRooms.Columns("Room No").Width = 110
        dgvRooms.Columns("Room Type").Width = 150
        dgvRooms.Columns("Class").Width = 115
        dgvRooms.Columns("Included Pax").Width = 125
        dgvRooms.Columns("Base Rate").Width = 109

        dgvRooms.Columns("Extra Pax Rate").Width = 135
        dgvRooms.Columns("Extra Mattress Rate").Width = 175
        dgvRooms.Columns("Room Status").Width = 140
    End Sub

    Private Sub FormatGrid()
        FormatMoneyColumn("Base Rate")
        FormatMoneyColumn("Extra Pax Rate")
        FormatMoneyColumn("Extra Mattress Rate")
    End Sub

    Private Sub FormatMoneyColumn(colName As String)
        If Not dgvRooms.Columns.Contains(colName) Then Exit Sub

        With dgvRooms.Columns(colName).DefaultCellStyle
            .Format = "C0"                 ' Currency, 2 decimals
            .FormatProvider = PH           ' Forces ₱ using PH culture
            .Alignment = DataGridViewContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub dgvRooms_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvRooms.CellFormatting
        Dim colName = dgvRooms.Columns(e.ColumnIndex).Name
        If colName = "Extra Pax Rate" OrElse colName = "Extra Mattress Rate" Then
            If e.Value Is Nothing OrElse IsDBNull(e.Value) Then
                e.Value = "N/A"
                e.FormattingApplied = True
            ElseIf IsNumeric(e.Value) AndAlso Convert.ToDecimal(e.Value) = 0D Then
                e.Value = "N/A"
                e.FormattingApplied = True
            End If
        End If
    End Sub



    Private Sub dgvRooms_SelectionChanged(sender As Object, e As EventArgs) Handles dgvRooms.SelectionChanged

        If CurrentMode <> FormMode.ViewMode Then Exit Sub
        If SuppressPhotoRefresh Then Exit Sub
        If dgvRooms.CurrentCell Is Nothing Then Exit Sub

        Dim row = dgvRooms.Rows(dgvRooms.CurrentCell.RowIndex)
        If row Is Nothing OrElse row.DataBoundItem Is Nothing Then Exit Sub

        UpdateDetailsFromRow(row)
    End Sub

    Private Sub MoveRoomSelection(delta As Integer)
        If dgvRooms.CurrentCell Is Nothing Then Return

        Dim colName As String = "Room No"
        If Not dgvRooms.Columns.Contains(colName) Then Return

        Dim targetRow As Integer = dgvRooms.CurrentCell.RowIndex + delta
        If targetRow >= dgvRooms.Rows.Count Then targetRow = 0
        If targetRow < 0 Then targetRow = dgvRooms.Rows.Count - 1

        dgvRooms.ClearSelection()
        dgvRooms.CurrentCell = dgvRooms.Rows(targetRow).Cells(colName)
        dgvRooms.Rows(targetRow).Selected = True
        UpdateDetailsFromRow(dgvRooms.Rows(targetRow))
    End Sub

    Private Sub dgvRooms_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvRooms.KeyDown
        If dgvRooms.CurrentCell Is Nothing Then Return

        If e.KeyCode = Keys.Tab Then
            e.Handled = True
            e.SuppressKeyPress = True
            Me.SelectNextControl(dgvRooms, Not e.Shift, True, True, True)
            Return
        End If

        If e.KeyCode = Keys.Down Then
            MoveRoomSelection(1)
            e.Handled = True
            e.SuppressKeyPress = True
            Return
        End If

        If e.KeyCode = Keys.Up Then
            MoveRoomSelection(-1)
            e.Handled = True
            e.SuppressKeyPress = True
            Return
        End If
    End Sub



    Private Sub PopulateInputsFromGrid(Optional row As DataGridViewRow = Nothing)
        If row Is Nothing Then
            row = dgvRooms.CurrentRow
        End If
        If row Is Nothing Then Return

        If row.Cells("RoomID").Value IsNot Nothing Then
            SelectedRoomID = Convert.ToInt32(row.Cells("RoomID").Value)
        Else
            SelectedRoomID = -1
        End If

        txtRoomNo.Text = row.Cells("Room No").Value?.ToString()
        txtRoomType.Text = row.Cells("Room Type").Value?.ToString()
        txtRoomClass.Text = row.Cells("Class").Value?.ToString()
        cboStatus.Text = row.Cells("Room Status").Value?.ToString()

        nudIncludedPax.Value = SafeDecimal(row.Cells("Included Pax").Value)
        nudBaseRate.Value = SafeDecimal(row.Cells("Base Rate").Value)
        nudExtraPaxRate.Value = SafeDecimal(row.Cells("Extra Pax Rate").Value)
        nudExtraMattressRate.Value = SafeDecimal(row.Cells("Extra Mattress Rate").Value)

        SetMode(FormMode.ViewMode)
    End Sub

    Private Sub UpdateDetailsFromRow(row As DataGridViewRow)
        If row Is Nothing Then Return
        If CurrentMode <> FormMode.ViewMode Then Return
        If SuppressPhotoRefresh Then Return

        PopulateInputsFromGrid(row)

        If dgvRooms.Columns.Contains("RoomPhotoPath") Then
            LoadRoomPhoto(row.Cells("RoomPhotoPath").Value)
        Else
            pbRooms.Image = Nothing
        End If
    End Sub

    Private Function SafeDecimal(v As Object) As Decimal
        If v Is Nothing OrElse IsDBNull(v) Then Return 0D
        Dim d As Decimal
        If Decimal.TryParse(v.ToString(), d) Then Return d
        Return 0D
    End Function

    Private Function SafeInteger(v As Object) As Integer
        If v Is Nothing OrElse IsDBNull(v) Then Return 0
        Dim i As Integer
        If Integer.TryParse(v.ToString(), i) Then Return i
        Dim d As Decimal
        If Decimal.TryParse(v.ToString(), d) Then Return CInt(d)
        Return 0
    End Function

    Private Function SafeString(v As Object) As String
        If v Is Nothing OrElse IsDBNull(v) Then Return ""
        Return v.ToString()
    End Function

    Private Sub FocusRoomRowById(roomId As Integer)
        If roomId <= 0 Then Return
        If Not dgvRooms.Columns.Contains("RoomID") Then Return

        dgvRooms.ClearSelection()

        For Each row As DataGridViewRow In dgvRooms.Rows
            Dim idObj = row.Cells("RoomID").Value
            If idObj IsNot Nothing AndAlso Not IsDBNull(idObj) AndAlso CInt(idObj) = roomId Then
                Dim colName As String = "Room No"
                If dgvRooms.Columns.Contains(colName) Then
                    dgvRooms.CurrentCell = row.Cells(colName)
                Else
                    dgvRooms.CurrentCell = row.Cells(0)
                End If
                row.Selected = True
                dgvRooms.Focus()
                If dgvRooms.Columns.Contains("RoomPhotoPath") Then
                    LoadRoomPhoto(row.Cells("RoomPhotoPath").Value)
                Else
                    pbRooms.Image = Nothing
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub SetMode(mode As FormMode)
        CurrentMode = mode

        Dim editing As Boolean
        editing = False

        If mode = FormMode.Adding Then
            editing = True
        End If

        If mode = FormMode.Editing Then
            editing = True
        End If

        If mode = FormMode.ViewMode Then
            IsDirty = False
        End If

        If mode = FormMode.Adding Then
            dgvRooms.ClearSelection()
            pbRooms.Image = Nothing
            pbRooms.ImageLocation = Nothing
        End If

        gbRooms.Enabled = Not editing
        gbFilter.Enabled = Not editing

        txtRoomNo.Enabled = True
        txtRoomType.Enabled = True
        txtRoomClass.Enabled = True
        nudIncludedPax.Enabled = True
        nudBaseRate.Enabled = True
        nudExtraPaxRate.Enabled = True
        nudExtraMattressRate.Enabled = True
        cboStatus.Enabled = True

        txtRoomNo.ReadOnly = Not editing
        txtRoomType.ReadOnly = Not editing
        txtRoomClass.ReadOnly = Not editing
        nudIncludedPax.ReadOnly = Not editing
        nudBaseRate.ReadOnly = Not editing
        nudExtraPaxRate.ReadOnly = Not editing
        nudExtraMattressRate.ReadOnly = Not editing

        txtRoomNo.BackColor = Color.White
        txtRoomType.BackColor = Color.White
        txtRoomClass.BackColor = Color.White
        nudIncludedPax.BackColor = Color.White
        nudBaseRate.BackColor = Color.White
        nudExtraPaxRate.BackColor = Color.White
        nudExtraMattressRate.BackColor = Color.White
        cboStatus.BackColor = Color.White

        txtRoomNo.ForeColor = Color.Black
        txtRoomType.ForeColor = Color.Black
        txtRoomClass.ForeColor = Color.Black
        nudIncludedPax.ForeColor = Color.Black
        nudBaseRate.ForeColor = Color.Black
        nudExtraPaxRate.ForeColor = Color.Black
        nudExtraMattressRate.ForeColor = Color.Black
        cboStatus.ForeColor = Color.Black

        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        If Not editing Then
            LastStatusValue = cboStatus.Text
        End If

        txtRoomNo.TabStop = editing
        txtRoomType.TabStop = editing
        txtRoomClass.TabStop = editing
        nudIncludedPax.TabStop = editing
        nudBaseRate.TabStop = editing
        nudExtraPaxRate.TabStop = editing
        nudExtraMattressRate.TabStop = editing
        cboStatus.TabStop = editing

        DisableNumericButtons(nudIncludedPax, editing)
        DisableNumericButtons(nudBaseRate, editing)
        DisableNumericButtons(nudExtraPaxRate, editing)
        DisableNumericButtons(nudExtraMattressRate, editing)
        btnPhotoRooms.Visible = editing
        btnPhotoRooms.Enabled = editing


        btnSave.Enabled = editing
        btnCancel.Enabled = editing

        btnAdd.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = True

        If editing = True Then
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False


        End If

        If editing = False Then
            If SelectedRoomID <= 0 Then
                btnEdit.Enabled = False
                btnDelete.Enabled = False
            End If
        End If

        btnMnuSave.Enabled = btnSave.Enabled
        btnMnuCancel.Enabled = btnCancel.Enabled
        btnMnuAddNew.Enabled = btnAdd.Enabled
        btnMnuEdit.Enabled = btnEdit.Enabled
        btnMnuDelete.Enabled = btnDelete.Enabled

        RefreshActionButtonsStyle()

    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click, btnMnuAddNew.Click
        SelectedRoomID = -1
        ClearInputsDefaults()
        SetMode(FormMode.Adding)

        FocusAndSelect(txtRoomNo)

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click, btnMnuEdit.Click
        If SelectedRoomID <= 0 Then
            MessageBox.Show("Please select a room to edit.")
            Return
        End If
        SetMode(FormMode.Editing)


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click, btnMnuCancel.Click
        If dgvRooms.CurrentRow IsNot Nothing Then
            PopulateInputsFromGrid()
        Else
            ClearInputsDefaults()
        End If

        SetMode(FormMode.ViewMode)
        FocusRoomRowById(SelectedRoomID)
    End Sub

    Private Sub ClearInputsDefaults()
        txtRoomNo.Clear()
        txtRoomType.Clear()
        txtRoomClass.Clear()
        cboStatus.Text = "Available"

        nudIncludedPax.Value = 0
        nudBaseRate.Value = 0
        nudExtraPaxRate.Value = 0
        nudExtraMattressRate.Value = 0
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtRoomNo.Text) Then
            MessageBox.Show("Room Number is required.", "Room Number Error",
  MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoomNo.Focus()
            Return False
        End If

        If IsRoomNoTaken(txtRoomNo.Text.Trim(), If(CurrentMode = FormMode.Editing, SelectedRoomID, -1)) Then
            MessageBox.Show("Room Number already exists.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRoomNo.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtRoomType.Text) Then
            MessageBox.Show("Room Type is required.", "Room Type Error",
  MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoomType.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtRoomClass.Text) Then
            MessageBox.Show("Classification is required.", "Class Error",
  MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoomClass.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(cboStatus.Text) Then
            MessageBox.Show("Room Status is required.", "Status Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboStatus.Focus()
            Return False
        End If

        If nudIncludedPax.Value < 0 OrElse nudBaseRate.Value < 0 OrElse nudExtraPaxRate.Value < 0 OrElse nudExtraMattressRate.Value < 0 Then
            MessageBox.Show("Numeric fields cannot be negative.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function IsRoomNoTaken(roomNo As String, excludeRoomId As Integer) As Boolean
        Dim sql As String = "SELECT COUNT(*) FROM tblRooms WHERE [Room No]=?"
        If excludeRoomId > 0 Then
            sql &= " AND RoomID<>?"
        End If

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand(sql, conn)
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = roomNo
                    If excludeRoomId > 0 Then
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = excludeRoomId
                    End If
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to validate Room Number." & vbCrLf & ex.Message, "Validation Error")
            Return True
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click, btnMnuSave.Click
        If ValidateInputs() = False Then Exit Sub

        If Not IsDirty Then
            MessageBox.Show("No changes to save.")
            Exit Sub
        End If

        Dim confirmText As String
        Dim confirmTitle As String
        If CurrentMode = FormMode.Adding Then
            confirmText = "Do you want to add this room?"
            confirmTitle = "Confirm Add"
        ElseIf CurrentMode = FormMode.Editing Then
            confirmText = "Do you want to save these changes?"
            confirmTitle = "Confirm Update"
        Else
            confirmText = "Do you want to save this room?"
            confirmTitle = "Confirm Save"
        End If

        If MessageBox.Show(confirmText, confirmTitle,
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()

                If CurrentMode = FormMode.Adding Then
                    Dim sqlInsert As String =
                    "INSERT INTO tblRooms ([Room No], [Room Type], [Class], [Included Pax], [Base Rate], [Extra Pax Rate], [Extra Mattress Rate], [Room Status]) " &
                    "VALUES (?,?,?,?,?,?,?,?);"

                    Using cmd As New OleDbCommand(sqlInsert, conn)
                        AddRoomParameters(cmd)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' Get new RoomID right away (same connection)
                    Using cmdId As New OleDbCommand("SELECT @@IDENTITY", conn)
                        SelectedRoomID = Convert.ToInt32(cmdId.ExecuteScalar())
                    End Using

                ElseIf CurrentMode = FormMode.Editing Then
                    Dim sqlUpdate As String =
                    "UPDATE tblRooms SET [Room No]=?, [Room Type]=?, [Class]=?, [Included Pax]=?, [Base Rate]=?, [Extra Pax Rate]=?, [Extra Mattress Rate]=?, [Room Status]=? " &
                    "WHERE RoomID=?;"

                    Using cmd As New OleDbCommand(sqlUpdate, conn)
                        AddRoomParameters(cmd)
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = SelectedRoomID
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using

            Dim savedRoomId As Integer = SelectedRoomID

            If PendingPhotoSourcePath <> "" Then
                SaveRoomPhoto(savedRoomId)
            End If

            LoadRooms()
            LoadFilterCombosFromDB()

            IsDirty = False
            SetMode(FormMode.ViewMode)
            FocusRoomRowById(savedRoomId)
            PopulateInputsFromGrid()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save failed")
        End Try
    End Sub



    Private Sub AddRoomParameters(cmd As OleDbCommand)
        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtRoomNo.Text.Trim()
        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtRoomType.Text.Trim()
        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtRoomClass.Text.Trim()
        cmd.Parameters.Add("?", OleDbType.Integer).Value = CInt(nudIncludedPax.Value)
        cmd.Parameters.Add("?", OleDbType.Currency).Value = nudBaseRate.Value
        cmd.Parameters.Add("?", OleDbType.Currency).Value = nudExtraPaxRate.Value
        cmd.Parameters.Add("?", OleDbType.Currency).Value = nudExtraMattressRate.Value
        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboStatus.Text
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click, btnMnuDelete.Click
        If SelectedRoomID <= 0 Then
            MessageBox.Show("Please select a room to delete.")
            Return
        End If

        Dim previousRowIndex As Integer = -1
        If dgvRooms.CurrentRow IsNot Nothing Then
            previousRowIndex = dgvRooms.CurrentRow.Index
        End If

        Dim photoPathToDelete As String = ""
        If dgvRooms.CurrentRow IsNot Nothing AndAlso dgvRooms.Columns.Contains("RoomPhotoPath") Then
            photoPathToDelete = SafeString(dgvRooms.CurrentRow.Cells("RoomPhotoPath").Value)
        End If

        If MessageBox.Show("Do you really want to delete this room?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand("DELETE FROM tblRooms WHERE RoomID=?;", conn)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = SelectedRoomID
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            If Not String.IsNullOrWhiteSpace(photoPathToDelete) Then
                Dim fullPath As String
                If photoPathToDelete.StartsWith("\\") OrElse photoPathToDelete.Contains(":\") Then
                    fullPath = photoPathToDelete
                Else
                    fullPath = Path.Combine(RoomImagesFolder(), photoPathToDelete)
                End If
                If File.Exists(fullPath) Then
                    File.Delete(fullPath)
                End If
            End If

            LoadRooms()
            LoadFilterCombosFromDB()
            ClearInputsDefaults()
            SelectedRoomID = -1
            SetMode(FormMode.ViewMode)

            If dgvRooms.Rows.Count > 0 Then
                If previousRowIndex < 0 Then
                    previousRowIndex = 0
                ElseIf previousRowIndex >= dgvRooms.Rows.Count Then
                    previousRowIndex = dgvRooms.Rows.Count - 1
                End If

                Dim colName As String = "Room No"
                If dgvRooms.Columns.Contains(colName) Then
                    dgvRooms.CurrentCell = dgvRooms.Rows(previousRowIndex).Cells(colName)
                Else
                    dgvRooms.CurrentCell = dgvRooms.Rows(previousRowIndex).Cells(0)
                End If
                PopulateInputsFromGrid()
                If dgvRooms.Columns.Contains("RoomPhotoPath") Then
                    LoadRoomPhoto(dgvRooms.CurrentRow.Cells("RoomPhotoPath").Value)
                Else
                    pbRooms.Image = Nothing
                End If
            Else
                pbRooms.Image = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Cannot delete this room (it may be used in Reservation).", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub




    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        txtSearch.Clear()
        SuppressFilterChange = True
        cboFilterType.SelectedIndex = 0
        cboFilterClass.SelectedIndex = 0
        cboFilterStatus.SelectedIndex = 0
        cboPrice.SelectedIndex = 0
        SuppressFilterChange = False

        LoadRooms()
    End Sub

    Private Sub btnClearFilter_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles btnClearFilter.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub btnClearFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles btnClearFilter.KeyDown
        If e.KeyCode <> Keys.Tab Then Return

        e.Handled = True
        e.SuppressKeyPress = True

        If e.Shift Then
            Me.SelectNextControl(btnClearFilter, False, True, True, True)
            Return
        End If

        If dgvRooms.Rows.Count = 0 Then Return
        If dgvRooms.Columns.Contains("Room No") AndAlso dgvRooms.Columns("Room No").Visible Then
            dgvRooms.Focus()
            dgvRooms.CurrentCell = dgvRooms.Rows(0).Cells("Room No")
        End If
    End Sub

    Private Sub LoadRoomsFiltered()
        Dim dt As New DataTable()

        Dim selectRooms As String =
        "SELECT RoomID, [Room No], [Room Type], [Class], [Included Pax], [Base Rate], [Extra Pax Rate], [Extra Mattress Rate], [Room Status], RoomPhotoPath " &
        "FROM tblRooms WHERE 1=1 "

        ' Search
        If txtSearch.Text.Trim() <> "" Then
            selectRooms &= "AND [Room No] LIKE ? "
        End If

        ' Filters (skip index 0 = All ...)
        If cboFilterType.SelectedIndex > 0 Then
            selectRooms &= "AND [Room Type] = ? "
        End If

        If cboFilterClass.SelectedIndex > 0 Then
            selectRooms &= "AND [Class] = ? "
        End If

        If cboFilterStatus.SelectedIndex > 0 Then
            selectRooms &= "AND [Room Status] = ? "
        End If

        ' Price filter (skip index 0 = -- All Prices --)
        Dim hasPrice As Boolean = (cboPrice.SelectedIndex > 0 AndAlso
                              cboPrice.SelectedValue IsNot Nothing AndAlso
                              Not IsDBNull(cboPrice.SelectedValue))

        If hasPrice Then
            selectRooms &= "AND [Base Rate] = ? "
        End If

        selectRooms &= "ORDER BY [Room No];"

        Try
            Using conn As New OleDbConnection(ConnStr)
                Using cmd As New OleDbCommand(selectRooms, conn)

                    ' IMPORTANT: parameter order must match the ? order in SQL
                    If txtSearch.Text.Trim() <> "" Then
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = "%" & txtSearch.Text.Trim() & "%"
                    End If

                    If cboFilterType.SelectedIndex > 0 Then
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboFilterType.Text
                    End If

                    If cboFilterClass.SelectedIndex > 0 Then
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboFilterClass.Text
                    End If

                    If cboFilterStatus.SelectedIndex > 0 Then
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = cboFilterStatus.Text
                    End If

                    If hasPrice Then
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = CDec(cboPrice.SelectedValue)
                    End If

                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            dgvRooms.DataSource = dt

            If dgvRooms.Columns.Contains("RoomID") Then
                dgvRooms.Columns("RoomID").Visible = False
            End If

            FormatGrid()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Search failed")
        End Try
    End Sub

    Private Sub ApplyRoomFilters()
        Dim hasFilter As Boolean = False

        If txtSearch.Text.Trim() <> "" Then hasFilter = True
        If cboFilterType.SelectedIndex > 0 Then hasFilter = True
        If cboFilterClass.SelectedIndex > 0 Then hasFilter = True
        If cboFilterStatus.SelectedIndex > 0 Then hasFilter = True
        If cboPrice.SelectedIndex > 0 Then hasFilter = True

        If hasFilter Then
            LoadRoomsFiltered()
        Else
            LoadRooms()
        End If
    End Sub

    Private Sub FilterCombos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _
        cboFilterType.SelectedIndexChanged,
        cboFilterClass.SelectedIndexChanged,
        cboFilterStatus.SelectedIndexChanged,
        cboPrice.SelectedIndexChanged
        If SuppressFilterChange Then Return
        ApplyRoomFilters()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyRoomFilters()
    End Sub


    Private Sub DebugFilterQuery(sql As String, cmd As OleDbCommand)
        Dim msg As String = "SQL:" & vbCrLf & sql & vbCrLf & vbCrLf &
            "Parameter count: " & cmd.Parameters.Count.ToString()
        MessageBox.Show(msg, "Filter Debug")
    End Sub



    Private Sub mnuRefresh_Click(sender As Object, e As EventArgs) Handles mnuRefresh.Click
        Me.Validate()

        Dim hasFilter As Boolean = False

        If txtSearch.Text.Trim() <> "" Then hasFilter = True
        If cboFilterType.SelectedIndex > 0 Then hasFilter = True
        If cboFilterClass.SelectedIndex > 0 Then hasFilter = True
        If cboFilterStatus.SelectedIndex > 0 Then hasFilter = True
        If cboPrice.SelectedIndex > 0 Then hasFilter = True


        If hasFilter Then
            LoadRoomsFiltered()
        Else
            LoadRooms()
        End If

        LoadFilterCombosFromDB()
    End Sub


    Private Sub FocusAndSelect(ctrl As Control)
        ctrl.Focus()
        If TypeOf ctrl Is TextBox Then
            DirectCast(ctrl, TextBox).SelectAll()
        ElseIf TypeOf ctrl Is NumericUpDown Then
            DirectCast(ctrl, NumericUpDown).Select(0, DirectCast(ctrl, NumericUpDown).Text.Length)
        End If
    End Sub

    Private Sub NumericAutoSelect(sender As Object, e As EventArgs) Handles _
        nudIncludedPax.Enter, nudBaseRate.Enter, nudExtraPaxRate.Enter, nudExtraMattressRate.Enter,
        nudIncludedPax.Click, nudBaseRate.Click, nudExtraPaxRate.Click, nudExtraMattressRate.Click
        If CurrentMode = FormMode.Editing Then Return
        Dim nud = TryCast(sender, NumericUpDown)
        If nud Is Nothing Then Return
        BeginInvoke(Sub() nud.Select(0, nud.Text.Length))
    End Sub

    Private Sub cboStatus_DropDown(sender As Object, e As EventArgs) Handles cboStatus.DropDown
        If CurrentMode = FormMode.ViewMode Then
            cboStatus.DroppedDown = False
        End If
    End Sub

    Private Sub cboStatus_MouseDown(sender As Object, e As MouseEventArgs) Handles cboStatus.MouseDown
        If CurrentMode = FormMode.ViewMode Then
            cboStatus.DroppedDown = False
        End If
    End Sub

    Private Sub cboStatus_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboStatus.SelectionChangeCommitted
        If CurrentMode = FormMode.ViewMode Then
            cboStatus.Text = LastStatusValue
        End If
    End Sub

    Private Sub PreventViewModeFocus(sender As Object, e As EventArgs) Handles _
        txtRoomNo.Enter, txtRoomType.Enter, txtRoomClass.Enter,
        nudIncludedPax.Enter, nudBaseRate.Enter, nudExtraPaxRate.Enter, nudExtraMattressRate.Enter,
        cboStatus.Enter
        If CurrentMode <> FormMode.ViewMode Then Return
        BeginInvoke(Sub() dgvRooms.Focus())
    End Sub

    Private Sub DisableNumericButtons(nud As NumericUpDown, editing As Boolean)
        If nud Is Nothing OrElse nud.Controls.Count = 0 Then Return
        Dim buttons = TryCast(nud.Controls(0), Control)
        If buttons IsNot Nothing Then
            buttons.Enabled = editing
        End If
    End Sub

    Private Sub Numeric_MouseWheel(sender As Object, e As MouseEventArgs) Handles _
        nudIncludedPax.MouseWheel, nudBaseRate.MouseWheel, nudExtraPaxRate.MouseWheel, nudExtraMattressRate.MouseWheel
        If CurrentMode = FormMode.ViewMode Then
            DirectCast(e, HandledMouseEventArgs).Handled = True
        End If
    End Sub

    Private Function RequireText(tb As TextBox, fieldName As String) As Boolean
        If tb.Text.Trim().Length < 1 Then
            MessageBox.Show("Please enter " & fieldName & ".", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FocusAndSelect(tb)
            Return False
        End If
        Return True
    End Function


    Private Sub txtRoomNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRoomNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If RequireText(txtRoomNo, "Room Number") Then
                FocusAndSelect(txtRoomType)
            End If
        End If
    End Sub

    Private Sub txtRoomType_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRoomType.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If RequireText(txtRoomType, "Room Type") Then
                FocusAndSelect(txtRoomClass)
            End If
        End If
    End Sub

    Private Sub txtRoomClass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRoomClass.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If RequireText(txtRoomClass, "Room Class") Then
                FocusAndSelect(nudIncludedPax)
            End If
        End If
    End Sub


    Private Sub nudIncludedPax_KeyDown(sender As Object, e As KeyEventArgs) Handles nudIncludedPax.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            FocusAndSelect(nudBaseRate)
        End If
    End Sub

    Private Sub nudBaseRate_KeyDown(sender As Object, e As KeyEventArgs) Handles nudBaseRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            FocusAndSelect(nudExtraPaxRate)
        End If
    End Sub

    Private Sub nudExtraPaxRate_KeyDown(sender As Object, e As KeyEventArgs) Handles nudExtraPaxRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            FocusAndSelect(nudExtraMattressRate)
        End If
    End Sub

    Private Sub nudExtraMattressRate_KeyDown(sender As Object, e As KeyEventArgs) Handles nudExtraMattressRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cboStatus.Focus()
        End If
    End Sub

    Private Sub NumericUpDown_Leave(sender As Object, e As EventArgs) _
        Handles nudIncludedPax.Leave, nudBaseRate.Leave, nudExtraPaxRate.Leave, nudExtraMattressRate.Leave
        Dim nud = TryCast(sender, NumericUpDown)
        If nud Is Nothing Then Return
        If String.IsNullOrWhiteSpace(nud.Text) OrElse nud.Text = "." Then
            nud.Value = 0
            Return
        End If
        Dim val As Decimal
        If Not Decimal.TryParse(nud.Text, val) Then
            nud.Value = 0
        End If
    End Sub

    Private statusOpened As Boolean = False

    Private Sub cboStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles cboStatus.KeyDown
        If CurrentMode = FormMode.ViewMode Then
            e.SuppressKeyPress = True
            Return
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            ' first Enter: open dropdown
            If statusOpened = False Then
                cboStatus.DroppedDown = True
                statusOpened = True
                Return
            End If

            ' second Enter: accept selection and go to Save
            statusOpened = False
            btnSave.Focus()
        End If
    End Sub

    Private Sub cboStatus_DropDownClosed(sender As Object, e As EventArgs) Handles cboStatus.DropDownClosed
        ' if user selects using mouse, go to save after closing
        statusOpened = False
        btnSave.Focus()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode <> Keys.Enter Then Return

        e.Handled = True
        e.SuppressKeyPress = True

        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            MessageBox.Show("Please enter a room number to search.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSearch.Focus()
            Return
        End If

        LoadRoomsFiltered()
    End Sub

    Private Sub JumpRoomSelection(toEnd As Boolean)
        If dgvRooms.CurrentCell Is Nothing Then Return

        Dim colName As String = "Room No"
        If Not dgvRooms.Columns.Contains(colName) Then Return

        Dim targetRow As Integer
        If toEnd Then
            targetRow = dgvRooms.Rows.Count - 1
        Else
            targetRow = 0
        End If

        dgvRooms.CurrentCell = dgvRooms.Rows(targetRow).Cells(colName)
    End Sub

    Private Sub mnuBOF_Click(sender As Object, e As EventArgs) Handles mnuBOF.Click
        JumpRoomSelection(False)
    End Sub

    Private Sub mnuNext_Click(sender As Object, e As EventArgs) Handles mnuNext.Click
        MoveRoomSelection(1)
    End Sub

    Private Sub mnuPrevious_Click(sender As Object, e As EventArgs) Handles mnuPrevious.Click
        MoveRoomSelection(-1)
    End Sub

    Private Sub mnuEOF_Click(sender As Object, e As EventArgs) Handles mnuEOF.Click
        JumpRoomSelection(True)
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Dim result = MessageBox.Show(
          "Are you sure you want to exit the Rooms?",
          "Exit Confirmation",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question
      )

        If result = DialogResult.Yes Then
            MainForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub mnuCrystalReport_Click(sender As Object, e As EventArgs) Handles mnuCrystalReport.Click
        Try
            Dim rptPath As String = Path.Combine(Application.StartupPath, "CRPrint.rpt")
            If Not File.Exists(rptPath) Then
                MessageBox.Show("Report file not found: " & rptPath, "Print")
                Return
            End If

            btnMnuPrint.Enabled = False
            ShowReportPreview(rptPath)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Print failed")
        Finally
            btnMnuPrint.Enabled = True
        End Try
    End Sub

    Private Sub ApplyReportDbPath(rpt As ReportDocument)
        Dim dbPath As String = GetDbPathFromConnStr()

        If rpt.DataSourceConnections IsNot Nothing AndAlso rpt.DataSourceConnections.Count > 0 Then
            For i As Integer = 0 To rpt.DataSourceConnections.Count - 1
                Dim conn = rpt.DataSourceConnections(i)
                conn.SetConnection(dbPath, "", "", "")
            Next
        End If

        For Each tbl As Table In rpt.Database.Tables
            ApplyTableLogon(tbl, dbPath)
        Next

        For Each sr As ReportDocument In rpt.Subreports
            If sr.DataSourceConnections IsNot Nothing AndAlso sr.DataSourceConnections.Count > 0 Then
                For i As Integer = 0 To sr.DataSourceConnections.Count - 1
                    Dim conn = sr.DataSourceConnections(i)
                    conn.SetConnection(dbPath, "", "", "")
                Next
            End If

            For Each tbl As Table In sr.Database.Tables
                ApplyTableLogon(tbl, dbPath)
            Next
        Next
    End Sub

    Private Sub ApplyTableLogon(tbl As Table, dbPath As String)
        Dim logon As TableLogOnInfo = tbl.LogOnInfo
        logon.ConnectionInfo.ServerName = dbPath
        logon.ConnectionInfo.DatabaseName = dbPath
        logon.ConnectionInfo.UserID = ""
        logon.ConnectionInfo.Password = ""
        tbl.ApplyLogOnInfo(logon)

        If tbl.Location.Contains(";") Then
            tbl.Location = dbPath & ";" & tbl.Name
        End If
    End Sub

    Private Sub ShowReportPreview(rptPath As String)
        Dim preview As New Form()
        preview.Text = "Print Preview"
        preview.StartPosition = FormStartPosition.CenterParent
        preview.WindowState = FormWindowState.Maximized
        preview.MinimizeBox = True

        Dim viewer As New CrystalReportViewer()
        viewer.Dock = DockStyle.Fill
        viewer.ShowRefreshButton = False
        viewer.ShowGroupTreeButton = False
        viewer.ToolPanelView = ToolPanelViewType.None
        viewer.DisplayStatusBar = False

        preview.Controls.Add(viewer)
        preview.UseWaitCursor = True

        Dim rpt As ReportDocument = Nothing
        AddHandler preview.Shown, Sub()
                                      preview.BeginInvoke(Sub()
                                                              rpt = New ReportDocument()
                                                              rpt.Load(rptPath)
                                                              ApplyReportDbPath(rpt)
                                                              viewer.ReportSource = rpt
                                                              viewer.RefreshReport()
                                                              preview.UseWaitCursor = False
                                                          End Sub)
                                  End Sub

        AddHandler preview.FormClosed, Sub()
                                           If rpt IsNot Nothing Then rpt.Dispose()
                                       End Sub

        preview.ShowDialog(Me)
    End Sub

    Private Sub PrintRoomsToExcelTemplate()
        Dim templatePath As String = Path.Combine(Application.StartupPath, "ReportTemplate.xlsx")
        If Not File.Exists(templatePath) Then
            MessageBox.Show("Excel template not found: " & templatePath, "Excel Print")
            Return
        End If

        Dim xlApp As Object = Nothing
        Dim wb As Object = Nothing
        Dim ws As Object = Nothing
        Dim dataStart As Object = Nothing

        Try
            xlApp = CreateObject("Excel.Application")
            xlApp.Visible = True
            wb = xlApp.Workbooks.Open(templatePath)
            ws = wb.Worksheets(1)

            ' Use a named range "DataStart" if you want to control where data begins
            Try
                dataStart = wb.Names("DataStart").RefersToRange
            Catch
                dataStart = Nothing
            End Try

            Dim startRow As Integer
            Dim startCol As Integer
            If dataStart IsNot Nothing Then
                startRow = CInt(dataStart.Row)
                startCol = CInt(dataStart.Column)
            Else
                startRow = 2
                startCol = 1
            End If

            Dim visibleCols As New List(Of DataGridViewColumn)()
            For Each col As DataGridViewColumn In dgvRooms.Columns
                If col.Visible AndAlso col.Name <> "RoomID" AndAlso col.Name <> "RoomPhotoPath" Then
                    visibleCols.Add(col)
                End If
            Next

            ' Headers
            For i As Integer = 0 To visibleCols.Count - 1
                ws.Cells(startRow - 1, startCol + i).Value = visibleCols(i).HeaderText
            Next
            If visibleCols.Count > 0 Then
                Dim headerRange = ws.Range(ws.Cells(startRow - 1, startCol), ws.Cells(startRow - 1, startCol + visibleCols.Count - 1))
                headerRange.Font.Bold = True
                headerRange.Font.Color = RGB(255, 255, 255)
                headerRange.Interior.Color = RGB(51, 63, 79)
            End If

            ' Date/Time stamp (H4 and H5)
            ws.Range("H2").Value = Date.Now.ToString("yyyy-MM-dd")
            ws.Range("H3").Value = Date.Now.ToString("HH:mm:ss")

            ' Title
            Dim titleRange = ws.Range("D3:F3")
            titleRange.Merge()
            titleRange.Value = "ROOM REPORTS"
            titleRange.Font.Bold = True
            titleRange.Font.Size = 20
            titleRange.HorizontalAlignment = -4108 ' xlCenter

            ' Data
            Dim r As Integer = startRow
            For Each row As DataGridViewRow In dgvRooms.Rows
                If row.IsNewRow Then Continue For
                For i As Integer = 0 To visibleCols.Count - 1
                    Dim col = visibleCols(i)
                    ws.Cells(r, startCol + i).Value = row.Cells(col.Index).Value
                Next
                r += 1
            Next

            ' Borders for header + data
            If visibleCols.Count > 0 Then
                Dim lastRow As Integer = Math.Max(startRow, r - 1)
                Dim fullRange = ws.Range(ws.Cells(startRow - 1, startCol), ws.Cells(lastRow, startCol + visibleCols.Count - 1))
                fullRange.Borders.LineStyle = 1 ' xlContinuous
                fullRange.Borders.Weight = 2    ' xlThin

                ' Apply peso format to rate columns
                For i As Integer = 0 To visibleCols.Count - 1
                    Dim header = visibleCols(i).HeaderText
                    If header IsNot Nothing AndAlso header.IndexOf("Rate", StringComparison.OrdinalIgnoreCase) >= 0 Then
                        Dim rateRange = ws.Range(ws.Cells(startRow, startCol + i), ws.Cells(lastRow, startCol + i))
                        rateRange.NumberFormat = "₱#,##0.00"
                    End If
                Next
            End If

            Try
                xlApp.CommandBars.ExecuteMso("FilePrintPreview")
            Catch
                wb.PrintPreview()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excel Print failed")
        Finally
            If dataStart IsNot Nothing Then Runtime.InteropServices.Marshal.ReleaseComObject(dataStart)
            If ws IsNot Nothing Then Runtime.InteropServices.Marshal.ReleaseComObject(ws)
            If wb IsNot Nothing Then Runtime.InteropServices.Marshal.ReleaseComObject(wb)
            If xlApp IsNot Nothing Then Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
        End Try
    End Sub

    ' --- ROOM PHOTO SUPPORT ---

    Private PendingPhotoSourcePath As String = ""

    Private Function GetDbPathFromConnStr() As String
        Return DbConfig.GetDbPath()
    End Function

    Private Function RoomImagesFolder() As String
        Dim dbPath = GetDbPathFromConnStr()
        Dim dbDir = Path.GetDirectoryName(dbPath)
        Return Path.Combine(dbDir, "RoomImages")
    End Function

    Private Sub EnsureRoomImagesFolder()
        Dim folder = RoomImagesFolder()
        If Not Directory.Exists(folder) Then
            Directory.CreateDirectory(folder)
        End If
    End Sub

    Private Function SanitizeFileNamePart(value As String) As String
        If String.IsNullOrWhiteSpace(value) Then Return ""
        Dim cleaned As String = value
        For Each ch In Path.GetInvalidFileNameChars()
            cleaned = cleaned.Replace(ch, "_"c)
        Next
        cleaned = cleaned.Trim()
        If cleaned = "" Then cleaned = "Room"
        Return cleaned
    End Function

    Private Function BuildRoomImageFileName(roomNo As String, roomId As Integer, sourceFile As String) As String
        Dim ext As String = Path.GetExtension(sourceFile).ToLower()

        If ext <> ".jpg" AndAlso ext <> ".jpeg" AndAlso ext <> ".png" AndAlso ext <> ".bmp" Then
            ext = ".jpg"
        End If

        Dim safeRoomNo = SanitizeFileNamePart(roomNo)
        If String.IsNullOrWhiteSpace(safeRoomNo) Then
            safeRoomNo = "Room"
        End If

        Return $"{safeRoomNo}_{roomId}{ext}"
    End Function

    Private Sub MigrateRoomPhotoNames()
        Try
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Using cmd As New OleDbCommand("SELECT RoomID, [Room No], RoomPhotoPath FROM tblRooms WHERE RoomPhotoPath Is Not Null AND RoomPhotoPath<>'';", conn),
                      reader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim roomId As Integer = CInt(reader("RoomID"))
                        Dim roomNo As String = SafeString(reader("Room No"))
                        Dim photoPath As String = SafeString(reader("RoomPhotoPath"))
                        If String.IsNullOrWhiteSpace(photoPath) Then Continue While

                        Dim fullPath As String
                        If photoPath.StartsWith("\\") OrElse photoPath.Contains(":\") Then
                            fullPath = photoPath
                        Else
                            fullPath = Path.Combine(RoomImagesFolder(), photoPath)
                        End If

                        If Not File.Exists(fullPath) Then Continue While

                        Dim newFileName = BuildRoomImageFileName(roomNo, roomId, fullPath)
                        Dim newFullPath = Path.Combine(RoomImagesFolder(), newFileName)

                        If String.Equals(fullPath, newFullPath, StringComparison.OrdinalIgnoreCase) Then
                            If Not String.Equals(photoPath, newFileName, StringComparison.OrdinalIgnoreCase) Then
                                UpdatePhotoPath(conn, roomId, newFileName)
                            End If
                            Continue While
                        End If

                        If Not File.Exists(newFullPath) Then
                            File.Move(fullPath, newFullPath)
                            UpdatePhotoPath(conn, roomId, newFileName)
                        End If
                    End While
                End Using
            End Using
        Catch
            ' Silent migration - avoid blocking UI if anything fails
        End Try
    End Sub

    Private Sub UpdatePhotoPath(conn As OleDbConnection, roomId As Integer, fileName As String)
        Using cmd As New OleDbCommand("UPDATE tblRooms SET RoomPhotoPath=? WHERE RoomID=?;", conn)
            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = fileName
            cmd.Parameters.Add("?", OleDbType.Integer).Value = roomId
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub SetPictureBoxImageSafe(fullPath As String)
        Try
            If String.IsNullOrWhiteSpace(fullPath) OrElse Not File.Exists(fullPath) Then
                pbRooms.Image = Nothing
                Return
            End If

            Using fs As New FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Using img = Image.FromStream(fs)
                    pbRooms.Image = New Bitmap(img)
                End Using
            End Using
        Catch
            pbRooms.Image = Nothing
        End Try
    End Sub

    Private Sub LoadRoomPhoto(roomPhotoPathValue As Object)
        Dim fileValue As String = SafeString(roomPhotoPathValue)

        If String.IsNullOrWhiteSpace(fileValue) Then
            pbRooms.Image = Nothing
            Return
        End If

        ' If you stored full path, use it. If you stored filename, build from RoomImages folder.
        Dim fullPath As String
        If fileValue.StartsWith("\\") OrElse fileValue.Contains(":\") Then
            fullPath = fileValue
        Else
            fullPath = Path.Combine(RoomImagesFolder(), fileValue)
        End If

        SetPictureBoxImageSafe(fullPath)
    End Sub

    Private Sub SaveRoomPhoto(roomId As Integer)
        If roomId <= 0 Then Return
        If String.IsNullOrWhiteSpace(PendingPhotoSourcePath) Then Return
        If Not File.Exists(PendingPhotoSourcePath) Then Return

        EnsureRoomImagesFolder()

        Dim fileName = BuildRoomImageFileName(txtRoomNo.Text.Trim(), roomId, PendingPhotoSourcePath)
        Dim destPath = Path.Combine(RoomImagesFolder(), fileName)

        File.Copy(PendingPhotoSourcePath, destPath, True)

        ' Store ONLY filename (recommended)
        Dim sql As String = "UPDATE tblRooms SET RoomPhotoPath=? WHERE RoomID=?"

        Using conn As New OleDbConnection(ConnStr),
              cmd As New OleDbCommand(sql, conn)

            conn.Open()
            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = fileName
            cmd.Parameters.Add("?", OleDbType.Integer).Value = roomId
            cmd.ExecuteNonQuery()
        End Using

        PendingPhotoSourcePath = ""
        LoadRoomPhoto(fileName) ' refresh preview
    End Sub

    Private Sub btnPhotoRooms_Click(sender As Object, e As EventArgs) Handles btnPhotoRooms.Click

        IsDirty = True
        ' Allow choosing photo ONLY when Adding/Editing
        If CurrentMode <> FormMode.Adding AndAlso CurrentMode <> FormMode.Editing Then
            MessageBox.Show("Click Edit/Add first to change the photo.")
            Exit Sub
        End If

        SuppressPhotoRefresh = True
        Dim previousPhotoValue As Object = Nothing
        If dgvRooms.CurrentRow IsNot Nothing AndAlso dgvRooms.Columns.Contains("RoomPhotoPath") Then
            previousPhotoValue = dgvRooms.CurrentRow.Cells("RoomPhotoPath").Value
        End If
        pbRooms.Image = Nothing
        pbRooms.ImageLocation = Nothing
        pbRooms.Refresh()

        Using ofd As New OpenFileDialog()
            ofd.Title = "Choose room photo"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

            If ofd.ShowDialog() = DialogResult.OK Then
                PendingPhotoSourcePath = ofd.FileName

                ' preview immediately in the PictureBox
                SetPictureBoxImageSafe(PendingPhotoSourcePath)
            Else
                If previousPhotoValue IsNot Nothing Then
                    LoadRoomPhoto(previousPhotoValue)
                Else
                    pbRooms.Image = Nothing
                End If
            End If
        End Using
        SuppressPhotoRefresh = False

    End Sub

    Private Sub mnuExcel_Click(sender As Object, e As EventArgs) Handles mnuExcel.Click
        PrintRoomsToExcelTemplate()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class
