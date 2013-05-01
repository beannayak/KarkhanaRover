Public Class Form1
    Dim ports As String() = SerialPort1.GetPortNames()
    Public Shared delayedCommandArray(50, 17) As Byte
    Public Shared delayedCommandArrayTimeStamp(50) As Date
    Public Shared count As Integer = 0
    Public Shared timeAddition As Integer = 0
    Dim placesText() As String = {"NepalNepal", "NepalWashington D.C.", "MoonNepal", "MarsNepal", "Washington D.C.Washington D.C.", "MoonWashington D.C.", "MarsWashington D.C.", "MoonMoon", "MarsMoon", "MarsMars"}
    Dim placesDuration() As Integer = {0, 1, 3, 250, 0, 3, 250, 0, 247, 0}

    Dim source(3) As RadioButton
    Dim destination(3) As RadioButton

    Public Sub delay(ByVal ms As Long)
        Dim A As Long
        Dim B As Long
        A = Date.Now().Millisecond + Date.Now().Second() * 1000 + Date.Now().Minute * 60 * 1000
        B = Date.Now().Millisecond + Date.Now().Second() * 1000 + Date.Now().Minute * 60 * 1000

        While ((B - A) < ms)
            B = Date.Now().Millisecond + Date.Now().Second() * 1000 + Date.Now().Minute * 60 * 1000
        End While
    End Sub

    Public Sub queue(ByVal bytesArray() As Byte)
        '@ puts characters to be send to robot in delayedCommandArray
        '@ which is afterward checked by timer1 to send to robot

        Dim additionTime As New Date

        '************getting a single Dimenstional array from 2 dimensional****
        For x As Integer = 0 To 17
            Form1.delayedCommandArray(Form1.count, x) = bytesArray(x)
        Next
        '**********************************************************************

        '******* add delay time according to location and place it in queue ***
        additionTime = Date.Now
        additionTime = additionTime.AddSeconds(timeAddition)
        Form1.delayedCommandArrayTimeStamp(Form1.count) = additionTime
        Form1.count += 1
        '**********************************************************************
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim port As String
        Dim Except As Exception
        Dim flag As Boolean = True
        Dim retVal As String = ""

        '*********************** Initilizing variables ********************
        source(0) = RadioButton1
        source(1) = RadioButton2
        source(2) = RadioButton3
        source(3) = RadioButton4

        destination(0) = RadioButton8
        destination(1) = RadioButton7
        destination(2) = RadioButton6
        destination(3) = RadioButton5
        '******************************************************************

        '********* making white transparent in pictureBox *****************
        Dim bm As Bitmap

        Dim myAsm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()

        bm = New Bitmap(myAsm.GetManifestResourceStream(Me.GetType, "Timon.bmp"))
        bm.MakeTransparent(Color.Red)
        PictureBox2.Image = bm
        '******************************************************************

        '** Searching if robot/wireless device is connected or not ********
        For Each port In ports
            Try
                With SerialPort1
                    .PortName = port
                    .Parity = IO.Ports.Parity.None
                    .StopBits = IO.Ports.StopBits.One
                    .BaudRate = 9600
                    .DataBits = 8
                    .Open()
                End With
            Catch Except
                SerialPort1.Close()
                Continue For
            End Try

            SerialPort1.Write("p                 ")
            delay(200)
            retVal = SerialPort1.ReadExisting()
            If (InStr(retVal, "KarkhanaRover", CompareMethod.Text) > 0) Then
                flag = False
                Exit For
            Else
                SerialPort1.Close()
            End If
        Next
        '*************************************************************************

        '**********Exit with message if robot is not attached*********************
        If (flag) Then
            MsgBox("Karkhana Rover not found, Connect the device and try again")
            'End
        End If
        '*************************************************************************

        '****** Initilize listview if robot is present ***************************
        ListView1.View = View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True

        'Add column header
        ListView1.Columns.Add("Sn.", 30)
        ListView1.Columns.Add("Rule Name", 100)
        ListView1.Columns.Add("DistG", 70)
        ListView1.Columns.Add("DistL", 70)
        ListView1.Columns.Add("TempG", 70)
        ListView1.Columns.Add("TempL", 70)
        ListView1.Columns.Add("Colour", 70)
        ListView1.Columns.Add("Dir1", 70)
        ListView1.Columns.Add("Dur1", 70)
        ListView1.Columns.Add("Dir2", 70)
        ListView1.Columns.Add("Dur2", 70)
        ListView1.Columns.Add("Dir3", 70)
        ListView1.Columns.Add("Dur3", 70)
        ListView1.Columns.Add("Dir4", 70)
        ListView1.Columns.Add("Dur4", 70)
        ListView1.Columns.Add("Dir5", 70)
        ListView1.Columns.Add("Dur5", 70)
        ListView1.Columns.Add("Enable", 70)
        ListView1.Scrollable = True
        '********************************************************************

        '**************Start listening for timeStamp of queue****************
        Timer1.Enabled = True
        '********************************************************************
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form2.Show()
    End Sub

    '******************** Default Move commands from buttons ****************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click, Button12.Click
        defaultMove("w")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button11.Click
        defaultMove("q")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click, Button15.Click
        defaultMove("x")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click, Button13.Click
        defaultMove("e")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click, Button14.Click
        defaultMove("a")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click, Button16.Click
        defaultMove("d")
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click, Button19.Click
        defaultMove("z")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click, Button17.Click
        defaultMove("s")
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click, Button18.Click
        defaultMove("c")
    End Sub
    '**************************************************************************************

    '****** Sending data to robot in byte format ******************************************
    Private Sub PrintByte(ByVal value As Byte)
        Dim bytes(0) As Byte
        bytes(0) = value
        Try
            SerialPort1.Write(bytes, 0, 1)
        Catch E As Exception
            MsgBox("KarkhanaRobot unpluged", MsgBoxStyle.Critical, "Karkhana Rover")
            End
        End Try
    End Sub
    
    Public Sub PrintByteArray(ByVal bytes() As Byte)
        Try
            SerialPort1.Write(bytes, 0, bytes.Length)
        Catch E As Exception
            MsgBox("KarkhanaRobot unpluged", MsgBoxStyle.Critical, "Karkhana Rover")
            End
        End Try
    End Sub
    '*************************************************************************

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '@ Checks the timeStamp of bytes stored in queue and
        '@ sends to robot accordingly

        'Debug.Print(SerialPort1.ReadExisting())     ' for debugging purpose only
        If (count <= 0) Then Exit Sub

        If (Date.Now >= delayedCommandArrayTimeStamp(0)) Then
            Dim aByte() As Byte = Nothing
            count -= 1

            '************reset robot first**********
            '@ robot reset its listening function 
            '@ once it gets '&'

            Dim resetByte As Byte = 0
            resetByte = CByte(Asc("&"))
            PrintByte(resetByte)
            '***************************************

            '****Getting 1D array from 2D **********
            ReDim aByte(17)
            For x As Integer = 0 To 17
                aByte(x) = delayedCommandArray(0, x)
            Next
            '***************************************
            
            PrintByteArray(aByte)
            swapDates()
            delay(50)           'give some time for transmit buffer to clear 
        End If
    End Sub

    Private Sub swapDates()
        Dim temp As Date = Nothing
        For x As Integer = 0 To 49
            temp = delayedCommandArrayTimeStamp(x + 1)
            delayedCommandArrayTimeStamp(x) = temp
        Next

        Dim aByte(17) As Byte
        For x As Integer = 0 To 49
            For y As Integer = 0 To 17
                aByte(y) = delayedCommandArray(x + 1, y)
            Next
            For y As Integer = 0 To 17
                delayedCommandArray(x, y) = aByte(y)
            Next
        Next

    End Sub

    Private Sub defaultMove(ByVal direction As Char)
        '@ Sends robot default direction to move
        Dim aBytes(17) As Byte
        aBytes(0) = CByte(Asc("m"))
        aBytes(1) = CByte(Asc(direction))
        For x As Integer = 0 To 15
            aBytes(x + 2) = CByte(0)
        Next
        queue(aBytes)
    End Sub
    
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.Click, RadioButton2.Click, RadioButton3.Click, RadioButton4.Click, RadioButton5.Click, RadioButton6.Click, RadioButton7.Click, RadioButton8.Click
        '@ Sets addition time to wait before sending data to robot
        '@ to give a feel of interplanetary communication
        Dim sourceString As String = ""
        Dim destinationString As String = ""
        Dim totalString As String = ""
        Dim indexed As Integer = 0

        '***** get the text of from where to wher *********
        For x As Integer = 0 To 3
            If (source(x).Checked) Then
                sourceString = source(x).Text
            End If
            If (destination(x).Checked) Then
                destinationString = destination(x).Text
            End If
        Next
        '*************************************************

        '********** concat the string ********************
        If (sourceString < destinationString) Then
            totalString = sourceString + destinationString
        Else
            totalString = destinationString + sourceString
        End If
        '*************************************************

        '**** compare the string to get delay seconds ****
        For x As Integer = 0 To 9
            If (LCase(placesText(x)) = LCase(totalString)) Then
                indexed = x
                Exit For
            End If
        Next
        timeAddition = placesDuration(indexed)
        '*************************************************
    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        '@ reopens the form2 (conditions selection window) with all 
        '@ previously selected info.

        Form2.TextBox1.Text = ListView1.SelectedItems(0).SubItems(1).Text
        Form2.Sn.Text = ListView1.SelectedItems(0).SubItems(0).Text
        Form2.ComboBox12.Text = ListView1.SelectedItems(0).SubItems(2).Text
        Form2.ComboBox13.Text = ListView1.SelectedItems(0).SubItems(3).Text
        Form2.ComboBox14.Text = ListView1.SelectedItems(0).SubItems(4).Text
        Form2.ComboBox15.Text = ListView1.SelectedItems(0).SubItems(5).Text
        Form2.ComboBox1.Text = ListView1.SelectedItems(0).SubItems(6).Text
        Form2.ComboBox2.Text = ListView1.SelectedItems(0).SubItems(7).Text
        Form2.ComboBox3.Text = ListView1.SelectedItems(0).SubItems(8).Text
        Form2.ComboBox5.Text = ListView1.SelectedItems(0).SubItems(9).Text
        Form2.ComboBox4.Text = ListView1.SelectedItems(0).SubItems(10).Text
        Form2.ComboBox7.Text = ListView1.SelectedItems(0).SubItems(11).Text
        Form2.ComboBox6.Text = ListView1.SelectedItems(0).SubItems(12).Text
        Form2.ComboBox9.Text = ListView1.SelectedItems(0).SubItems(13).Text
        Form2.ComboBox8.Text = ListView1.SelectedItems(0).SubItems(14).Text
        Form2.ComboBox11.Text = ListView1.SelectedItems(0).SubItems(15).Text
        Form2.ComboBox10.Text = ListView1.SelectedItems(0).SubItems(16).Text

        If (Form2.ComboBox12.Text <> "Don't Use") Then Form2.CheckBox1.Checked = True
        If (Form2.ComboBox13.Text <> "Don't Use") Then Form2.CheckBox2.Checked = True
        If (Form2.ComboBox14.Text <> "Don't Use") Then Form2.CheckBox3.Checked = True
        If (Form2.ComboBox15.Text <> "Don't Use") Then Form2.CheckBox4.Checked = True
        If (Form2.ComboBox1.Text <> "Don't Use") Then Form2.CheckBox5.Checked = True
        If (ListView1.SelectedItems(0).SubItems(17).Text = "False") Then Form2.CheckBox6.Checked = False

        Form2.Show()
    End Sub

    Private Sub Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If (ListView1.Items.Count() <= 50) Then
            Form2.Show()
        Else
            MsgBox("Maximum number of rules reached")
        End If
    End Sub
End Class
