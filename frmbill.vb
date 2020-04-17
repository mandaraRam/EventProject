
Imports System.Data
Imports System.Data.OleDb
Public Class frmbill
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Public id1 As Integer
    Public r As Integer
    Public i As Integer
    Public cnt1 As Integer

    'foreign keys
    Dim cmd1 As OleDbCommand
    Dim da1 As OleDbDataAdapter
    Dim ds1 As DataSet
    Dim cmd2 As OleDbCommand
    Dim da2 As OleDbDataAdapter
    Dim ds2 As DataSet

    'calculations
    Public Shared amt As Double
    Public Shared vat As Double
    Public Shared stax As Double
    Public Shared disc As Double
    Public Shared gtotal As Double
    Public Shared str1 As String
    Public Shared str2 As String
    Public Shared str3 As String
    Public Shared no1 As Integer
    Private Sub frmbill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\Project vb.net\test.mdb")
            con.Open()
            MsgBox("Connection is done")
            cmd = New OleDbCommand("Select * from Bill", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Bill")
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
           
            cmd1 = New OleDbCommand("Select * from client1", con)
            da1 = New OleDbDataAdapter(cmd1)
            ds1 = New DataSet("client1")
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
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            cmd = New OleDbCommand("Select max(Billid) from Bill", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Bill")
            da.Fill(ds)
            id1 = 0
            id1 = Val(ds.Tables(0).Rows(0).Item(0).ToString())
            id1 = id1 + 1
            txtbillid.Text = id1.ToString()
            no1 = id1
            str3 = DateTimePicker1.Text
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
            cmd = New OleDbCommand("Select * from Bill", con)
            cmd.CommandText = "Delete from bill where Billid=" + txtbillid.Text
            r = cmd.ExecuteNonQuery()
            If r = 0 Then
                MsgBox("Record is not deleted")
            Else
                MsgBox("Record is deleted")
                txtbillid.Text = ""
                cmbclientid.Text = ""
                cmbbookingid.Text = ""
                txtamount.Text = ""
                txtvat.Text = ""
                txtdiscount.Text = ""
                txtbilltotal.Text = ""

            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()
            da.Dispose()
            ds.Dispose()

        End Try
    End Sub

    Private Sub btnshow11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow11.Click
        Try

            cmd1 = New OleDbCommand("Select * from client1 where clientname='" + cmbclientname.Text + "'", con)
            da1 = New OleDbDataAdapter(cmd1)
            ds1 = New DataSet("client1")
            da1.Fill(ds1)

            cmbclientid.Text = ds1.Tables(0).Rows(0).Item(0).ToString()
            txtclientaddress.Text = ds1.Tables(0).Rows(0).Item(2).ToString()
            str1 = ds1.Tables(0).Rows(0).Item(1).ToString()
            str2 = txtclientaddress.Text
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd1.Dispose()
            da1.Dispose()
            ds1.Dispose()
        End Try
        Try

            cmd2 = New OleDbCommand("Select * from EventBooking where clientid=" + cmbclientid.Text, con)
            da2 = New OleDbDataAdapter(cmd2)
            ds2 = New DataSet("EventBooking")
            da2.Fill(ds2)

            cnt1 = 0
            cnt1 = ds2.Tables(0).Rows.Count - 1
            For Me.i = 0 To cnt1 Step 1
                cmbbookingid.Items.Add(ds2.Tables(0).Rows(i).Item(0).ToString())
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd2.Dispose()
            da2.Dispose()
            ds2.Dispose()
        End Try
    End Sub

    Private Sub cmbbookingid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbookingid.SelectedIndexChanged
        Try

            cmd2 = New OleDbCommand("Select * from EventBooking where EBkid=" + cmbbookingid.Text, con)
            da2 = New OleDbDataAdapter(cmd2)
            ds2 = New DataSet("EventBooking")
            da2.Fill(ds2)


            txtamount.Text = ds2.Tables(0).Rows(0).Item(6).ToString()
            amt = Val(txtamount.Text)
            vat = (amt * 12.5D) / 100D
            txtvat.Text = vat.ToString()
            stax = (amt * 14D) / 100D
            txtservicetax.Text = vat.ToString()
            amt = amt + stax + vat
            txtamount.Text = amt.ToString()
            disc = (10D * amt) / 100D
            txtdiscount.Text = disc.ToString()
            gtotal = amt - disc
            txtbilltotal.Text = gtotal.ToString()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd2.Dispose()
            da2.Dispose()
            ds2.Dispose()
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmbillprintout.Show()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            cmd = New OleDbCommand("Select * from Bill", con)
            cmd.CommandText = "Insert into Bill values(" + txtbillid.Text + "," + cmbbookingid.Text + "," + cmbclientid.Text + "," + txtamount.Text + "," + txtservicetax.Text + "," + txtvat.Text + "," + txtdiscount.Text + "," + txtbilltotal.Text + ",'" + DateTimePicker1.Text + "')"
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
            cmd = New OleDbCommand("Select * from Bill", con)
            cmd.CommandText = "Update Bill set EBkid =" + cmbbookingid.Text + ",clientid=" + cmbclientid.Text + ",Amount =" + txtamount.Text + ",STax =" + txtservicetax.Text + ", Vat= " + txtvat.Text + ",Discount =" + txtdiscount.Text + ",Total =" + txtbilltotal.Text + ",Billdate ='" + DateTimePicker1.Text + "' where Billid=" + txtbillid.Text
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
        id1 = InputBox("Enter Bill to search")
        Try
            cmd = New OleDbCommand("Select * from Bill", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Bill")
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            cnt1 = 0
            cnt1 = ds.Tables(0).Rows.Count - 1
            r = 0
            For Me.i = 0 To cnt1 Step 1
                r = Val(ds.Tables(0).Rows(Me.i).Item(0).ToString())
                If r = id1 Then
                    txtbillid.Text = ds.Tables(0).Rows(Me.i).Item(0).ToString()
                    cmbbookingid.Text = ds.Tables(0).Rows(Me.i).Item(1).ToString()
                    cmbclientid.Text = ds.Tables(0).Rows(Me.i).Item(2).ToString()
                    txtamount.Text = ds.Tables(0).Rows(Me.i).Item(3).ToString()
                    txtservicetax.Text = ds.Tables(0).Rows(Me.i).Item(4).ToString()
                    txtvat.Text = ds.Tables(0).Rows(Me.i).Item(5).ToString()
                    txtdiscount.Text = ds.Tables(0).Rows(Me.i).Item(6).ToString()
                    txtbilltotal.Text = ds.Tables(0).Rows(Me.i).Item(7).ToString()
                    DateTimePicker1.Text = ds.Tables(0).Rows(Me.i).Item(8).ToString()

                    Exit For
                Else
                    r = 0
                End If
            Next
            If r = 0 Then
                MsgBox("Bill ID not present")
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
        txtbillid.Text = ""
        txtamount.Text = ""
        txtservicetax.Text = ""
        txtvat.Text = ""
        txtdiscount.Text = ""
        DateTimePicker1.Text = ""
        txtbilltotal.Text = ""
        txtclientaddress.Text = ""
        cmbclientid.Text = ""
        cmbclientname.Text = ""
        cmbbookingid.Text = ""
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Hide()
    End Sub

    Private Sub btnshow1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow1.Click
        Try
           
            cmd = New OleDbCommand("Select * from Bill", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Bill")
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

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub txtvat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvat.TextChanged

    End Sub
End Class