<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPictionary
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
        Me.lstGlyph = New System.Windows.Forms.ListView
        Me.colGlyph = New System.Windows.Forms.ColumnHeader
        Me.colEnglish = New System.Windows.Forms.ColumnHeader
        Me.colNative = New System.Windows.Forms.ColumnHeader
        Me.colInfo = New System.Windows.Forms.ColumnHeader
        Me.colFrequency = New System.Windows.Forms.ColumnHeader
        Me.colAppears = New System.Windows.Forms.ColumnHeader
        Me.colPrayer = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.JumpToHieroglyphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.ViewEditHieroglyphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddHieroglyphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.DeleteHieroglyphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Timers.Timer
        Me.btnMoveUp = New System.Windows.Forms.Button
        Me.btnMoveDown = New System.Windows.Forms.Button
        Me.btnMoveFirst = New System.Windows.Forms.Button
        Me.btnMoveLast = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnRemove = New System.Windows.Forms.Button
        Me.lblSearch = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.lblglyphsloaded = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.lstSearch = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.Timer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstGlyph
        '
        Me.lstGlyph.AllowDrop = True
        Me.lstGlyph.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstGlyph.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colGlyph, Me.colEnglish, Me.colNative, Me.colInfo, Me.colFrequency, Me.colAppears, Me.colPrayer})
        Me.lstGlyph.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lstGlyph.FullRowSelect = True
        Me.lstGlyph.LargeImageList = Me.ImageList1
        Me.lstGlyph.Location = New System.Drawing.Point(12, 70)
        Me.lstGlyph.Name = "lstGlyph"
        Me.lstGlyph.Size = New System.Drawing.Size(830, 381)
        Me.lstGlyph.SmallImageList = Me.ImageList1
        Me.lstGlyph.StateImageList = Me.ImageList1
        Me.lstGlyph.TabIndex = 16
        Me.lstGlyph.UseCompatibleStateImageBehavior = False
        Me.lstGlyph.View = System.Windows.Forms.View.Details
        '
        'colGlyph
        '
        Me.colGlyph.Text = "Glyph"
        Me.colGlyph.Width = 250
        '
        'colEnglish
        '
        Me.colEnglish.Text = "English text"
        Me.colEnglish.Width = 225
        '
        'colNative
        '
        Me.colNative.Text = "Native text"
        Me.colNative.Width = 150
        '
        'colInfo
        '
        Me.colInfo.Text = "Addition info"
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
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JumpToHieroglyphToolStripMenuItem, Me.ToolStripMenuItem1, Me.ViewEditHieroglyphToolStripMenuItem, Me.AddHieroglyphToolStripMenuItem, Me.ToolStripMenuItem2, Me.DeleteHieroglyphToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(185, 104)
        '
        'JumpToHieroglyphToolStripMenuItem
        '
        Me.JumpToHieroglyphToolStripMenuItem.Name = "JumpToHieroglyphToolStripMenuItem"
        Me.JumpToHieroglyphToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.JumpToHieroglyphToolStripMenuItem.Text = "Jump to hieroglyph"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 6)
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
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(181, 6)
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
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 75
        '
        'Timer2
        '
        Me.Timer2.AutoReset = False
        Me.Timer2.Interval = 400
        Me.Timer2.SynchronizingObject = Me
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Location = New System.Drawing.Point(27, 19)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(46, 23)
        Me.btnMoveUp.TabIndex = 17
        Me.btnMoveUp.Text = "Up"
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Location = New System.Drawing.Point(79, 19)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(46, 23)
        Me.btnMoveDown.TabIndex = 18
        Me.btnMoveDown.Text = "Down"
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Location = New System.Drawing.Point(149, 19)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(46, 23)
        Me.btnMoveFirst.TabIndex = 19
        Me.btnMoveFirst.Text = "First"
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Location = New System.Drawing.Point(201, 19)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(46, 23)
        Me.btnMoveLast.TabIndex = 20
        Me.btnMoveLast.Text = "Last"
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(6, 19)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(77, 23)
        Me.btnAdd.TabIndex = 21
        Me.btnAdd.Text = "Add image"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnMoveFirst)
        Me.GroupBox1.Controls.Add(Me.btnMoveUp)
        Me.GroupBox1.Controls.Add(Me.btnMoveLast)
        Me.GroupBox1.Controls.Add(Me.btnMoveDown)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 52)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Move selected hieroglyphs"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnRemove)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Location = New System.Drawing.Point(585, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(257, 52)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add or remove selected hieroglyphs"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(89, 19)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(162, 23)
        Me.btnRemove.TabIndex = 22
        Me.btnRemove.Text = "Delete selected hieroglyphs"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(14, 25)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(39, 13)
        Me.lblSearch.TabIndex = 25
        Me.lblSearch.Text = "Terms:"
        Me.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(59, 22)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(224, 20)
        Me.txtSearch.TabIndex = 24
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblSearch)
        Me.GroupBox3.Controls.Add(Me.txtSearch)
        Me.GroupBox3.Location = New System.Drawing.Point(275, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(304, 52)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Search"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(727, 457)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 23)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "Load prayer set"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblglyphsloaded
        '
        Me.lblglyphsloaded.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblglyphsloaded.AutoSize = True
        Me.lblglyphsloaded.Location = New System.Drawing.Point(29, 462)
        Me.lblglyphsloaded.Name = "lblglyphsloaded"
        Me.lblglyphsloaded.Size = New System.Drawing.Size(77, 13)
        Me.lblglyphsloaded.TabIndex = 30
        Me.lblglyphsloaded.Text = "Glyphs loaded:"
        Me.lblglyphsloaded.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(112, 464)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(609, 11)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 29
        '
        'lstSearch
        '
        Me.lstSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSearch.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lstSearch.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lstSearch.FullRowSelect = True
        Me.lstSearch.LargeImageList = Me.ImageList1
        Me.lstSearch.Location = New System.Drawing.Point(13, 70)
        Me.lstSearch.Name = "lstSearch"
        Me.lstSearch.Size = New System.Drawing.Size(829, 381)
        Me.lstSearch.SmallImageList = Me.ImageList1
        Me.lstSearch.StateImageList = Me.ImageList1
        Me.lstSearch.TabIndex = 31
        Me.lstSearch.UseCompatibleStateImageBehavior = False
        Me.lstSearch.View = System.Windows.Forms.View.Details
        Me.lstSearch.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Glyph"
        Me.ColumnHeader1.Width = 250
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "English text"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Native text"
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Additional info"
        Me.ColumnHeader4.Width = 200
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Frequency"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Image index"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Prayer"
        Me.ColumnHeader7.Width = 100
        '
        'frmPictionary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 492)
        Me.Controls.Add(Me.lstSearch)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblglyphsloaded)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lstGlyph)
        Me.DoubleBuffered = True
        Me.Name = "frmPictionary"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dictionary of hieroglyphics"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.Timer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstGlyph As System.Windows.Forms.ListView
    Friend WithEvents colGlyph As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEnglish As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNative As System.Windows.Forms.ColumnHeader
    Friend WithEvents colInfo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPrayer As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAppears As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFrequency As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Timers.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewEditHieroglyphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddHieroglyphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteHieroglyphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JumpToHieroglyphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnMoveLast As System.Windows.Forms.Button
    Friend WithEvents btnMoveFirst As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblglyphsloaded As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lstSearch As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
End Class
