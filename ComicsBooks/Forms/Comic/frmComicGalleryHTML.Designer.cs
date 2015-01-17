namespace Bau.Applications.ComicsBooks.Forms.Comic
{
	partial class frmComicGalleryHTML
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
		this.udtPath = new Bau.Controls.Files.TextBoxSelectPath();
		this.txtTitle = new System.Windows.Forms.TextBox();
		this.nudColumns = new System.Windows.Forms.NumericUpDown();
		this.nudWidthPage = new System.Windows.Forms.NumericUpDown();
		this.nudWidth = new System.Windows.Forms.NumericUpDown();
		this.label6 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.cmdAccept = new System.Windows.Forms.Button();
		this.cmdCancel = new System.Windows.Forms.Button();
		this.groupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize) (this.nudColumns)).BeginInit();
		((System.ComponentModel.ISupportInitialize) (this.nudWidthPage)).BeginInit();
		((System.ComponentModel.ISupportInitialize) (this.nudWidth)).BeginInit();
		this.SuspendLayout();
		// 
		// label1
		// 
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label1.Location = new System.Drawing.Point(11, 24);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(55, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Directorio:";
		// 
		// groupBox1
		// 
		this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.groupBox1.Controls.Add(this.chkSeeResult);
		this.groupBox1.Controls.Add(this.udtPath);
		this.groupBox1.Controls.Add(this.txtTitle);
		this.groupBox1.Controls.Add(this.nudColumns);
		this.groupBox1.Controls.Add(this.nudWidthPage);
		this.groupBox1.Controls.Add(this.nudWidth);
		this.groupBox1.Controls.Add(this.label6);
		this.groupBox1.Controls.Add(this.label5);
		this.groupBox1.Controls.Add(this.label4);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
		this.groupBox1.Location = new System.Drawing.Point(6, 5);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(383, 158);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Parámetros de generación";
		// 
		// chkSeeResult
		// 
		this.chkSeeResult.AutoSize = true;
		this.chkSeeResult.Checked = true;
		this.chkSeeResult.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkSeeResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.chkSeeResult.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.chkSeeResult.Location = new System.Drawing.Point(198, 135);
		this.chkSeeResult.Name = "chkSeeResult";
		this.chkSeeResult.Size = new System.Drawing.Size(177, 17);
		this.chkSeeResult.TabIndex = 11;
		this.chkSeeResult.Text = "Ver el resultado en el explorador";
		this.chkSeeResult.UseVisualStyleBackColor = true;
		// 
		// udtPath
		// 
		this.udtPath.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.udtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.udtPath.ForeColor = System.Drawing.Color.Black;
		this.udtPath.Location = new System.Drawing.Point(108, 20);
		this.udtPath.Margin = new System.Windows.Forms.Padding(0);
		this.udtPath.MaximumSize = new System.Drawing.Size(11667, 20);
		this.udtPath.MinimumSize = new System.Drawing.Size(233, 20);
		this.udtPath.Name = "udtPath";
		this.udtPath.PathName = "";
		this.udtPath.Size = new System.Drawing.Size(269, 20);
		this.udtPath.TabIndex = 1;
		// 
		// txtTitle
		// 
		this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.txtTitle.Location = new System.Drawing.Point(108, 48);
		this.txtTitle.Name = "txtTitle";
		this.txtTitle.Size = new System.Drawing.Size(269, 20);
		this.txtTitle.TabIndex = 3;
		// 
		// nudColumns
		// 
		this.nudColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.nudColumns.Location = new System.Drawing.Point(314, 76);
		this.nudColumns.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
		this.nudColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
		this.nudColumns.Name = "nudColumns";
		this.nudColumns.Size = new System.Drawing.Size(61, 20);
		this.nudColumns.TabIndex = 7;
		this.nudColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.nudColumns.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
		// 
		// nudWidthPage
		// 
		this.nudWidthPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.nudWidthPage.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
		this.nudWidthPage.Location = new System.Drawing.Point(108, 102);
		this.nudWidthPage.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
		this.nudWidthPage.Name = "nudWidthPage";
		this.nudWidthPage.Size = new System.Drawing.Size(61, 20);
		this.nudWidthPage.TabIndex = 9;
		this.nudWidthPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		// 
		// nudWidth
		// 
		this.nudWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.nudWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
		this.nudWidth.Location = new System.Drawing.Point(108, 76);
		this.nudWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
		this.nudWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
		this.nudWidth.Name = "nudWidth";
		this.nudWidth.Size = new System.Drawing.Size(61, 20);
		this.nudWidth.TabIndex = 5;
		this.nudWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.nudWidth.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
		// 
		// label6
		// 
		this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label6.ForeColor = System.Drawing.Color.Red;
		this.label6.Location = new System.Drawing.Point(175, 102);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(200, 29);
		this.label6.TabIndex = 10;
		this.label6.Text = "(si deja el valor 0 las imágenes se graban con el tamaño original)";
		// 
		// label5
		// 
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label5.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label5.Location = new System.Drawing.Point(11, 106);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(79, 13);
		this.label5.TabIndex = 8;
		this.label5.Text = "Ancho máximo:";
		// 
		// label4
		// 
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label4.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label4.Location = new System.Drawing.Point(252, 80);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(56, 13);
		this.label4.TabIndex = 6;
		this.label4.Text = "Columnas:";
		// 
		// label3
		// 
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label3.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label3.Location = new System.Drawing.Point(11, 80);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(91, 13);
		this.label3.TabIndex = 4;
		this.label3.Text = "Ancho miniaturas:";
		// 
		// label2
		// 
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label2.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label2.Location = new System.Drawing.Point(11, 52);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(38, 13);
		this.label2.TabIndex = 2;
		this.label2.Text = "Título:";
		// 
		// cmdAccept
		// 
		this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.cmdAccept.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Accept;
		this.cmdAccept.Location = new System.Drawing.Point(205, 172);
		this.cmdAccept.Name = "cmdAccept";
		this.cmdAccept.Size = new System.Drawing.Size(89, 31);
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
		this.cmdCancel.Location = new System.Drawing.Point(300, 172);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size(89, 31);
		this.cmdCancel.TabIndex = 2;
		this.cmdCancel.Text = "&Cancelar";
		this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.cmdCancel.UseVisualStyleBackColor = true;
		// 
		// frmComicGalleryHTML
		// 
		this.AcceptButton = this.cmdAccept;
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.CancelButton = this.cmdCancel;
		this.ClientSize = new System.Drawing.Size(394, 210);
		this.Controls.Add(this.cmdCancel);
		this.Controls.Add(this.cmdAccept);
		this.Controls.Add(this.groupBox1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		this.Name = "frmComicGalleryHTML";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Galería HTML";
		this.Load += new System.EventHandler(this.frmComicGalleryHTML_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize) (this.nudColumns)).EndInit();
		((System.ComponentModel.ISupportInitialize) (this.nudWidthPage)).EndInit();
		((System.ComponentModel.ISupportInitialize) (this.nudWidth)).EndInit();
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.NumericUpDown nudWidth;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private Bau.Controls.Files.TextBoxSelectPath udtPath;
		private System.Windows.Forms.Button cmdAccept;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.NumericUpDown nudColumns;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox chkSeeResult;
		private System.Windows.Forms.NumericUpDown nudWidthPage;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
	}
}