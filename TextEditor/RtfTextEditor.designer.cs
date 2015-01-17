namespace Bau.Controls.Text
{
    partial class RtfTextEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        //this.fontComboBox1 = new TextRuler.AdvancedTextEditorControl.FontComboBoxControl.FontComboBox();

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
					System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RtfTextEditor));
					this.tblEditorLayout = new System.Windows.Forms.TableLayoutPanel();
					this.tlbFiles = new System.Windows.Forms.ToolStrip();
					this.cmdNew = new System.Windows.Forms.ToolStripButton();
					this.cmdOpen = new System.Windows.Forms.ToolStripButton();
					this.cmdSave = new System.Windows.Forms.ToolStripButton();
					this.cmdSaveAs = new System.Windows.Forms.ToolStripButton();
					this.sepTBMain1 = new System.Windows.Forms.ToolStripSeparator();
					this.cmdPrint = new System.Windows.Forms.ToolStripButton();
					this.cmdPrintPreview = new System.Windows.Forms.ToolStripButton();
					this.sepTBMain2 = new System.Windows.Forms.ToolStripSeparator();
					this.cmdCut = new System.Windows.Forms.ToolStripButton();
					this.cmdCopy = new System.Windows.Forms.ToolStripButton();
					this.cmdPaste = new System.Windows.Forms.ToolStripButton();
					this.sepTBMain3 = new System.Windows.Forms.ToolStripSeparator();
					this.cmdUndo = new System.Windows.Forms.ToolStripButton();
					this.cmdRedo = new System.Windows.Forms.ToolStripButton();
					this.rtfEditor = new Bau.Controls.Text.ExtendedRichTextBox();
					this.pnlFormattingToolbar = new System.Windows.Forms.Panel();
					this.tlbFormat = new System.Windows.Forms.ToolStrip();
					this.cmdSetFont = new System.Windows.Forms.ToolStripButton();
					this.cboFontName = new System.Windows.Forms.ToolStripComboBox();
					this.cboFontSize = new System.Windows.Forms.ToolStripComboBox();
					this.sepTBFormatting1 = new System.Windows.Forms.ToolStripSeparator();
					this.cmdBold = new System.Windows.Forms.ToolStripButton();
					this.cmdItalic = new System.Windows.Forms.ToolStripButton();
					this.cmdUnderline = new System.Windows.Forms.ToolStripButton();
					this.cmdStrikeThrough = new System.Windows.Forms.ToolStripButton();
					this.sepTBFormatting2 = new System.Windows.Forms.ToolStripSeparator();
					this.cmdAlignLeft = new System.Windows.Forms.ToolStripButton();
					this.cmdAlignCenter = new System.Windows.Forms.ToolStripButton();
					this.cmdAlignRight = new System.Windows.Forms.ToolStripButton();
					this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
					this.cmdForeColor = new System.Windows.Forms.ToolStripButton();
					this.cmdBackColor = new System.Windows.Forms.ToolStripButton();
					this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
					this.cmdSearch = new System.Windows.Forms.ToolStripButton();
					this.udtRuler = new Bau.Controls.Text.TextRulerControl.TextRuler();
					this.prtDoc = new System.Drawing.Printing.PrintDocument();
					this.DocPreview = new System.Windows.Forms.PrintPreviewDialog();
					this.PageSettings = new System.Windows.Forms.PageSetupDialog();
					this.PrintWnd = new System.Windows.Forms.PrintDialog();
					this.tblEditorLayout.SuspendLayout();
					this.tlbFiles.SuspendLayout();
					this.pnlFormattingToolbar.SuspendLayout();
					this.tlbFormat.SuspendLayout();
					this.SuspendLayout();
					// 
					// tblEditorLayout
					// 
					this.tblEditorLayout.ColumnCount = 1;
					this.tblEditorLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
					this.tblEditorLayout.Controls.Add(this.tlbFiles, 0, 0);
					this.tblEditorLayout.Controls.Add(this.rtfEditor, 0, 3);
					this.tblEditorLayout.Controls.Add(this.pnlFormattingToolbar, 0, 1);
					this.tblEditorLayout.Controls.Add(this.udtRuler, 0, 2);
					this.tblEditorLayout.Dock = System.Windows.Forms.DockStyle.Fill;
					this.tblEditorLayout.Location = new System.Drawing.Point(0, 0);
					this.tblEditorLayout.Name = "tblEditorLayout";
					this.tblEditorLayout.RowCount = 4;
					this.tblEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
					this.tblEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
					this.tblEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
					this.tblEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
					this.tblEditorLayout.Size = new System.Drawing.Size(687, 502);
					this.tblEditorLayout.TabIndex = 0;
					// 
					// tlbFiles
					// 
					this.tlbFiles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
					this.tlbFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdNew,
            this.cmdOpen,
            this.cmdSave,
            this.cmdSaveAs,
            this.sepTBMain1,
            this.cmdPrint,
            this.cmdPrintPreview,
            this.sepTBMain2,
            this.cmdCut,
            this.cmdCopy,
            this.cmdPaste,
            this.sepTBMain3,
            this.cmdUndo,
            this.cmdRedo});
					this.tlbFiles.Location = new System.Drawing.Point(0, 0);
					this.tlbFiles.Name = "tlbFiles";
					this.tlbFiles.Size = new System.Drawing.Size(687, 25);
					this.tlbFiles.TabIndex = 8;
					this.tlbFiles.Text = "tlfFiles";
					// 
					// cmdNew
					// 
					this.cmdNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdNew.Image = ((System.Drawing.Image)(resources.GetObject("cmdNew.Image")));
					this.cmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdNew.Name = "cmdNew";
					this.cmdNew.Size = new System.Drawing.Size(23, 22);
					this.cmdNew.Text = "Nuevo";
					this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
					// 
					// cmdOpen
					// 
					this.cmdOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdOpen.Image = ((System.Drawing.Image)(resources.GetObject("cmdOpen.Image")));
					this.cmdOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdOpen.Name = "cmdOpen";
					this.cmdOpen.Size = new System.Drawing.Size(23, 22);
					this.cmdOpen.Text = "Abrir";
					this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
					// 
					// cmdSave
					// 
					this.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdSave.Image = global::Bau.Controls.Text.Properties.Resources.Save;
					this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdSave.Name = "cmdSave";
					this.cmdSave.Size = new System.Drawing.Size(23, 22);
					this.cmdSave.Text = "Guardar";
					this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
					// 
					// cmdSaveAs
					// 
					this.cmdSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdSaveAs.Image = global::Bau.Controls.Text.Properties.Resources.SaveAs;
					this.cmdSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdSaveAs.Name = "cmdSaveAs";
					this.cmdSaveAs.Size = new System.Drawing.Size(23, 22);
					this.cmdSaveAs.Text = "Guardar como";
					this.cmdSaveAs.Click += new System.EventHandler(this.cmdSaveAs_Click);
					// 
					// sepTBMain1
					// 
					this.sepTBMain1.Name = "sepTBMain1";
					this.sepTBMain1.Size = new System.Drawing.Size(6, 25);
					// 
					// cmdPrint
					// 
					this.cmdPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
					this.cmdPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdPrint.Name = "cmdPrint";
					this.cmdPrint.Size = new System.Drawing.Size(23, 22);
					this.cmdPrint.Text = "Imprimir";
					this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
					// 
					// cmdPrintPreview
					// 
					this.cmdPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrintPreview.Image")));
					this.cmdPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdPrintPreview.Name = "cmdPrintPreview";
					this.cmdPrintPreview.Size = new System.Drawing.Size(23, 22);
					this.cmdPrintPreview.Text = "Vista preliminar";
					this.cmdPrintPreview.Click += new System.EventHandler(this.cmdPrintPreview_Click);
					// 
					// sepTBMain2
					// 
					this.sepTBMain2.Name = "sepTBMain2";
					this.sepTBMain2.Size = new System.Drawing.Size(6, 25);
					// 
					// cmdCut
					// 
					this.cmdCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdCut.Image = ((System.Drawing.Image)(resources.GetObject("cmdCut.Image")));
					this.cmdCut.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdCut.Name = "cmdCut";
					this.cmdCut.Size = new System.Drawing.Size(23, 22);
					this.cmdCut.Text = "Cortar";
					this.cmdCut.Click += new System.EventHandler(this.cmdCut_Click);
					// 
					// cmdCopy
					// 
					this.cmdCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdCopy.Image = ((System.Drawing.Image)(resources.GetObject("cmdCopy.Image")));
					this.cmdCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdCopy.Name = "cmdCopy";
					this.cmdCopy.Size = new System.Drawing.Size(23, 22);
					this.cmdCopy.Text = "Copiar";
					this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
					// 
					// cmdPaste
					// 
					this.cmdPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdPaste.Image = ((System.Drawing.Image)(resources.GetObject("cmdPaste.Image")));
					this.cmdPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdPaste.Name = "cmdPaste";
					this.cmdPaste.Size = new System.Drawing.Size(23, 22);
					this.cmdPaste.Text = "Pegar";
					this.cmdPaste.Click += new System.EventHandler(this.cmdPaste_Click);
					// 
					// sepTBMain3
					// 
					this.sepTBMain3.Name = "sepTBMain3";
					this.sepTBMain3.Size = new System.Drawing.Size(6, 25);
					// 
					// cmdUndo
					// 
					this.cmdUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdUndo.Image = global::Bau.Controls.Text.Properties.Resources.Undo;
					this.cmdUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdUndo.Name = "cmdUndo";
					this.cmdUndo.Size = new System.Drawing.Size(23, 22);
					this.cmdUndo.Text = "Deshacer";
					this.cmdUndo.Click += new System.EventHandler(this.cmdUndo_Click);
					// 
					// cmdRedo
					// 
					this.cmdRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdRedo.Image = global::Bau.Controls.Text.Properties.Resources.Redo;
					this.cmdRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdRedo.Name = "cmdRedo";
					this.cmdRedo.Size = new System.Drawing.Size(23, 22);
					this.cmdRedo.Text = "Rehacer";
					this.cmdRedo.Click += new System.EventHandler(this.cmdRedo_Click);
					// 
					// rtfEditor
					// 
					this.rtfEditor.AcceptsTab = true;
					this.rtfEditor.Dock = System.Windows.Forms.DockStyle.Fill;
					this.rtfEditor.HideSelection = false;
					this.rtfEditor.Location = new System.Drawing.Point(3, 75);
					this.rtfEditor.Name = "rtfEditor";
					this.rtfEditor.Size = new System.Drawing.Size(681, 424);
					this.rtfEditor.TabIndex = 3;
					this.rtfEditor.Text = "";
					this.rtfEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtfEditor_KeyDown);
					this.rtfEditor.SelectionChanged += new System.EventHandler(this.rtfEditor_SelectionChanged);
					this.rtfEditor.TextChanged += new System.EventHandler(this.rtfEditor_TextChanged);
					// 
					// pnlFormattingToolbar
					// 
					this.pnlFormattingToolbar.Controls.Add(this.tlbFormat);
					this.pnlFormattingToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
					this.pnlFormattingToolbar.Location = new System.Drawing.Point(0, 26);
					this.pnlFormattingToolbar.Margin = new System.Windows.Forms.Padding(0);
					this.pnlFormattingToolbar.Name = "pnlFormattingToolbar";
					this.pnlFormattingToolbar.Size = new System.Drawing.Size(687, 26);
					this.pnlFormattingToolbar.TabIndex = 6;
					// 
					// tlbFormat
					// 
					this.tlbFormat.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
					this.tlbFormat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdSetFont,
            this.cboFontName,
            this.cboFontSize,
            this.sepTBFormatting1,
            this.cmdBold,
            this.cmdItalic,
            this.cmdUnderline,
            this.cmdStrikeThrough,
            this.sepTBFormatting2,
            this.cmdAlignLeft,
            this.cmdAlignCenter,
            this.cmdAlignRight,
            this.toolStripSeparator1,
            this.cmdForeColor,
            this.cmdBackColor,
            this.toolStripSeparator2,
            this.cmdSearch});
					this.tlbFormat.Location = new System.Drawing.Point(0, 0);
					this.tlbFormat.Name = "tlbFormat";
					this.tlbFormat.Size = new System.Drawing.Size(687, 25);
					this.tlbFormat.TabIndex = 9;
					this.tlbFormat.Text = "tlbFormat";
					// 
					// cmdSetFont
					// 
					this.cmdSetFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdSetFont.Image = global::Bau.Controls.Text.Properties.Resources.Font;
					this.cmdSetFont.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdSetFont.Name = "cmdSetFont";
					this.cmdSetFont.Size = new System.Drawing.Size(23, 22);
					this.cmdSetFont.Text = "Fuente";
					this.cmdSetFont.Click += new System.EventHandler(this.cmdSetFont_Click);
					// 
					// cboFontName
					// 
					this.cboFontName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
					this.cboFontName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
					this.cboFontName.DropDownHeight = 300;
					this.cboFontName.IntegralHeight = false;
					this.cboFontName.Name = "cboFontName";
					this.cboFontName.Size = new System.Drawing.Size(170, 25);
					this.cboFontName.SelectedIndexChanged += new System.EventHandler(this.cboFontName_SelectedIndexChanged);
					this.cboFontName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboFontName_KeyUp);
					// 
					// cboFontSize
					// 
					this.cboFontSize.AutoSize = false;
					this.cboFontSize.DropDownHeight = 200;
					this.cboFontSize.IntegralHeight = false;
					this.cboFontSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "30",
            "36",
            "48",
            "60",
            "72",
            "85",
            "100"});
					this.cboFontSize.MaxDropDownItems = 20;
					this.cboFontSize.Name = "cboFontSize";
					this.cboFontSize.Size = new System.Drawing.Size(50, 21);
					this.cboFontSize.Text = "8";
					this.cboFontSize.SelectedIndexChanged += new System.EventHandler(this.cboFontSize_SelectedIndexChanged);
					this.cboFontSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboFontSize_KeyUp);
					this.cboFontSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboFontSize_KeyDown);
					// 
					// sepTBFormatting1
					// 
					this.sepTBFormatting1.Name = "sepTBFormatting1";
					this.sepTBFormatting1.Size = new System.Drawing.Size(6, 25);
					// 
					// cmdBold
					// 
					this.cmdBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdBold.Image = global::Bau.Controls.Text.Properties.Resources.Bold;
					this.cmdBold.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdBold.Name = "cmdBold";
					this.cmdBold.Size = new System.Drawing.Size(23, 22);
					this.cmdBold.Text = "Negrita";
					this.cmdBold.Click += new System.EventHandler(this.cmdBold_Click);
					// 
					// cmdItalic
					// 
					this.cmdItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdItalic.Image = global::Bau.Controls.Text.Properties.Resources.Italic;
					this.cmdItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdItalic.Name = "cmdItalic";
					this.cmdItalic.Size = new System.Drawing.Size(23, 22);
					this.cmdItalic.Text = "Cursiva";
					this.cmdItalic.Click += new System.EventHandler(this.cmdItalic_Click);
					// 
					// cmdUnderline
					// 
					this.cmdUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdUnderline.Image = global::Bau.Controls.Text.Properties.Resources.Underline;
					this.cmdUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdUnderline.Name = "cmdUnderline";
					this.cmdUnderline.Size = new System.Drawing.Size(23, 22);
					this.cmdUnderline.Text = "Subrayado";
					this.cmdUnderline.Click += new System.EventHandler(this.cmdUnderline_Click);
					// 
					// cmdStrikeThrough
					// 
					this.cmdStrikeThrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdStrikeThrough.Image = global::Bau.Controls.Text.Properties.Resources.Strikethrough;
					this.cmdStrikeThrough.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdStrikeThrough.Name = "cmdStrikeThrough";
					this.cmdStrikeThrough.Size = new System.Drawing.Size(23, 22);
					this.cmdStrikeThrough.Text = "Tachado";
					this.cmdStrikeThrough.Click += new System.EventHandler(this.cmdStrikeThrough_Click);
					// 
					// sepTBFormatting2
					// 
					this.sepTBFormatting2.Name = "sepTBFormatting2";
					this.sepTBFormatting2.Size = new System.Drawing.Size(6, 25);
					// 
					// cmdAlignLeft
					// 
					this.cmdAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdAlignLeft.Image = global::Bau.Controls.Text.Properties.Resources.AlignLeft;
					this.cmdAlignLeft.ImageTransparentColor = System.Drawing.Color.Black;
					this.cmdAlignLeft.Name = "cmdAlignLeft";
					this.cmdAlignLeft.Size = new System.Drawing.Size(23, 22);
					this.cmdAlignLeft.Text = "Alinear izquierda";
					this.cmdAlignLeft.Click += new System.EventHandler(this.cmdAlignLeft_Click);
					// 
					// cmdAlignCenter
					// 
					this.cmdAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdAlignCenter.Image = global::Bau.Controls.Text.Properties.Resources.AlignCenter;
					this.cmdAlignCenter.ImageTransparentColor = System.Drawing.Color.Black;
					this.cmdAlignCenter.Name = "cmdAlignCenter";
					this.cmdAlignCenter.Size = new System.Drawing.Size(23, 22);
					this.cmdAlignCenter.Text = "Centrar";
					this.cmdAlignCenter.Click += new System.EventHandler(this.cmdAlignCenter_Click);
					// 
					// cmdAlignRight
					// 
					this.cmdAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdAlignRight.Image = global::Bau.Controls.Text.Properties.Resources.AlignRight;
					this.cmdAlignRight.ImageTransparentColor = System.Drawing.Color.Black;
					this.cmdAlignRight.Name = "cmdAlignRight";
					this.cmdAlignRight.Size = new System.Drawing.Size(23, 22);
					this.cmdAlignRight.Text = "Alinera derecha";
					this.cmdAlignRight.Click += new System.EventHandler(this.cmdAlignRight_Click);
					// 
					// toolStripSeparator1
					// 
					this.toolStripSeparator1.Name = "toolStripSeparator1";
					this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
					// 
					// cmdForeColor
					// 
					this.cmdForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdForeColor.Image = global::Bau.Controls.Text.Properties.Resources.ForeColor;
					this.cmdForeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdForeColor.Name = "cmdForeColor";
					this.cmdForeColor.Size = new System.Drawing.Size(23, 22);
					this.cmdForeColor.Text = "Color texto";
					this.cmdForeColor.Click += new System.EventHandler(this.cmdForeColor_Click);
					// 
					// cmdBackColor
					// 
					this.cmdBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdBackColor.Image = global::Bau.Controls.Text.Properties.Resources.BackColor;
					this.cmdBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdBackColor.Name = "cmdBackColor";
					this.cmdBackColor.Size = new System.Drawing.Size(23, 22);
					this.cmdBackColor.Text = "Color de fondo";
					this.cmdBackColor.Click += new System.EventHandler(this.cmdBackColor_Click);
					// 
					// toolStripSeparator2
					// 
					this.toolStripSeparator2.Name = "toolStripSeparator2";
					this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
					// 
					// cmdSearch
					// 
					this.cmdSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
					this.cmdSearch.Image = global::Bau.Controls.Text.Properties.Resources.Search;
					this.cmdSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
					this.cmdSearch.Name = "cmdSearch";
					this.cmdSearch.Size = new System.Drawing.Size(23, 22);
					this.cmdSearch.Text = "Buscar";
					this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
					// 
					// udtRuler
					// 
					this.udtRuler.BackColor = System.Drawing.Color.Transparent;
					this.udtRuler.Dock = System.Windows.Forms.DockStyle.Bottom;
					this.udtRuler.Font = new System.Drawing.Font("Arial", 7.25F);
					this.udtRuler.LeftMargin = 1;
					this.udtRuler.Location = new System.Drawing.Point(3, 55);
					this.udtRuler.Name = "udtRuler";
					this.udtRuler.NoMargins = true;
					this.udtRuler.RightMargin = 1;
					this.udtRuler.Size = new System.Drawing.Size(681, 20);
					this.udtRuler.TabIndex = 7;
					this.udtRuler.TabsEnabled = true;
					this.udtRuler.TabAdded += new Bau.Controls.Text.TextRulerControl.TextRuler.TabChangedEventHandler(this.udtRuler_TabAdded);
					this.udtRuler.TabRemoved += new Bau.Controls.Text.TextRulerControl.TextRuler.TabChangedEventHandler(this.udtRuler_TabRemoved);
					this.udtRuler.RightIndentChanging += new Bau.Controls.Text.TextRulerControl.TextRuler.IndentChangedEventHandler(this.udtRuler_RightIndentChanging);
					this.udtRuler.LeftHangingIndentChanging += new Bau.Controls.Text.TextRulerControl.TextRuler.IndentChangedEventHandler(this.udtRuler_LeftHangingIndentChanging);
					this.udtRuler.TabChanged += new Bau.Controls.Text.TextRulerControl.TextRuler.TabChangedEventHandler(this.udtRuler_TabChanged);
					this.udtRuler.LeftIndentChanging += new Bau.Controls.Text.TextRulerControl.TextRuler.IndentChangedEventHandler(this.udtRuler_LeftIndentChanging);
					// 
					// DocPreview
					// 
					this.DocPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
					this.DocPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
					this.DocPreview.ClientSize = new System.Drawing.Size(400, 300);
					this.DocPreview.Document = this.prtDoc;
					this.DocPreview.Enabled = true;
					this.DocPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("DocPreview.Icon")));
					this.DocPreview.Name = "DocPreview";
					this.DocPreview.Visible = false;
					// 
					// PageSettings
					// 
					this.PageSettings.Document = this.prtDoc;
					// 
					// PrintWnd
					// 
					this.PrintWnd.Document = this.prtDoc;
					this.PrintWnd.UseEXDialog = true;
					// 
					// RtfTextEditor
					// 
					this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
					this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
					this.Controls.Add(this.tblEditorLayout);
					this.Name = "RtfTextEditor";
					this.Size = new System.Drawing.Size(687, 502);
					this.Load += new System.EventHandler(this.RtfTextEditor_Load);
					this.tblEditorLayout.ResumeLayout(false);
					this.tblEditorLayout.PerformLayout();
					this.tlbFiles.ResumeLayout(false);
					this.tlbFiles.PerformLayout();
					this.pnlFormattingToolbar.ResumeLayout(false);
					this.pnlFormattingToolbar.PerformLayout();
					this.tlbFormat.ResumeLayout(false);
					this.tlbFormat.PerformLayout();
					this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblEditorLayout;        
        private System.Windows.Forms.ToolStripButton cmdNew;
        private System.Windows.Forms.ToolStripButton cmdOpen;
        private System.Windows.Forms.ToolStripButton cmdSave;
        private System.Windows.Forms.ToolStripSeparator sepTBMain1;
        private System.Windows.Forms.ToolStripButton cmdPrint;
        private System.Windows.Forms.ToolStripButton cmdPrintPreview;
        private System.Windows.Forms.ToolStripSeparator sepTBMain2;
        private System.Windows.Forms.ToolStripButton cmdCut;
        private System.Windows.Forms.ToolStripButton cmdCopy;
        private System.Windows.Forms.ToolStripButton cmdPaste;
				private System.Windows.Forms.ToolStripSeparator sepTBMain3;
        private System.Windows.Forms.ToolStrip tlbFormat;
        private System.Windows.Forms.ToolStripComboBox cboFontName;
        private System.Windows.Forms.ToolStripComboBox cboFontSize;
        private System.Windows.Forms.ToolStripSeparator sepTBFormatting1;
        private System.Windows.Forms.ToolStripButton cmdBold;
        private System.Windows.Forms.ToolStripButton cmdItalic;
        private System.Windows.Forms.ToolStripButton cmdUnderline;
        private System.Windows.Forms.ToolStripButton cmdStrikeThrough;
        private System.Windows.Forms.ToolStripSeparator sepTBFormatting2;
        private System.Windows.Forms.ToolStripButton cmdAlignLeft;
        private System.Windows.Forms.ToolStripButton cmdAlignCenter;
        private System.Windows.Forms.ToolStripButton cmdAlignRight;
        private System.Windows.Forms.ToolStripButton cmdUndo;
			private System.Windows.Forms.ToolStripButton cmdRedo;
        private System.Windows.Forms.Panel pnlFormattingToolbar;
				private TextRulerControl.TextRuler udtRuler;
        private System.Drawing.Printing.PrintDocument prtDoc;
        private System.Windows.Forms.PrintPreviewDialog DocPreview;
				private System.Windows.Forms.PageSetupDialog PageSettings;
				private System.Windows.Forms.PrintDialog PrintWnd;
				internal ExtendedRichTextBox rtfEditor;
				private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
				private System.Windows.Forms.ToolStripButton cmdForeColor;
				private System.Windows.Forms.ToolStripButton cmdBackColor;
				private System.Windows.Forms.ToolStripButton cmdSaveAs;
				private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
				private System.Windows.Forms.ToolStripButton cmdSearch;
				private System.Windows.Forms.ToolStrip tlbFiles;
			private System.Windows.Forms.ToolStripButton cmdSetFont;
    }
}
