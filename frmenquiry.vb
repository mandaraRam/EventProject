Imports System.Data
Imports System.Data.OleDb
Public Class frmenquiry
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Public id1 As Integer
    Public r As Integer
    Public i As Integer
    Public cnt1 As Integer



    Private Sub frmenquiry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\Project vb.net\test.mdb")
            con.Open()
            MsgBox("Connection is done")
            cmd = New OleDbCommand("Select * from Enquiry", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Enquiry")
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
            cmd = New OleDbCommand("Select max(Enqid) from Enquiry", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Enquiry")
            da.Fill(ds)
            id1 = 0
            id1 = Val(ds.Tables(0).Rows(0).Item(0).ToString())
            id1 = id1 + 1
            txtenqid.Text = id1.ToString()
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
            cmd = New OleDbCommand("Select * from Enquiry", con)
            cmd.CommandText = "Delete from Enquiry where Enqid=" + txtenqid.Text
            r = cmd.ExecuteNonQuery()
            If r = 0 Then
                MsgBox("Record is not deleted")
            Else
                MsgBox("Record is deleted")
                txtenqid.Text = ""
                txtenqname.Text = ""
                txtenqadd.Text = ""
                txtenqphn.Text = ""
                txtenqemail.Text = ""
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
            cmd = New OleDbCommand("Select * from Enquiry", con)
            cmd.CommandText = "Insert into Enquiry values(" + txtenqid.Text + ",'" + txtenqname.Text + "','" + txtenqadd.Text + "','" + txtenqphn.Text + "','" + txtenqemail.Text + "')"
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

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        id1 = 0
        id1 = InputBox("Enter Enquiry ID to search")
        Try
            cmd = New OleDbCommand("Select * from Enquiry", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Enquiry")
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            cnt1 = 0
            cnt1 = ds.Tables(0).Rows.Count - 1
            r = 0
            For Me.i = 0 To cnt1 Step 1
                r = Val(ds.Tables(0).Rows(Me.i).Item(0).ToString())
                If r = id1 Then
                    txtenqid.Text = ds.Tables(0).Rows(Me.i).Item(0).ToString()
                    txtenqname.Text = ds.Tables(0).Rows(Me.i).Item(1).ToString()
                    txtenqadd.Text = ds.Tables(0).Rows(Me.i).Item(2).ToString()
                    txtenqphn.Text = ds.Tables(0).Rows(Me.i).Item(3).ToString()
                    txtenqemail.Text = ds.Tables(0).Rows(Me.i).Item(4).ToString()
                    Exit For
                Else
                    r = 0
                End If
            Next
            If r = 0 Then
                MsgBox("Enquiry ID not present")
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
            cmd = New OleDbCommand("Select * from Enquiry", con)
            cmd.CommandText = "Update Enquiry set Enqname ='" + txtenqname.Text + "',Enqadd ='" + txtenqadd.Text + "' , Enqphn= '" + txtenqphn.Text + "',Enqemail='" + txtenqemail.Text + "' where Enqid=" + txtenqid.Text
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

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        txtenqid.Text = ""
        txtenqname.Text = ""
        txtenqadd.Text = ""
        txtenqphn.Text = ""
        txtenqemail.Text = ""
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Hide()
    End Sub

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        Try
           
            cmd = New OleDbCommand("Select * from Enquiry", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Enquiry")
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

    Private Sub txtenqid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtenqid.KeyPress
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

    Private Sub txtenqname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtenqname.KeyPress
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

    Private Sub txtenqphn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtenqphn.KeyPress
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

    Private Sub txtenqemail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtenqemail.LostFocus
        Dim ss1 As String
        Dim len As Integer
        Dim i As Integer

        ss1 = txtenqemail.Text
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
            txtenqemail.Text = ""
        End If
    End Sub

End Class