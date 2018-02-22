Imports System.IO
Public Class Form1

    Dim Lletra As String
    Dim LletraS As String


    Private Sub AbrirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
        MPlayer.URL = OpenFileDialog1.FileName
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = MPlayer.Ctlcontrols.currentPositionString
    End Sub


    Private Sub ExportarlrcToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportarlrcToolStripMenuItem.Click
        Dim LRC As String = TextBox1.Text
        Dim ruta = Path.ChangeExtension(MPlayer.URL, ".lrc")
        My.Computer.FileSystem.WriteAllText(ruta, LRC, False)
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.F11 Then
            If MPlayer.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                Dim separador As Char() = {vbCr, vbLf}
                Dim s As String() = TextBox1.Text.Split(separador, StringSplitOptions.RemoveEmptyEntries)
                Dim lenght As Integer = s.Length - 1
                For i = 0 To lenght
                    If s(i).Substring(0, 1) <> "[" Then
                        s(i) = "[" & MPlayer.Ctlcontrols.currentPositionString & "]" & " " & s(i)
                        Exit For
                    End If
                Next
                TextBox1.Text = ""
                For u = 0 To lenght
                    TextBox1.Text = TextBox1.Text & s(u) & vbCrLf
                Next
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim x As String() = TextBox1.Text.Split(vbCrLf)
    End Sub
End Class
