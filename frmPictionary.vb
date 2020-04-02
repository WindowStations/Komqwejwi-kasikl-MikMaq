Public Class frmPictionary
    Private i As Int32 = 0
    Private lvwColumnSorter As New ListViewColumnSorter()
    Private lvwColumnSorter2 As New ListViewColumnSorter()
    Private lvitmps(-1) As ListViewItem
    Private navdown As Boolean = False
    Private navtck As Int32 = 0
    Private navigatingup As Boolean = False
    Private navigatingdown As Boolean = False

    Private Sub frmPictionary_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frmPictionary_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub
    Private Sub frmPictionary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modFriend.spash = False
        Me.Tag = "\pictionary.txt"
        Dim t As New Threading.Thread(AddressOf LoadDictionary)
        t.Start()
    End Sub
    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        On Error Resume Next
        If txtSearch.Text.Trim = "" Then
            lstSearch.Visible = False
            lstSearch.Items.Clear()
            Exit Sub
        End If
        If e.KeyCode = Keys.Enter Then
            lstSearch.Visible = True
            lstSearch.Items.Clear()
            Dim sch As String = txtSearch.Text.ToLower
            Dim lvis(-1) As ListViewItem
            For i As Int32 = 0 To lstGlyph.Items.Count - 1
                Dim x As String = lstGlyph.Items.Item(i).SubItems(1).Text.ToLower
                Dim xs() As String = x.Split(" ")
                Dim bsearch As Boolean = False
                Dim xch() As String = sch.Split(" ")
                Dim bluff As Boolean = False
                For Each xx As String In xs
                    For Each xc As String In xch
                        If xx.ToLower.Trim.IndexOf(xc.ToLower.Trim) <> -1 Then bsearch = True
                        If xc.ToLower.Trim.IndexOf("-") <> -1 AndAlso xc.Trim.Substring(0, 1) = "-" AndAlso xx.ToLower.Trim.IndexOf(xc.Trim.Substring(1)) <> -1 Then bsearch = False : bluff = True
                        If xc.ToLower.Trim.IndexOf("-") <> -1 AndAlso xc.Trim.Substring(0, 1) = "-" Then
                            If xs.Contains(xc.Trim.Substring(1)) = True Then
                                bsearch = False : bluff = True
                            End If
                        End If
                    Next
                    If bluff = True Then
                        bluff = False
                        bsearch = False
                    End If
                Next
                If bsearch = True Then
                    Array.Resize(lvis, lvis.Length + 1)
                    lvis(lvis.Length - 1) = lstGlyph.Items(i)
                End If
            Next
            Dim y As Int32 = 0
            For z As Int32 = 0 To lvis.Length - 1
                y = CInt(lvis(z).SubItems(0).Text)
                Dim lv As ListViewItem = lstSearch.Items.Add(y.ToString)
                lv.ImageKey = y.ToString
                lv.SubItems.Add(lvis(z).SubItems(1).Text)
                lv.SubItems.Add(lvis(z).SubItems(2).Text)
                lv.SubItems.Add(lvis(z).SubItems(3).Text)
                lv.SubItems.Add(lvis(z).SubItems(4).Text)
                lv.SubItems.Add(lvis(z).SubItems(5).Text)
                lv.SubItems.Add(lvis(z).SubItems(6).Text)
                lv.Tag = lvis(z).Tag
                lstSearch.Columns.Item(0).Text = "Loaded: " & (z + 1).ToString
            Next
        End If
    End Sub
    Friend Sub LoadDictionary()
        On Error Resume Next
        Dim pth As String = Application.StartupPath & Me.Tag.ToString '"\pictionary.txt"
        If IO.File.Exists(pth) = False Then Exit Sub
        Dim sr As New IO.StreamReader(pth)
        Me.Cursor = Cursors.WaitCursor
        lstGlyph.Items.Clear()
        ImageList1.Images.Clear()
        i = 0
        lvwColumnSorter = New ListViewColumnSorter()
        lstGlyph.ListViewItemSorter = lvwColumnSorter
        Dim lvis(-1) As ListViewItem
        Dim sr2 As New IO.StreamReader(pth)
        Dim srs As Int32 = sr2.ReadToEnd.Split(vbCrLf).Length
        sr2.Close()
        Do
            If sr.EndOfStream = True Then Exit Do
            Dim inp As String = sr.ReadLine.Trim
            Dim p() As String = inp.Split("|")
            If p.Length >= 5 Then

                p(3) = Application.StartupPath & "\" & p(3)

                Dim x As String = p(3)
                x = IO.Path.GetFileNameWithoutExtension(x)
                Dim y As Int32 = CInt(x)
                y -= 1
                x = y.ToString
                Dim lvi As New ListViewItem With {.text = i.ToString}
                lvi.Tag = (y + 1).ToString
                lvi.ImageKey = i
                ImageList1.Images.Add(i, Image.FromFile(p(3)))
                lvi.SubItems.Add(p(0).ToLower.Replace(".", "").Replace("?", "").Replace(":", ""))
                lvi.SubItems.Add(p(1).ToLower.Replace(".", "").Replace("?", "").Replace(":", ""))
                lvi.SubItems.Add(p(2))

                Dim wcnt As Int32 = 0


                Dim prw() As String = p(1).Split(";")



                For Each pw As String In prw
                    For Each pl As String In frmGlyphManifest.prayerlines
                        Dim pls() As String = pl.Split("|")
                        If pw.ToLower.Replace(".", "").Replace("?", "").Replace(":", "").Trim = pls(1).ToLower.Replace(".", "").Replace("?", "").Replace(":", "").Trim Then
                            wcnt += 1
                            '  MsgBox(wcnt)
                        End If
                    Next
                Next
                If wcnt = 0 Then wcnt = 1

                lvi.SubItems.Add(wcnt.ToString)
                lvi.Selected = False
                If p.Length >= 4 Then lvi.SubItems.Add(p(3).Replace(Application.StartupPath & "\", ""))
                If p.Length >= 5 Then lvi.SubItems.Add(p(4))
                Array.Resize(lvis, lvis.Length + 1)
                lvis(lvis.Length - 1) = lvi
                i += 1

                ProgressBar1.Value = CInt(100 * (i / (srs - 1)))
                Application.DoEvents()
            End If
        Loop
        sr.Close()
        lstGlyph.Items.AddRange(lvis)
        lstGlyph.Items.Item(DictionaryIndex).EnsureVisible()
        lstGlyph.Items.Item(DictionaryIndex).Selected = True
        Me.Cursor = Cursors.Default
        Me.Text = "Dictionary of hieroglyphics (" & lstGlyph.Items.Count.ToString & " terms)"
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim dres As New DialogResult
        Dim ofd As New OpenFileDialog
        ofd.Title = ""
        ofd.InitialDirectory = Application.StartupPath & "\Primary" ' Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        ofd.Filter = "Bitmap Files(*.bmp)|*.bmp|Personal graphics Files(*.png)|*.png|Jpeg Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif"
        ofd.DefaultExt = ".bmp"
        ofd.FilterIndex = 0
        ofd.Multiselect = False
        ofd.CheckFileExists = True
        ofd.CheckPathExists = True
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fn As String = ofd.FileName
            Dim s As Size = Image.FromFile(ofd.FileName).Size
            Dim pth As String = Application.StartupPath & "\PRAYERS\CUSTOM\"
            Dim f As New frmGlyphImage
            '  Dim pth As String = ""

            If s.Width > s.Height Then s.Height = s.Width
            If s.Height > s.Width Then s.Width = s.Height
            Dim b As New Bitmap(s.Width, s.Height)
            b = frmGlyphManifest.ResizeImage(Image.FromFile(ofd.FileName), s.Width, s.Height)

            Dim i As Int32 = 1
            Do
                If IO.File.Exists(pth & i.ToString & ".png") = False Then Exit Do
                i += 1
            Loop
            b.Save(pth & i.ToString & ".png", Imaging.ImageFormat.Png) 'IO.File.Copy(fn, th & i.ToString & ".png")

            f.PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
            f.PictureBox1.BackgroundImage = Bitmap.FromFile(pth & i.ToString & ".png")
            f.txtInfo.Text = "none"
            f.lblPrayer.Text = "CUSTOM"
            f.lblPath.Text = pth & i.ToString & ".png"
            f.Text = "()"
            f.Show()
        End If

        'Dim ofd As New OpenFileDialog
        'Dim dres As New DialogResult
        'ofd.InitialDirectory = Application.StartupPath & "\PRAYERS\CUSTOM"
        'ofd.CheckFileExists = True

        'dres = ofd.ShowDialog
        'If dres = Windows.Forms.DialogResult.OK Then
        '    Dim fn As String = ofd.FileName
        '    '  Dim lvi As ListViewItem = lstGlyph.SelectedItems.Item(0)

        '    Dim f As New frmGlyphImage
        '    ' Dim pth As String = ""
        '    'Dim x As String = 'lvi.Tag.ToString  ' lvi.SubItems.Item(0).Text
        '    ' pth = Application.StartupPath & "\PRAYERS\" & lvi.SubItems.Item(6).Text
        '    f.PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        '    f.PictureBox1.BackgroundImage = Bitmap.FromFile(fn)
        '    f.txtEnglish.Text = "" ' lvi.SubItems.Item(1).Text
        '    f.txtNative.Text = "" 'lvi.SubItems.Item(2).Text
        '    f.txtInfo.Text = "" ' lvi.SubItems.Item(3).Text
        '    f.lblPrayer.Text = "CUSTOM" ' lvi.SubItems.Item(6).Text
        '    f.lblPath.Text = fn
        '    f.Text = "" 'lvi.SubItems.Item(1).Text & " (" & lvi.SubItems.Item(2).Text & ")"
        '    f.Show()
        'End If
    End Sub


    'Dim pth3 As String = Application.StartupPath & "\NativeToEnglishTranslations3.txt"
    'Dim pth2 As String = Application.StartupPath & "\NativeToEnglishTranslations2.txt"


    'Dim sw As New IO.StreamWriter(pth2)
    'Dim sw3 As New IO.StreamWriter(pth3)
    'Dim last As String = ""

    'For Each ln As String In lns
    '    Dim ne() As String = ln.Split("|")
    '    If ne(0) <> last Then
    '        last = ne(0)
    '        sw.WriteLine(ln.Replace(vbLf, "").Replace(vbCr, ""))
    '    Else
    '        'If ne(1) = "" Then
    '        '
    '        sw3.WriteLine(ln.Replace(vbLf, "").Replace(vbCr, ""))
    '        '  End If

    '    End If
    'Next
    'sw.Flush()
    'sw.Close()
    'sw3.close()
    'Dim pth3 As String = Application.StartupPath & "\NativeToEnglishTranslations3.txt"
    'Dim pth2 As String = Application.StartupPath & "\NativeToEnglishTranslations2.txt"
    'Dim pth As String = Application.StartupPath & "\NativeToEnglishTranslations.txt"
    'Dim sr As New IO.StreamReader(pth)
    'Dim lns() As String = sr.ReadToEnd.Split(vbCrLf)
    'sr.Close()
    'Dim sw As New IO.StreamWriter(pth2)
    'Dim sw3 As New IO.StreamWriter(pth3)
    'Dim last As String = ""

    'For Each ln As String In lns
    '    Dim ne() As String = ln.Split("|")
    '    If ne(0) <> last Then
    '        last = ne(0)
    '        sw.WriteLine(ln.Replace(vbLf, "").Replace(vbCr, ""))
    '    Else
    '        'If ne(1) = "" Then
    '        '
    '        sw3.WriteLine(ln.Replace(vbLf, "").Replace(vbCr, ""))
    '        '  End If

    '    End If
    'Next
    'sw.Flush()
    'sw.Close()
    'sw3.close()
    Private Sub CombineTranslations()
        On Error Resume Next
        Dim lv(-1) As String

        For Each lvi1 As ListViewItem In frmGlyphManifest.lstGlyphs.Items
            Dim txtEng As String = lvi1.SubItems.Item(1).Text
            Dim txtNat As String = lvi1.SubItems.Item(2).Text
            For Each lvi2 As ListViewItem In frmGlyphManifest.lstGlyphs.Items
                If lvi1.Index <> lvi2.Index Then
                    'If lvi1.SubItems(1).Text = lvi2.SubItems(1).Text Then
                    '    Dim xn() As String = txtNat.Split(";")
                    '    If xn.Contains(lvi2.SubItems(2).Text) = False Then
                    '        txtNat &= ";" & lvi2.SubItems(2).Text
                    '    End If
                    'End If
                    If lvi1.SubItems(2).Text = lvi2.SubItems(2).Text Then
                        Dim xn() As String = txtEng.Split(";")
                        If xn.Contains(lvi2.SubItems(1).Text) = False Then
                            txtEng &= ";" & lvi2.SubItems(1).Text
                        End If
                    End If
                End If
            Next

            Dim s As String = txtNat & "|" & txtEng
            Dim s2 As String = txtEng & "|" & txtNat
            If lv.Contains(s) = False AndAlso lv.Contains(s2) = False Then
                Array.Resize(lv, lv.Length + 1)
                lv(lv.Length - 1) = s
            End If
        Next

        Dim pth As String = Application.StartupPath & "\NativeToEnglishTranslations.txt"
        Dim sw As New IO.StreamWriter(pth)
        For Each l As String In lv
            sw.WriteLine(l)
        Next
        sw.Flush()
        sw.Close()
    End Sub


    Friend Sub SaveDictionaryItems()
        On Error Resume Next
        Dim pth As String = Application.StartupPath & Me.Tag.ToString.Replace(".txt", "3.txt") '"\pictionary3.txt"
        Dim pth2 As String = Application.StartupPath & Me.Tag.ToString ' "\pictionary.txt"
        If IO.File.Exists(pth) = True Then IO.File.Delete(pth)
        Dim sw As New IO.StreamWriter(pth)
        For Each lvi As ListViewItem In lstGlyph.Items
            Dim txt As String = lvi.SubItems.Item(1).Text & "|" & lvi.SubItems.Item(2).Text & "|" & lvi.SubItems.Item(3).Text & "|" & lvi.SubItems.Item(5).Text & "|" & lvi.SubItems.Item(6).Text
            sw.WriteLine(txt)
        Next
        sw.Flush()
        sw.Close()
        If IO.File.Exists(pth) = True Then
            IO.File.Delete(pth2)
            IO.File.Copy(pth, pth2, True)
        End If
    End Sub
    Private Sub lstGlyph_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstGlyph.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.ListViewItem") Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub lstGlyph_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lstGlyph.ItemDrag
        Me.Text = e.Item.ToString
        ' lvitmp = lstGlyph.SelectedItems(0).Clone()

        ' Create a DataObject that holds the ListViewItem.
        ' sender.DoDragDrop(New DataObject("System.Windows.Forms.ListViewItem", lvitmp), DragDropEffects.Copy)
    End Sub
    Private Sub lstGlyph_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstGlyph.DragDrop
        lstGlyph.Items.Remove(lstGlyph.SelectedItems(0))
        Dim lp As New Drawing.Point(lstGlyph.PointToClient(MousePosition))
        Dim x As Int32 = lstGlyph.GetItemAt(lp.X, lp.Y).Index
        ' lstGlyph.Items.Insert(x, lvitmp)
        DictionaryIndex = x
    End Sub
    Private Sub btnMoveUp_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMoveUp.MouseDown
        If lstGlyph.SelectedItems.Count = 0 Then Exit Sub
        navigatingup = True
        Navup()
        navtck = Environment.TickCount
    End Sub
    Private Sub btnMoveUp_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMoveUp.MouseUp
        navigatingup = False
        SaveDictionaryItems()
    End Sub
    Private Sub btnMoveDown_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMoveDown.MouseDown
        If lstGlyph.SelectedItems.Count = 0 Then Exit Sub
        navigatingdown = True
        NavDn()
        navtck = Environment.TickCount
    End Sub
    Private Sub btnMoveDown_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMoveDown.MouseUp
        navigatingdown = False
        SaveDictionaryItems()
    End Sub
    Private Sub btnMoveFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveFirst.Click
        If lstGlyph.SelectedItems.Count = 0 Then Exit Sub
        Dim x As ListView.SelectedIndexCollection = lstGlyph.SelectedIndices
        Dim xi As Int32 = x.Item(0)
        If xi = 0 Then Exit Sub
        Dim xc As Int32 = x.Count
        Dim lvis(-1) As ListViewItem
        For i As Int32 = ((xi + xc) - 1) To xi Step -1
            Array.Resize(lvis, lvis.Length + 1)
            lvis(lvis.Length - 1) = lstGlyph.Items.Item(i).Clone
        Next
        For i As Int32 = 1 To xc
            lstGlyph.Items.Item(xi).Remove()
        Next
        Application.DoEvents()
        Threading.Thread.Sleep(0)
        Dim z As Int32 = 0
        For i As Int32 = ((xi + xc) - 1) To xi Step -1
            lstGlyph.Items.Insert(0, lvis(z).Clone)
            z += 1
        Next
        For j As Int32 = 0 To xc - 1
            lstGlyph.Items.Item(j).Selected = True
            DictionaryIndex = j
            lstGlyph.Items.Item(j).EnsureVisible()
        Next
        SaveDictionaryItems()
    End Sub
    Private Sub btnMoveLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveLast.Click
        If lstGlyph.SelectedItems.Count = 0 Then Exit Sub
        Dim x As ListView.SelectedIndexCollection = lstGlyph.SelectedIndices
        Dim a As Int32 = 1
        Dim xi As Int32 = x.Item(0)
        Dim xc As Int32 = x.Count
        If x.Item(x.Count - 1) = lstGlyph.Items.Count - 1 Then Exit Sub
        Dim ec As Int32 = lstGlyph.Items.Count - 1
        For z As Int32 = x.Count - 1 To 0 Step -1
            Dim i As Int32 = x.Item(z)
            lstGlyph.Items.Insert(ec + 1, lstGlyph.Items.Item(i).Clone)
        Next
        For z As Int32 = 0 To x.Count - 1
            lstGlyph.Items.RemoveAt(x.Item(0))
        Next
        Application.DoEvents()
        Threading.Thread.Sleep(0)
        For z As Int32 = (ec - xc) + 1 To ec
            lstGlyph.Items.Item(z).Selected = True
            DictionaryIndex = z
            lstGlyph.Items.Item(z).EnsureVisible()
        Next
        SaveDictionaryItems()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (Environment.TickCount - navtck) < 600 Then Exit Sub
        If navigatingup = True Then
            Navup()
        ElseIf navigatingdown = True Then
            NavDn()
        End If
    End Sub
    Private Sub Navup()
        If lstGlyph.SelectedItems.Count = 0 Then Exit Sub
        Dim x As ListView.SelectedIndexCollection = lstGlyph.SelectedIndices
        Dim xi As Int32 = x.Item(0)
        If xi = 0 Then Exit Sub
        Dim xc As Int32 = x.Count
        Dim lvis(-1) As ListViewItem
        For i As Int32 = ((xi + xc) - 1) To xi Step -1
            Array.Resize(lvis, lvis.Length + 1)
            lvis(lvis.Length - 1) = lstGlyph.Items.Item(i).Clone
        Next
        For i As Int32 = 1 To xc
            lstGlyph.Items.Item(xi).Remove()
        Next
        Application.DoEvents()
        Threading.Thread.Sleep(0)
        Dim z As Int32 = 0
        For i As Int32 = ((xi + xc) - 1) To xi Step -1
            Try
                lstGlyph.Items.Insert(xi - 1, lvis(z).Clone)
                z += 1
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & vbCrLf & i.ToString)
            End Try
        Next
        For j As Int32 = xi - 1 To (xi + xc) - 2
            lstGlyph.Items.Item(j).Selected = True
            DictionaryIndex = j
            lstGlyph.Items.Item(j).EnsureVisible()
        Next
    End Sub
    Private Sub NavDn()
        If lstGlyph.SelectedItems.Count = 0 Then Exit Sub
        Dim x As ListView.SelectedIndexCollection = lstGlyph.SelectedIndices
        Dim a As Int32 = 1
        Dim xi As Int32 = x.Item(0)
        Dim xc As Int32 = x.Count
        If x.Item(x.Count - 1) = lstGlyph.Items.Count - 1 Then Exit Sub

        For z As Int32 = x.Count - 1 To 0 Step -1
            Dim i As Int32 = x.Item(z)
            lstGlyph.Items.Insert(i + a + 1, lstGlyph.Items.Item(i).Clone)
            a += 1
        Next
        For z As Int32 = 0 To x.Count - 1
            lstGlyph.Items.RemoveAt(x.Item(0))
        Next
        Application.DoEvents()
        Threading.Thread.Sleep(0)
        For z As Int32 = xi + 1 To xi + xc
            lstGlyph.Items.Item(z).Selected = True
            DictionaryIndex = z
            lstGlyph.Items.Item(z).EnsureVisible()
        Next
    End Sub
    Private Sub lstGlyph_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lstGlyph.ItemSelectionChanged
        If e.IsSelected = True Then
            DictionaryIndex = e.ItemIndex
        End If
    End Sub
    Private Sub lstGlyph_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstGlyph.ItemActivate
        On Error Resume Next
        Dim lvi As ListViewItem = lstGlyph.SelectedItems.Item(0)
        Dim f As New frmGlyphImage
        Dim pth As String = ""
        Dim x As String = lvi.Tag.ToString  ' lvi.SubItems.Item(0).Text
        pth = Application.StartupPath & "\PRAYERS\" & lvi.SubItems.Item(6).Text
        f.PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        f.PictureBox1.BackgroundImage = Bitmap.FromFile(pth & "\" & x & ".png")
        f.txtEnglish.Text = lvi.SubItems.Item(1).Text
        f.txtNative.Text = lvi.SubItems.Item(2).Text
        f.txtInfo.Text = lvi.SubItems.Item(3).Text
        f.lblPrayer.Text = lvi.SubItems.Item(6).Text
        f.lblPath.Text = pth & "\" & x & ".png"

        f.Text = lvi.SubItems.Item(1).Text & " (" & lvi.SubItems.Item(2).Text & ")"
        f.Show()
    End Sub
    Private Sub lstGlyph_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstGlyph.ColumnClick
        On Error Resume Next
        If lstGlyph.Items.Count = 0 OrElse lstGlyph.Columns.Count = 0 Then Exit Sub

        If e.Column = lvwColumnSorter.SortColumn Then  ' Determine if clicked column is already the column that is being sorted.
            If lvwColumnSorter.Order = SortOrder.Ascending Then ' Reverse the current sort direction for this column.
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else ' Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If
        lstGlyph.Sort() ' Perform the sort with these new sort options.
    End Sub

    Private Sub JumpToHieroglyphToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JumpToHieroglyphToolStripMenuItem.Click
        For Each lvi As ListViewItem In frmGlyphManifest.lstGlyphs.Items
            lvi.Selected = False
            Dim selkt As String = lstGlyph.SelectedItems.Item(0).SubItems.Item(5).Text
            Dim s As String = Application.StartupPath & "\PRAYERS\" & lvi.SubItems.Item(6).Text & "\" & lvi.SubItems.Item(5).Text & ".png"
            If s = selkt Then
                frmGlyphManifest.BringToFront()
                frmGlyphManifest.Focus()
                frmGlyphManifest.Select()
                lvi.EnsureVisible()
                lvi.Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        For Each g As ListViewItem In lstGlyph.SelectedItems
            g.Remove()
        Next
        SaveDictionaryItems()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmGlyphManifest.Show()
    End Sub
End Class