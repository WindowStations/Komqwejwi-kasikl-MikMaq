<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGlyphManifest
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGlyphManifest))
        Me.lstGlyphs = New System.Windows.Forms.ListView
        Me.colGlyph1 = New System.Windows.Forms.ColumnHeader
        Me.colEnglish1 = New System.Windows.Forms.ColumnHeader
        Me.colNative1 = New System.Windows.Forms.ColumnHeader
        Me.colInfo1 = New System.Windows.Forms.ColumnHeader
        Me.colFrequency1 = New System.Windows.Forms.ColumnHeader
        Me.colAppears1 = New System.Windows.Forms.ColumnHeader
        Me.colPrayer1 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewEditHieroglyphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddHieroglyphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteHieroglyphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.lblSearch = New System.Windows.Forms.Label
        Me.lstSearch = New System.Windows.Forms.ListView
        Me.colGlyph = New System.Windows.Forms.ColumnHeader
        Me.colEnglish = New System.Windows.Forms.ColumnHeader
        Me.colNative = New System.Windows.Forms.ColumnHeader
        Me.colInfo = New System.Windows.Forms.ColumnHeader
        Me.colFrequency = New System.Windows.Forms.ColumnHeader
        Me.colAppears = New System.Windows.Forms.ColumnHeader
        Me.colPrayer = New System.Windows.Forms.ColumnHeader
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.RadioButton6 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblglyphsloaded = New System.Windows.Forms.Label
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstGlyphs
        '
        Me.lstGlyphs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstGlyphs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colGlyph1, Me.colEnglish1, Me.colNative1, Me.colInfo1, Me.colFrequency1, Me.colAppears1, Me.colPrayer1})
        Me.lstGlyphs.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lstGlyphs.FullRowSelect = True
        Me.lstGlyphs.LargeImageList = Me.ImageList1
        Me.lstGlyphs.Location = New System.Drawing.Point(12, 95)
        Me.lstGlyphs.Name = "lstGlyphs"
        Me.lstGlyphs.Size = New System.Drawing.Size(829, 426)
        Me.lstGlyphs.SmallImageList = Me.ImageList1
        Me.lstGlyphs.StateImageList = Me.ImageList1
        Me.lstGlyphs.TabIndex = 7
        Me.lstGlyphs.UseCompatibleStateImageBehavior = False
        Me.lstGlyphs.View = System.Windows.Forms.View.Details
        '
        'colGlyph1
        '
        Me.colGlyph1.Text = "Glyph"
        Me.colGlyph1.Width = 250
        '
        'colEnglish1
        '
        Me.colEnglish1.Text = "English text"
        Me.colEnglish1.Width = 150
        '
        'colNative1
        '
        Me.colNative1.Text = "Native text"
        Me.colNative1.Width = 150
        '
        'colInfo1
        '
        Me.colInfo1.Text = "Additional info"
        Me.colInfo1.Width = 200
        '
        'colFrequency1
        '
        Me.colFrequency1.Text = "Frequency"
        Me.colFrequency1.Width = 100
        '
        'colAppears1
        '
        Me.colAppears1.Text = "Image index"
        Me.colAppears1.Width = 100
        '
        'colPrayer1
        '
        Me.colPrayer1.Text = "Prayer"
        Me.colPrayer1.Width = 100
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewEditHieroglyphToolStripMenuItem, Me.AddHieroglyphToolStripMenuItem, Me.DeleteHieroglyphToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(185, 70)
        '
        'ViewEditHieroglyphToolStripMenuItem
        '
        Me.ViewEditHieroglyphToolStripMenuItem.Name = "ViewEditHieroglyphToolStripMenuItem"
        Me.ViewEditHieroglyphToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ViewEditHieroglyphToolStripMenuItem.Text = "View/Edit hieroglyph"
        '
        'AddHieroglyphToolStripMenuItem
        '
        Me.AddHieroglyphToolStripMenuItem.Name = "AddHieroglyphToolStripMenuItem"
        Me.AddHieroglyphToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.AddHieroglyphToolStripMenuItem.Text = "Add hieroglyph"
        '
        'DeleteHieroglyphToolStripMenuItem
        '
        Me.DeleteHieroglyphToolStripMenuItem.Name = "DeleteHieroglyphToolStripMenuItem"
        Me.DeleteHieroglyphToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.DeleteHieroglyphToolStripMenuItem.Text = "Delete hieroglyph"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(96, 96)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(123, 71)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(131, 11)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 16
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(91, 12)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(750, 20)
        Me.txtSearch.TabIndex = 11
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(13, 15)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(72, 13)
        Me.lblSearch.TabIndex = 14
        Me.lblSearch.Text = "Search terms:"
        Me.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstSearch
        '
        Me.lstSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSearch.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colGlyph, Me.colEnglish, Me.colNative, Me.colInfo, Me.colFrequency, Me.colAppears, Me.colPrayer})
        Me.lstSearch.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lstSearch.FullRowSelect = True
        Me.lstSearch.LargeImageList = Me.ImageList1
        Me.lstSearch.Location = New System.Drawing.Point(12, 94)
        Me.lstSearch.Name = "lstSearch"
        Me.lstSearch.Size = New System.Drawing.Size(829, 427)
        Me.lstSearch.SmallImageList = Me.ImageList1
        Me.lstSearch.StateImageList = Me.ImageList1
        Me.lstSearch.TabIndex = 15
        Me.lstSearch.UseCompatibleStateImageBehavior = False
        Me.lstSearch.View = System.Windows.Forms.View.Details
        Me.lstSearch.Visible = False
        '
        'colGlyph
        '
        Me.colGlyph.Text = "Glyph"
        Me.colGlyph.Width = 250
        '
        'colEnglish
        '
        Me.colEnglish.Text = "English text"
        Me.colEnglish.Width = 150
        '
        'colNative
        '
        Me.colNative.Text = "Native text"
        Me.colNative.Width = 150
        '
        'colInfo
        '
        Me.colInfo.Text = "Additional info"
        Me.colInfo.Width = 200
        '
        'colFrequency
        '
        Me.colFrequency.Text = "Frequency"
        '
        'colAppears
        '
        Me.colAppears.Text = "Image index"
        Me.colAppears.Width = 100
        '
        'colPrayer
        '
        Me.colPrayer.Text = "Prayer"
        Me.colPrayer.Width = 100
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"01 The Sign of the cross", "02 The Lord's prayer", "03 The Angelical Salutation", "04 The Apostles creed", "05 The Decalogue", "06 The Precepts of the Church", "07 An Act of Faith", "08 An Act of Hope", "09 An Act of Charity", "10 Thanksgiving", "11 An Act of Contrition", "12 The Confiteor", "13 A Longer Act of Contrition", "14 Grace Before Meals", "15 Grace After Meals", "16 Morning Prayer", "17 Litany of The Holy Name", "18 The sacraments", "19 Baptism", "20 Confirmation", "21 The Blessed Eucharist", "22 Penance", "23 Purgatory", "24 Exteme Unction", "25 Holy Orders", "26 Matrimony", "27 The Passion of Our Lord"})
        Me.ComboBox1.Location = New System.Drawing.Point(91, 38)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(159, 21)
        Me.ComboBox1.TabIndex = 19
        Me.ComboBox1.Text = "01 The Sign of The Cross"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(274, 42)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(65, 17)
        Me.RadioButton1.TabIndex = 20
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Thought"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(370, 42)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(62, 17)
        Me.RadioButton2.TabIndex = 21
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Speech"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(466, 42)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(66, 17)
        Me.RadioButton3.TabIndex = 22
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Location"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(274, 67)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(58, 17)
        Me.RadioButton4.TabIndex = 23
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Seeing"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(370, 67)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(50, 17)
        Me.RadioButton5.TabIndex = 24
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "Earth"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(466, 67)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton6.TabIndex = 25
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "He"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Browse:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblglyphsloaded
        '
        Me.lblglyphsloaded.AutoSize = True
        Me.lblglyphsloaded.Location = New System.Drawing.Point(8, 69)
        Me.lblglyphsloaded.Name = "lblglyphsloaded"
        Me.lblglyphsloaded.Size = New System.Drawing.Size(77, 13)
        Me.lblglyphsloaded.TabIndex = 28
        Me.lblglyphsloaded.Text = "Glyphs loaded:"
        Me.lblglyphsloaded.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmGlyphManifest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 533)
        Me.Controls.Add(Me.lblglyphsloaded)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.RadioButton6)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.lstSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lstGlyphs)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGlyphManifest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mi'kmaq glyph manifest"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstGlyphs As System.Windows.Forms.ListView
    Friend WithEvents colGlyph1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEnglish1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents colNative1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents colInfo1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstSearch As System.Windows.Forms.ListView
    Friend WithEvents colGlyph As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEnglish As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNative As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFrequency As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAppears As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFrequency1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents colInfo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPrayer As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAppears1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPrayer1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblglyphsloaded As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddHieroglyphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteHieroglyphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewEditHieroglyphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
