namespace Bau.Applications.ComicsBooks.Forms.Comic
{
	partial class frmComicEPub
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
		this.label1 = new System.Windows.Forms.Label();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.chkSeeResult = new System.Windows.Forms.CheckBox();
		this.udtFile = new Bau.Controls.Files.TextBoxSelectFile();
		this.txtTitle = new System.Windows.Forms.TextBox();
		this.nudWidthPage = new System.Windows.Forms.NumericUpDown();
		this.label6 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.cmdAccept = new System.Windows.Forms.Button();
		this.cmdCancel = new System.Windows.Forms.Button();
		this.chkWhiteAndBlack = new System.Windows.Forms.CheckBox();
		this.groupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize) (this.nudWidthPage)).BeginInit();
		this.SuspendLayout();
		// 
		// label1
		// 
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label1.Location = new System.Drawing.Point(11, 23);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(55, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Archivo:";
		// 
		// groupBox1
		// 
		this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
								| System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.groupBox1.Controls.Add(this.chkWhiteAndBlack);
		this.groupBox1.Controls.Add(this.chkSeeResult);
		this.groupBox1.Controls.Add(this.udtFile);
		this.groupBox1.Controls.Add(this.txtTitle);
		this.groupBox1.Controls.Add(this.nudWidthPage);
		this.groupBox1.Controls.Add(this.label6);
		this.groupBox1.Controls.Add(this.label5);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
		this.groupBox1.Location = new System.Drawing.Point(6, 5);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(501, 124);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Parámetros de generación";
		// 
		// chkSeeResult
		// 
		this.chkSeeResult.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		this.chkSeeResult.AutoSize = true;
		this.chkSeeResult.Checked = true;
		this.chkSeeResult.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkSeeResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.chkSeeResult.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.chkSeeResult.Location = new System.Drawing.Point(313, 94);
		this.chkSeeResult.Name = "chkSeeResult";
		this.chkSeeResult.Size = new System.Drawing.Size(177, 17);
		this.chkSeeResult.TabIndex = 8;
		this.chkSeeResult.Text = "Abrir el archivo creado";
		this.chkSeeResult.UseVisualStyleBackColor = true;
		// 
		// udtFile
		// 
		this.udtFile.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.udtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.udtFile.ForeColor = System.Drawing.Color.Black;
		this.udtFile.Location = new System.Drawing.Point(108, 19);
		this.udtFile.Margin = new System.Windows.Forms.Padding(0);
		this.udtFile.MaximumSize = new System.Drawing.Size(11667, 20);
		this.udtFile.MinimumSize = new System.Drawing.Size(233, 20);
		this.udtFile.Name = "udtFile";
		this.udtFile.FileName = "";
		this.udtFile.Filter = "Archivos ePub (*.ePub)|*.ePub|Todos los archivos (*.*)|*.*";
		this.udtFile.Type = Bau.Controls.Files.TextBoxSelectFile.FileSelectType.Save;
		this.udtFile.Size = new System.Drawing.Size(387, 20);
		this.udtFile.TabIndex = 1;
		// 
		// txtTitle
		// 
		this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.txtTitle.Location = new System.Drawing.Point(108, 43);
		this.txtTitle.Name = "txtTitle";
		this.txtTitle.Size = new System.Drawing.Size(387, 20);
		this.txtTitle.TabIndex = 3;
		// 
		// nudWidthPage
		// 
		this.nudWidthPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.nudWidthPage.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
		this.nudWidthPage.Location = new System.Drawing.Point(108, 67);
		this.nudWidthPage.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
		this.nudWidthPage.Name = "nudWidthPage";
		this.nudWidthPage.Size = new System.Drawing.Size(61, 20);
		this.nudWidthPage.TabIndex = 5;
		this.nudWidthPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		// 
		// label6
		// 
		this.label6.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label6.ForeColor = System.Drawing.Color.Red;
		this.label6.Location = new System.Drawing.Point(175, 71);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(309, 13);
		this.label6.TabIndex = 6;
		this.label6.Text = "(si deja el valor 0 las imágenes se graban con el tamaño original)";
		// 
		// label5
		// 
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label5.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label5.Location = new System.Drawing.Point(11, 71);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(79, 13);
		this.label5.TabIndex = 4;
		this.label5.Text = "Ancho máximo:";
		// 
		// label2
		// 
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label2.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label2.Location = new System.Drawing.Point(11, 47);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(38, 13);
		this.label2.TabIndex = 2;
		this.label2.Text = "Título:";
		// 
		// cmdAccept
		// 
		this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.cmdAccept.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Accept;
		this.cmdAccept.Location = new System.Drawing.Point(323, 134);
		this.cmdAccept.Name = "cmdAccept";
		this.cmdAccept.Size = new System.Drawing.Size(89, 28);
		this.cmdAccept.TabIndex = 1;
		this.cmdAccept.Text = "&Aceptar";
		this.cmdAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.cmdAccept.UseVisualStyleBackColor = true;
		this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
		// 
		// cmdCancel
		// 
		this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.cancel;
		this.cmdCancel.Location = new System.Drawing.Point(418, 134);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size(89, 28);
		this.cmdCancel.TabIndex = 2;
		this.cmdCancel.Text = "&Cancelar";
		this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.cmdCancel.UseVisualStyleBackColor = true;
		// 
		// chkWhiteAndBlack
		// 
		this.chkWhiteAndBlack.AutoSize = true;
		this.chkWhiteAndBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.chkWhiteAndBlack.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.chkWhiteAndBlack.Location = new System.Drawing.Point(108, 94);
		this.chkWhiteAndBlack.Name = "chkWhiteAndBlack";
		this.chkWhiteAndBlack.Size = new System.Drawing.Size(97, 17);
		this.chkWhiteAndBlack.TabIndex = 7;
		this.chkWhiteAndBlack.Text = "Blanco y negro";
		this.chkWhiteAndBlack.UseVisualStyleBackColor = true;
		// 
		// frmComicEPub
		// 
		this.AcceptButton = this.cmdAccept;
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.CancelButton = this.cmdCancel;
		this.ClientSize = new System.Drawing.Size(512, 166);
		this.Controls.Add(this.cmdCancel);
		this.Controls.Add(this.cmdAccept);
		this.Controls.Add(this.groupBox1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		this.Name = "frmComicEPub";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Creación de eBook";
		this.Load += new System.EventHandler(this.frmComicGalleryHTML_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize) (this.nudWidthPage)).EndInit();
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label label2;
		private Bau.Controls.Files.TextBoxSelectFile udtFile;
		private System.Windows.Forms.Button cmdAccept;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.CheckBox chkSeeResult;
		private System.Windows.Forms.NumericUpDown nudWidthPage;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkWhiteAndBlack;
	}
}