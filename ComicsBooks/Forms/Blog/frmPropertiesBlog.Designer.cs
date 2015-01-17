namespace Bau.Applications.ComicsBooks.Forms.Blog
{
	partial class frmPropertiesBlog
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		this.cmdAccept = new System.Windows.Forms.Button();
		this.cmdCancel = new System.Windows.Forms.Button();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.txtUser = new System.Windows.Forms.TextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.txtDescription = new System.Windows.Forms.TextBox();
		this.txtURL = new System.Windows.Forms.TextBox();
		this.txtName = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.chkEnabled = new System.Windows.Forms.CheckBox();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.SuspendLayout();
		// 
		// cmdAccept
		// 
		this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.cmdAccept.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Accept;
		this.cmdAccept.Location = new System.Drawing.Point(369, 233);
		this.cmdAccept.Name = "cmdAccept";
		this.cmdAccept.Size = new System.Drawing.Size(87, 27);
		this.cmdAccept.TabIndex = 2;
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
		this.cmdCancel.Location = new System.Drawing.Point(462, 233);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size(87, 27);
		this.cmdCancel.TabIndex = 3;
		this.cmdCancel.Text = "&Cancelar";
		this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.cmdCancel.UseVisualStyleBackColor = true;
		// 
		// groupBox1
		// 
		this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.groupBox1.Controls.Add(this.txtPassword);
		this.groupBox1.Controls.Add(this.txtUser);
		this.groupBox1.Controls.Add(this.label5);
		this.groupBox1.Controls.Add(this.label4);
		this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
		this.groupBox1.Location = new System.Drawing.Point(7, 177);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(541, 50);
		this.groupBox1.TabIndex = 1;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Credenciales";
		// 
		// txtPassword
		// 
		this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.txtPassword.Location = new System.Drawing.Point(398, 19);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = '*';
		this.txtPassword.Size = new System.Drawing.Size(136, 20);
		this.txtPassword.TabIndex = 3;
		this.txtPassword.UseSystemPasswordChar = true;
		// 
		// txtUser
		// 
		this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.txtUser.Location = new System.Drawing.Point(84, 20);
		this.txtUser.Name = "txtUser";
		this.txtUser.Size = new System.Drawing.Size(136, 20);
		this.txtUser.TabIndex = 1;
		// 
		// label5
		// 
		this.label5.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label5.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label5.Location = new System.Drawing.Point(328, 22);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(64, 13);
		this.label5.TabIndex = 2;
		this.label5.Text = "Contraseña:";
		// 
		// label4
		// 
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label4.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label4.Location = new System.Drawing.Point(14, 24);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(46, 13);
		this.label4.TabIndex = 0;
		this.label4.Text = "Usuario:";
		// 
		// groupBox2
		// 
		this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.groupBox2.Controls.Add(this.chkEnabled);
		this.groupBox2.Controls.Add(this.txtDescription);
		this.groupBox2.Controls.Add(this.txtURL);
		this.groupBox2.Controls.Add(this.txtName);
		this.groupBox2.Controls.Add(this.label3);
		this.groupBox2.Controls.Add(this.label2);
		this.groupBox2.Controls.Add(this.label1);
		this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
		this.groupBox2.Location = new System.Drawing.Point(7, 6);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(541, 165);
		this.groupBox2.TabIndex = 0;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Definición";
		// 
		// txtDescription
		// 
		this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
								| System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.txtDescription.Location = new System.Drawing.Point(84, 64);
		this.txtDescription.Multiline = true;
		this.txtDescription.Name = "txtDescription";
		this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtDescription.Size = new System.Drawing.Size(451, 73);
		this.txtDescription.TabIndex = 5;
		// 
		// txtURL
		// 
		this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.txtURL.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (192)))));
		this.txtURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.txtURL.Location = new System.Drawing.Point(84, 40);
		this.txtURL.Name = "txtURL";
		this.txtURL.Size = new System.Drawing.Size(451, 20);
		this.txtURL.TabIndex = 3;
		// 
		// txtName
		// 
		this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.txtName.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (192)))));
		this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.txtName.Location = new System.Drawing.Point(84, 16);
		this.txtName.Name = "txtName";
		this.txtName.Size = new System.Drawing.Size(451, 20);
		this.txtName.TabIndex = 1;
		// 
		// label3
		// 
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label3.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label3.Location = new System.Drawing.Point(14, 66);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(66, 13);
		this.label3.TabIndex = 4;
		this.label3.Text = "Descripción:";
		// 
		// label2
		// 
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label2.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label2.Location = new System.Drawing.Point(14, 44);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(32, 13);
		this.label2.TabIndex = 2;
		this.label2.Text = "URL:";
		// 
		// label1
		// 
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label1.Location = new System.Drawing.Point(14, 20);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(47, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Nombre:";
		// 
		// chkEnabled
		// 
		this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.chkEnabled.AutoSize = true;
		this.chkEnabled.Checked = true;
		this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.chkEnabled.ForeColor = System.Drawing.Color.Black;
		this.chkEnabled.Location = new System.Drawing.Point(473, 143);
		this.chkEnabled.Name = "chkEnabled";
		this.chkEnabled.Size = new System.Drawing.Size(56, 17);
		this.chkEnabled.TabIndex = 6;
		this.chkEnabled.Text = "&Activo";
		this.chkEnabled.UseVisualStyleBackColor = true;
		// 
		// frmPropertiesBlog
		// 
		this.AcceptButton = this.cmdAccept;
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.CancelButton = this.cmdCancel;
		this.ClientSize = new System.Drawing.Size(553, 264);
		this.Controls.Add(this.groupBox2);
		this.Controls.Add(this.groupBox1);
		this.Controls.Add(this.cmdCancel);
		this.Controls.Add(this.cmdAccept);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmPropertiesBlog";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Propiedades del blog";
		this.Load += new System.EventHandler(this.frmPropertiesBlog_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cmdAccept;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.CheckBox chkEnabled;
	}
}