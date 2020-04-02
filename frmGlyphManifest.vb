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
        'Environment.Exit(0)

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

        'Dim th As String = Application.StartupPath & "\pictionary.txt"
        'Dim sr2 As New IO.StreamReader(th)
        'Dim lns() As String = sr2.ReadToEnd.Split(vbCrLf)
        'sr2.Close()
        'Dim th2 As String = Application.StartupPath & "\newpic.txt"
        'Dim sw As New IO.StreamWriter(th2)



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




                        'Dim b As Boolean = False
                        'For Each ln As String In lns

                        '    Try
                        '        Dim par() As String = ln.Split("|")
                        '        ' MsgBox(i.ToString & " - " & par.Length.ToString)

                        '        If par.Length >= 4 AndAlso par(3).Replace(vbCrLf, "").Replace(vbCr, "").Replace(vbLf, "") = pth Then
                        '            b = True
                        '            Exit For
                        '        End If
                        '    Catch ex As Exception
                        '        MsgBox(ex.Message)
                        '    End Try

                        'Next

                        'If b = False Then


                        '    sw.WriteLine(lvi.SubItems.Item(1).Text & "|" & lvi.SubItems.Item(2).Text & "|" & lvi.SubItems.Item(3).Text & "|" & pth & "|" & prys(j))
                        '    sw.Flush()
                        'End If

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
        'If ListView2.Items.Count = 0 OrElse ListView2.Columns.Count = 0 Then Exit Sub

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
    Private Sub AddHieroglyphToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddHieroglyphToolStripMenuItem.Click
   
    End Sub
    Private Sub DeleteHieroglyphToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteHieroglyphToolStripMenuItem.Click

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
        modFriend.spash = False
        SplashScreen1.Close()
        Dim f As New frmPictionary
        f.Tag = "\unsorted.txt"
        f.Show()
        'f.TopMost = True
        'f.TopMost = False
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
    'Dim s As Size = Image.FromFile(pth).Size
    'If s.Width > s.Height Then s.Height = s.Width
    'If s.Height > s.Width Then s.Width = s.Height
    'Dim b As New Bitmap(s.Width, s.Height)
    'b = ResizeImage(Image.FromFile(pth), s.Width, s.Height)
    'b.Save(pth.Replace(".bmp", ".png"), Imaging.ImageFormat.Png)

    'Private Sub daaedsf()
    '    On Error Resume Next
    '    Dim pth As String = Application.StartupPath & "\NativeToEnglishTranslations.txt"
    '    Dim sr As New IO.StreamReader(pth)
    '    Dim lnsTrans() As String = sr.ReadToEnd.Split(vbCrLf)
    '    sr.Close()

    '    pth = Application.StartupPath & "\pictionary.txt"
    '    sr = New IO.StreamReader(pth)
    '    Dim lnsPic() As String = sr.ReadToEnd.Split(vbCrLf)
    '    sr.Close()

    '    pth = Application.StartupPath & "\pic2.txt"
    '    Dim sw As New IO.StreamWriter(pth)

    '    For Each lnP As String In lnsPic
    '        Dim p() As String = lnP.Split("|") 'parameters for glyph
    '        If p.Length > 3 Then 'if params were found
    '            Dim txt As String = "" ' lnP 'initialize output for line
    '            Dim pengs() As String = p(0).Split(";")
    '            Dim pnats() As String = p(1).Split(";")

    '            For Each pnat As String In pnats

    '                For Each tra As String In lnsTrans
    '                    Dim tras() As String = tra.Split("|")

    '                    If tras(0).ToLower.Replace(".", "").Replace(",", "").Trim = pnat.ToLower.Replace(".", "").Replace(",", "").Trim Then

    '                        ' p(0) = tras(1)

    '                        Dim zz() As String = p(0).Split(";")
    '                        Dim ts() As String = tras(1).Split(";")

    '                        For Each t As String In ts
    '                            Dim b As Boolean = False
    '                            For Each z As String In zz
    '                                If t.ToLower.Replace(".", "").Replace(",", "").Trim = z.ToLower.Replace(".", "").Replace(",", "").Trim Then
    '                                    b = True
    '                                End If
    '                            Next
    '                            If b = False Then p(0) &= ";" & t
    '                        Next

    '                        'For Each peng As String In pengs


    '                        '   
    '                        '    Dim b As Boolean = False
    '                        '    For Each z As String In zz

    '                        '        If z.ToLower.Replace(".", "").Replace(",", "").Trim = peng.ToLower.Replace(".", "").Replace(",", "").Trim Then
    '                        '            b = True
    '                        '        End If
    '                        '    Next
    '                        '    If b = False Then
    '                        '        '  MsgBox(p(0) & vbCrLf & vbCrLf & peng.ToLower.Replace(".", "").Replace(",", "").Trim)
    '                        '        p(0) &= ";" & peng.ToLower.Replace(".", "").Replace(",", "").Trim
    '                        '    End If

    '                        'Next
    '                    End If
    '                Next
    '            Next
    '            '  If eng <> "" AndAlso eng.Substring(0, 1) = ";" Then eng = eng.Substring(1)

    '            If My.Computer.Keyboard.ShiftKeyDown = True Then Exit For
    '            txt = p(0) & "|" & p(1) & "|" & p(2) & "|" & p(3) & "|" & p(4)

    '            sw.WriteLine(txt.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, ""))
    '        End If
    '    Next
    '    sw.Close()
    'End Sub
    ''Private Sub daaedsf()
    ''    On Error Resume Next
    ''    Dim pth As String = Application.StartupPath & "\NativeToEnglishTranslations.txt"
    ''    Dim sr As New IO.StreamReader(pth)
    ''    Dim lns() As String = sr.ReadToEnd.Split(vbCrLf)
    ''    sr.Close()

    ''    pth = Application.StartupPath & "\pictionary.txt"
    ''    sr = New IO.StreamReader(pth)
    ''    Dim lns2() As String = sr.ReadToEnd.Split(vbCrLf)
    ''    sr.Close()

    ''    pth = Application.StartupPath & "\pic2.txt"
    ''    Dim sw As New IO.StreamWriter(pth)

    ''    For Each ln2 As String In lns2
    ''        Dim p() As String = ln2.Split("|") 'parameters for glyph
    ''        If p.Length > 0 Then 'if params were found
    ''            Dim txt As String = ln2 'initialize output for line
    ''            Dim eng As String = p(0) 'initialize any existing english translations
    ''            For Each ln As String In lns 'loop through translations looking for matches
    ''                Dim t() As String = ln.Split("|") 'translations have two params
    ''                If t.Length > 0 Then 'if params were found
    ''                    Dim c1() As String = p(1).Split(";") 'pictionary native array
    ''                    Dim c2() As String = t(0).Split(";") 'translation native array

    ''                    If c1.Length > 0 AndAlso c2.Length > 0 Then

    ''                        For Each c1b As String In c1
    ''                            For Each c2b As String In c2
    ''                                If c1b.ToLower.Trim = c2b.ToLower.Trim Then

    ''                                    Dim eg() As String = eng.Split(";")
    ''                                    If eg.Contains(c2b.ToLower.Trim) = False Then
    ''                                        eng &= ";" & c2b.ToLower.Trim

    ''                                    End If
    ''                                End If
    ''                            Next
    ''                        Next
    ''                    End If
    ''                End If
    ''            Next
    ''            txt = eng & "|" & p(0) & "|" & p(1) & "|" & p(2) & "|" & p(3) & "|" & p(4) & "|" & p(5) & "|" & p(5)
    ''            sw.WriteLine(txt.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, ""))
    ''        End If
    ''    Next
    ''    sw.Close()
    ''End Sub
    'Private Sub doit()

    '    Dim pth As String = Application.StartupPath & "\pictionary.txt"
    '    Dim pth2 As String = Application.StartupPath & "\pictionary2.txt"
    '    Dim pth3 As String = Application.StartupPath & "\pictionary3.txt"
    '    Dim lns(-1) As String
    '    Dim sr As New IO.StreamReader(pth2)
    '    Do
    '        If sr.EndOfStream = True Then Exit Do
    '        Dim inp As String = sr.ReadLine
    '        If inp.Trim <> "" Then
    '            Array.Resize(lns, lns.Length + 1)
    '            lns(lns.Length - 1) = inp.Trim
    '        End If
    '    Loop
    '    sr.Close()
    '    '
    '    Dim sw3 As New IO.StreamWriter(pth3)
    '    sr = New IO.StreamReader(pth)
    '    Dim z As Int32 = 0
    '    Do
    '        If sr.EndOfStream = True Then Exit Do
    '        Dim inp As String = sr.ReadLine.Trim
    '        If inp <> "" Then
    '            If inp.IndexOf("|") <> -1 Then
    '                Dim s() As String = inp.Split("|")
    '                If s(1) = "" Then
    '                    sw3.WriteLine(inp & lns(z))
    '                    z += 1
    '                Else
    '                    sw3.WriteLine(inp)
    '                End If
    '            End If
    '        End If
    '    Loop
    '    sr.Close()
    '    sw3.Close()
    'End Sub
    'Private Sub Translate()
    '    Dim pth2 As String = Application.StartupPath & "\pictionary.txt"
    '    Dim sr2 As New IO.StreamReader(pth2)
    '    Dim lns() As String = sr2.ReadToEnd.Split(vbCrLf)
    '    sr2.Close()
    '    Dim i As Int32 = 0
    '    Dim pth As String = ""
    '    For j As Int32 = 0 To prys.Length - 1
    '        pth = Application.StartupPath & "\PRAYERS\" & prys(j) & "\txt.txt"
    '        If IO.File.Exists(pth) = True Then
    '            Try
    '                Dim sr As New IO.StreamReader(pth)
    '                Do
    '                    Dim inp As String = sr.ReadLine
    '                    If inp.Trim <> "" Then
    '                        Array.Resize(prayerlines, prayerlines.Length + 1)
    '                        prayerlines(prayerlines.Length - 1) = inp
    '                    End If
    '                Loop
    '                sr.Close()
    '            Catch ex As Exception
    '            End Try
    '        End If
    '    Next

    '    Dim np(-1) As String

    '    For j As Int32 = 0 To prys.Length - 1
    '        Dim n As Int32 = 1
    '        Do
    '            pth = Application.StartupPath & "\PRAYERS\" & prys(j) & "\" & n.ToString & ".png"
    '            If IO.File.Exists(pth) = False Then Exit Do
    '            n += 1
    '            Try
    '                If prayerlines(i).IndexOf("|") = -1 Then prayerlines(i) = prayerlines(i).Trim & "|"
    '                Dim wrds() As String = prayerlines(i).Split("|")
    '                If wrds.Length > 0 Then
    '                    Dim x As Int32 = 0
    '                    For Each pl As String In prayerlines
    '                        If pl.ToLower.Replace(".", "").Replace("?", "").Replace(":", "").Replace(",","").Trim.IndexOf(wrds(0).ToLower.Replace(".", "").Replace("?", "").Replace(":", "").Replace(",","").Trim & "|") <> -1 Then ' & wrds(1).Replace(".", "").Replace("?", "").Replace(":", "").Replace(",","").ToLower.Trim Then
    '                            x += 1
    '                        End If
    '                    Next


    '                    i += 1

    '                    Array.Resize(np, np.Length + 1)
    '                    np(np.Length - 1) = wrds(1) & "|" & pth

    '                End If
    '            Catch ex As Exception
    '            End Try
    '        Loop
    '    Next



    '    For z As Int32 = 0 To lns.Length - 1
    '        Dim ss() As String = lns(z).Split("|")

    '        If ss.Length > 1 Then
    '            If ss(1).Trim = "" Then

    '                For Each f As String In np
    '                    Dim ps() As String = f.Split("|")
    '                    If ps.Length > 1 Then
    '                        If lns(z).IndexOf(ps(1)) <> -1 Then
    '                            Dim x() As String = lns(z).Split("|")
    '                            If x.Length > 4 Then
    '                                'lns(z) = x(0) & "|" & ps(0) & "|" & x(2) & "|" & x(3) & "|" & x(4) & "|" & x(5) & "|" & x(6)
    '                                lns(z) = x(0) & "|" & ps(0) & "|" & x(2) & "|" & x(3) & "|" & x(4)
    '                            End If

    '                            Exit For
    '                        End If
    '                    End If

    '                Next


    '            End If
    '        End If

    '    Next


    '    pth2 = Application.StartupPath & "\pic2.txt"
    '    Dim sw As New IO.StreamWriter(pth2)
    '    For Each ln As String In lns
    '        sw.WriteLine(ln.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, ""))
    '    Next
    '    sw.Close()

    'End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class
