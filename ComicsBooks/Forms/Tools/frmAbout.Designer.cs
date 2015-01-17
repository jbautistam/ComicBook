namespace Bau.Applications.ComicsBooks.Forms.Tools
{
	partial class frmAbout
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
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
		this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
		this.logoPictureBox = new System.Windows.Forms.PictureBox();
		this.labelProductName = new System.Windows.Forms.Label();
		this.labelVersion = new System.Windows.Forms.Label();
		this.labelCopyright = new System.Windows.Forms.Label();
		this.labelCompanyName = new System.Windows.Forms.Label();
		this.textBoxDescription = new System.Windows.Forms.TextBox();
		this.cmdAccept = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.lnkEmail = new System.Windows.Forms.LinkLabel();
		this.label2 = new System.Windows.Forms.Label();
		this.lnkWeb = new System.Windows.Forms.LinkLabel();
		this.tableLayoutPanel.SuspendLayout();
		((System.ComponentModel.ISupportInitialize) (this.logoPictureBox)).BeginInit();
		this.SuspendLayout();
		// 
		// tableLayoutPanel
		// 
		this.tableLayoutPanel.ColumnCount = 3;
		this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 333F));
		this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
		this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
		this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
		this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
		this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
		this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
		this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
		this.tableLayoutPanel.Controls.Add(this.cmdAccept, 2, 7);
		this.tableLayoutPanel.Controls.Add(this.label1, 1, 6);
		this.tableLayoutPanel.Controls.Add(this.lnkEmail, 2, 6);
		this.tableLayoutPanel.Controls.Add(this.label2, 1, 5);
		this.tableLayoutPanel.Controls.Add(this.lnkWeb, 2, 5);
		this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
		this.tableLayoutPanel.Name = "tableLayoutPanel";
		this.tableLayoutPanel.RowCount = 8;
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
		this.tableLayoutPanel.Size = new System.Drawing.Size(625, 507);
		this.tableLayoutPanel.TabIndex = 0;
		// 
		// logoPictureBox
		// 
		this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
		this.logoPictureBox.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Splash;
		this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
		this.logoPictureBox.Name = "logoPictureBox";
		this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 8);
		this.logoPictureBox.Size = new System.Drawing.Size(327, 501);
		this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.logoPictureBox.TabIndex = 12;
		this.logoPictureBox.TabStop = false;
		// 
		// labelProductName
		// 
		this.tableLayoutPanel.SetColumnSpan(this.labelProductName, 2);
		this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
		this.labelProductName.Location = new System.Drawing.Point(339, 0);
		this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
		this.labelProductName.Name = "labelProductName";
		this.labelProductName.Size = new System.Drawing.Size(283, 17);
		this.labelProductName.TabIndex = 19;
		this.labelProductName.Text = "Nombre del producto";
		this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// labelVersion
		// 
		this.tableLayoutPanel.SetColumnSpan(this.labelVersion, 2);
		this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
		this.labelVersion.Location = new System.Drawing.Point(339, 25);
		this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
		this.labelVersion.Name = "labelVersion";
		this.labelVersion.Size = new System.Drawing.Size(283, 17);
		this.labelVersion.TabIndex = 0;
		this.labelVersion.Text = "Versión";
		this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// labelCopyright
		// 
		this.tableLayoutPanel.SetColumnSpan(this.labelCopyright, 2);
		this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
		this.labelCopyright.Location = new System.Drawing.Point(339, 45);
		this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
		this.labelCopyright.Name = "labelCopyright";
		this.labelCopyright.Size = new System.Drawing.Size(283, 17);
		this.labelCopyright.TabIndex = 21;
		this.labelCopyright.Text = "Copyright";
		this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// labelCompanyName
		// 
		this.tableLayoutPanel.SetColumnSpan(this.labelCompanyName, 2);
		this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
		this.labelCompanyName.Location = new System.Drawing.Point(339, 67);
		this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
		this.labelCompanyName.Name = "labelCompanyName";
		this.labelCompanyName.Size = new System.Drawing.Size(283, 17);
		this.labelCompanyName.TabIndex = 22;
		this.labelCompanyName.Text = "Nombre de la compañía";
		this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// textBoxDescription
		// 
		this.tableLayoutPanel.SetColumnSpan(this.textBoxDescription, 2);
		this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
		this.textBoxDescription.Location = new System.Drawing.Point(339, 96);
		this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		this.textBoxDescription.Multiline = true;
		this.textBoxDescription.Name = "textBoxDescription";
		this.textBoxDescription.ReadOnly = true;
		this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.textBoxDescription.Size = new System.Drawing.Size(283, 335);
		this.textBoxDescription.TabIndex = 23;
		this.textBoxDescription.TabStop = false;
		this.textBoxDescription.Text = "Descripción";
		// 
		// cmdAccept
		// 
		this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.cmdAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdAccept.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Accept;
		this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdAccept.Location = new System.Drawing.Point(526, 478);
		this.cmdAccept.Name = "cmdAccept";
		this.cmdAccept.Size = new System.Drawing.Size(96, 26);
		this.cmdAccept.TabIndex = 24;
		this.cmdAccept.Text = "&Aceptar";
		// 
		// label1
		// 
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(336, 456);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(35, 13);
		this.label1.TabIndex = 26;
		this.label1.Text = "eMail:";
		// 
		// lnkEmail
		// 
		this.lnkEmail.AutoSize = true;
		this.lnkEmail.Location = new System.Drawing.Point(389, 456);
		this.lnkEmail.Name = "lnkEmail";
		this.lnkEmail.Size = new System.Drawing.Size(152, 13);
		this.lnkEmail.TabIndex = 25;
		this.lnkEmail.TabStop = true;
		this.lnkEmail.Text = "jbautistam@ant2e6.site11.com";
		// 
		// label2
		// 
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(336, 434);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(33, 13);
		this.label2.TabIndex = 26;
		this.label2.Text = "Web:";
		// 
		// lnkWeb
		// 
		this.lnkWeb.AutoSize = true;
		this.lnkWeb.Location = new System.Drawing.Point(389, 434);
		this.lnkWeb.Name = "lnkWeb";
		this.lnkWeb.Size = new System.Drawing.Size(125, 13);
		this.lnkWeb.TabIndex = 25;
		this.lnkWeb.TabStop = true;
		this.lnkWeb.Text = "http://ant2e6.site11.com";
		this.lnkWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWeb_LinkClicked);
		// 
		// frmAbout
		// 
		this.AcceptButton = this.cmdAccept;
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.CancelButton = this.cmdAccept;
		this.ClientSize = new System.Drawing.Size(643, 525);
		this.Controls.Add(this.tableLayoutPanel);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmAbout";
		this.Padding = new System.Windows.Forms.Padding(9);
		this.ShowIcon = false;
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Acerca de ";
		this.Load += new System.EventHandler(this.frmAbout_Load);
		this.tableLayoutPanel.ResumeLayout(false);
		this.tableLayoutPanel.PerformLayout();
		((System.ComponentModel.ISupportInitialize) (this.logoPictureBox)).EndInit();
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.PictureBox logoPictureBox;
		private System.Windows.Forms.Label labelProductName;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.Label labelCompanyName;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Button cmdAccept;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel lnkEmail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel lnkWeb;
	}
}
