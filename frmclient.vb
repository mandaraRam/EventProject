'ADO.NET advanced data object technology for network/internet applications
'Imports System.Data is namespace for common database connection classes
'Imports System.Data.OleDb is special namespace for vb.net and msaccess
'database connection and transaction classes
'
Imports System.Data
Imports System.Data.OleDb
Public Class frmclient

    Dim con As OleDbConnection
    'This class is for logical and technical connection between vb.net 2008 and msaccess 2007/2010
    Dim cmd As OleDbCommand
    'this class will execute all sql coomands specially select insert delete update etc
    'result is stored on database server
    Dim da As OleDbDataAdapter
    'it is middleman class between server and client to upgrade changes form server to client
    'vice versa
    Dim ds As DataSet
    'da brings copy of original table and store it in ds or dataset
    'it is client side dummy tables group
    Public id1 As Integer
    Public r As Integer
    Public i As Integer
    Public cnt1 As Integer

    Private Sub frmclient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\Project vb.net\test.mdb")
            con.Open()
            MsgBox("Connection is done")
            cmd = New OleDbCommand("Select * from Client1", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Client")
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
            cmd = New OleDbCommand("Select max(clientid) from Client1", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Client")
            da.Fill(ds)
            id1 = 0
            id1 = Val(ds.Tables(0).Rows(0).Item(0).ToString())
            id1 = id1 + 1
            txtclientid.Text = id1.ToString()
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
            cmd = New OleDbCommand("Select * from Client1", con)
            cmd.CommandText = "Delete from Client1 where Clientid=" + txtclientid.Text
            r = cmd.ExecuteNonQuery()
            If r = 0 Then
                MsgBox("Record is not deleted")
            Else
                MsgBox("Record is deleted")
                
                txtclientid.Text = ""
                txtclientname.Text = ""
                txtclientaddress.Text = ""
                txtclientcontact.Text = ""
                txtclientmob.Text = ""
                txtclientemail.Text = ""
                txtclientfax.Text = ""
                txtclientid.Text = ""
                txtclientweb.Text = ""
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
            cmd = New OleDbCommand("Select * from Client1", con)
            cmd.CommandText = "Insert into client1 values(" + txtclientid.Text + ",'" + txtclientname.Text + "','" + txtclientaddress.Text + "' ,'" + txtclientcontact.Text + "','" + txtclientmob.Text + "','" + txtclientemail.Text + "' ,'" + txtclientfax.Text + "','" + txtclientweb.Text + "')"
            MsgBox(cmd.CommandText)
            r = cmd.ExecuteNonQuery()
            If r = 0 Then
                MsgBox("Record is not saved")
            Else
                MsgBox("Record is saved")
                txtclientid.Text = ""
                txtclientname.Text = ""
                txtclientaddress.Text = ""
                txtclientcontact.Text = ""
                txtclientmob.Text = ""
                txtclientemail.Text = ""
                txtclientfax.Text = ""
                txtclientid.Text = ""
                txtclientweb.Text = ""
               
            End If
           
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Try
            cmd = New OleDbCommand("Select * from Client1", con)
            cmd.CommandText = "Update client1 set clientname ='" + txtclientname.Text + "',clientadd ='" + txtclientaddress.Text + "' ,clientphn = '" + txtclientcontact.Text + "',clientmob ='" + txtclientmob.Text + "', clientemail='" + txtclientemail.Text + "' , clientfax ='" + txtclientfax.Text + "',clientweb='" + txtclientweb.Text + "' where Clientid=" + txtclientid.Text
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
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Hide()
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        txtclientid.Text = ""
        txtclientname.Text = ""
        txtclientaddress.Text = ""
        txtclientcontact.Text = ""
        txtclientmob.Text = ""
        txtclientemail.Text = ""
        txtclientfax.Text = ""
        txtclientweb.Text = ""
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        id1 = 0
        id1 = InputBox("Enter client ID to search")
        Try
            cmd = New OleDbCommand("Select * from Client1", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Client1")
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            cnt1 = 0
            cnt1 = ds.Tables(0).Rows.Count - 1
            r = 0
            For Me.i = 0 To cnt1 Step 1
                r = Val(ds.Tables(0).Rows(Me.i).Item(0).ToString())
                If r = id1 Then
                    txtclientid.Text = ds.Tables(0).Rows(Me.i).Item(0).ToString()
                    txtclientname.Text = ds.Tables(0).Rows(Me.i).Item(1).ToString()
                    txtclientaddress.Text = ds.Tables(0).Rows(Me.i).Item(2).ToString()
                    txtclientcontact.Text = ds.Tables(0).Rows(Me.i).Item(3).ToString()
                    txtclientmob.Text = ds.Tables(0).Rows(Me.i).Item(4).ToString()
                    txtclientemail.Text = ds.Tables(0).Rows(Me.i).Item(5).ToString()
                    txtclientfax.Text = ds.Tables(0).Rows(Me.i).Item(6).ToString()
                    txtclientweb.Text = ds.Tables(0).Rows(Me.i).Item(7).ToString()
                    Exit For
                Else
                    r = 0
                End If
            Next
            If r = 0 Then
                MsgBox("Client ID not present")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub

    Private Sub txtclientid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtclientid.KeyPress
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

    Private Sub txtclientcontact_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtclientcontact.KeyPress
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
    Private Sub txtclientname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtclientname.KeyPress
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

    Private Sub txtclientemail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtclientemail.LostFocus
        'validating emailid
        Dim ss1 As String
        Dim len As Integer
        Dim i As Integer

        ss1 = txtclientemail.Text
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
            'txtcemail.Text = ""
            res1 = False
        ElseIf res2 = True Then
            MsgBox("Email must have @ symbol")
            txtclientemail.Text = ""
        End If
    End Sub

    Private Sub txtclientmob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtclientmob.KeyPress
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

    Private Sub btnshow1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow1.Click
        Try
           
            cmd = New OleDbCommand("Select * from Client1", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Client")
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

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class