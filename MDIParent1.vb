Imports System.Windows.Forms

Public Class MDIParent1

    Private Sub mnuclient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuclient.Click
        Dim c1 As New frmclient
        c1.MdiParent = Me
        c1.Show()
    End Sub


    Private Sub mneventtype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mneventtype.Click
        Dim c2 As New frmeventtype
        c2.MdiParent = Me
        c2.Show()
    End Sub

    Private Sub mnuhall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuhall.Click
        Dim c3 As New frmhall
        c3.MdiParent = Me
        c3.Show()
    End Sub

    Private Sub mnucatering_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucatering.Click
        Dim c4 As New frmcatering
        c4.MdiParent = Me
        c4.Show()
    End Sub

    Private Sub mnuguestlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuguestlist.Click
        Dim c5 As New frmguestlist
        c5.MdiParent = Me
        c5.Show()
    End Sub

    Private Sub mnuenquiry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuenquiry.Click
        Dim b1 As New frmenquiry
        b1.MdiParent = Me
        b1.Show()
    End Sub

    Private Sub mnueventbooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnueventbooking.Click
        Dim b2 As New frmeventbooking
        b2.MdiParent = Me
        b2.Show()
    End Sub

    Private Sub mnuhallbooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuhallbooking.Click
        Dim b3 As New frmhallbooking
        b3.MdiParent = Me
        b3.Show()
    End Sub

    Private Sub mnucateringbooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucateringbooking.Click
        Dim b1 As New frmcateringbooking
        b1.MdiParent = Me
        b1.Show()
    End Sub

    Private Sub mnubill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnubill.Click
        Dim e1 As New frmbill
        e1.MdiParent = Me
        e1.Show()
    End Sub

    Private Sub mnupayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupayment.Click
        Dim e1 As New frmpayment
        e1.MdiParent = Me
        e1.Show()
    End Sub

    Private Sub mnuexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexit.Click
        End
    End Sub

    Private Sub mnureport1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnureport1.Click
        Dim r1 As New frmenquiryrpt
        r1.MdiParent = Me
        r1.Show()
    End Sub

    Private Sub mnureport2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnureport2.Click
        Dim r2 As New frmclient1rpt
        r2.MdiParent = Me
        r2.Show()
    End Sub

    Private Sub mnureport3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnureport3.Click
        Dim r3 As New frmhallreport
        r3.MdiParent = Me
        r3.Show()
    End Sub

    Private Sub mnureport4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnureport4.Click
        Dim r4 As New frmeventbookingreport
        r4.MdiParent = Me
        r4.Show()
    End Sub

    Private Sub mnucancelation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucancelation.Click
        Dim r5 As New frmcancelation
        r5.MdiParent = Me
        r5.Show()
    End Sub

    Private Sub mnureport5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnureport5.Click
        Dim r6 As New frmcateringreport
        r6.MdiParent = Me
        r6.Show()
    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
