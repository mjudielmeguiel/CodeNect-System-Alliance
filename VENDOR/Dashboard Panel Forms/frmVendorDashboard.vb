Imports MySqlConnector

Public Class frmVendorDashboard

    Public Shared VendorID As String = ""
    Public Shared VendorName As String = ""
    Public Shared VendorCode As String = ""

    Private Sub frmVendorDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DBConnection.SetVendorInfo(VendorCode, VendorName)

        Panelmenu.Controls.Clear()
        Dim VHome As New frmVendorHome()
        VHome.TopLevel = False
        VHome.FormBorderStyle = FormBorderStyle.None
        VHome.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(VHome)
        VHome.Show()

        frmVendorHome.VendorID = VendorID
        frmVendorHome.VendorName = VendorName
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        If Panelmenu.Controls.Count > 0 Then
            Dim homeForm As frmVendorHome = TryCast(Panelmenu.Controls(0), frmVendorHome)
            If homeForm IsNot Nothing Then
                homeForm.RefreshDashboard()
            End If
        End If
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        DBConnection.SetVendorInfo(VendorCode, VendorName)

        Panelmenu.Controls.Clear()
        Dim Products As New frmVendor_Products()
        Products.TopLevel = False
        Products.FormBorderStyle = FormBorderStyle.None
        Products.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(Products)
        Products.Show()
    End Sub

    Private Sub btnOrders_Click(sender As Object, e As EventArgs) Handles btnOrders.Click
        Panelmenu.Controls.Clear()
        Dim Orders As New frmOrders
        Orders.TopLevel = False
        Orders.FormBorderStyle = FormBorderStyle.None
        Orders.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(Orders)
        Orders.Show()
    End Sub

    Private Sub btnReturns_Click(sender As Object, e As EventArgs) Handles btnReturns.Click
        MessageBox.Show("Returns section will load here.", "Vendor Panel", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSignOut_Click(sender As Object, e As EventArgs) Handles btnSignOut.Click
        AuditLogger.LogAction("VENDOR_LOGOUT", "Vendor Panel", $"Vendor [{VendorName}] ID: {VendorID} logged out")

        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE `vendor_account` SET `STATUS`='OFFLINE' WHERE `ID`=@vid", conn)
                    cmd.Parameters.AddWithValue("@vid", VendorID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try

        DBConnection.ClearVendorInfo()
        Login.Show()
        Me.Close()
    End Sub

    Private Sub btnCient_Click(sender As Object, e As EventArgs) Handles btnCient.Click
        Panelmenu.Controls.Clear()
        Dim Branch As New frmBranches
        Branch.TopLevel = False
        Branch.FormBorderStyle = FormBorderStyle.None
        Branch.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(Branch)
        Branch.Show()
    End Sub
End Class