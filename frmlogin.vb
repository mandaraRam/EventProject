Public Class frmlogin

    'Private Sub txtpass_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'validating phone length
    '    Dim ss1 As String
    '    Dim len As Integer
    '    Dim i As Integer
    '    len = 0
    '    ss1 = txtpass.Text
    '    len = ss1.Length

    '    Dim ch1(len) As Char
    '    ch1 = ss1.ToCharArray()


    '    Dim res1 As Boolean
    '    Dim res2 As Boolean
    '    Dim res3 As Boolean
    '    Dim res4 As Boolean
    '    res1 = False
    '    res2 = False
    '    res3 = False
    '    res4 = False
    '    If len = 8 Then
    '        res1 = True
    '    Else
    '        res2 = True
    '    End If

    '    If res1 = True Then
    '        'MsgBox("Digits are not allowed in coach name")
    '        'txtcemail.Text = ""
    '        res1 = False
    '    ElseIf res2 = True Then
    '        MsgBox("Password must be 8 digit long")
    '        txtpass.Text = ""
    '    End If
    'End Sub

    'Private Sub btnsubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If txtuname.Text.Equals("") Or txtpass.Text.Equals("") Then
    '        MsgBox("Empty details is not allowed")
    '    ElseIf txtuname.Text.Equals("Palash") And txtpass.Text.Equals("Pranav11") Then
    '        MsgBox("Login is correct")
    '        MDIParent1.Show()
    '        Me.Hide()
    '    Else
    '        MsgBox("Login is not correct so reneter details")
    '        txtuname.Text = ""
    '        txtpass.Text = ""
    '        txtuname.Focus()
    '    End If
    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    'End Sub

    Private Sub frmlogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Dim str1 As String
    Dim str2 As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        str1 = txtuname.Text
        str2 = txtpass.Text
        If str1.Equals("") Or str2.Equals("") Then
            MsgBox("Empty values not allowed")
            txtuname.Text = ""
            txtpass.Text = ""
            txtuname.Focus()
        ElseIf str1.Equals("admin") And str2.Equals("admin123") Then
            MsgBox("Login is correct")
            MDIParent1.Show()
            Me.Hide()
        Else
            MsgBox("Login is not correct")
            txtuname.Text = ""
            txtpass.Text = ""
            txtuname.Focus()

        End If
    End Sub

    Private Sub txtpass_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpass.LostFocus
        'validating phone length
        Dim ss1 As String
        Dim len As Integer
        Dim i As Integer
        len = 0
        ss1 = txtpass.Text
        len = ss1.Length

        Dim ch1(len) As Char
        ch1 = ss1.ToCharArray()


        Dim res1 As Boolean
        Dim res2 As Boolean
        Dim res3 As Boolean
        Dim res4 As Boolean
        res1 = False
        res2 = False
        res3 = False
        res4 = False
        If len = 8 Then
            res1 = True
        Else
            res2 = True
        End If

        If res1 = True Then
            'MsgBox("Digits are not allowed in coach name")
            'txtcemail.Text = ""
            res1 = False
        ElseIf res2 = True Then
            MsgBox("Password must be 8 char long")
            txtpass.Text = ""
        End If

    End Sub

End Class