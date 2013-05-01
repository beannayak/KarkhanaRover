Public Class Form2
    Dim secCombo(4) As ComboBox
    Dim directionCombo(4) As ComboBox

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '*********** Setting global varialbes ****************************
        secCombo(0) = ComboBox3
        secCombo(1) = ComboBox4
        secCombo(2) = ComboBox6
        secCombo(3) = ComboBox8
        secCombo(4) = ComboBox10

        directionCombo(0) = ComboBox12
        directionCombo(1) = ComboBox13
        directionCombo(2) = ComboBox14
        directionCombo(3) = ComboBox15
        '*****************************************************************

        '************ Set values to combo boxes **************************
        For x As Integer = 0 To 3
            directionCombo(x).Items.Clear()
            directionCombo(x).Items.Add("Don't Use")
            If (Sn.Text = "-1") Then directionCombo(x).Text = "Don't Use"
            For y As Integer = 0 To 254
                directionCombo(x).Items.Add(y)
            Next
        Next

        For x As Integer = 0 To 4
            secCombo(x).Items.Clear()
            For y As Integer = 0 To 255
                secCombo(x).Items.Add(y)
            Next
        Next
        '*****************************************************************
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '@ Creates the bytes array to be send to robot and
        '@ sends it to queue where it will be evaluated by
        '@ timer1.
        Dim textCombo(15) As ComboBox
        Dim byteString(17) As Byte
        Dim checkedBox(4) As CheckBox

        '********************** initilizing variables **************
        checkedBox(0) = CheckBox1
        checkedBox(1) = CheckBox2
        checkedBox(2) = CheckBox3
        checkedBox(3) = CheckBox4
        checkedBox(4) = CheckBox5

        textCombo(0) = ComboBox12
        textCombo(1) = ComboBox13
        textCombo(2) = ComboBox14
        textCombo(3) = ComboBox15
        textCombo(4) = ComboBox1
        textCombo(5) = ComboBox2
        textCombo(6) = ComboBox3
        textCombo(7) = ComboBox5
        textCombo(8) = ComboBox4
        textCombo(9) = ComboBox7
        textCombo(10) = ComboBox6
        textCombo(11) = ComboBox9
        textCombo(12) = ComboBox8
        textCombo(13) = ComboBox11
        textCombo(14) = ComboBox10
        '******************************************************************

        '************** Adding Item in form1.ListView *********************
        Dim anItem As ListViewItem
        If (Sn.Text = "-1") Then
            anItem = Form1.ListView1.Items.Add(Form1.ListView1.Items.Count)
        Else
            anItem = Form1.ListView1.Items(CInt(Val(Sn.Text)))
            anItem.SubItems.Clear()
            anItem.SubItems.Item(0).Text = Sn.Text
        End If

        With anItem
            .SubItems.Add(TextBox1.Text)
            For x As Integer = 0 To 14
                .SubItems.Add(textCombo(x).Text)
            Next
            .SubItems.Add(CheckBox6.Checked)
        End With
        '********************************************************************

        'CREATE THE SENDING TEXT ****************************************************
        byteString(0) = CByte(Asc("c"))

        '***** insert value in byte string to be sent, 255 if don't use *****
        For x As Integer = 0 To 3
            If (checkedBox(x).Checked) Then
                If (textCombo(x).Text <> "Don't Use") Then
                    byteString(x + 1) = CByte(Val(textCombo(x).Text))
                End If
            Else
                byteString(x + 1) = CByte(255)
            End If
        Next

        If (textCombo(4).Text = "Don't Use") Then byteString(5) = 255 Else byteString(5) = textCombo(4).Text
        '*********************************************************************

        '********** Insert enable/disable rule value *************************
        If (CheckBox6.Checked) Then
            byteString(6) = CByte(1)
        Else
            byteString(6) = CByte(0)
        End If
        '********************************************************************

        '**** check if it is previously created or not value and send it ****
        If (Sn.Text = "-1") Then
            byteString(7) = Form1.ListView1.Items.Count - 1
        Else
            byteString(7) = CByte(Sn.Text)
        End If
        '********************************************************************

        '************* write string in sending bytes array ******************
        If (textCombo(5).Text = "None") Then byteString(8) = CByte(255) Else byteString(8) = CByte(Asc(getDirection(textCombo(5).Text)))
        If (textCombo(7).Text = "None") Then byteString(10) = CByte(255) Else byteString(10) = CByte(Asc(getDirection(textCombo(7).Text)))
        If (textCombo(9).Text = "None") Then byteString(12) = CByte(255) Else byteString(12) = CByte(Asc(getDirection(textCombo(9).Text)))
        If (textCombo(11).Text = "None") Then byteString(14) = CByte(255) Else byteString(14) = CByte(Asc(getDirection(textCombo(11).Text)))
        If (textCombo(13).Text = "None") Then byteString(16) = CByte(255) Else byteString(16) = CByte(Asc(getDirection(textCombo(13).Text)))
        byteString(9) = Val(textCombo(6).Text)
        byteString(11) = Val(textCombo(8).Text)
        byteString(13) = Val(textCombo(10).Text)
        byteString(15) = Val(textCombo(12).Text)
        byteString(17) = Val(textCombo(14).Text)
        '*************************************************************************************
        'SENDING TEXT CREATED ************************************************************************

        '************************ Send the text to queue and exit ****************************
        Form1.queue(byteString)
        Me.Close()
        '*************************************************************************************
    End Sub

    Private Function getDirection(ByVal value As String) As Char
        '@ returns direction string from 
        '@ comboboxes values
        Dim retVal As Char = ""
        Select Case value
            Case "Go Forward"
                retVal = "w"

            Case "Go Backward"
                retVal = "s"

            Case "Turn Left"
                retVal = "a"

            Case "Turn Right"
                retVal = "d"

            Case "Stop"
                retVal = "x"

            Case "Sharp Turn Left"
                retVal = "q"

            Case "Sharp Turn Right"
                retVal = "e"

            Case "Reverse Turn Left"
                retVal = "z"

            Case "Reverse Turn Right"
                retVal = "c"
        End Select
        Return retVal
    End Function
End Class