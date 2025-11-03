Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Microsoft.Data.SqlClient

Public Class Form2
    Public Property n_1 As Integer
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None

        TabControl1.TabPages.Remove(stock_tab)

        TabControl1.TabPages.Remove(sales_tab)

        TabControl1.TabPages.Remove(add_a_new_medicine_tab)

        TabControl1.TabPages.Remove(adjust_medicine_data_tab)

        TabControl1.TabPages.Remove(enrollment_tab)

        TabControl1.TabPages.Remove(edit_tab)

        TabControl1.TabPages.Remove(records_tab)

        Select Case (n_1)
            Case 1
                If Not TabControl1.TabPages.Contains(stock_tab) Then
                    TabControl1.TabPages.Insert(0, stock_tab)
                End If
                If Not TabControl1.TabPages.Contains(sales_tab) Then
                    TabControl1.TabPages.Insert(1, sales_tab)
                End If
                If Not TabControl1.TabPages.Contains(add_a_new_medicine_tab) Then
                    TabControl1.TabPages.Insert(2, add_a_new_medicine_tab)
                End If
                If Not TabControl1.TabPages.Contains(adjust_medicine_data_tab) Then
                    TabControl1.TabPages.Insert(3, adjust_medicine_data_tab)
                End If
                If Not TabControl1.TabPages.Contains(enrollment_tab) Then
                    TabControl1.TabPages.Insert(4, enrollment_tab)
                End If
                If Not TabControl1.TabPages.Contains(edit_tab) Then
                    TabControl1.TabPages.Insert(5, edit_tab)
                End If
                If Not TabControl1.TabPages.Contains(records_tab) Then
                    TabControl1.TabPages.Insert(6, records_tab)
                End If

                Label15.Visible = True
                TextBox13.Visible = True
                btn_alarm.Visible = True
                CheckStockAgainstAlarm()
                Me.Refresh()


            Case 2

                If Not TabControl1.TabPages.Contains(stock_tab) Then
                    TabControl1.TabPages.Insert(0, stock_tab)
                End If
                If Not TabControl1.TabPages.Contains(add_a_new_medicine_tab) Then
                    TabControl1.TabPages.Insert(1, add_a_new_medicine_tab)
                End If

                If Not TabControl1.TabPages.Contains(adjust_medicine_data_tab) Then
                    TabControl1.TabPages.Insert(2, adjust_medicine_data_tab)
                End If
                CheckStockAgainstAlarm()
                Me.Refresh()

            Case 3

                If Not TabControl1.TabPages.Contains(stock_tab) Then
                    TabControl1.TabPages.Insert(0, stock_tab)
                End If
                If Not TabControl1.TabPages.Contains(sales_tab) Then
                    TabControl1.TabPages.Insert(1, sales_tab)
                End If


        End Select

        fillmedicineComboBox()
        fillemployeeComboBox()

    End Sub

    Dim x As New Dictionary(Of String, Integer)

    Private q As New Dictionary(Of String, Integer) ' Declare this at the class level

    Private Sub fillmedicineComboBox()
        Try
            con.Open()
            Dim cmd As New SqlCommand("SELECT id_medicine, medicine_name FROM medicine_table", con)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            medObox.Items.Clear()
            q.Clear()

            While reader.Read()
                Dim id As Integer = reader("id_medicine")
                Dim name As String = reader("medicine_name").ToString().Trim() ' Trim for NCHAR
                Dim display As String = $"{id} {name}"

                medObox.Items.Add(display)
                q(display) = id
            End While

            reader.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading medicine list: " & ex.Message)
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub saleObox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles medObox.SelectedIndexChanged
        If medObox.SelectedItem IsNot Nothing Then
            Dim selectedDisplay As String = medObox.SelectedItem.ToString()
            If q.ContainsKey(selectedDisplay) Then
                Dim selectedId As Integer = q(selectedDisplay)
            End If
        End If
    End Sub

    Private Sub fillemployeeComboBox()
        Try
            con.Open()
            Dim cmd As New SqlCommand("SELECT id, name FROM employee_records", con)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            ComboBox1.Items.Clear()
            x.Clear()

            While reader.Read()
                Dim id As Integer = reader("id")
                Dim name As String = reader("name").ToString()
                Dim display As String = $"{id} {name}"

                ComboBox1.Items.Add(display)
                x(display) = id
            End While

            reader.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedDisplay As String = ComboBox1.SelectedItem.ToString()
            If x.ContainsKey(selectedDisplay) Then
                Dim selectedID As Integer = x(selectedDisplay)

            End If
        End If
    End Sub







    Private Sub exit_button_Click(sender As Object, e As EventArgs) Handles btn_exit_form2.Click
        If con.State = ConnectionState.Open Then con.Close()
        Application.Exit()
    End Sub

    Private Sub logout_button_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to log out?",
        "Confirm Logout",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    )

        If result = DialogResult.Yes Then

            If con.State = ConnectionState.Open Then con.Close()


            Form1.username_input.Text = ""
            Form1.password_input.Text = ""


            Form1.Show()
            Me.Close()
        Else

        End If

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub btn_sale_rest_Click(sender As Object, e As EventArgs) Handles btn_sale_rest.Click
        medObox.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
    End Sub

    Private Sub btn_rest_resupply_Click(sender As Object, e As EventArgs) Handles btn_rest_resupply.Click
        buyname.Text = ""
        bulkprice.Text = ""
        unitprice.Text = ""
        numOpurchase.Text = ""
    End Sub

    Private Sub btn_rest_enrollment_Click(sender As Object, e As EventArgs) Handles btn_rest_enrollment.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        newaccT.Text = ""
        TextBox4.Text = ""
        TextBox3.Text = ""
        newpassT.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub btn_rest_data_Click(sender As Object, e As EventArgs) Handles btn_rest_data.Click
        ComboBox1.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btn_add_to_stock.Click

        If buyname.Text = "" Or bulkprice.Text = "" Or unitprice.Text = "" Or numOpurchase.Text = "" Then
            MessageBox.Show("Please fill in all fields", "alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If



        Dim cmd As New SqlCommand("
        INSERT INTO medicine_table 
        ( medicine_name, medicine_bulk_price, medicine_unit_price, number_of_units_in_stock) 
        VALUES 
        ( @medicine_name, @medicine_bulk_price, @medicine_unit_price, @number_of_units_in_stock)
    ", con)

        'update delete insert nonquery

        cmd.Parameters.AddWithValue("@medicine_name", buyname.Text)
        cmd.Parameters.AddWithValue("@medicine_bulk_price", Convert.ToDecimal(bulkprice.Text))
        cmd.Parameters.AddWithValue("@medicine_unit_price", Convert.ToDecimal(unitprice.Text))
        cmd.Parameters.AddWithValue("@number_of_units_in_stock", Convert.ToInt32(numOpurchase.Text))

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Added successfully", "completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("An error occurred while adding: " & ex.Message, "mistake", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btn_add_employee_Click(sender As Object, e As EventArgs) Handles btn_add_employee.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or newaccT.Text = "" Or TextBox4.Text =
            "" Or TextBox3.Text = "" Or newpassT.Text = "" Or TextBox5.Text = "" Then
            MessageBox.Show("Please fill in all fields", "alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If



        Dim cmd As New SqlCommand("
        INSERT INTO employee_records 
        (name, role, shift_hours , monthly_salary , account_name , account_passcode , account_lvl) 
        VALUES 
        (@name, @role, @shift_hours, @monthly_salary, @account_name, @account_passcode, @account_lvl)
        
    ", con)


        cmd.Parameters.AddWithValue("@name", TextBox1.Text)
        cmd.Parameters.AddWithValue("@role", TextBox2.Text)
        cmd.Parameters.AddWithValue("@shift_hours", newaccT.Text)
        cmd.Parameters.AddWithValue("@monthly_salary", Convert.ToInt32(TextBox4.Text))
        cmd.Parameters.AddWithValue("@account_name", TextBox3.Text)
        cmd.Parameters.AddWithValue("@account_passcode", newpassT.Text)
        cmd.Parameters.AddWithValue("@account_lvl", Convert.ToInt32(TextBox5.Text))
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Added successfully", "completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("An error occurred while adding: " & ex.Message, "mistake", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btn_delete_records_Click(sender As Object, e As EventArgs) Handles btn_delete_records.Click
        If ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please select an employee to delete.")
            Exit Sub
        End If

        Dim selectedDisplay As String = ComboBox1.SelectedItem.ToString()

        If Not x.ContainsKey(selectedDisplay) Then
            MessageBox.Show("Selected employee not found in dictionary.")
            Exit Sub
        End If

        Dim empId As Integer = x(selectedDisplay)

        ' Extract name portion (optional, only for display)
        Dim empName As String = selectedDisplay
        If selectedDisplay.Contains("(") Then
            empName = selectedDisplay.Substring(0, selectedDisplay.IndexOf("(")).Trim()
        End If

        Dim result As DialogResult = MessageBox.Show(
            $"Are you sure you want to delete employee {empName} (ID: {empId}) from employee_records?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

        If result = DialogResult.No Then Exit Sub

        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim cmd As New SqlCommand("DELETE FROM employee_records WHERE id = @id", con)
            cmd.Parameters.AddWithValue("@id", empId)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Employee record deleted successfully.")
                ComboBox1.Items.Remove(selectedDisplay)
                x.Remove(selectedDisplay)
            Else
                MessageBox.Show("No matching record found.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error during deletion: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub btn_adjust_data_Click(sender As Object, e As EventArgs) Handles btn_adjust_data.Click
        If ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please select an employee from the list.")
            Return
        End If

        Dim selectedDisplay As String = ComboBox1.SelectedItem.ToString()
        If Not x.ContainsKey(selectedDisplay) Then
            MessageBox.Show("Invalid selection.")
            Return
        End If

        Dim employeeID As Integer = x(selectedDisplay)
        Dim updates As New List(Of String)
        Dim parameters As New List(Of SqlParameter)

        If TextBox6.Text.Trim() <> "" Then
            updates.Add("name = @name")
            parameters.Add(New SqlParameter("@name", TextBox6.Text.Trim()))
        End If

        If TextBox7.Text.Trim() <> "" Then
            updates.Add("role = @role")
            parameters.Add(New SqlParameter("@role", TextBox7.Text.Trim()))
        End If

        If TextBox8.Text.Trim() <> "" Then
            updates.Add("shift_hours = @shift_hours")
            parameters.Add(New SqlParameter("@shift_hours", TextBox8.Text.Trim()))
        End If

        If TextBox9.Text.Trim() <> "" Then
            Dim monthlySalary As Integer
            If Integer.TryParse(TextBox9.Text.Trim(), monthlySalary) Then
                updates.Add("monthly_salary = @monthly_salary")
                parameters.Add(New SqlParameter("@monthly_salary", monthlySalary))
            Else
                MessageBox.Show("Monthly Salary must be an integer.")
                Return
            End If
        End If

        If TextBox10.Text.Trim() <> "" Then
            updates.Add("account_name = @account_name")
            parameters.Add(New SqlParameter("@account_name", TextBox10.Text.Trim()))
        End If

        If TextBox11.Text.Trim() <> "" Then
            updates.Add("account_passcode = @account_passcode")
            parameters.Add(New SqlParameter("@account_passcode", TextBox11.Text.Trim()))
        End If

        If TextBox12.Text.Trim() <> "" Then
            Dim accountLevel As Integer
            If Integer.TryParse(TextBox12.Text.Trim(), accountLevel) Then
                updates.Add("account_lvl = @account_lvl")
                parameters.Add(New SqlParameter("@account_lvl", accountLevel))
            Else
                MessageBox.Show("Account Level must be an integer.")
                Return
            End If
        End If

        If updates.Count = 0 Then
            MessageBox.Show("No changes to update.")
            Return
        End If

        Dim updateQuery As String = $"UPDATE employee_records SET {String.Join(", ", updates)} WHERE id = @employee_id"
        parameters.Add(New SqlParameter("@employee_id", employeeID))

        Try
            con.Open()
            Using cmd As New SqlCommand(updateQuery, con)
                cmd.Parameters.AddRange(parameters.ToArray())
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Record updated successfully.")
                Else
                    MessageBox.Show("Update failed.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub btn_stock_refresh_Click(sender As Object, e As EventArgs) Handles btn_stock_refresh.Click
        con.Open()
        Try
            Dim ad As New SqlDataAdapter("select * from medicine_table ", con)
            Dim ds As New DataSet
            ad.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0)


            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGridView2.AllowUserToResizeRows = False
            DataGridView2.AllowUserToResizeColumns = True


            DataGridView2.RowHeadersVisible = False
            DataGridView2.ReadOnly = True
            DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView2.MultiSelect = False
            DataGridView2.BackgroundColor = SystemColors.Window


            DataGridView2.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message & " - an error occurred")
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btn_medObox_refresh_Click(sender As Object, e As EventArgs) Handles btn_medObox_refresh.Click
        fillmedicineComboBox()
    End Sub

    Private Sub btn_employee_data_adjustment_refresh_Click(sender As Object, e As EventArgs) Handles btn_employee_data_adjustment_refresh.Click
        fillemployeeComboBox()
    End Sub

    Private Sub btn_records_refresh_Click(sender As Object, e As EventArgs) Handles btn_records_refresh.Click
        con.Open()
        Try
            Dim ad As New SqlDataAdapter("SELECT * FROM employee_records", con)
            Dim ds As New DataSet
            ad.Fill(ds)


            DataGridView1.DataSource = ds.Tables(0)

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            DataGridView1.AllowUserToResizeRows = False

            DataGridView1.AllowUserToResizeColumns = True

            DataGridView1.RowHeadersVisible = False

            DataGridView1.ReadOnly = True

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            DataGridView1.MultiSelect = False

            DataGridView1.BackgroundColor = SystemColors.Window

            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

            DataGridView1.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message & " - An error occurred", MsgBoxStyle.Critical, "Error")
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox20.Text = ""
        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""
        TextBox24.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox25.Text = ""
        TextBox26.Text = ""
        TextBox27.Text = ""
        TextBox28.Text = ""
        TextBox29.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox30.Text = ""
        TextBox31.Text = ""
        TextBox32.Text = ""
        TextBox33.Text = ""
        TextBox34.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox35.Text = ""
        TextBox36.Text = ""
        TextBox37.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox40.Text = ""
        TextBox41.Text = ""
        TextBox42.Text = ""
        TextBox43.Text = ""
        TextBox44.Text = ""
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox20.Text = ""
        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""
        TextBox24.Text = ""
        TextBox25.Text = ""
        TextBox26.Text = ""
        TextBox27.Text = ""
        TextBox28.Text = ""
        TextBox29.Text = ""
        TextBox30.Text = ""
        TextBox31.Text = ""
        TextBox32.Text = ""
        TextBox33.Text = ""
        TextBox34.Text = ""
        TextBox35.Text = ""
        TextBox36.Text = ""
        TextBox37.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
        TextBox40.Text = ""
        TextBox41.Text = ""
        TextBox42.Text = ""
        TextBox43.Text = ""
        TextBox44.Text = ""
    End Sub

    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged
        If Not String.IsNullOrWhiteSpace(TextBox20.Text) Then
            Dim medicineId As Integer
            If Integer.TryParse(TextBox20.Text, medicineId) Then
                FetchMedicineDetails(medicineId)
            Else
                TextBox21.Clear()
                TextBox22.Clear()
                TextBox23.Clear()
            End If
        Else
            TextBox21.Clear()
            TextBox22.Clear()
            TextBox23.Clear()
        End If
    End Sub

    Private Sub FetchMedicineDetails(medicineId As Integer)
        Try
            con.Open()
            Dim query As String = "SELECT medicine_name, medicine_unit_price, number_of_units_in_stock FROM medicine_table WHERE Id_medicine = @medicineId"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@medicineId", medicineId)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                TextBox21.Text = reader("medicine_name").ToString().Trim()
                TextBox22.Text = reader("medicine_unit_price").ToString()
                TextBox23.Text = reader("number_of_units_in_stock").ToString()
            Else
                TextBox21.Clear()
                TextBox22.Clear()
                TextBox23.Clear()
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub TextBox25_TextChanged(sender As Object, e As EventArgs) Handles TextBox25.TextChanged
        If Not String.IsNullOrWhiteSpace(TextBox25.Text) Then
            Dim medicineId As Integer
            If Integer.TryParse(TextBox25.Text, medicineId) Then
                FetchMedicineDetails2(medicineId)
            Else
                TextBox26.Clear()
                TextBox27.Clear()
                TextBox28.Clear()
            End If
        Else
            TextBox26.Clear()
            TextBox27.Clear()
            TextBox28.Clear()
        End If
    End Sub

    Private Sub FetchMedicineDetails2(medicineId As Integer)
        Try
            con.Open()
            Dim query As String = "SELECT medicine_name, medicine_unit_price, number_of_units_in_stock FROM medicine_table WHERE Id_medicine = @medicineId"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@medicineId", medicineId)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                TextBox26.Text = reader("medicine_name").ToString().Trim()
                TextBox27.Text = reader("medicine_unit_price").ToString()
                TextBox28.Text = reader("number_of_units_in_stock").ToString()
            Else
                TextBox26.Clear()
                TextBox27.Clear()
                TextBox28.Clear()
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub TextBox30_TextChanged(sender As Object, e As EventArgs) Handles TextBox30.TextChanged
        If Not String.IsNullOrWhiteSpace(TextBox30.Text) Then
            Dim medicineId As Integer
            If Integer.TryParse(TextBox30.Text, medicineId) Then
                FetchMedicineDetails3(medicineId)
            Else
                TextBox31.Clear()
                TextBox32.Clear()
                TextBox33.Clear()
            End If
        Else
            TextBox30.Clear()
            TextBox32.Clear()
            TextBox33.Clear()
        End If
    End Sub

    Private Sub FetchMedicineDetails3(medicineId As Integer)
        Try
            con.Open()
            Dim query As String = "SELECT medicine_name, medicine_unit_price, number_of_units_in_stock FROM medicine_table WHERE Id_medicine = @medicineId"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@medicineId", medicineId)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                TextBox31.Text = reader("medicine_name").ToString().Trim()
                TextBox32.Text = reader("medicine_unit_price").ToString()
                TextBox33.Text = reader("number_of_units_in_stock").ToString()
            Else
                TextBox31.Clear()
                TextBox32.Clear()
                TextBox33.Clear()
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub TextBox35_TextChanged(sender As Object, e As EventArgs) Handles TextBox35.TextChanged
        If Not String.IsNullOrWhiteSpace(TextBox35.Text) Then
            Dim medicineId As Integer
            If Integer.TryParse(TextBox35.Text, medicineId) Then
                FetchMedicineDetails4(medicineId)
            Else
                TextBox36.Clear()
                TextBox37.Clear()
                TextBox38.Clear()
            End If
        Else
            TextBox36.Clear()
            TextBox37.Clear()
            TextBox38.Clear()
        End If
    End Sub

    Private Sub FetchMedicineDetails4(medicineId As Integer)
        Try
            con.Open()
            Dim query As String = "SELECT medicine_name, medicine_unit_price, number_of_units_in_stock FROM medicine_table WHERE Id_medicine = @medicineId"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@medicineId", medicineId)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                TextBox36.Text = reader("medicine_name").ToString().Trim()
                TextBox37.Text = reader("medicine_unit_price").ToString()
                TextBox38.Text = reader("number_of_units_in_stock").ToString()
            Else
                TextBox36.Clear()
                TextBox37.Clear()
                TextBox38.Clear()
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub TextBox40_TextChanged(sender As Object, e As EventArgs) Handles TextBox40.TextChanged
        If Not String.IsNullOrWhiteSpace(TextBox40.Text) Then
            Dim medicineId As Integer
            If Integer.TryParse(TextBox40.Text, medicineId) Then
                FetchMedicineDetails5(medicineId)
            Else
                TextBox41.Clear()
                TextBox42.Clear()
                TextBox43.Clear()
            End If
        Else
            TextBox41.Clear()
            TextBox42.Clear()
            TextBox43.Clear()
        End If
    End Sub

    Private Sub FetchMedicineDetails5(medicineId As Integer)
        Try
            con.Open()
            Dim query As String = "SELECT medicine_name, medicine_unit_price, number_of_units_in_stock FROM medicine_table WHERE Id_medicine = @medicineId"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@medicineId", medicineId)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                TextBox41.Text = reader("medicine_name").ToString().Trim()
                TextBox42.Text = reader("medicine_unit_price").ToString()
                TextBox43.Text = reader("number_of_units_in_stock").ToString()
            Else
                TextBox41.Clear()
                TextBox42.Clear()
                TextBox43.Clear()
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim total As Decimal = 0
        Dim medicineDetails As New List(Of String)

        ' Group related TextBoxes
        Dim textBoxIds As TextBox() = {TextBox20, TextBox25, TextBox30, TextBox35, TextBox40}
        Dim textBoxUnitPrices As TextBox() = {TextBox22, TextBox27, TextBox32, TextBox37, TextBox42}
        Dim textBoxQuantities As TextBox() = {TextBox24, TextBox29, TextBox34, TextBox39, TextBox44}

        ' Loop through the arrays
        For i As Integer = 0 To textBoxIds.Length - 1
            Dim idText As String = textBoxIds(i).Text.Trim()
            Dim unitPriceText As String = textBoxUnitPrices(i).Text.Trim()
            Dim quantityText As String = textBoxQuantities(i).Text.Trim()

            If String.IsNullOrWhiteSpace(idText) Then Continue For

            Dim medicineId As Integer
            If Not Integer.TryParse(idText, medicineId) Then
                MessageBox.Show($"Invalid medicine ID in row {i + 1}.")
                Continue For
            End If

            Dim medicineName As String = GetMedicineName(medicineId)
            If String.IsNullOrWhiteSpace(medicineName) Then
                MessageBox.Show($"Medicine ID {medicineId} not found in database.")
                Continue For
            End If

            Dim unitPrice As Decimal
            If Not Decimal.TryParse(unitPriceText, unitPrice) Then
                MessageBox.Show($"Invalid unit price for medicine ID {medicineId}.")
                Continue For
            End If

            Dim quantity As Integer
            If Not Integer.TryParse(quantityText, quantity) Then
                MessageBox.Show($"Invalid quantity for medicine ID {medicineId}.")
                Continue For
            End If

            ' Deduct from stock
            If Not DeductFromStock(medicineId, quantity) Then
                MessageBox.Show($"Insufficient stock for medicine ID {medicineId}.")
                Continue For
            End If

            Dim medicineTotal As Decimal = unitPrice * quantity
            total += medicineTotal

            medicineDetails.Add($"{medicineId} - {medicineName}: {quantity} x JOD {unitPrice:F2} = JOD {medicineTotal:F2}")
        Next

        ' Show result
        If medicineDetails.Count > 0 Then
            Dim message As String = "Details of Medicines:" & vbCrLf & String.Join(vbCrLf, medicineDetails)
            message &= vbCrLf & vbCrLf & "Grand Total: JOD " & total.ToString("F2")
            MessageBox.Show(message)
        Else
            MessageBox.Show("No valid medicine entries found.")
        End If
    End Sub

    Private Function GetMedicineName(medicineId As Integer) As String
        Try
            con.Open()
            Dim cmd As New SqlCommand("SELECT medicine_name FROM medicine_table WHERE Id_medicine = @medicineId", con)
            cmd.Parameters.AddWithValue("@medicineId", medicineId)

            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Return reader("medicine_name").ToString().Trim()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error fetching medicine name: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        Return String.Empty
    End Function

    Private Function DeductFromStock(medicineId As Integer, quantityToDeduct As Integer) As Boolean
        Try
            con.Open()

            ' Check current stock
            Dim checkCmd As New SqlCommand("SELECT number_of_units_in_stock FROM medicine_table WHERE Id_medicine = @id", con)
            checkCmd.Parameters.AddWithValue("@id", medicineId)

            Dim currentStock As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
            If currentStock < quantityToDeduct Then
                Return False ' Not enough stock
            End If

            ' Deduct stock
            Dim updateCmd As New SqlCommand("UPDATE medicine_table SET number_of_units_in_stock = number_of_units_in_stock - @qty WHERE Id_medicine = @id", con)
            updateCmd.Parameters.AddWithValue("@qty", quantityToDeduct)
            updateCmd.Parameters.AddWithValue("@id", medicineId)

            updateCmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            MessageBox.Show("Error updating stock: " & ex.Message)
            Return False
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Function

    Private Function GetSelectedDisplay() As String
        Return medObox.SelectedItem
    End Function

    Private Sub btn_alarm_Click_1(sender As Object, e As EventArgs) Handles btn_alarm.Click
        If medObox.SelectedItem Is Nothing OrElse medObox.SelectedItem.ToString().Trim() = "" Then
            MessageBox.Show("Please select a medicine.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(TextBox13.Text) OrElse Not IsNumeric(TextBox13.Text) Then
            MessageBox.Show("Please enter a valid number.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get selected medicine ID from dictionary (assumes 'q' maps display string to ID)
        Dim selectedDisplay As String = medObox.SelectedItem.ToString()
        If Not q.ContainsKey(selectedDisplay) Then
            MessageBox.Show("Invalid selection.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim medicineID As Integer = q(selectedDisplay)
        Dim alarmValue As Integer = Convert.ToInt32(TextBox13.Text)

        Dim query As String = "
        UPDATE medicine_table
        SET quantity_for_Alarm = @quantity_for_Alarm
        WHERE Id_medicine = @Id_medicine"

        Using cmd As New SqlCommand(query, con)
            cmd.Parameters.Add(New SqlParameter("@quantity_for_Alarm", alarmValue))
            cmd.Parameters.Add(New SqlParameter("@Id_medicine", medicineID))

            Try
                con.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Alarm value updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Medicine not found. No update was made.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub


    Private Sub CheckStockAgainstAlarm()
        Dim query As String = "SELECT Id_medicine, medicine_name, number_of_units_in_stock, quantity_for_Alarm FROM medicine_table"
        Dim message As String = ""

        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Using cmd As New SqlCommand(query, con)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id As Integer = reader("Id_medicine")
                        Dim name As String = reader("medicine_name").ToString().Trim()
                        Dim stock As Integer = reader("number_of_units_in_stock")
                        Dim alarmQty As Object = reader("quantity_for_Alarm")

                        If Not IsDBNull(alarmQty) AndAlso stock <= Convert.ToInt32(alarmQty) Then
                            message &= $"{id} - {name} - needs to be resupplied" & Environment.NewLine
                        End If
                    End While
                End Using
            End Using

            If message <> "" Then
                MessageBox.Show(message, "Resupply Alert")
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub btn_adjust_medicne_Click(sender As Object, e As EventArgs) Handles btn_adjust_medicne.Click
        If medObox.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a medicine from the list.")
            Return
        End If

        Dim selectedDisplay As String = medObox.SelectedItem.ToString()
        If Not q.ContainsKey(selectedDisplay) Then
            MessageBox.Show("Invalid selection.")
            Return
        End If

        Dim medicineID As Integer = q(selectedDisplay)
        Dim updates As New List(Of String)
        Dim parameters As New List(Of SqlParameter)

        ' Update medicine name
        If TextBox14.Text.Trim() <> "" Then
            updates.Add("medicine_name = @medicine_name")
            parameters.Add(New SqlParameter("@medicine_name", TextBox14.Text.Trim()))
        End If

        ' Update bulk price
        If TextBox15.Text.Trim() <> "" Then
            Dim bulkprice As Decimal
            If Decimal.TryParse(TextBox15.Text.Trim(), bulkprice) Then
                updates.Add("medicine_bulk_price = @medicine_bulk_price")
                parameters.Add(New SqlParameter("@medicine_bulk_price", bulkprice))
            Else
                MessageBox.Show("Medicine bulk price must be a Decimal.")
                Return
            End If
        End If

        ' Update unit price
        If TextBox16.Text.Trim() <> "" Then
            Dim unitprice As Decimal
            If Decimal.TryParse(TextBox16.Text.Trim(), unitprice) Then
                updates.Add("medicine_unit_price = @medicine_unit_price")
                parameters.Add(New SqlParameter("@medicine_unit_price", unitprice))
            Else
                MessageBox.Show("Medicine unit price must be a Decimal.")
                Return
            End If
        End If

        ' Update number of units in stock
        If TextBox17.Text.Trim() <> "" Then
            Dim quantity As Integer
            If Integer.TryParse(TextBox17.Text.Trim(), quantity) Then
                updates.Add("number_of_units_in_stock = @number_of_units_in_stock")
                parameters.Add(New SqlParameter("@number_of_units_in_stock", quantity))
            Else
                MessageBox.Show("Quantity must be an Integer.")
                Return
            End If
        End If

        If updates.Count = 0 Then
            MessageBox.Show("No changes to update.")
            Return
        End If

        Dim updateQuery As String = $"UPDATE medicine_table SET {String.Join(", ", updates)} WHERE Id_medicine = @Id_medicine"
        parameters.Add(New SqlParameter("@Id_medicine", medicineID))

        Try
            con.Open()
            Using cmd As New SqlCommand(updateQuery, con)
                cmd.Parameters.AddRange(parameters.ToArray())
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Record updated successfully.")
                Else
                    MessageBox.Show("Update failed.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub btn_delete_medicine_Click(sender As Object, e As EventArgs) Handles btn_delete_medicine.Click
        If medObox.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a medicine to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedDisplay As String = medObox.SelectedItem.ToString()

        ' Check if selected item exists in the dictionary
        If Not q.ContainsKey(selectedDisplay) Then
            MessageBox.Show("Invalid selection.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim medicineID As Integer = q(selectedDisplay)

        ' Confirm deletion
        Dim confirmResult As DialogResult = MessageBox.Show("Are you sure you want to delete this medicine?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmResult <> DialogResult.Yes Then
            Return
        End If

        ' Delete command

        Using cmd As New SqlCommand("DELETE FROM medicine_table WHERE Id_medicine = @Id_medicine", con)
            cmd.Parameters.Add(New SqlParameter("@Id_medicine", medicineID))

            Try
                con.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Medicine deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Optionally remove from ComboBox and dictionary
                    q.Remove(selectedDisplay)
                    medObox.Items.Remove(selectedDisplay)

                Else
                    MessageBox.Show("Medicine not found. No deletion was made.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub

End Class