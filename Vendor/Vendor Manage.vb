Imports System.Data.SqlClient
Imports System.IO

Public Class Vendor_Manage

    Private _dtVendors As New DataTable

    ' ─────────────────────────────────────────────────────────
    ' Pagbukas ng Form
    ' ─────────────────────────────────────────────────────────
    Private Sub Vendor_Manage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGrid()
        LoadAllVendors()
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Ayos ng Grid — EKSAKTO SA LAHAT NG KOLUM MALIBAN SA LOGO
    ' ─────────────────────────────────────────────────────────
    Private Sub SetupGrid()
        With dgvVendors
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .RowHeadersVisible = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 48)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .RowTemplate.Height = 30
        End With

        dgvVendors.Columns.Clear()

        ' ✅ LAHAT NG KOLUM GAYA SA TABLE MO (WALANG LOGO)
        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "ID",
            .HeaderText = "ID",
            .DataPropertyName = "ID",
            .Visible = False
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "VENDOR_CODE",
            .HeaderText = "VENDOR CODE",
            .DataPropertyName = "VENDOR_CODE",
            .Width = 120
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "VENDOR",
            .HeaderText = "VENDOR NAME",
            .DataPropertyName = "VENDOR",
            .Width = 260
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "BUSINESS_TYPE",
            .HeaderText = "BUSINESS TYPE",
            .DataPropertyName = "BUSINESS_TYPE",
            .Width = 160
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "CONTACT",
            .HeaderText = "CONTACT #",
            .DataPropertyName = "CONTACT",
            .Width = 130
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "EMAIL",
            .HeaderText = "EMAIL",
            .DataPropertyName = "EMAIL",
            .Width = 200
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "TIN",
            .HeaderText = "TIN",
            .DataPropertyName = "TIN",
            .Width = 130
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "DTI_REG_NUMBER",
            .HeaderText = "DTI REG #",
            .DataPropertyName = "DTI_REG_NUMBER",
            .Width = 150
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "VAT_STATUS",
            .HeaderText = "VAT STATUS",
            .DataPropertyName = "VAT_STATUS",
            .Width = 120
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "SALES_PERSON",
            .HeaderText = "SALES PERSON",
            .DataPropertyName = "SALES_PERSON",
            .Width = 160
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "MODE_OF_PAYMENT",
            .HeaderText = "PAYMENT MODE",
            .DataPropertyName = "MODE_OF_PAYMENT",
            .Width = 140
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "BANK",
            .HeaderText = "BANK",
            .DataPropertyName = "BANK",
            .Width = 160
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "BANK_ACCOUNT_NUMBER",
            .HeaderText = "ACCOUNT NO",
            .DataPropertyName = "BANK_ACCOUNT_NUMBER",
            .Width = 170
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "PAYMENT_TERMS",
            .HeaderText = "PAYMENT TERMS",
            .DataPropertyName = "PAYMENT_TERMS",
            .Width = 160
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "DATE_REGISTERED",
            .HeaderText = "DATE REGISTERED",
            .DataPropertyName = "DATE_REGISTERED",
            .Width = 140
        })

        dgvVendors.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "STATUS",
            .HeaderText = "STATUS",
            .DataPropertyName = "STATUS",
            .Width = 110
        })
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Koneksyon sa SQL Server
    ' ─────────────────────────────────────────────────────────
    Private Function GetConnection() As SqlConnection
        Return New SqlConnection("Data Source=JUDIEL\SQLEXPRESS;Initial Catalog=CodeNectDB;Integrated Security=True;")
    End Function

    ' ─────────────────────────────────────────────────────────
    ' Kunin ang lahat ng Vendor (WALANG LOGO)
    ' ─────────────────────────────────────────────────────────
    Private Sub LoadAllVendors()
        Try
            _dtVendors.Clear()
            Using con As SqlConnection = GetConnection()
                ' ✅ Eksaktong query — Lahat ng kolum MALIBAN sa LOGO
                Dim sql As String = "
                    SELECT 
                        ID,
                        VENDOR_CODE,
                        VENDOR,
                        BUSINESS_TYPE,
                        CONTACT,
                        EMAIL,
                        TIN,
                        DTI_REG_NUMBER,
                        VAT_STATUS,
                        SALES_PERSON,
                        MODE_OF_PAYMENT,
                        BANK,
                        BANK_ACCOUNT_NUMBER,
                        PAYMENT_TERMS,
                        DATE_REGISTERED,
                        STATUS
                    FROM vendor
                    ORDER BY VENDOR ASC"

                Using cmd As New SqlCommand(sql, con)
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(_dtVendors)
                    End Using
                End Using
            End Using
            dgvVendors.DataSource = _dtVendors
        Catch ex As Exception
            MessageBox.Show("Error loading vendor list: " & ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Search Function
    ' ─────────────────────────────────────────────────────────
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            If String.IsNullOrWhiteSpace(txtSearch.Text) Then
                _dtVendors.DefaultView.RowFilter = ""
            Else
                Dim hanap As String = txtSearch.Text.Replace("'", "''")
                _dtVendors.DefaultView.RowFilter = $"
                    VENDOR_CODE LIKE '%{hanap}%' OR 
                    VENDOR LIKE '%{hanap}%' OR 
                    CONTACT_NUMBER LIKE '%{hanap}%' OR
                    TIN LIKE '%{hanap}%'"
            End If
        Catch
        End Try
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Button: Add
    ' ─────────────────────────────────────────────────────────
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Dito mo ilalagay ang pagbubukas ng iyong Add Vendor form kapag meron ka na
        MessageBox.Show("Open Add Vendor Form here", "Add Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Button: Refresh
    ' ─────────────────────────────────────────────────────────
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        LoadAllVendors()
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Button: Save to Excel
    ' ─────────────────────────────────────────────────────────
    Private Sub btnSaveToExcel_Click(sender As Object, e As EventArgs) Handles btnSaveToExcel.Click
        If _dtVendors.Rows.Count = 0 Then
            MessageBox.Show("No records found to save!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Try
            Dim saveDialog As New SaveFileDialog With {
                .Filter = "CSV File (*.csv)|*.csv",
                .Title = "Save Vendor List",
                .FileName = $"Vendor_List_{DateTime.Now:yyyyMMdd}"
            }
            If saveDialog.ShowDialog() = DialogResult.OK Then
                Using sw As New StreamWriter(saveDialog.FileName, False, System.Text.Encoding.UTF8)
                    ' Headers
                    sw.WriteLine("Vendor Code,Vendor Name,Business Type,Contact Number,Email,TIN,DTI Reg No,VAT Status,Sales Person,Payment Mode,Bank,Account No,Payment Terms,Date Registered,Status")
                    ' Rows
                    For Each dr As DataRow In _dtVendors.Rows
                        sw.WriteLine(String.Join(",",
                            """" & dr("VENDOR_CODE") & """",
                            """" & dr("VENDOR") & """",
                            """" & If(dr("BUSINESS_TYPE") Is DBNull.Value, "", dr("BUSINESS_TYPE")) & """",
                            """" & If(dr("CONTACT") Is DBNull.Value, "", dr("CONTACT")) & """",
                            """" & If(dr("EMAIL") Is DBNull.Value, "", dr("EMAIL")) & """",
                            """" & If(dr("TIN") Is DBNull.Value, "", dr("TIN")) & """",
                            """" & If(dr("DTI_REG_NUMBER") Is DBNull.Value, "", dr("DTI_REG_NUMBER")) & """",
                            """" & If(dr("VAT_STATUS") Is DBNull.Value, "", dr("VAT_STATUS")) & """",
                            """" & If(dr("SALES_PERSON") Is DBNull.Value, "", dr("SALES_PERSON")) & """",
                            """" & If(dr("MODE_OF_PAYMENT") Is DBNull.Value, "", dr("MODE_OF_PAYMENT")) & """",
                            """" & If(dr("BANK") Is DBNull.Value, "", dr("BANK")) & """",
                            """" & If(dr("BANK_ACCOUNT_NUMBER") Is DBNull.Value, "", dr("BANK_ACCOUNT_NUMBER")) & """",
                            """" & If(dr("PAYMENT_TERMS") Is DBNull.Value, "", dr("PAYMENT_TERMS")) & """",
                            """" & CDate(dr("DATE_REGISTERED")).ToString("yyyy-MM-dd") & """",
                            """" & dr("STATUS") & """"
                        ))
                    Next
                End Using
                MessageBox.Show("Vendor list saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving list: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- KAPAG DINOBLE CLICK ANG LINYA SA LISTAHAN ---
    Private Sub dgvVendors_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVendors.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedVendorCode As String = dgvVendors.Rows(e.RowIndex).Cells("VENDOR_CODE").Value.ToString()

            ' Buksan ang Vendor Info at ipasa ang Vendor Code
            Dim frmInfo As New Vendor_Info()
            frmInfo.SelectedVendorCode = selectedVendorCode
            frmInfo.ShowDialog()
        End If
    End Sub
End Class