Public Class Form1

    Public Declare Auto Function mouse Lib "user32.dll" Alias "mouse_event" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal dwData As Integer, ByVal dwExtraIfo As Integer) As Integer
    Public Declare Auto Function mv Lib "user32.dll" Alias "SetCursorPos" (ByVal x As Integer, ByVal y As Integer) As Integer
    Public Declare Sub key Lib "user32.dll" Alias "keybd_event" (ByVal bVk As Byte, ByVal Scan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Public Const MOUSEEVENTF_LEFTDOWN As Integer = &H2
    Public Const MOUSEEVENTF_LEFTUP As Integer = &H4
    Public Const MOUSEEVENTF_ABSOLUTE As Integer = &H8000
    Public Const KEYEVENTF_EXTENDEDKEY As Integer = &H1
    Public Const KEYEVENTF_KEYUP As Integer = &H2
    Public Const VK_LWIN As Integer = &H5B
    Public Const VK_RIGHT As Integer = &H27
    Public Const VK_LEFT As Integer = &H25
    Public Const VK_D As Integer = &H44

    Private openYoudao As Boolean
    Private erby As Boolean = False
    Private eryd As Boolean = False

    Public Sub Button1_Click() Handles Button1.Click



        If ComboBox1.Text = "::" Then
            MsgBox("版本3.00.0030")
            ComboBox1.Text = Nothing
            Exit Sub
        End If

        If ComboBox1.Text = "::key" Then
            If Timer1.Enabled = False Then
                Timer1.Start()
            Else
                Timer1.Stop()
            End If
            ComboBox1.Text = Nothing
            Exit Sub
        End If

        If ComboBox1.Text = Nothing Then
            If ComboBox1.Items.Count <> 0 Then
                ComboBox1.Text = ComboBox1.GetItemText(ComboBox1.Items.Item(0))
            End If
        End If

        Try
            AppActivate("有道词典")
        Catch ex As ArgumentException
            Shell(Application.StartupPath + "\starting.bat 1",, True)
            openYoudao = True
            TimerSnap.Start()
            eryd = True
            TimerContinue.Interval = 1000
        End Try
        If eryd = False Then
            My.Computer.Keyboard.SendKeys("^a")
            My.Computer.Keyboard.SendKeys("{BACKSPACE}")
            My.Computer.Keyboard.SendKeys(ComboBox1.Text)
            My.Computer.Keyboard.SendKeys("~")
            My.Computer.Keyboard.SendKeys("~")
            'TimerTypeY.Start()
        End If

        TimerContinue.Start()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If My.Computer.Keyboard.AltKeyDown = True Then
            AppActivate("一键查词")
            'mv(100, 10)
            'mouse(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
            'mouse(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
        End If
        If My.Computer.Keyboard.CtrlKeyDown = True Then
            Timer2.Stop()
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        mv(730, 186)
        mouse(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
        mouse(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
        Timer2.Stop()
    End Sub

    Private Sub Timeropenbing_Tick(sender As Object, e As EventArgs) Handles Timeropenbing.Tick
        mouse(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
        mouse(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
        TimerSnap.Start()
        Timeropenbing.Stop()
    End Sub

    Private Sub TimerSnap_Tick(sender As Object, e As EventArgs) Handles TimerSnap.Tick
        key(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY, 0)
        If openYoudao Then
            key(VK_LEFT, 0, KEYEVENTF_EXTENDEDKEY, 0)
        Else
            AppActivate("必应词典")
            key(VK_RIGHT, 0, KEYEVENTF_EXTENDEDKEY, 0)
        End If
        TimerSnap2.Start()
        TimerSnap.Stop()
    End Sub

    Private Sub TimerSnap2_Tick(sender As Object, e As EventArgs) Handles TimerSnap2.Tick
        key(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        If openYoudao Then
            key(VK_LEFT, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        Else
            key(VK_RIGHT, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        End If
        TimerOpenDesk.Start()
        TimerSnap2.Stop()
    End Sub

    Private Sub TimerOpenDesk_Tick(sender As Object, e As EventArgs) Handles TimerOpenDesk.Tick
        mv(0, 0)
        mouse(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
        mouse(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
        TimerOpenDesk.Stop()

        If erby And eryd Then
            Shell(Application.StartupPath + "\starting.bat 3",, True)
            TimerClose.Start()
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1_Click()
    End Sub

    Private Sub TimerContinue_Tick(sender As Object, e As EventArgs) Handles TimerContinue.Tick

        Try
            AppActivate("必应词典")
        Catch ey As ArgumentException
            Shell(Application.StartupPath + "\starting.bat 2",, True)
            'My.Computer.Keyboard.SendKeys("^{ESC}")
            'mv(314, 597)
            'Timeropenbing.Start()
            openYoudao = False
            TimerSnap.Start()
            erby = True
        End Try

        TimerTypeB.Start()
        TimerContinue.Stop()
    End Sub

    Private Sub TimerTypeY_Tick(sender As Object, e As EventArgs) Handles TimerTypeY.Tick
        My.Computer.Keyboard.SendKeys("^a")
        My.Computer.Keyboard.SendKeys("{BACKSPACE}")
        My.Computer.Keyboard.SendKeys(ComboBox1.Text)
        My.Computer.Keyboard.SendKeys("~")
        My.Computer.Keyboard.SendKeys("~")
        TimerTypeY.Stop()
    End Sub

    Private Sub TimerTypeB_Tick(sender As Object, e As EventArgs) Handles TimerTypeB.Tick
        If erby = False Then
            My.Computer.Keyboard.SendKeys("{TAB}")
            My.Computer.Keyboard.SendKeys(ComboBox1.Text)
            My.Computer.Keyboard.SendKeys("~")
            My.Computer.Keyboard.SendKeys("~")
            If Timer2.Enabled = False Then
                Timer2.Start()
            Else
                Timer2.Stop()
                Timer2.Start()
            End If
        End If

        'If ComboBox1.Items.Contains(ComboBox1.Text) = True Then
        'ComboBox1.Items.RemoveAt(ComboBox1.Items.IndexOf(ComboBox1.Text))
        'End If
        ComboBox1.Items.Insert(0, ComboBox1.Text)
        ComboBox1.Text = Nothing

        If TimerContinue.Interval <> 100 Then
            TimerContinue.Interval = 100
        End If
        TimerTypeB.Stop()
    End Sub

    Private Sub TimerClose_Tick(sender As Object, e As EventArgs) Handles TimerClose.Tick
        Close()
    End Sub

    'Private Sub TimerOpenDesk2_Tick(sender As Object, e As EventArgs) Handles TimerOpenDesk2.Tick
    '    My.Computer.Keyboard.SendKeys("^{ESC}")
    '    mv(258, 593)
    '    TimerOpenDesk.Start()
    '    TimerOpenDesk2.Stop()
    'End Sub
End Class