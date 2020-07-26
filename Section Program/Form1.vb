Public Class Form1

    'Declare Variables
    Dim StudentName, Address, Gender, Qualif, Grade As String
    Dim StudentNumber As Integer
    Dim GPA As Double

    'Date and Time
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = String.Format("{0:d}", Now)
        Label3.Text = String.Format("{0:hh:mm:ss}", Now)
    End Sub

    'Procedure To Clear TextBoxes and ComboBoxes
    Sub clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
    End Sub

    'Procedure To View Data in listBox
    Sub view()

        FileOpen(1, "Students.txt", OpenMode.Input)

        ListBox1.Height = (ListBox1.ItemHeight + 3) * 14
        ListBox1.Items.Clear() 'لمسح البيانات الموجوده في الليست بوكس

        ListBox1.Items.Add("") 'علشان نسيب اول سطر ف الليست بوكس فاضي ويبدأ يكتب من السطر التاني
        ListBox1.Items.Add("|" + " Student Number")
        ListBox1.Items.Add("|" + "__________________________________________________________________________")
        ListBox1.Items.Add("|" + "Student Name ")
        ListBox1.Items.Add("|" + "__________________________________________________________________________")
        ListBox1.Items.Add("|" + "Address")
        ListBox1.Items.Add("|" + "__________________________________________________________________________")
        ListBox1.Items.Add("|" + "Gender ")
        ListBox1.Items.Add("|" + "__________________________________________________________________________")
        ListBox1.Items.Add("|" + "Qualification")
        ListBox1.Items.Add("|" + "__________________________________________________________________________")
        ListBox1.Items.Add("|" + " Degree ")
        ListBox1.Items.Add("|" + "__________________________________________________________________________")
        ListBox1.Items.Add("|" + " Grade ")

        Do While Not EOF(1)

            'بنجيب بيانات أول صف ف الفايل
            Input(1, StudentNumber)
            Input(1, StudentName)
            Input(1, Address)
            Input(1, Gender)
            Input(1, Qualif)
            Input(1, GPA)
            Input(1, Grade)

            'بنعرض البيانات في الليست بوكس
            ListBox1.Items.Add("")
            ListBox1.Items.Add("|" + Str(StudentNumber))
            ListBox1.Items.Add("|" + "__________________________________________________________________________")
            ListBox1.Items.Add("|" + StudentName)
            ListBox1.Items.Add("|" + "__________________________________________________________________________")
            ListBox1.Items.Add("|" + Address)
            ListBox1.Items.Add("|" + "__________________________________________________________________________")
            ListBox1.Items.Add("|" + Gender)
            ListBox1.Items.Add("|" + "__________________________________________________________________________")
            ListBox1.Items.Add("|" + Qualif)
            ListBox1.Items.Add("|" + "__________________________________________________________________________")
            ListBox1.Items.Add("|" + Str(GPA))
            ListBox1.Items.Add("|" + "__________________________________________________________________________")
            ListBox1.Items.Add("|" + Grade)

            'علشان لما اكتب رقم الصنف واضغط علي عرض الصنف يعرضلي كل البيانات بتاعته ف كل التيكست بوكسيز
            If StudentNumber = Val(TextBox1.Text) Then

                TextBox2.Text = StudentName
                TextBox3.Text = Address
                ComboBox1.Text = Gender
                TextBox4.Text = Qualif
                TextBox5.Text = GPA
                ComboBox2.Text = Grade

            End If

        Loop

        FileClose(1)

    End Sub

    'Exit Button 
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        End
    End Sub

    'Add Student Button 
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        FileOpen(1, "Students.txt", OpenMode.Append)

        StudentNumber = Val(TextBox1.Text)
        StudentName = TextBox2.Text
        Address = TextBox3.Text
        Gender = ComboBox1.Text
        Qualif = TextBox4.Text
        GPA = Val(TextBox5.Text)
        Grade = ComboBox2.Text

        WriteLine(1, StudentNumber, StudentName, Address, Gender, Qualif, GPA, Grade)

        FileClose(1)

        MsgBox("    Records Saves    ")
        clear()

    End Sub

    'Edit Student Button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        FileOpen(1, "Students.txt", OpenMode.Input)
        FileOpen(2, "Edited.txt", OpenMode.Append)

        Do While Not EOF(1)

            Input(1, StudentNumber)
            Input(1, StudentName)
            Input(1, Address)
            Input(1, Gender)
            Input(1, Qualif)
            Input(1, GPA)
            Input(1, Grade)

            'IF this are The Record You want To Edit
            If StudentNumber = Val(TextBox1.Text) Then

                StudentName = TextBox2.Text
                Address = TextBox3.Text
                Gender = ComboBox1.Text
                Qualif = TextBox4.Text
                GPA = Val(TextBox5.Text)
                Grade = ComboBox2.Text

                WriteLine(2, StudentNumber, StudentName, Address, Gender, Qualif, GPA, Grade)

            End If

            'IF this are Not The Record You want To Edit
            If StudentNumber <> Val(TextBox1.Text) Then

                WriteLine(2, StudentNumber, StudentName, Address, Gender, Qualif, GPA, Grade)

            End If

        Loop

        FileClose(2)
        FileClose(1)

        Kill("Students.txt")
        Rename("Edited.txt", "students.txt")

        MsgBox("     Edited Saved     ", MsgBoxStyle.Information, "Done")
        clear()

    End Sub

    'Delete Student Button
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        FileOpen(1, "Students.txt", OpenMode.Input)
        FileOpen(2, "Edited.txt", OpenMode.Append)

        Do While Not EOF(1)

            Input(1, StudentNumber)
            Input(1, StudentName)
            Input(1, Address)
            Input(1, Gender)
            Input(1, Qualif)
            Input(1, GPA)
            Input(1, Grade)

            'IF this are Not The Record You want To Delete
            If StudentNumber <> Val(TextBox1.Text) Then

                WriteLine(2, StudentNumber, StudentName, Address, Gender, Qualif, GPA, Grade)

            End If

        Loop

        FileClose(2)
        FileClose(1)

        Kill("Students.txt")
        Rename("Edited.txt", "Students.txt")

        MsgBox("     Record Deleted     ", MsgBoxStyle.Information, "Done")
        clear()

    End Sub

    'View Button
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        View()
    End Sub

    ' استحدمنا حدث آخر لزرار اضافه طالب  علشان بمجرد م اضغط عليه واضيف طالب جديدالتعديل يظهر ف الليست بوكس  من غير ما نضغط علي زرار العرض
    Private Sub Button1_MouseUp(sender As Object, e As MouseEventArgs) Handles Button1.MouseUp
        view()
    End Sub

    ' استحدمنا حدث آخر لزرار تعديل طالب علشان بمجرد م اضغط عليه واعدل علي طالب التعديل يظهر ف الليست بوكس  من غير ما نضغط علي زرار العرض
    Private Sub Button2_MouseUp(sender As Object, e As MouseEventArgs) Handles Button2.MouseUp
        view()
    End Sub

    ' استحدمنا حدث آخر لزرار حذف طالب علشان بمجرد م اضغط عليه واحذف طالب التعديل يظهر ف الليست بوكس  من غير ما نضغط علي زرار العرض
    Private Sub Button4_MouseUp(sender As Object, e As MouseEventArgs) Handles Button4.MouseUp
        view()
    End Sub

End Class
