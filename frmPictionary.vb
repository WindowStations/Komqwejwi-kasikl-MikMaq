Public Class frmPictionary

    Private i As Int32 = 0
    Private lvwColumnSorter As New ListViewColumnSorter()
    Private lvwColumnSorter2 As New ListViewColumnSorter()
    Private lvitmps(-1) As ListViewItem
    Private navdown As Boolean = False
    Private navtck As Int32 = 0
    Private navigatingup As Boolean = False
    Private navigatingdown As Boolean = False

    Private Sub frmPictionary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Tag = "\pictionary.txt"

        Application.EnableVisualStyles()

        Dim t As New Threading.Thread(AddressOf LoadDictionary)
        t.Start()


    End Sub



    'subordinating conjunction because
    '7 coordinating conjunction (for - and - or -   but - yet - nor - so)
    'Preposition - possessive   (in - on - from - at - into - through - inside) - (your - their - my)

    Friend Sub LoadDictionary()
        On Error Resume Next
        Dim pth As String = Application.StartupPath & "\pictionary.txt"
        Dim glyphs() As GLYPH = LoadGlyphsFromFile(pth)

        Me.Cursor = Cursors.WaitCursor
        lstGlyph.Items.Clear()
        ImageList1.Images.Clear()
        i = 0
        lvwColumnSorter = New ListViewColumnSorter()
        lvwColumnSorter2 = New ListViewColumnSorter()
        lstGlyph.ListViewItemSorter = lvwColumnSorter
        lstSearch.ListViewItemSorter = lvwColumnSorter2
        Dim lvis(-1) As ListViewItem
        Dim sr2 As New IO.StreamReader(pth)
        Dim srs As Int32 = sr2.ReadToEnd.Split(vbCrLf).Length
        sr2.Close()
        For j As Int32 = 0 To glyphs.Length - 1

            Dim x As String = Application.StartupPath & "\" & glyphs(j).ImagePath
            x = IO.Path.GetFileNameWithoutExtension(x)
            Dim y As Int32 = CInt(x)
            y -= 1
            x = y.ToString
            Dim lvi As New ListViewItem With {.text = i.ToString}
            lvi.Tag = i '(y + 1).ToString
            lvi.ImageKey = i
            ImageList1.Images.Add(i, Image.FromFile(Application.StartupPath & "\" & glyphs(j).ImagePath))

            lvi.SubItems.Add(glyphs(j).EnglishText) ' 'english
            lvi.SubItems.Add(glyphs(j).NativeText) ' 'native
            lvi.SubItems.Add(glyphs(j).InfoText) ' 'info
            lvi.SubItems.Add(glyphs(j).Group.Trim) 'group name
            lvi.SubItems.Add(glyphs(j).ImagePath.Replace(Application.StartupPath & "\", "")) 'image path (short version)

            lvi.Selected = False


            Array.Resize(lvis, lvis.Length + 1)
            lvis(lvis.Length - 1) = lvi
            i += 1
            ProgressBar1.Value = CInt(100 * (i / (srs - 1)))
            Application.DoEvents()


        Next

        lstGlyph.Items.AddRange(lvis)
        lstGlyph.Items.Item(DictionaryIndex).EnsureVisible()
        lstGlyph.Items.Item(DictionaryIndex).Selected = True
        Me.Cursor = Cursors.Default
        Me.Text = "Dictionary of hieroglyphics (" & lstGlyph.Items.Count.ToString & " terms)"


    End Sub


    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        On Error Resume Next
        If txtSearch.Text.Trim = "" Then
            lstSearch.Visible = False
            lstGlyph.Visible = True
            lstSearch.Items.Clear()
            Exit Sub
        End If

        If e.KeyCode = Keys.Enter Then
            lstGlyph.Visible = False

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
                lv.SubItems.Add(lvis(z).SubItems(7).Text)

                lv.Tag = lvis(z).Tag
                lstSearch.Columns.Item(0).Text = "Loaded: " & (z + 1).ToString
            Next
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        AddGlyph()
    End Sub
    Private Sub AddGlyph()
        On Error Resume Next
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
            f.txtSimilar.Text = ""
            f.lblPath.Text = pth & i.ToString & ".png"
            f.Text = "()"

            f.Show()
        End If

    End Sub
    Private Sub ActivateItem(ByRef lstView As ListView)
        On Error Resume Next
        Dim lvi As ListViewItem = lstView.SelectedItems.Item(0)
        Dim f As New frmGlyphImage
        Dim pth As String = ""
        Dim x As String = lvi.Tag.ToString
        pth = Application.StartupPath & "\" & lvi.SubItems.Item(5).Text
        f.PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        f.PictureBox1.BackgroundImage = Bitmap.FromFile(pth)
        f.txtEnglish.Text = lvi.SubItems.Item(1).Text
        f.txtNative.Text = lvi.SubItems.Item(2).Text
        f.txtInfo.Text = lvi.SubItems.Item(3).Text
        f.txtSimilar.Text = lvi.SubItems.Item(4).Text
        f.lblPath.Text = pth
        f.Text = lvi.SubItems.Item(1).Text & " (" & lvi.SubItems.Item(2).Text & ")"
        f.Show()
    End Sub
    Friend Sub EditDictionarylistItem(ByVal dwIndex As Int32, ByVal lpEnglish As String, ByVal lpNative As String, ByVal lpInfo As String, ByVal lpSimilar As String, ByVal lpPath As String)
        If lstGlyph.Items.Count > 0 Then
            If lstGlyph.Items.Item(dwIndex).SubItems.Count > 0 Then
                'lstGlyph.Items.Item(dwIndex).SubItems.Item(0).Text = dwIndex
                lstGlyph.Items.Item(dwIndex).SubItems.Item(1).Text = lpEnglish
                lstGlyph.Items.Item(dwIndex).SubItems.Item(2).Text = lpNative
                lstGlyph.Items.Item(dwIndex).SubItems.Item(3).Text = lpInfo
                lstGlyph.Items.Item(dwIndex).SubItems.Item(4).Text = lpSimilar
                lstGlyph.Items.Item(dwIndex).SubItems.Item(5).Text = lpPath

            End If
        End If
    End Sub


    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim dres As New DialogResult
        dres = MessageBox.Show("Would you like to delete the selected entries from the dictionary?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dres = Windows.Forms.DialogResult.Yes Then
            If txtSearch.Text = "" Then
                For Each g As ListViewItem In lstGlyph.SelectedItems
                    DeleteDictionaryItem(g.SubItems(5).Text)
                    DictionaryIndex -= 1
                    g.Remove()
                Next
            Else
                For Each g As ListViewItem In lstSearch.SelectedItems
                    g.Remove()
                Next
            End If
            Me.Text = "Dictionary of hieroglyphics (" & lstGlyph.Items.Count.ToString & " terms)"
        End If

    End Sub
    Private Sub CombineTranslations()
        On Error Resume Next
        Dim lv(-1) As String

        For Each lvi1 As ListViewItem In frmGlyphManifest.lstGlyphs.Items
            Dim txtEng As String = lvi1.SubItems.Item(1).Text
            Dim txtNat As String = lvi1.SubItems.Item(2).Text
            For Each lvi2 As ListViewItem In frmGlyphManifest.lstGlyphs.Items
                If lvi1.Index <> lvi2.Index Then
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
    Friend Sub SaveDictionaryItems(ByRef lstView As ListView)
        On Error Resume Next
        Dim pth As String = Application.StartupPath & "\pictionary3.txt" '.Replace(".txt", "3.txt") '"\pictionary3.txt"
        Dim pth2 As String = Application.StartupPath & "\pictionary.txt" ' "\pictionary.txt"
        If IO.File.Exists(pth) = True Then IO.File.Delete(pth)
        Dim sw As New IO.StreamWriter(pth)
        For Each lvi As ListViewItem In lstView.Items
            Dim txt As String = lvi.SubItems.Item(1).Text & "|" & lvi.SubItems.Item(2).Text & "|" & lvi.SubItems.Item(3).Text & "|" & lvi.SubItems.Item(5).Text & "|" & lvi.SubItems.Item(4).Text
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
    End Sub
    Private Sub lstGlyph_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstGlyph.DragDrop
        lstGlyph.Items.Remove(lstGlyph.SelectedItems(0))
        Dim lp As New Drawing.Point(lstGlyph.PointToClient(MousePosition))
        Dim x As Int32 = lstGlyph.GetItemAt(lp.X, lp.Y).Index
        DictionaryIndex = x
    End Sub
    Private mvarIndex As Int32 = 0

    Private Sub btnMoveUp_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMoveUp.MouseDown
        If lstGlyph.SelectedItems.Count = 0 Then Exit Sub
        navigatingup = True

        If txtSearch.Text = "" Then
            Navup(lstGlyph)
        Else
            Navup(lstSearch)
        End If

        navtck = Environment.TickCount

    End Sub
    Private Sub btnMoveUp_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMoveUp.MouseUp
        navigatingup = False
        If txtSearch.Text = "" Then
            SaveDictionaryItems(lstGlyph)
        Else
            SaveDictionaryItems(lstSearch)
        End If
    End Sub
    Private Sub btnMoveDown_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMoveDown.MouseDown
        If lstGlyph.SelectedItems.Count = 0 Then Exit Sub
        navigatingdown = True


        If txtSearch.Text = "" Then
            NavDn(lstGlyph)
        Else
            NavDn(lstSearch)
        End If

        navtck = Environment.TickCount

    End Sub
    Private Sub btnMoveDown_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMoveDown.MouseUp
        navigatingdown = False
        If txtSearch.Text = "" Then
            SaveDictionaryItems(lstGlyph)
        Else
            SaveDictionaryItems(lstSearch)
        End If
    End Sub
    Private Sub btnMoveFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveFirst.Click

        If txtSearch.Text = "" Then
            MoveFirst(lstGlyph)
        Else
            MoveFirst(lstSearch)
        End If
    End Sub
    Private Sub btnMoveLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveLast.Click
        If txtSearch.Text = "" Then
            MoveLast(lstGlyph)
        Else
            MoveLast(lstSearch)
        End If
    End Sub
    Private Sub MoveFirst(ByRef lstView As ListView)
        If lstView.SelectedItems.Count = 0 Then Exit Sub
        Dim x As ListView.SelectedIndexCollection = lstView.SelectedIndices
        Dim xi As Int32 = x.Item(0)
        If xi = 0 Then Exit Sub
        Dim xc As Int32 = x.Count
        Dim lvis(-1) As ListViewItem
        For i As Int32 = ((xi + xc) - 1) To xi Step -1
            Array.Resize(lvis, lvis.Length + 1)
            lvis(lvis.Length - 1) = lstView.Items.Item(i).Clone
        Next
        For i As Int32 = 1 To xc
            lstView.Items.Item(xi).Remove()
        Next
        Application.DoEvents()
        Threading.Thread.Sleep(0)
        Dim z As Int32 = 0
        For i As Int32 = ((xi + xc) - 1) To xi Step -1
            lstView.Items.Insert(0, lvis(z).Clone)
            z += 1
        Next
        For j As Int32 = 0 To xc - 1
            lstView.Items.Item(j).Selected = True
            DictionaryIndex = j
            lstView.Items.Item(j).EnsureVisible()
        Next
        SaveDictionaryItems(lstView)
    End Sub
    Private Sub MoveLast(ByRef lstView As ListView)
        If lstView.SelectedItems.Count = 0 Then Exit Sub
        Dim x As ListView.SelectedIndexCollection = lstView.SelectedIndices
        Dim a As Int32 = 1
        Dim xi As Int32 = x.Item(0)
        Dim xc As Int32 = x.Count
        If x.Item(x.Count - 1) = lstView.Items.Count - 1 Then Exit Sub
        Dim ec As Int32 = lstView.Items.Count - 1
        For z As Int32 = x.Count - 1 To 0 Step -1
            Dim i As Int32 = x.Item(z)
            lstView.Items.Insert(ec + 1, lstView.Items.Item(i).Clone)
        Next
        For z As Int32 = 0 To x.Count - 1
            lstView.Items.RemoveAt(x.Item(0))
        Next
        Application.DoEvents()
        Threading.Thread.Sleep(0)
        For z As Int32 = (ec - xc) + 1 To ec
            lstView.Items.Item(z).Selected = True
            DictionaryIndex = z
            lstView.Items.Item(z).EnsureVisible()
        Next
        SaveDictionaryItems(lstView)
    End Sub


    Private Sub Navup(ByRef lstView As ListView)

        If lstView.SelectedItems.Count = 0 Then Exit Sub
        Dim x As ListView.SelectedIndexCollection = lstView.SelectedIndices

        Dim xi As Int32 = x.Item(0)
        If xi = 0 Then Exit Sub
        Dim xc As Int32 = x.Count
        Dim lvis(-1) As ListViewItem
        For i As Int32 = ((xi + xc) - 1) To xi Step -1
            Array.Resize(lvis, lvis.Length + 1)
            lvis(lvis.Length - 1) = lstView.Items.Item(i).Clone
        Next
        For i As Int32 = 1 To xc
            lstView.Items.Item(xi).Remove()
        Next
        Application.DoEvents()
        Threading.Thread.Sleep(0)
        lstView.Refresh()

        Dim z As Int32 = 0
        For i As Int32 = ((xi + xc) - 1) To xi Step -1
            Try
                lstView.Items.Insert(xi - 1, lvis(z).Clone)
                z += 1
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & vbCrLf & i.ToString)
            End Try
        Next
        For j As Int32 = xi - 1 To (xi + xc) - 2
            lstView.Items.Item(j).Selected = True
            DictionaryIndex = j
            lstView.Items.Item(j).EnsureVisible()
            lstView.Items.Item(j).Selected = True
            lstView.Items.Item(j).Focused = True
        Next
    End Sub
    Private Sub NavDn(ByRef lstView As ListView)
        If lstView.SelectedItems.Count = 0 Then Exit Sub
        Dim x As ListView.SelectedIndexCollection = lstView.SelectedIndices
        Dim a As Int32 = 1
        Dim xi As Int32 = x.Item(0)
        Dim xc As Int32 = x.Count
        If x.Item(x.Count - 1) = lstView.Items.Count - 1 Then Exit Sub

        For z As Int32 = x.Count - 1 To 0 Step -1
            Dim i As Int32 = x.Item(z)
            lstView.Items.Insert(i + a + 1, lstView.Items.Item(i).Clone)
            a += 1
        Next
        For z As Int32 = 0 To x.Count - 1
            lstView.Items.RemoveAt(x.Item(0))
        Next
        Application.DoEvents()
        Threading.Thread.Sleep(0)
        lstView.Refresh()

        For z As Int32 = xi + 1 To xi + xc
            lstView.Items.Item(z).Selected = True
            DictionaryIndex = z
            lstView.Items.Item(z).EnsureVisible()
            lstView.Items.Item(z).Selected = True
            lstView.Items.Item(z).Focused = True
        Next
    End Sub
    Private Sub lstGlyph_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lstGlyph.ItemSelectionChanged
        If e.IsSelected = True Then
            DictionaryIndex = e.ItemIndex
        End If
    End Sub
    Private Sub lstGlyph_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstGlyph.ItemActivate
        ActivateItem(lstGlyph)
    End Sub
    Private Sub lstSearch_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSearch.ItemActivate
        ActivateItem(lstSearch)
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

    Private Sub lstSearch_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstSearch.ColumnClick
        On Error Resume Next
        If lstSearch.Items.Count = 0 OrElse lstSearch.Columns.Count = 0 Then Exit Sub

        If e.Column = lvwColumnSorter2.SortColumn Then  ' Determine if clicked column is already the column that is being sorted.
            If lvwColumnSorter2.Order = SortOrder.Ascending Then ' Reverse the current sort direction for this column.
                lvwColumnSorter2.Order = SortOrder.Descending
            Else
                lvwColumnSorter2.Order = SortOrder.Ascending
            End If
        Else ' Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter2.SortColumn = e.Column
            lvwColumnSorter2.Order = SortOrder.Ascending
        End If
        lstSearch.Sort() ' Perform the sort with these new sort options.
    End Sub
    Private Sub JumpToHieroglyphToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmGlyphManifest.Show()
    End Sub

    Private Sub AddHieroglyphToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AddGlyph()
    End Sub


    Private Sub chkGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGroup.CheckedChanged

        If txtSearch.Text = "" Then
            If chkGroup.Checked = True Then
                Dim grps(-1) As ListViewGroup
                For j As Int32 = 0 To lstGlyph.Items.Count - 1
                    Dim b As Boolean = False
                    For Each g As ListViewGroup In grps
                        If g.Header.ToLower.Trim = lstGlyph.Items.Item(j).SubItems.Item(4).Text.ToLower.Trim Then
                            b = True
                        End If
                    Next
                    If b = False Then
                        Array.Resize(grps, grps.Length + 1)
                        grps(grps.Length - 1) = New ListViewGroup(lstGlyph.Items.Item(j).SubItems.Item(4).Text.ToLower.Trim, HorizontalAlignment.Left)
                        lstGlyph.Groups.Add(grps(grps.Length - 1))
                    End If
                    For z As Int32 = 0 To grps.Length - 1
                        If grps(z).Header.ToLower.Trim = lstGlyph.Items.Item(j).SubItems.Item(4).Text.ToLower.Trim Then
                            lstGlyph.Items.Item(j).Group = grps(z)

                        End If
                    Next

                Next
            Else
                For j As Int32 = 0 To lstGlyph.Items.Count - 1
                    lstGlyph.Items.Item(j).Group = Nothing
                Next
            End If
            lstGlyph.Sort()
        Else

            If chkGroup.Checked = True Then
                Dim grps(-1) As ListViewGroup
                For j As Int32 = 0 To lstSearch.Items.Count - 1
                    Dim b As Boolean = False
                    For Each g As ListViewGroup In grps
                        If g.Header.ToLower.Trim = lstSearch.Items.Item(j).SubItems.Item(4).Text.ToLower.Trim Then
                            b = True
                        End If
                    Next
                    If b = False Then
                        Array.Resize(grps, grps.Length + 1)
                        grps(grps.Length - 1) = New ListViewGroup(lstSearch.Items.Item(j).SubItems.Item(4).Text.ToLower.Trim, HorizontalAlignment.Left)
                        lstSearch.Groups.Add(grps(grps.Length - 1))
                    End If
                    For z As Int32 = 0 To grps.Length - 1
                        If grps(z).Header.ToLower.Trim = lstSearch.Items.Item(j).SubItems.Item(4).Text.ToLower.Trim Then
                            lstSearch.Items.Item(j).Group = grps(z)

                        End If
                    Next

                Next
            Else
                For j As Int32 = 0 To lstSearch.Items.Count - 1
                    lstSearch.Items.Item(j).Group = Nothing
                Next
            End If
        End If
        lstSearch.Sort()

    End Sub
    

End Class