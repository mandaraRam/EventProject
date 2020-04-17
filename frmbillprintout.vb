Public Class frmbillprintout


    Private Sub frmbillprintout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtclientname.Text = frmbill.str1
        txtaddress.Text = frmbill.str2
        txtETid.Text = frmbill.no1
        txtbillamount.Text = frmbill.gtotal
        Label8.Text = frmbill.str3
    End Sub
End Class