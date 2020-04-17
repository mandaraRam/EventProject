Imports System.Data
Imports System.Data.OleDb
Public Class frmadmin
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Public id1 As Integer
    Public cnt As Integer
    Public r As Integer
    Private Sub frmadmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Try
        '    con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Palash_Project\Cricket_Club_System\Cricket_Club.mdb")
        '    con.Open()
        '    MsgBox("Connection is done for Admin Details")
        '    cmd = New OleDbCommand("Select * from Admin", con)
        '    da = New OleDbDataAdapter(cmd)
        '    ds = New DataSet("Admin")
        '    da.Fill(ds)
        'Catch ex As Exception
        '    MsgBox(ex.Message.ToString())
        'Finally
        '    cmd.Dispose()
        '    da.Dispose()
        '    ds.Dispose()
        'End Try
    End Sub

    Private Sub btnsubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    cmd = New OleDbCommand("Select * from Admin", con)
        '    cmd.CommandText = "insert into Admin values(" + txtbid.Text + ",'" + txttime.Text + "','" + txtdays.Text + "','" + txtcoach.Text + "','" + cmbage.SelectedItem.ToString() + "')"
        '    r = 0
        '    r = cmd.ExecuteNonQuery()
        '    If r = 0 Then
        '        MsgBox("Admin Record is not saved")
        '    Else
        '        MsgBox("Admin Record is successfully saved")
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message.ToString())
        'Finally
        '    cmd.Dispose()

        'End Try
    End Sub

    'Private Sub txtfullname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Dim x As Integer
    '    x = Asc(e.KeyChar)
    '    If x >= 0 And x <= 7 Then
    '        MsgBox("Symbols are not allowed")
    '        e.KeyChar = ""
    '    ElseIf x >= 8 And x <= 31 Then
    '        MsgBox("Symbols are not allowed")
    '        e.KeyChar = ""
    '    ElseIf x >= 33 And x <= 47 Then
    '        MsgBox("Symbols are not allowed")
    '        e.KeyChar = ""
    '    ElseIf x >= 48 And x <= 57 Then
    '        MsgBox("Digits are not allowed")
    '        e.KeyChar = ""
    '    ElseIf x >= 58 And x <= 64 Then
    '        MsgBox("Symbols are not allowed")
    '        e.KeyChar = ""
    '    ElseIf x >= 91 And x <= 96 Then
    '        MsgBox("Symbols are not allowed")
    '        e.KeyChar = ""
    '    ElseIf x >= 123 And x <= 255 Then
    '        MsgBox("Symbols are not allowed")
    '        e.KeyChar = ""
    '    Else
    '        'txtcid.Text = e.KeyChar.ToString()
    '    End If
    'End Sub

    'Private Sub txtpass_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'validating phone length
    '    Dim ss1 As String
    '    Dim len As Integer
    '    Dim i As Integer
    '    len = 0
    '    ss1 = txtpass.Text
    '    len = ss1.Length

    '    Dim ch1(len) As Char
    '    ch1 = ss1.ToCharArray()


    '    Dim res1 As Boolean
    '    Dim res2 As Boolean
    '    Dim res3 As Boolean
    '    Dim res4 As Boolean
    '    res1 = False
    '    res2 = False
    '    res3 = False
    '    res4 = False
    '    If len = 8 Then
    '        res1 = True
    '    Else
    '        res2 = True
    '    End If

    '    If res1 = True Then
    '        'MsgBox("Digits are not allowed in coach name")
    '        'txtcemail.Text = ""
    '        res1 = False
    '    ElseIf res2 = True Then
    '        MsgBox("Password must be 8 digit long")
    '        txtpass.Text = ""
    '    End If
    'End Sub

End Class