Public Class Form2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim eryd As Boolean = False
        Dim erby As Boolean = False

        If ComboBox1.Text = Nothing Then
            If ComboBox1.Items.Count <> 0 Then
                ComboBox1.Text = ComboBox1.GetItemText(ComboBox1.Items.Item(0))
            End If
        End If

        Try
            AppActivate("有道词典")
        Catch ex As ArgumentException
            MsgBox("你没有启动有道词典！", MsgBoxStyle.OkOnly, "错误！")
            eryd = True
        End Try
        If eryd = False Then
            My.Computer.Keyboard.SendKeys(ComboBox1.Text)
            My.Computer.Keyboard.SendKeys("~")
            My.Computer.Keyboard.SendKeys("~")
        End If

        WebBrowser1.Navigate("http://cn.bing.com/dict/" & ComboBox1.Text)

        ComboBox1.Items.Insert(0, ComboBox1.Text)
        ComboBox1.Text = Nothing
    End Sub
End Class