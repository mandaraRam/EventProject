<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnumaster = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuclient = New System.Windows.Forms.ToolStripMenuItem
        Me.mneventtype = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuhall = New System.Windows.Forms.ToolStripMenuItem
        Me.mnucatering = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuguestlist = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuexit = New System.Windows.Forms.ToolStripMenuItem
        Me.OrdersProccessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuenquiry = New System.Windows.Forms.ToolStripMenuItem
        Me.mnueventbooking = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuhallbooking = New System.Windows.Forms.ToolStripMenuItem
        Me.mnucateringbooking = New System.Windows.Forms.ToolStripMenuItem
        Me.mnucancelation = New System.Windows.Forms.ToolStripMenuItem
        Me.AccountProccessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnubill = New System.Windows.Forms.ToolStripMenuItem
        Me.mnupayment = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsProcessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnureport1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnureport2 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnureport3 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnureport4 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnureport5 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnumaster, Me.OrdersProccessToolStripMenuItem, Me.AccountProccessToolStripMenuItem, Me.ReportsProcessToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1249, 31)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnumaster
        '
        Me.mnumaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuclient, Me.mneventtype, Me.mnuhall, Me.mnucatering, Me.mnuguestlist, Me.mnuexit})
        Me.mnumaster.Name = "mnumaster"
        Me.mnumaster.Size = New System.Drawing.Size(127, 27)
        Me.mnumaster.Text = "Master Form"
        '
        'mnuclient
        '
        Me.mnuclient.Name = "mnuclient"
        Me.mnuclient.Size = New System.Drawing.Size(254, 28)
        Me.mnuclient.Text = "Client Details"
        '
        'mneventtype
        '
        Me.mneventtype.Name = "mneventtype"
        Me.mneventtype.Size = New System.Drawing.Size(254, 28)
        Me.mneventtype.Text = "Event Type Details"
        '
        'mnuhall
        '
        Me.mnuhall.Name = "mnuhall"
        Me.mnuhall.Size = New System.Drawing.Size(254, 28)
        Me.mnuhall.Text = "Hall Details"
        '
        'mnucatering
        '
        Me.mnucatering.Name = "mnucatering"
        Me.mnucatering.Size = New System.Drawing.Size(254, 28)
        Me.mnucatering.Text = "Catering Details"
        '
        'mnuguestlist
        '
        Me.mnuguestlist.Name = "mnuguestlist"
        Me.mnuguestlist.Size = New System.Drawing.Size(254, 28)
        Me.mnuguestlist.Text = "Guest List Details"
        '
        'mnuexit
        '
        Me.mnuexit.Name = "mnuexit"
        Me.mnuexit.Size = New System.Drawing.Size(254, 28)
        Me.mnuexit.Text = "Exit"
        '
        'OrdersProccessToolStripMenuItem
        '
        Me.OrdersProccessToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuenquiry, Me.mnueventbooking, Me.mnuhallbooking, Me.mnucateringbooking, Me.mnucancelation})
        Me.OrdersProccessToolStripMenuItem.Name = "OrdersProccessToolStripMenuItem"
        Me.OrdersProccessToolStripMenuItem.Size = New System.Drawing.Size(155, 27)
        Me.OrdersProccessToolStripMenuItem.Text = "Orders Proccess"
        '
        'mnuenquiry
        '
        Me.mnuenquiry.Name = "mnuenquiry"
        Me.mnuenquiry.Size = New System.Drawing.Size(302, 28)
        Me.mnuenquiry.Text = "Enquiry Details"
        '
        'mnueventbooking
        '
        Me.mnueventbooking.Name = "mnueventbooking"
        Me.mnueventbooking.Size = New System.Drawing.Size(302, 28)
        Me.mnueventbooking.Text = "Event Booking Details"
        '
        'mnuhallbooking
        '
        Me.mnuhallbooking.Name = "mnuhallbooking"
        Me.mnuhallbooking.Size = New System.Drawing.Size(302, 28)
        Me.mnuhallbooking.Text = "Hall Booking Details"
        '
        'mnucateringbooking
        '
        Me.mnucateringbooking.Name = "mnucateringbooking"
        Me.mnucateringbooking.Size = New System.Drawing.Size(302, 28)
        Me.mnucateringbooking.Text = "Catering Booking Details"
        '
        'mnucancelation
        '
        Me.mnucancelation.Name = "mnucancelation"
        Me.mnucancelation.Size = New System.Drawing.Size(302, 28)
        Me.mnucancelation.Text = "Cancelation Details"
        '
        'AccountProccessToolStripMenuItem
        '
        Me.AccountProccessToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnubill, Me.mnupayment})
        Me.AccountProccessToolStripMenuItem.Name = "AccountProccessToolStripMenuItem"
        Me.AccountProccessToolStripMenuItem.Size = New System.Drawing.Size(166, 27)
        Me.AccountProccessToolStripMenuItem.Text = "Account Proccess"
        '
        'mnubill
        '
        Me.mnubill.Name = "mnubill"
        Me.mnubill.Size = New System.Drawing.Size(232, 28)
        Me.mnubill.Text = "Bill Details"
        '
        'mnupayment
        '
        Me.mnupayment.Name = "mnupayment"
        Me.mnupayment.Size = New System.Drawing.Size(232, 28)
        Me.mnupayment.Text = "Payment Details"
        '
        'ReportsProcessToolStripMenuItem
        '
        Me.ReportsProcessToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnureport1, Me.mnureport2, Me.mnureport3, Me.mnureport4, Me.mnureport5})
        Me.ReportsProcessToolStripMenuItem.Name = "ReportsProcessToolStripMenuItem"
        Me.ReportsProcessToolStripMenuItem.Size = New System.Drawing.Size(154, 27)
        Me.ReportsProcessToolStripMenuItem.Text = "Reports Process"
        '
        'mnureport1
        '
        Me.mnureport1.Name = "mnureport1"
        Me.mnureport1.Size = New System.Drawing.Size(341, 28)
        Me.mnureport1.Text = "Enquiry Details Report"
        '
        'mnureport2
        '
        Me.mnureport2.Name = "mnureport2"
        Me.mnureport2.Size = New System.Drawing.Size(341, 28)
        Me.mnureport2.Text = "Client Details Report"
        '
        'mnureport3
        '
        Me.mnureport3.Name = "mnureport3"
        Me.mnureport3.Size = New System.Drawing.Size(341, 28)
        Me.mnureport3.Text = "Hall Details Report"
        '
        'mnureport4
        '
        Me.mnureport4.Name = "mnureport4"
        Me.mnureport4.Size = New System.Drawing.Size(341, 28)
        Me.mnureport4.Text = "Event booking Details Report"
        '
        'mnureport5
        '
        Me.mnureport5.Name = "mnureport5"
        Me.mnureport5.Size = New System.Drawing.Size(341, 28)
        Me.mnureport5.Text = "Catering Details Report "
        '
        'MDIParent1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1249, 575)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "MDIParent1"
        Me.Text = "Event Management System ...................... "
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnumaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuclient As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mneventtype As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuhall As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnucatering As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuguestlist As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuexit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdersProccessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuenquiry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnueventbooking As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuhallbooking As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnucateringbooking As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnucancelation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountProccessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnubill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnupayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsProcessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnureport1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnureport2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnureport3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnureport4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnureport5 As System.Windows.Forms.ToolStripMenuItem

End Class
