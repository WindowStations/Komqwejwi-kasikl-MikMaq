Public Class frmGlyphImage
    Private delglyph As Boolean = False
    Private sindex As Int32 = -1
    Private Sub frmGlyphImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmPictionary.lstGlyph.SelectedIndices.Count = 1 Then
            sindex = frmPictionary.lstGlyph.SelectedIndices(0)
        End If

    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If sindex <> -1 Then
            EditDictionaryItem()
        Else
            MsgBox("The index of the list item was not detected", MsgBoxStyle.OkOnly, "Error saving")
        End If
    End Sub
    Private Sub EditDictionaryItem()
        'Me.Cursor = Cursors.WaitCursor
        Try
            Dim pth As String = Application.StartupPath & "\pictionary.txt"
            Dim pth2 As String = Application.StartupPath & "\pictionary2.txt"
            Dim glyphs() As GLYPH = LoadGlyphsFromFile(pth)
            Dim bEditDelete As Boolean = False
            Dim bpath As Boolean = IO.File.Exists(lblPath.Text.Trim)


            Dim i As Int32 = 0
            IO.File.Delete(pth2)
            Dim sw As New IO.StreamWriter(pth2)
            For j As Int32 = 0 To glyphs.Length - 1
                i += 1
                If bpath = True AndAlso lblPath.Text.ToLower.Trim.IndexOf(glyphs(j).ImagePath.ToLower.Trim) <> -1 Then 'if an existing line matches the same glyph path being edited or deleted
                    bEditDelete = True 'set flag to determine below
                    sw.WriteLine(txtEnglish.Text.Trim & "|" & txtNative.Text.Trim & "|" & txtInfo.Text.Replace(vbCrLf, " ").Replace(vbCr, " ").Replace(vbLf, " ").Trim & "|" & lblPath.Text.ToLower.Replace(Application.StartupPath.ToLower & "\", "") & "|" & txtSimilar.Text.Trim)
                    sw.Flush()
                Else 'otherwise just write the existing line to the new file
                    sw.WriteLine(glyphs(j).EnglishText & "|" & glyphs(j).NativeText & "|" & glyphs(j).InfoText & "|" & glyphs(j).ImagePath & "|" & glyphs(j).Group) '
                    sw.Flush()
                End If
            Next
            sw.Close()

            Me.Visible = False



            'if we were not editing a line above, then we are adding it as the last line in the file.  User can move it around from there
            If bEditDelete = False Then 'no matches found in dictionary.  Add as a new entry instead.
                sw.WriteLine(txtEnglish.Text.Trim & "|" & txtNative.Text.Trim & "|" & txtInfo.Text.Trim & "|" & lblPath.Text.ToLower.Replace(Application.StartupPath.ToLower & "\", "") & "|" & txtSimilar.Text.Trim)
                Dim lvi As New ListViewItem

                lvi = frmPictionary.lstGlyph.Items.Add(frmPictionary.lstGlyph.Items.Count)
                lvi.Tag = frmPictionary.lstGlyph.Items.Count - 1
                lvi.SubItems.Add(txtEnglish.Text.Trim)
                lvi.SubItems.Add(txtNative.Text.Trim)
                lvi.SubItems.Add(txtInfo.Text.Trim)
                lvi.SubItems.Add(txtSimilar.Text.Trim)
                lvi.SubItems.Add(lblPath.Text.ToLower.Replace(Application.StartupPath.ToLower & "\", "").Trim)
                lvi.ImageKey = frmPictionary.lstGlyph.Items.Count

                frmPictionary.ImageList1.Images.Add(frmPictionary.lstGlyph.Items.Count, Image.FromFile(lblPath.Text))
            End If

            'If bEditDelete = True Then

            If IO.File.Exists(pth2) = True Then 'if new raw generated file exists
                If IO.Directory.Exists(Application.StartupPath & "\Archive") = False Then 'if archive directory does not exist then create it
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Archive")
                End If
                'move to archive for non-desctructive safety
                If IO.Directory.Exists(Application.StartupPath & "\Archive") = True Then 'if it actually was created, then move file to it
                    Dim dest As String = Application.StartupPath & "\Archive\" & Now.ToString.Replace(" ", "-").Replace("/", "-").Replace(":", "-") & "pictionary.txt"
                    IO.File.Move(pth, dest)
                End If
                'now copy 
                IO.File.Copy(pth2, pth, True) 'copy new to old file
                If IO.File.Exists(pth) = True Then 'if new file has actually replaced old
                    IO.File.Delete(pth2) 'only then delete the raw generation
                End If
            End If

            frmPictionary.EditDictionarylistItem(sindex, txtEnglish.Text.Trim, txtNative.Text.Trim, txtInfo.Text.Trim, txtSimilar.Text.Trim, lblPath.Text.ToLower.Replace(Application.StartupPath.ToLower & "\", ""))

            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Me.Cursor = Cursors.Default
        Me.Close()

    End Sub

    Private Sub txtInfo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInfo.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnSave.PerformClick()
        End If
    End Sub
    Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        If Me.WindowState = FormWindowState.Normal Or Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        SendKeys.Flush()
        Windows.Forms.SendKeys.Send("%{PRTSC}")
        SendKeys.Flush()
    End Sub


   
End Class