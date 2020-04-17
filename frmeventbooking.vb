
Imports System.Data
Imports System.Data.OleDb
Public Class frmeventbooking
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd1 As OleDbCommand
    Dim da1 As OleDbDataAdapter
    Dim ds1 As DataSet
    Dim cmd2 As OleDbCommand
    Dim da2 As OleDbDataAdapter
    Dim ds2 As DataSet
    Public id1 As Integer
    Public r As Integer
    Public i As Integer
    Public cnt1 As Integer

    Private Sub frmeventbooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\Project vb.net\test.mdb")
            con.Open()
            MsgBox("Connection is done")
            cmd = New OleDbCommand("Select * from EventBooking", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("EventBooking")
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try
        Try

            cmd1 = New OleDbCommand("Select * from Client1", con)
            da1 = New OleDbDataAdapter(cmd1)
            ds1 = New DataSet("Client1")
            da1.Fill(ds1)
            cnt1 = 0
            cnt1 = ds1.Tables(0).Rows.Count - 1

            For Me.i = 0 To cnt1 Step 1
                cmbclientname.Items.Add(ds1.Tables(0).Rows(Me.i).Item(1).ToString())
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd1.Dispose()
            da1.Dispose()
            ds1.Dispose()
        End Try
        Try
            cmd2 = New OleDbCommand("Select * from EventType", con)
            da2 = New OleDbDataAdapter(cmd2)
            ds2 = New DataSet("EventType")
            da2.Fill(ds2)
            cnt1 = 0
            cnt1 = ds2.Tables(0).Rows.Count - 1

            For Me.i = 0 To cnt1 Step 1
                cmbeventtypename.Items.Add(ds2.Tables(0).Rows(Me.i).Item(1).ToString())
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd2.Dispose()
            da2.Dispose()
            ds2.Dispose()
        End Try
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            cmd = New OleDbCommand("Select max(EBkid) from EventBooking", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Event Booking")
            da.Fill(ds)
            id1 = 0
            id1 = Val(ds.Tables(0).Rows(0).Item(0).ToString())
            id1 = id1 + 1
            txtEBid.Text = id1.ToString()
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
            cmd = New OleDbCommand("Select * from EventBooking", con)
            cmd.CommandText = "Delete from bill where EBkid=" + txtEBid.Text
            r = cmd.ExecuteNonQuery()
            If r = 0 Then
                MsgBox("Record is not deleted")
            Else
                MsgBox("Record is deleted")
                txtEBid.Text = ""
                cmbclientname.Text = ""
                cmbeventtypename.Text = ""
                txtclientid.Text = ""
                txtadvance.Text = ""
                txttypeid.Text = ""
                DateTimePicker1.Text = ""
                DateTimePicker2.Text = ""
                DateTimePicker3.Text = ""



            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()
            da.Dispose()
            ds.Dispose()

        End Try
    End Sub

    Private Sub btndisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndisplay.Click
        Try

            cmd1 = New OleDbCommand("Select * from Client1 where clientname='" + cmbclientname.Text + "'", con)
            da1 = New OleDbDataAdapter(cmd1)
            ds1 = New DataSet("Client1")
            da1.Fill(ds1)
            
            txtclientid.Text = ds1.Tables(0).Rows(0).Item(0).ToString()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd1.Dispose()
            da1.Dispose()
            ds1.Dispose()
        End Try
        Try

            cmd2 = New OleDbCommand("Select * from EventType where Typename='" + cmbeventtypename.Text + "'", con)
            da2 = New OleDbDataAdapter(cmd2)
            ds2 = New DataSet("EventType")
            da2.Fill(ds2)

            txttypeid.Text = ds2.Tables(0).Rows(0).Item(0).ToString()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd2.Dispose()
            da2.Dispose()
            ds2.Dispose()
        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            cmd = New OleDbCommand("Select * from EventBooking", con)
            cmd.CommandText = "Insert into EventBooking values(" + txtEBid.Text + "," + txtclientid.Text + "," + txttypeid.Text + ",'" + DateTimePicker1.Text + "','" + DateTimePicker2.Text + "','" + DateTimePicker3.Text + "'," + txtadvance.Text + ")"
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
            cmd = New OleDbCommand("Select * from EventBooking", con)
            cmd.CommandText = "Update EventBooking set  clientid = " + txtclientid.Text + ",ETid = " + txttypeid.Text + ",Bkdate='" + DateTimePicker1.Text + "',Fromdate ='" + DateTimePicker2.Text + "' , Todate= '" + DateTimePicker3.Text + "',Advance =" + txtadvance.Text + " where EBkid=" + txtEBid.Text
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
        id1 = InputBox("Enter EventBookingid to search")
        Try
            cmd = New OleDbCommand("Select * from EventBooking", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("EventBooking")
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            cnt1 = 0
            cnt1 = ds.Tables(0).Rows.Count - 1
            r = 0
            For Me.i = 0 To cnt1 Step 1
                r = Val(ds.Tables(0).Rows(Me.i).Item(0).ToString())
                If r = id1 Then
                    MsgBox("Event Booking ID is present")
                    txtEBid.Text = ds.Tables(0).Rows(Me.i).Item(0).ToString()
                    txtclientid.Text = ds.Tables(0).Rows(Me.i).Item(1).ToString()
                    txttypeid.Text = ds.Tables(0).Rows(Me.i).Item(2).ToString()
                    DateTimePicker1.Text = ds.Tables(0).Rows(Me.i).Item(3).ToString()
                    DateTimePicker2.Text = ds.Tables(0).Rows(Me.i).Item(4).ToString()
                    DateTimePicker3.Text = ds.Tables(0).Rows(Me.i).Item(5).ToString()
                    txtadvance.Text = ds.Tables(0).Rows(Me.i).Item(6).ToString()
                    Exit For
                Else
                    r = 0
                End If
            Next
            If r = 0 Then
                MsgBox("Event Booking ID not present")
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
        txtEBid.Text = ""
        txttypeid.Text = ""
        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""
        DateTimePicker3.Text = ""
        txtadvance.Text = ""
        cmbclientname.Text = ""
        txtclientid.Text = ""
        cmbeventtypename.Text = ""
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Hide()
    End Sub

    Private Sub txtEBid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEBid.KeyPress
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

    Private Sub txttypeid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttypeid.KeyPress
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


End Class
