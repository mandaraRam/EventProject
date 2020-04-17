Public Class frmpaymentreciept

   
    Private Sub frmpaymentreciept_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtname.Text = frmpayment.clientname.ToString()
        txtaddress.Text = frmpayment.clientaddress.ToString()
        txtphoneno.Text = frmpayment.clientphone.ToString()
        lblrecno.Text = frmpayment.recieptno.ToString()
        txtamount.Text = frmpayment.amount.ToString()
        txtbillno.Text = frmpayment.billno.ToString()
    End Sub
End Class