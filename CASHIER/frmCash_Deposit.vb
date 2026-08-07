Imports System.Data.SqlClient

Public Class frmCash_Deposit

    ' Koneksyon gamit ang iyong existing connection
    Private ReadOnly connStr As String = modConnection.connStr

    Private Sub frmCashDeposit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateTransactionID()
        txtFullName.Clear()
        txtAmount.Clear()
        txtRemarks.Clear()
        txtFullName.Focus()
        txtAmount.Text = frmCash_Declaration.lblTotal.Text
    End Sub

    ' ✅ Gumawa ng natatanging Transaction ID
    Private Sub GenerateTransactionID()
        Dim newTransID As String = "DEP-" & Now.ToString("yyyyMMdd") & "-" & New Random().Next(10000, 99999).ToString()
        lblTransactionID.Text = newTransID
    End Sub

    ' ✅ Button: Declare / I-save ang transaksyon
    Private Sub btnDeclare_Click(sender As Object, e As EventArgs) Handles btnDeclare.Click
        ' Validate inputs
        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Ilagay ang buong pangalan.", "Kinakailangan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If

        Dim depositAmount As Decimal = 0
        If Not Decimal.TryParse(txtAmount.Text.Trim(), depositAmount) OrElse depositAmount <= 0 Then
            MessageBox.Show("Ilagay ang tamang halaga na mas mataas sa 0.", "Maling Halaga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmount.Focus()
            Return
        End If

        ' I-save sa database
        Try
            Using conn As New SqlConnection(connStr)
                Dim sql As String = "INSERT INTO dbo.Cash_Deposit 
                    (Transaction_ID, Full_Name, Amount, Remarks, Created_By)
                    VALUES (@TransID, @FullName, @Amount, @Remarks, @CreatedBy)"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@TransID", lblTransactionID.Text.Trim())
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Amount", depositAmount)
                    cmd.Parameters.AddWithValue("@Remarks", If(String.IsNullOrWhiteSpace(txtRemarks.Text), DBNull.Value, txtRemarks.Text.Trim()))
                    cmd.Parameters.AddWithValue("@CreatedBy", frmPOSLogin.txtUsername.Text.Trim()) ' o LoggedInUser

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Cash Deposit naitala nang matagumpay! 🎉", "Tagumpay", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' I-reset ang form para sa susunod na transaksyon
            GenerateTransactionID()
            txtFullName.Clear()
            txtAmount.Clear()
            txtRemarks.Clear()
            txtFullName.Focus()

        Catch ex As Exception
            MessageBox.Show("Error habang nagse-save: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ Button: Exit
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    ' ✅ Payagan lang ang numero at tuldok sa Amount field
    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If
        ' Isang tuldok lang ang pwede
        If e.KeyChar = "." AndAlso txtAmount.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

End Class