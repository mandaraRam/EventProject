Imports System.Data
Imports System.Data.OleDb
Public Class frmcancelation
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
    Private Sub frmcancelation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\Project vb.net\test.mdb")
            con.Open()
            MsgBox("Connection is done")
            cmd = New OleDbCommand("Select * from Cancelation", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Cancelation")
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
            ds1 = New DataSet("client1")
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
    End Sub
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            cmd = New OleDbCommand("Select * from Cancelation", con)
            cmd.CommandText = "Insert into Cancelation values(" + cmbcanid.Text + "," + cmbetbkid.Text + "," + txtclientid.Text + ",'" + cmbclientname.Text + "','" + txtcreason.Text + "','" + DateTimePicker1.Text + "','" + txtrefstatus.Text + "'," + txtrefamount.Text + ")"
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

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            cmd = New OleDbCommand("Select max(CanID) from Cancelation", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Cancelation")
            da.Fill(ds)
            id1 = 0
            id1 = Val(ds.Tables(0).Rows(0).Item(0).ToString())
            id1 = id1 + 1
            cmbcanid.Text = id1.ToString()
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
            cmd = New OleDbCommand("Select * from Cancelation", con)
            cmd.CommandText = "Update Cancelation set EBkid=" + cmbetbkid.Text + ",Clientid=" + txtclientid.Text + ",Clientname='" + cmbclientname.Text + "',Cresn='" + txtcreason.Text + "',Cdate='" + DateTimePicker1.Text + "',Refstatus='" + txtrefstatus.Text + "',Refamount=" + txtrefamount.Text + " where CanID =" + cmbcanid.Text
            MsgBox(cmd.CommandText)
            r = 0
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

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        Try
            cmd = New OleDbCommand("Select * from Cancelation", con)
            cmd.CommandText = "Delete from Cancelation  where CanID =" + cmbcanid.Text
            MsgBox(cmd.CommandText)
            r = 0
            r = cmd.ExecuteNonQuery()
            If r = 0 Then
                MsgBox("Record is not Deleted")
            Else
                MsgBox("Record is deleted")
                cmbcanid.Text = ""
                cmbetbkid.Text = ""
                txtclientid.Text = ""
                cmbclientname.Text = ""
                txtcreason.Text = ""
                'DateTimePicker1.Text = ""
                txtrefstatus.Text = ""
                txtrefamount.Text = ""

            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()

        End Try
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        id1 = 0
        id1 = InputBox("Enter Cancelation ID to search")
        Try
            cmd = New OleDbCommand("Select * from Cancelation", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Cancelation")
            da.Fill(ds)
            cnt1 = 0
            cnt1 = ds.Tables(0).Rows.Count - 1
            r = 0
            For Me.i = 0 To cnt1 Step 1
                r = Val(ds.Tables(0).Rows(Me.i).Item(0).ToString())
                If r = id1 Then
                    MsgBox("Cancelllation ID is present")
                    cmbcanid.Text = ds.Tables(0).Rows(Me.i).Item(0).ToString()
                    cmbetbkid.Text = ds.Tables(0).Rows(Me.i).Item(1).ToString()
                    txtclientid.Text = ds.Tables(0).Rows(Me.i).Item(2).ToString()
                    cmbclientname.Text = ds.Tables(0).Rows(Me.i).Item(3).ToString()
                    txtcreason.Text = ds.Tables(0).Rows(Me.i).Item(4).ToString()
                    DateTimePicker1.Text = ds.Tables(0).Rows(Me.i).Item(5).ToString()
                    txtrefstatus.Text = ds.Tables(0).Rows(Me.i).Item(6).ToString()
                    txtrefamount.Text = ds.Tables(0).Rows(Me.i).Item(7).ToString()

                Else
                    r = 0
                End If
            Next
            If r = 0 Then
                MsgBox("Cancelllation ID not present")
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

    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Hide()
    End Sub

   
    Private Sub cmbclientname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbclientname.SelectedIndexChanged
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

            cmd2 = New OleDbCommand("Select * from EventBooking where clientid=" + txtclientid.Text, con)
            da2 = New OleDbDataAdapter(cmd2)
            ds2 = New DataSet("Client1")
            da2.Fill(ds2)

            cnt1 = 0
            cnt1 = ds2.Tables(0).Rows.Count - 1
            cmbetbkid.Items.Clear()
            For Me.i = 0 To cnt1 Step 1
                cmbetbkid.Items.Add(ds2.Tables(0).Rows(Me.i).Item(0).ToString())
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd2.Dispose()
            da2.Dispose()
            ds2.Dispose()
        End Try
    End Sub

    Private Sub btnshow1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow1.Click
        Try
            cmd = New OleDbCommand("Select * from Cancelation", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("Cancelation")
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