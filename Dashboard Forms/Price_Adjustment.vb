Imports MySqlConnector
Imports System.Drawing
Imports System.IO

Public Class Price_Adjustment

    Private connStr As String = DBConnection.connStr
    Private currentUserAccountID As String = Login.LoggedInAccountID
    Private currentUserRole As String = Login.LoggedInUserType

    Private Sub Price_Adjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If String.IsNullOrWhiteSpace(currentUserRole) OrElse String.IsNullOrWhiteSpace(currentUserAccountID) Then
            MessageBox.Show("Session not found. Please login again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        If currentUserRole.Trim.ToUpper() <> "BUSINESS ADMIN" Then
            MessageBox.Show("Access Denied: Only Main Office users can adjust prices.", "Security Restriction", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If

        txtbarcode.ReadOnly = False
        txtPrice.ReadOnly = True
        txtbarcode.Focus()
    End Sub

    Private Sub txtbarcode_TextChanged(sender As Object, e As EventArgs) Handles txtbarcode.TextChanged
        Dim searchValue As String = txtbarcode.Text.Trim()
        If Not String.IsNullOrWhiteSpace(searchValue) Then
            LoadProduct(searchValue)
        Else
            ClearAllFields()
        End If
    End Sub

    Private Sub LoadProduct(searchKey As String)
        ClearDisplay()
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim sql As String = "SELECT `BRAND`, `DESCRIPTIONS`, `SIZE`, `VENDOR_CODE`, `VENDOR`, `PRICE`, `AVAILABILITY`, `BARCODE`, `SKU`, `ACCOUNT_ID` " &
                                    "FROM `inventory_information` " &
                                    "WHERE (`BARCODE` = @Key OR `SKU` = @Key) AND `ACCOUNT_ID` = @AccountID"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Key", searchKey)
                    cmd.Parameters.AddWithValue("@AccountID", currentUserAccountID)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblBrand.Text = reader("BRAND").ToString()
                            lblDesc.Text = reader("DESCRIPTIONS").ToString()
                            lblSize.Text = reader("SIZE").ToString()
                            lblVendorCode.Text = reader("VENDOR_CODE").ToString()
                            lblVendor.Text = reader("VENDOR").ToString()
                            lblAvail.Text = reader("AVAILABILITY").ToString()
                            txtPrice.Text = Convert.ToDecimal(reader("PRICE")).ToString("F2")
                            txtPrice.ReadOnly = False
                            If reader("AVAILABILITY").ToString().Trim().ToUpper() <> "AVAILABLE" Then
                                MessageBox.Show("This product is NOT available.", "Product Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ClearAllFields()
                            End If
                        Else
                            MessageBox.Show("Product not found or not registered under your account.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ClearDisplay()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If currentUserRole.Trim.ToUpper() <> "BUSINESS ADMIN" Then
            MessageBox.Show("Only Main Office can update prices.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If
        Dim searchKey As String = txtbarcode.Text.Trim()
        If String.IsNullOrWhiteSpace(searchKey) Then
            MessageBox.Show("Scan or enter Barcode/SKU first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtbarcode.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtPrice.Text) Then
            MessageBox.Show("Enter new price.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPrice.Focus()
            Return
        End If
        Dim newPrice As Decimal
        If Not Decimal.TryParse(txtPrice.Text, newPrice) OrElse newPrice <= 0 Then
            MessageBox.Show("Enter a valid positive price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPrice.SelectAll()
            txtPrice.Focus()
            Return
        End If
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim updSql As String = "UPDATE `inventory_information` " &
                                       "SET `PRICE` = @NewPrice " &
                                       "WHERE (`BARCODE` = @Key OR `SKU` = @Key) AND `ACCOUNT_ID` = @AccountID"
                Using cmd As New MySqlCommand(updSql, conn)
                    cmd.Parameters.AddWithValue("@NewPrice", newPrice)
                    cmd.Parameters.AddWithValue("@Key", searchKey)
                    cmd.Parameters.AddWithValue("@AccountID", currentUserAccountID)
                    Dim rowsUpdated As Integer = cmd.ExecuteNonQuery()
                    If rowsUpdated > 0 Then
                        MessageBox.Show($"Price updated successfully for ALL branches under this Account ID. ({rowsUpdated} record/s updated)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearAllFields()
                        txtbarcode.Focus()
                    Else
                        MessageBox.Show("No matching product found to update.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Update error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ClearDisplay()
        lblBrand.Text = String.Empty
        lblDesc.Text = String.Empty
        lblSize.Text = String.Empty
        lblVendorCode.Text = String.Empty
        lblVendor.Text = String.Empty
        lblAvail.Text = String.Empty
        txtPrice.ReadOnly = True
    End Sub

    Private Sub ClearAllFields()
        txtbarcode.Clear()
        txtPrice.Clear()
        ClearDisplay()
    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." AndAlso txtPrice.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

End Class