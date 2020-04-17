
Imports System.Data
Imports System.Data.OleDb
Public Class frmguestlist
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Public r As Integer
    Public id1 As Integer
    Public i As Integer
    Public cnt1 As Integer


    Private Sub frmguestlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\Project vb.net\test.mdb")
            con.Open()
            MsgBox("Connection is done")
            cmd = New OleDbCommand("Select * from GuestList", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("GuestList")
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            cmd = New OleDbCommand("Select max(Guestid) from GuestList", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("GuestList")
            da.Fill(ds)
            id1 = 0
            id1 = Val(ds.Tables(0).Rows(0).Item(0).ToString())
            id1 = id1 + 1
            txtguestid.Text = id1.ToString()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        Try
            cmd = New OleDbCommand("Select * from Guest", con)
            cmd.CommandText = "Delete from bill where Guestid=" + txtguestid.Text
            r = cmd.ExecuteNonQuery()
            If r = 0 Then
                MsgBox("Record is not deleted")
            Else
                MsgBox("Record is deleted")
                txtguestid.Text = ""
                cmbclientid.Text = ""
                txtguestname.Text = ""
                txtguestadd.Text = ""
                txtguestphn.Text = ""
                txtguestemail.Text = ""

            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()
            da.Dispose()
            ds.Dispose()

        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            cmd = New OleDbCommand("Select * from Guestlist", con)
            cmd.CommandText = "Insert into Guestlist values(" + txtguestid.Text + ",'" + txtguestname.Text + "','" + txtguestadd.Text + "','" + txtguestphn.Text + "','" + txtguestemail.Text + "')"
            MsgBox(cmd.CommandText)
            r = 0
            r = cmd.ExecuteNonQuery()
            If r = 0 Then
                MsgBox("Record is not saved")
            Else
                MsgBox("Record is saved")

            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()

        End Try
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Try
            cmd = New OleDbCommand("Select * from GuestList", con)
            cmd.CommandText = "Update GuestList set Guestname ='" + txtguestname.Text + "',Guestname ='" + txtguestname.Text + "' , Guestadd= '" + txtguestadd.Text + "',Guestphn ='" + txtguestphn.Text + "',Guestemail ='" + txtguestemail.Text + "' where Guestid=" + txtguestid.Text
            MsgBox(cmd.CommandText)
            r = cmd.ExecuteNonQuery()
            If r = 0 Then
                MsgBox("Record is not updated")
            Else
                MsgBox("Record is updated")

            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()

        End Try
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        id1 = 0
        id1 = InputBox("Enter GuestList to search")
        Try
            cmd = New OleDbCommand("Select * from GuestList", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("GuestList")
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            cnt1 = 0
            cnt1 = ds.Tables(0).Rows.Count - 1
            r = 0
            For Me.i = 0 To cnt1 Step 1
                r = Val(ds.Tables(0).Rows(Me.i).Item(0).ToString())
                If r = id1 Then
                    txtguestid.Text = ds.Tables(0).Rows(Me.i).Item(0).ToString()
                    txtguestname.Text = ds.Tables(0).Rows(Me.i).Item(1).ToString()
                    txtguestadd.Text = ds.Tables(0).Rows(Me.i).Item(2).ToString()
                    txtguestphn.Text = ds.Tables(0).Rows(Me.i).Item(3).ToString()
                    txtguestemail.Text = ds.Tables(0).Rows(Me.i).Item(4).ToString()
                    Exit For
                Else
                    r = 0
                End If
            Next
            If r = 0 Then
                MsgBox("Guest List ID not present")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        txtguestid.Text = ""
        txtguestname.Text = ""
        txtguestadd.Text = ""
        txtguestphn.Text = ""
        txtguestemail.Text = ""
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Hide()
    End Sub

    Private Sub txtguestid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtguestid.KeyPress
        Dim x As Integer
        x = Asc(e.KeyChar)
        If x >= 0 And x <= 7 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 8 And x <= 31 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 33 And x <= 47 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 58 And x <= 65 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 65 And x <= 90 Then
            MsgBox("Capiltal letters are not allowed")
            e.KeyChar = ""
        ElseIf x >= 91 And x <= 96 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 97 And x <= 122 Then
            MsgBox("Small letters are not allowed")
            e.KeyChar = ""
        ElseIf x >= 123 And x <= 255 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        Else
            'txtcid.Text = e.KeyChar.ToString()
        End If

    End Sub
    Private Sub txtguestname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtguestname.KeyPress
        Dim x As Integer
        x = Asc(e.KeyChar)
        If x >= 0 And x <= 7 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 8 And x <= 31 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 33 And x <= 47 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 48 And x <= 57 Then
            MsgBox("Digits are not allowed")
            e.KeyChar = ""
        ElseIf x >= 58 And x <= 64 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 91 And x <= 96 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 123 And x <= 255 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        Else
            'txtcid.Text = e.KeyChar.ToString()
        End If

    End Sub

    Private Sub txtguestemail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtguestemail.LostFocus
        'validating emailid
        Dim ss1 As String
        Dim len As Integer
        Dim i As Integer

        ss1 = txtguestemail.Text
        len = ss1.Length

        Dim ch1(len) As Char
        ch1 = ss1.ToCharArray()

        Dim res1 As Boolean
        Dim res2 As Boolean
        Dim res3 As Boolean
        Dim res4 As Boolean
        res1 = False
        res2 = False
        res3 = False
        res4 = False

        For i = 0 To len - 1 Step 1
            If ch1(i) = "@" Then
                res1 = True
            Else
                res2 = True
            End If
        Next
        If res1 = True Then
            'MsgBox("Digits are not allowed in coach name")
            'txtguestemail.Text = ""
            res1 = False
        ElseIf res2 = True Then
            MsgBox("Email must have @ symbol")
            txtguestemail.Text = ""
        End If
    End Sub

    Private Sub txtguestphn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtguestphn.KeyPress
        Dim x As Integer
        x = Asc(e.KeyChar)
        If x >= 0 And x <= 7 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 8 And x <= 31 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 33 And x <= 47 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 58 And x <= 65 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 65 And x <= 90 Then
            MsgBox("Capiltal letters are not allowed")
            e.KeyChar = ""
        ElseIf x >= 91 And x <= 96 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        ElseIf x >= 97 And x <= 122 Then
            MsgBox("Small letters are not allowed")
            e.KeyChar = ""
        ElseIf x >= 123 And x <= 255 Then
            MsgBox("Symbols are not allowed")
            e.KeyChar = ""
        Else
            'txtguestphn.Text = e.KeyChar.ToString()
        End If

    End Sub

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        Try
           
            cmd = New OleDbCommand("Select * from GuestList", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("GuestList")
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub
End Class