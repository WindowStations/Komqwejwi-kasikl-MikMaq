Public Class frmGlyphManifest
    Private lvwColumnSorter As New ListViewColumnSorter()
    Private lvwColumnSorter2 As New ListViewColumnSorter()
    Friend prayerlines(-1) As String
    Private ispainted As Boolean = False
    Friend prys() As String = {"01TheSignOfTheCross", "02TheLordsPrayer", "03TheAngelicalSalutation", "04TheApostlesCreed", "05TheDecalogue", "06ThePreceptsOfTheChurch", "07AnActOfFaith", "08AnActOfHope", "09AnActOfCharity", "10Thanksgiving", "11AnActOfContrition", "12TheConfiteor", "13ALongerActOfContrition", "14GraceBeforeMeals", "15GraceAfterMeals", "16MorningPrayer", "17LitanyOfTheHolyName", "18TheSacraments", "19Baptism", "20Confirmation", "21TheBlessedEucharist", "22Penance", "23Purgatory", "24ExtremeUnction", "25HolyOrders", "26Matrimony", "27ThePassionOfOurLord"}
    Private thLoad As New Threading.Thread(AddressOf LoadPrayers)
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lvwColumnSorter = New ListViewColumnSorter()
        lvwColumnSorter2 = New ListViewColumnSorter()
        lstGlyphs.ListViewItemSorter = lvwColumnSorter
        lstSearch.ListViewItemSorter = lvwColumnSorter2
    End Sub
    Private Sub frmGlyphManifest_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        thLoad.Abort()
    End Sub
    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If ispainted = True Then Exit Sub
        ispainted = True
        thLoad = New Threading.Thread(AddressOf LoadPrayers)
        thLoad.Start()
    End Sub
    Private Sub LoadPrayers()
        lstGlyphs.Items.Clear()
        lstSearch.Items.Clear()
        ImageList1.Images.Clear()
        Array.Resize(prayerlines, 0)
        Dim i As Int32 = 0
        Dim pth As String = ""
        For j As Int32 = 0 To prys.Length - 1
            pth = Application.StartupPath & "\PRAYERS\" & prys(j) & "\txt.txt"
            If IO.File.Exists(pth) = True Then
                Try
                    Dim sr As New IO.StreamReader(pth)
                    Do
                        Dim inp As String = sr.ReadLine
                        If inp.Trim <> "" Then
                            Array.Resize(prayerlines, prayerlines.Length + 1)
                            prayerlines(prayerlines.Length - 1) = inp
                        End If
                    Loop
                    sr.Close()
                Catch ex As Exception
                End Try
            End If
        Next


        Dim t As Int32 = Environment.TickCount
        Dim lvis(-1) As ListViewItem
        For j As Int32 = 0 To prys.Length - 1
            Dim n As Int32 = 1
            Do
                pth = Application.StartupPath & "\PRAYERS\" & prys(j) & "\" & n.ToString & ".png"
                If IO.File.Exists(pth) = False Then Exit Do
                n += 1
                Try
                    If prayerlines(i).IndexOf("|") = -1 Then prayerlines(i) = prayerlines(i).Trim & "|"
                    Dim wrds() As String = prayerlines(i).Split("|")
                    If wrds.Length > 0 Then
                        Dim lvi As New ListViewItem ' = lstGlyphs.Items.Add(i.ToString)
                        lvi.Text = i.ToString
                        lvi.Tag = n - 1
                        If n = 2 Then lvi.BackColor = Color.Gray
                        lvi.ImageKey = i.ToString
                        ImageList1.Images.Add(i.ToString, Image.FromFile(pth))
                        Dim x As Int32 = 0
                        For Each pl As String In prayerlines
                            Dim pls() As String = pl.Split("|")

                            If pls(0).ToLower.Replace(".", "").Replace("?", "").Replace(":", "").Replace(",", "").Trim = wrds(0).ToLower.Replace(".", "").Replace("?", "").Replace(":", "").Replace(",", "").Trim Then ' & wrds(1).Replace(".", "").Replace("?", "").Replace(":", "").Replace(",","").ToLower.Trim Then
                                x += 1
                            End If
                        Next
                        lvi.SubItems.Add(wrds(0).Replace(".", "").Replace("?", "").Replace(":", "").Replace(",", "").Trim)
                        lvi.SubItems.Add(wrds(1).Replace(".", "").Replace("?", "").Replace(":", "").Replace(",", "").Trim)
                        If wrds.Length >= 3 Then
                            lvi.SubItems.Add(wrds(2))
                        Else
                            lvi.SubItems.Add("none")
                        End If
                        lvi.SubItems.Add(x.ToString)
                        If wrds.Length >= 4 Then
                            lvi.SubItems.Add(wrds(3))
                        Else
                            lvi.SubItems.Add((n - 1).ToString)
                        End If
                        lvi.SubItems.Add(prys(j))
                        Array.Resize(lvis, lvis.Length + 1)
                        lvis(lvis.Length - 1) = lvi
                        lblglyphsloaded.Text = "Glyphs loaded:   " & (i + 1).ToString
                        i += 1


                    End If
                Catch ex As Exception
                End Try
                If Environment.TickCount - t >= 1200 Then
                    t = Environment.TickCount
                    ProgressBar1.Value = CInt(100 * (i / (prayerlines.Length - 1)))
                    Application.DoEvents()
                End If
            Loop
        Next
        ' sw.Close()
        If lvis.Length > 0 Then lstGlyphs.Items.AddRange(lvis)
        ProgressBar1.Visible = False
    End Sub
    Private Sub lstGlyphs_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstGlyphs.ColumnClick
        On Error Resume Next
        If lstGlyphs.Items.Count = 0 OrElse lstGlyphs.Columns.Count = 0 Then Exit Sub

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
        lstGlyphs.Sort() ' Perform the sort with these new sort options.
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
    Private Sub lstGlyphs_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lstGlyphs.ItemSelectionChanged
        If e.IsSelected = True Then
            ' ManifestIndex = e.ItemIndex
        End If
    End Sub
    Private Sub lstSearch_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lstSearch.ItemSelectionChanged
        If e.IsSelected = True Then
            'SearchIndex = e.ItemIndex
        End If
    End Sub
    Private Sub lstGlyphs_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstGlyphs.ItemActivate
        On Error Resume Next
        Dim lvi As ListViewItem = lstGlyphs.SelectedItems.Item(0)
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
    Private Sub lstSearch_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSearch.ItemActivate
        On Error Resume Next
        Dim lvi As ListViewItem = lstSearch.SelectedItems.Item(0)
        Dim f As New frmGlyphImage
        Dim pth As String = ""
        Dim x As String = lvi.Tag.ToString  ' lvi.SubItems.Item(0).Text
        pth = Application.StartupPath & "\PRAYERS\" & lvi.SubItems.Item(6).Text
        f.PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        f.PictureBox1.BackgroundImage = Bitmap.FromFile(pth & "\" & x & ".png")
        DictionaryIndex = lstSearch.SelectedIndices(0)
        f.txtEnglish.Text = lvi.SubItems.Item(1).Text
        f.txtNative.Text = lvi.SubItems.Item(2).Text
        f.txtInfo.Text = lvi.SubItems.Item(3).Text
        f.lblPrayer.Text = lvi.SubItems.Item(6).Text
        f.lblPath.Text = pth & "\" & x & ".png"
        f.Text = lvi.SubItems.Item(1).Text & " (" & lvi.SubItems.Item(2).Text & ")"
        f.Show()
    End Sub

    Private Sub ViewEditHieroglyphToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewEditHieroglyphToolStripMenuItem.Click
        If lstSearch.Visible = True Then
            lstSearch_ItemActivate(sender, e)
        Else
            lstGlyphs_ItemActivate(sender, e)
        End If
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
            For i As Int32 = 0 To lstGlyphs.Items.Count - 1
                Dim x As String = lstGlyphs.Items.Item(i).SubItems(1).Text.ToLower
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
                    lvis(lvis.Length - 1) = lstGlyphs.Items(i)
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
    Private Sub ComboBox1_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectionChangeCommitted
        On Error Resume Next
        Dim x As Int32 = ComboBox1.SelectedIndex
        x = GetPrayerIndex(x)
        lstGlyphs.TopItem = lstGlyphs.Items.Item(x)
        '1,8,57,85,194,268 331 388 426 454 493 520 631 694 715 744 998 1296 1329 1666 1836 2069 2708 2763 2846 2996 3251
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        txtSearch.Text = "think thought remember mourn envision decide"
        txtSearch.Focus()
        SendKeys.Send("{enter}")
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        txtSearch.Text = "say saying spoke said told telling answer respond ask asked abused leave judas plead quitely forgive deny -forgiveness -sinfully"
        txtSearch.Focus()
        SendKeys.Send("{enter}")
    End Sub
    Private Sub RadioButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.Click
        txtSearch.Text = "here there -where -put -everywhere -forever -go -therefore -takes -nowhere -governs -gather -those -nailed -king -time -people -many -from -prayed -envision -comes -one"
        txtSearch.Focus()
        SendKeys.Send("{enter}")
    End Sub
    Private Sub RadioButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.Click
        txtSearch.Text = "see look saw raise eye covered -seek -medicine -blood -beseech -himself -right -native -everywhere"
        txtSearch.Focus()
        SendKeys.Send("{enter}")
    End Sub
    Private Sub RadioButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.Click
        txtSearch.Text = "earth bury buried underground tomb world"
        txtSearch.Focus()
        SendKeys.Send("{enter}")
    End Sub
    Private Sub RadioButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton6.Click
        txtSearch.Text = "he -then -here -there -the -heaven -henceforth -hey -when -herod -head -heart -hear -blaspheme -helpless -teacher -they -help -heal -heavy"
        txtSearch.Focus()
        SendKeys.Send("{enter}")
    End Sub
    Private Sub btnUnsorted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim f As New frmPictionary
        f.Tag = "\unsorted.txt"
        f.Show()

    End Sub

    Private Function GetPrayerIndex(ByVal x As Int32) As Int32
        If x = 0 Then Return 0
        If x = 1 Then Return 7
        If x = 2 Then Return 56
        If x = 3 Then Return 84
        If x = 4 Then Return 193
        If x = 5 Then Return 267
        If x = 6 Then Return 330
        If x = 7 Then Return 387
        If x = 8 Then Return 425
        If x = 9 Then Return 453
        If x = 10 Then Return 492
        If x = 11 Then Return 519
        If x = 12 Then Return 630
        If x = 13 Then Return 693
        If x = 14 Then Return 714
        If x = 15 Then Return 743
        If x = 16 Then Return 997
        If x = 17 Then Return 1294
        If x = 18 Then Return 1328 'baptism
        If x = 19 Then Return 1665
        If x = 20 Then Return 1835
        If x = 21 Then Return 2068
        If x = 22 Then Return 2707
        If x = 23 Then Return 2762
        If x = 24 Then Return 2845
        If x = 25 Then Return 2995
        If x = 26 Then Return 3250
    End Function
    Public Overloads Shared Function ResizeImage(ByVal SourceImage As Drawing.Image, ByVal TargetWidth As Int32, ByVal TargetHeight As Int32) As Drawing.Bitmap
        Dim bmSource = New Drawing.Bitmap(SourceImage)
        Return ResizeImage(bmSource, TargetWidth, TargetHeight)
    End Function
    Public Overloads Shared Function ResizeImage(ByVal bmSource As Drawing.Bitmap, ByVal TargetWidth As Int32, ByVal TargetHeight As Int32) As Drawing.Bitmap
        Dim bmDest As New Drawing.Bitmap(TargetWidth, TargetHeight, Drawing.Imaging.PixelFormat.Format32bppArgb)

        Dim nSourceAspectRatio = bmSource.Width / bmSource.Height
        Dim nDestAspectRatio = bmDest.Width / bmDest.Height

        Dim NewX = 0
        Dim NewY = 0
        Dim NewWidth = bmDest.Width
        Dim NewHeight = bmDest.Height

        If nDestAspectRatio = nSourceAspectRatio Then
            'same ratio
        ElseIf nDestAspectRatio > nSourceAspectRatio Then
            'Source is taller
            NewWidth = Convert.ToInt32(Math.Floor(nSourceAspectRatio * NewHeight))
            NewX = Convert.ToInt32(Math.Floor((bmDest.Width - NewWidth) / 2))
        Else
            'Source is wider
            NewHeight = Convert.ToInt32(Math.Floor((1 / nSourceAspectRatio) * NewWidth))
            NewY = Convert.ToInt32(Math.Floor((bmDest.Height - NewHeight) / 2))
        End If

        Using grDest = Drawing.Graphics.FromImage(bmDest)
            With grDest
                .CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                .InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                .PixelOffsetMode = Drawing.Drawing2D.PixelOffsetMode.HighQuality
                .SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias
                .CompositingMode = Drawing.Drawing2D.CompositingMode.SourceOver

                .DrawImage(bmSource, NewX, NewY, NewWidth, NewHeight)
            End With
        End Using

        Return bmDest
    End Function


End Class
