Imports System.Data
Imports System.Data.OleDb
Public Class frmcateringbooking
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Public id1 As Integer
    Public r As Integer
    Public i As Integer
    Public cnt1 As Integer

    'foriegn keys
    Dim cmd1 As OleDbCommand
    Dim da1 As OleDbDataAdapter
    Dim ds1 As DataSet
    Dim cmd2 As OleDbCommand
    Dim da2 As OleDbDataAdapter
    Dim ds2 As DataSet
    Private Sub frmcateringbooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\Project vb.net\test.mdb")
            con.Open()
            MsgBox("Connection is done")
            cmd = New OleDbCommand("Select * from CateringBooking", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("CateringBooking")
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
                cmbclientname.Items.Add(ds1.Tables(0).Rows(i).Item(1).ToString())
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd1.Dispose()
            da1.Dispose()
            ds1.Dispose()
        End Try
        Try
            cmd2 = New OleDbCommand("Select * from Catering", con)
            da2 = New OleDbDataAdapter(cmd2)
            ds2 = New DataSet("CateringBooking")
            da2.Fill(ds2)
            cnt1 = 0
            cnt1 = ds2.Tables(0).Rows.Count - 1
            For Me.i = 0 To cnt1 Step 1
                cmbmenu.Items.Add(ds2.Tables(0).Rows(i).Item(1).ToString())
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
            cmd = New OleDbCommand("Select max(CatBkid) from CateringBooking", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("CateringBooking")
            da.Fill(ds)
            id1 = 0
            id1 = Val(ds.Tables(0).Rows(0).Item(0).ToString())
            id1 = id1 + 1
            txtCBid.Text = id1.ToString()
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
            cmd = New OleDbCommand("Select * from CateringBooking", con)
            cmd.CommandText = "Delete from cateringbooking where CBid=" + txtCBid.Text
            r = cmd.ExecuteNonQuery()
            If r = 0 Then
                MsgBox("Record is not deleted")
            Else
                MsgBox("Record is deleted")
                txtCBid.Text = ""
                cmbclientid.Text = ""
                cmbcateringid.Text = ""
                txtnoofdish.Text = ""
                txtcatadvance.Text = ""
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
            cmd = New OleDbCommand("Select * from CateringBooking", con)
            cmd.CommandText = "insert into CateringBooking Values(" + txtCBid.Text + "," + cmbcateringid.Text + ",'" + txtcatadvance.Text + "','" + DateTimePicker1.Text + "'," + txtnoofdish.Text + ")"
            MsgBox(cmd.CommandText)
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
            cmd = New OleDbCommand("Select * from CateringBooking", con)
            cmd.CommandText = "Update CateringBooking set Catid =" + cmbcateringid.Text + ",Catadvance ='" + txtcatadvance.Text + "' , Catdate= '" + DateTimePicker1.Text + "',Noofdish =" + txtnoofdish.Text + " where CatBkid=" + txtCBid.Text
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
        id1 = InputBox("Enter CateringBookingid to search")
        Try
            cmd = New OleDbCommand("Select * from CateringBooking", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("CateringBooking")
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            cnt1 = 0
            cnt1 = ds.Tables(0).Rows.Count - 1
            r = 0
            For Me.i = 0 To cnt1 Step 1
                r = Val(ds.Tables(0).Rows(Me.i).Item(0).ToString())
                If r = id1 Then
                    txtCBid.Text = ds.Tables(0).Rows(Me.i).Item(0).ToString()
                    cmbcateringid.Text = ds.Tables(0).Rows(Me.i).Item(1).ToString()
                    txtcatadvance.Text = ds.Tables(0).Rows(Me.i).Item(2).ToString()
                    DateTimePicker1.Text = ds.Tables(0).Rows(Me.i).Item(3).ToString()
                    txtnoofdish.Text = ds.Tables(0).Rows(Me.i).Item(4).ToString()
                    Exit For
                Else
                    r = 0
                End If
            Next
            If r = 0 Then
                MsgBox("Catering Booking ID not present")
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
        txtCBid.Text = ""
        cmbcateringid.Text = ""
        DateTimePicker1.Text = ""
        txtnoofdish.Text = ""
        txtcatadvance.Text = ""
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Hide()
    End Sub

    Private Sub btnskip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnskip.Click
        Try
            
            cmd = New OleDbCommand("Select * from CateringBooking", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("CateringBooking")
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

   
    Private Sub btndisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndisplay.Click
        Try
            cmd1 = New OleDbCommand("Select * from Client1 where clientname='" + cmbclientname.Text + "'", con)
            da1 = New OleDbDataAdapter(cmd1)
            ds1 = New DataSet("Client1")
            da1.Fill(ds1)
            
            cmbclientid.Text = ds1.Tables(0).Rows(0).Item(0).ToString()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd1.Dispose()
            da1.Dispose()
            ds1.Dispose()
        End Try
        Try
            cmd2 = New OleDbCommand("Select * from Catering where Menutype='" + cmbmenu.Text + "'", con)
            da2 = New OleDbDataAdapter(cmd2)
            ds2 = New DataSet("Catering")
            da2.Fill(ds2)

            cmbcatid.Text = ds2.Tables(0).Rows(0).Item(0).ToString()
            cmbcateringid.Text = ds2.Tables(0).Rows(0).Item(0).ToString()
            cmbmenu.Text = ds2.Tables(0).Rows(0).Item(1).ToString()
            cmbsub.Text = ds2.Tables(0).Rows(0).Item(2).ToString()
            txtrate.Text = ds2.Tables(0).Rows(0).Item(3).ToString()

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd2.Dispose()
            da2.Dispose()
            ds2.Dispose()
        End Try
    End Sub

    Private Sub btncal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncal.Click
        Dim rate As Double
        Dim qty As Integer
        Dim tot As Double
        rate = Val(txtrate.Text)
        qty = Val(txtnoofdish.Text)
        tot = 0
        tot = rate * qty
        txtcatadvance.Text = tot.ToString()
    End Sub

    Private Sub txtCBid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCBid.KeyPress
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

    Private Sub txtnoofdish_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnoofdish.KeyPress
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

    Private Sub txtcatadvance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcatadvance.KeyPress
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