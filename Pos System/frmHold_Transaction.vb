Public Class frmHold_Transaction
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Me.TopMost = False
        frmPOS_System.Enabled = True
    End Sub
End Class