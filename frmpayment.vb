Imports System.Data
Imports System.Data.OleDb
Public Class frmpayment

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
    Public Shared clientname As String
    Public Shared clientaddress As String
    Public Shared clientphone As String
    Public Shared recieptno As Integer
    Public Shared billno As Integer
    Public Shared amount As Double
    Private Sub frmpayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\Project vb.net\test.mdb")
            con.Open()
            MsgBox("Connection is done")
            cmd = New OleDbCommand("Select * from Payment", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Payment")
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try
        'taking client names
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
            cmd = New OleDbCommand("Select max(Payid) from Payment", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Payment")
            da.Fill(ds)
            id1 = 0
            id1 = Val(ds.Tables(0).Rows(0).Item(0).ToString())
            id1 = id1 + 1
            txtpayid.Text = id1.ToString()
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
            cmd = New OleDbCommand("Select * from Payment", con)
            cmd.CommandText = "Delete from bill where Payid=" + txtpayid.Text
            r = cmd.ExecuteNonQuery()
            If r = 0 Then
                MsgBox("Record is not deleted")
            Else
                MsgBox("Record is deleted")
                txtpayid.Text = ""
                cmbbillid.Text = ""
                cmbpaymenttype.Text = ""
                txtpayamount.Text = ""
                txtchqno.Text = ""
                txtbankdtls.Text = ""


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
            cmd = New OleDbCommand("Select * from Payment", con)
            cmd.CommandText = "Insert into Payment values(" + txtpayid.Text + "," + cmbbillid.Text + ",'" + DateTimePicker1.Text + "','" + cmbpaymenttype.Text + "'," + txtpayamount.Text + ",'" + txtchqno.Text + "','" + txtbankdtls.Text + "')"
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
            cmd = New OleDbCommand("Select * from Payment", con)
            cmd.CommandText = "Update Payment set Billid=" + cmbbillid.Text + ",Paydate ='" + DateTimePicker1.Text + "',Paytype ='" + cmbpaymenttype.Text + "' , Payamount= " + txtpayamount.Text + ",Chequeno ='" + txtchqno.Text + "',Bankdlts ='" + txtbankdtls.Text + "' where Payid=" + txtpayid.Text
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
        id1 = InputBox("Enter Paymentid to search")
        Try
            cmd = New OleDbCommand("Select * from Payment", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Payment")
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            cnt1 = 0
            cnt1 = ds.Tables(0).Rows.Count - 1
            r = 0
            For Me.i = 0 To cnt1 Step 1
                r = Val(ds.Tables(0).Rows(Me.i).Item(0).ToString())
                If r = id1 Then
                    txtpayid.Text = ds.Tables(0).Rows(Me.i).Item(0).ToString()
                    cmbbillid.Text = ds.Tables(0).Rows(Me.i).Item(1).ToString()
                    DateTimePicker1.Text = ds.Tables(0).Rows(Me.i).Item(2).ToString()
                    cmbpaymenttype.Text = ds.Tables(0).Rows(Me.i).Item(3).ToString()
                    txtpayamount.Text = ds.Tables(0).Rows(Me.i).Item(4).ToString()
                    txtchqno.Text = ds.Tables(0).Rows(Me.i).Item(5).ToString()
                    txtbankdtls.Text = ds.Tables(0).Rows(Me.i).Item(6).ToString()
                    Exit For
                Else
                    r = 0
                End If
            Next
            If r = 0 Then
                MsgBox("Payment ID not present")
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
        txtpayid.Text = ""
        DateTimePicker1.Text = ""
        cmbpaymenttype.Text = ""
        txtpayamount.Text = ""
        txtchqno.Text = ""
        txtbankdtls.Text = ""
        txtclientaddress.Text = ""
        cmbbillid.Text = ""
        cmbclientname.Text = ""
        cmbclientid.Text = ""

    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Hide()
    End Sub

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        Try

            cmd1 = New OleDbCommand("Select * from client1 where clientname='" + cmbclientname.Text + "'", con)
            da1 = New OleDbDataAdapter(cmd1)
            ds1 = New DataSet("client1")
            da1.Fill(ds1)

            cmbclientid.Text = ds1.Tables(0).Rows(0).Item(0).ToString()
            txtclientaddress.Text = ds1.Tables(0).Rows(0).Item(2).ToString()
            clientname = ds1.Tables(0).Rows(0).Item(1).ToString()
            clientaddress = txtclientaddress.Text
            clientphone = ds1.Tables(0).Rows(0).Item(3).ToString()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd1.Dispose()
            da1.Dispose()
            ds1.Dispose()
        End Try
        cmbbillid.Items.Clear()
        Try

            cmd2 = New OleDbCommand("Select * from Bill where clientid=" + cmbclientid.Text, con)
            da2 = New OleDbDataAdapter(cmd2)
            ds2 = New DataSet("Bill")
            da2.Fill(ds2)

            cnt1 = 0
            cnt1 = ds2.Tables(0).Rows.Count - 1
            For Me.i = 0 To cnt1 Step 1
                cmbbillid.Items.Add(ds2.Tables(0).Rows(i).Item(0).ToString())
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd2.Dispose()
            da2.Dispose()
            ds2.Dispose()
        End Try
    End Sub

    Private Sub cmbbillid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbillid.SelectedIndexChanged
        Try

            cmd2 = New OleDbCommand("Select * from Bill where Billid=" + cmbbillid.Text, con)
            da2 = New OleDbDataAdapter(cmd2)
            ds2 = New DataSet("Bill")
            da2.Fill(ds2)

            txtpayamount.Text = ds2.Tables(0).Rows(0).Item(7).ToString()


        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd2.Dispose()
            da2.Dispose()
            ds2.Dispose()
        End Try
    End Sub

    Private Sub btnprtrecpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprtrecpt.Click
        recieptno = Val(txtpayid.Text)
        billno = Val(cmbbillid.Text)
        amount = Val(txtpayamount.Text)
        frmpaymentreciept.Show()
    End Sub

    Private Sub btnshow1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow1.Click
        Try
            cmd = New OleDbCommand("Select * from Payment", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Payment")
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