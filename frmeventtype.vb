Imports System.Data
Imports System.Data.OleDb
Public Class frmeventtype
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Public id1 As Integer
    Public r As Integer
    Public i As Integer
    Public cnt1 As Integer

    Private Sub frmeventtype_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\Project vb.net\test.mdb")
            con.Open()
            MsgBox("Connection is done")
            cmd = New OleDbCommand("Select * from EventType", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("EventType")
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
            cmd = New OleDbCommand("Select max(ETid) from EventType", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("EventType")
            da.Fill(ds)
            id1 = 0
            id1 = Val(ds.Tables(0).Rows(0).Item(0).ToString())
            id1 = id1 + 1
            txtETid.Text = id1.ToString()
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
            cmd = New OleDbCommand("Select * from EventType", con)
            cmd.CommandText = "Delete from EventType where ETid=" + txtETid.Text
            r = cmd.ExecuteNonQuery()
            If r = 0 Then
                MsgBox("Record is not deleted")
            Else
                MsgBox("Record is deleted")
                txtETid.Text = ""
                cmbtypename.Text = ""
                cmbeventsubtype.Text = ""
                txteventrate.Text = ""
                txtremark.Text = ""

            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            cmd.Dispose()
           
        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            cmd = New OleDbCommand("Select * from EventType", con)
            cmd.CommandText = "Insert into EventType values(" + txtETid.Text + ",'" + cmbtypename.Text + "','" + cmbeventsubtype.Text + "','" + txteventrate.Text + "','" + txtremark.Text + "')"
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
            cmd = New OleDbCommand("Select * from EventType", con)
            cmd.CommandText = "Update EventType set Typename ='" + cmbtypename.Text + "',TypeSubtype ='" + cmbeventsubtype.Text + "' , Typerate= '" + txteventrate.Text + "',Remarks ='" + txtremark.Text + "' where ETid=" + txtETid.Text
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
        txtETid.Text = ""
        cmbtypename.Text = ""
        cmbeventsubtype.Text = ""
        txteventrate.Text = ""
        txtremark.Text = ""
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        id1 = 0
        id1 = InputBox("Enter EventTypeid to search")
        Try
            cmd = New OleDbCommand("Select * from EventType", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("EventType")
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            cnt1 = 0
            cnt1 = ds.Tables(0).Rows.Count - 1
            r = 0
            For Me.i = 0 To cnt1 Step 1
                r = Val(ds.Tables(0).Rows(Me.i).Item(0).ToString())
                If r = id1 Then
                    txtETid.Text = ds.Tables(0).Rows(Me.i).Item(0).ToString()
                    cmbtypename.Text = ds.Tables(0).Rows(Me.i).Item(1).ToString()
                    cmbeventsubtype.Text = ds.Tables(0).Rows(Me.i).Item(2).ToString()
                    txteventrate.Text = ds.Tables(0).Rows(Me.i).Item(3).ToString()
                    txtremark.Text = ds.Tables(0).Rows(Me.i).Item(4).ToString()
                    Exit For
                Else
                    r = 0
                End If
            Next
            If r = 0 Then
                MsgBox("Event Type ID not present")
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

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        Try
            cmd = New OleDbCommand("Select * from EventType", con)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet("EventType")
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