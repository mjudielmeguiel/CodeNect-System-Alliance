Imports System.Data
Imports MySqlConnector

Public Class frmCategory
    Private CurrentAccountID As String = ""
    Private connStr As String = DBConnection.connStr

    Private Sub frmCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentAccountID = Login.LoggedInAccountID
        Me.Text = "Manage Categories"
        AuditLogger.LogAction("OPEN_CAT_MGR", "CategoryMgr", $"Opened Category Manager | Account: {CurrentAccountID}")
        LoadCategoryList()
    End Sub

    Private Sub LoadCategoryList()
        Try
            lstCategories.Items.Clear()
            Using conn As New MySqlConnection(connStr)
                Dim qry As String = "SELECT `category_name` FROM `product_categories` WHERE `ACCOUNT_ID` = @Acc ORDER BY `category_name`"
                Using cmd As New MySqlCommand(qry, conn)
                    cmd.Parameters.AddWithValue("@Acc", CurrentAccountID)
                    conn.Open()
                    Dim dr = cmd.ExecuteReader()
                    Dim count As Integer = 0
                    While dr.Read()
                        lstCategories.Items.Add(dr("category_name").ToString())
                        count += 1
                    End While
                    dr.Close()
                    AuditLogger.LogAction("CATS_LOADED", "CategoryMgr", $"Loaded {count} categories | Account: {CurrentAccountID}")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Load Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "CategoryMgr", $"Load list failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim categoryName As String = txtCategoryName.Text.Trim()

        If String.IsNullOrWhiteSpace(categoryName) Then
            MessageBox.Show("Ilagay ang pangalan ng Category.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCategoryName.Focus()
            AuditLogger.LogAction("CREATE_FAIL", "CategoryMgr", "Create cancelled - empty name")
            Return
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim checkSql As String = "SELECT COUNT(*) FROM `product_categories` WHERE `ACCOUNT_ID` = @Acc AND `category_name` = @Name"
                Using cmdCheck As New MySqlCommand(checkSql, conn)
                    cmdCheck.Parameters.AddWithValue("@Acc", CurrentAccountID)
                    cmdCheck.Parameters.AddWithValue("@Name", categoryName)
                    If CInt(cmdCheck.ExecuteScalar()) > 0 Then
                        MessageBox.Show("May ganito nang Category.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        AuditLogger.LogAction("CREATE_DUPLICATE", "CategoryMgr", $"Duplicate category | Name: {categoryName}")
                        Return
                    End If
                End Using

                Dim insertSql As String = "INSERT INTO `product_categories` (`ACCOUNT_ID`, `category_name`) VALUES (@Acc, @Name)"
                Using cmdInsert As New MySqlCommand(insertSql, conn)
                    cmdInsert.Parameters.AddWithValue("@Acc", CurrentAccountID)
                    cmdInsert.Parameters.AddWithValue("@Name", categoryName)
                    cmdInsert.ExecuteNonQuery()
                End Using

                MessageBox.Show("Naidagdag na ang Category.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                AuditLogger.LogAction("CAT_CREATED", "CategoryMgr", $"New category added | Name: {categoryName}")
                txtCategoryName.Clear()
                LoadCategoryList()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("CREATE_ERROR", "CategoryMgr", $"Create failed | Name: {categoryName} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If lstCategories.SelectedIndex = -1 Then
            MessageBox.Show("Pumili muna ng buburahin sa listahan.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditLogger.LogAction("REMOVE_FAIL", "CategoryMgr", "Remove cancelled - no selection")
            Return
        End If

        Dim selectedCat As String = lstCategories.SelectedItem.ToString()

        If MessageBox.Show("Burahin ba ang: " & selectedCat & "?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            AuditLogger.LogAction("REMOVE_CANCEL", "CategoryMgr", $"Remove cancelled by user | Name: {selectedCat}")
            Return
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim delSql As String = "DELETE FROM `product_categories` WHERE `ACCOUNT_ID` = @Acc AND `category_name` = @Name"
                Using cmdDel As New MySqlCommand(delSql, conn)
                    cmdDel.Parameters.AddWithValue("@Acc", CurrentAccountID)
                    cmdDel.Parameters.AddWithValue("@Name", selectedCat)
                    cmdDel.ExecuteNonQuery()
                End Using

                MessageBox.Show("Nabura na ang Category.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                AuditLogger.LogAction("CAT_REMOVED", "CategoryMgr", $"Category deleted | Name: {selectedCat}")
                LoadCategoryList()
            End Using
        Catch ex As Exception
            MessageBox.Show("Remove Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("REMOVE_ERROR", "CategoryMgr", $"Delete failed | Name: {selectedCat} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        AuditLogger.LogAction("CLOSE_CAT", "CategoryMgr", "Category Manager closed")
        Me.Close()
    End Sub
End Class