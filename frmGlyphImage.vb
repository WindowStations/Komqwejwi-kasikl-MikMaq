Public Class frmGlyphImage
    Private delglyph As Boolean = False
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        On Error Resume Next
        Me.Visible = False
        Me.Cursor = Cursors.WaitCursor
        IO.File.Delete(Application.StartupPath & Me.Tag.ToString.Replace(".txt", "2.txt"))
        Dim sr As New IO.StreamReader(Application.StartupPath & Me.Tag.ToString)
        Dim sw As New IO.StreamWriter(Application.StartupPath & Me.Tag.ToString.Replace(".txt", "2.txt"))
        Dim bEditDelete As Boolean = False
        Dim bpath As Boolean = IO.File.Exists(lblPath.Text.Trim)
        Dim i As Int32 = 0
        Do
            If sr.EndOfStream = True Then Exit Do
            Dim inp As String = sr.ReadLine
            If inp.Trim <> "" Then 'Read only lines with data
                i += 1
                If bpath = True AndAlso inp.ToLower.IndexOf(lblPath.Text.ToLower.Trim) <> -1 Then 'if an existing line matches the same glyph path being edited or deleted
                    bEditDelete = True 'set flag to determine below
                    If delglyph = True Then 'Flag was set to delete this line, ie skips the line to be written
                    Else 'otherwise we are editing this line with new info and writing it to the new file
                        'MsgBox(i.ToString & " - " & inp & vbCrLf & vbCrLf & txtEnglish.Text.Trim & "|" & txtNative.Text.Trim & "|" & txtInfo.Text.Trim & "|" & lblPath.Text & "|" & lblPrayer.Text)

                        sw.WriteLine(txtEnglish.Text.Trim & "|" & txtNative.Text.Trim & "|" & txtInfo.Text.Replace(vbCrLf, " ").Replace(vbCr, " ").Replace(vbLf, " ").Trim & "|" & lblPath.Text & "|" & lblPrayer.Text)
                        sw.Flush()
                    End If
                Else 'otherwise just write the existing line to the new file
                    sw.WriteLine(inp)
                    sw.Flush()
                End If
            End If
        Loop
        'if we were not editing or deleting a line above, then we are adding it as the last line in the file.  User can move it around from there
        If bEditDelete = False Then sw.WriteLine(txtEnglish.Text.Trim & "|" & txtNative.Text.Trim & "|" & txtInfo.Text.Trim & "|" & lblPath.Text & "|" & lblPrayer.Text)
        sr.Close()
        sw.Close()
        If IO.File.Exists(Application.StartupPath & Me.Tag.ToString.Replace(".txt", "2.txt")) = True Then
            IO.File.Delete(Application.StartupPath & Me.Tag.ToString)
            IO.File.Copy(Application.StartupPath & Me.Tag.ToString.Replace(".txt", "2.txt"), Application.StartupPath & Me.Tag.ToString, True)
            If IO.File.Exists(Application.StartupPath & Me.Tag.ToString) = True Then
                IO.File.Delete(Application.StartupPath & Me.Tag.ToString.Replace(".txt", "2.txt"))
            End If
        End If
        frmPictionary.LoadDictionary()
        Me.Cursor = Cursors.Default
        Me.Close()
    End Sub
    Private Sub txtInfo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInfo.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnAdd.PerformClick()
        End If
    End Sub
    Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        If Me.WindowState = FormWindowState.Normal Or Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dres As New DialogResult
        dres = MessageBox.Show("Are you sure that you want to delete this entry from the dictionary?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dres = Windows.Forms.DialogResult.Yes Then
            delglyph = True
            DictionaryIndex -= 1
            btnAdd.PerformClick()
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim pth As String = ""
        Dim i As Int32 = 1
        Do
            pth = Application.StartupPath & "\Primary\" & i.ToString & ".png"
            If IO.File.Exists(pth) = False Then Exit Do
            i += 1
        Loop
        PictureBox1.BackgroundImage.Save(pth, Imaging.ImageFormat.Png)
        Me.Close()
    End Sub

    Private Sub frmGlyphImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class