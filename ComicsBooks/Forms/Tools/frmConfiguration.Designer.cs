namespace Bau.Applications.ComicsBooks.Forms.Tools
{
	partial class frmConfiguration
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
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.chkLinkEPub = new System.Windows.Forms.CheckBox();
		this.chkLinkCBT = new System.Windows.Forms.CheckBox();
		this.chkLinkCBZ = new System.Windows.Forms.CheckBox();
		this.chkLinkCBR = new System.Windows.Forms.CheckBox();
		this.cmdAccept = new System.Windows.Forms.Button();
		this.cmdCancel = new System.Windows.Forms.Button();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.chkAddFiles = new System.Windows.Forms.CheckBox();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.nudPort = new System.Windows.Forms.NumericUpDown();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.txtUser = new System.Windows.Forms.TextBox();
		this.txtServer = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.chkUseProxy = new System.Windows.Forms.CheckBox();
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.fnTemplateFeed = new Bau.Controls.Files.TextBoxSelectFile();
		this.nudMarkNotUpdated = new Bau.Controls.TextBox.NumericUpDowExtended();
		this.nudMarkRead = new Bau.Controls.TextBox.NumericUpDowExtended();
		this.nudDownloadInterval = new Bau.Controls.TextBox.NumericUpDowExtended();
		this.label12 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.chkMarkReadAuto = new System.Windows.Forms.CheckBox();
		this.chkDownloadBlog = new System.Windows.Forms.CheckBox();
		this.label6 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.groupBox3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize) (this.nudPort)).BeginInit();
		this.groupBox4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize) (this.nudMarkNotUpdated)).BeginInit();
		((System.ComponentModel.ISupportInitialize) (this.nudMarkRead)).BeginInit();
		((System.ComponentModel.ISupportInitialize) (this.nudDownloadInterval)).BeginInit();
		this.SuspendLayout();
		// 
		// groupBox1
		// 
		this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.groupBox1.Controls.Add(this.chkLinkEPub);
		this.groupBox1.Controls.Add(this.chkLinkCBT);
		this.groupBox1.Controls.Add(this.chkLinkCBZ);
		this.groupBox1.Controls.Add(this.chkLinkCBR);
		this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
		this.groupBox1.Location = new System.Drawing.Point(4, 49);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(311, 44);
		this.groupBox1.TabIndex = 1;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Asociación de archivos con extensión";
		// 
		// chkLinkEPub
		// 
		this.chkLinkEPub.AutoSize = true;
		this.chkLinkEPub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.chkLinkEPub.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.chkLinkEPub.Location = new System.Drawing.Point(244, 20);
		this.chkLinkEPub.Name = "chkLinkEPub";
		this.chkLinkEPub.Size = new System.Drawing.Size(54, 17);
		this.chkLinkEPub.TabIndex = 2;
		this.chkLinkEPub.Text = ".ePub";
		this.chkLinkEPub.UseVisualStyleBackColor = true;
		// 
		// chkLinkCBT
		// 
		this.chkLinkCBT.AutoSize = true;
		this.chkLinkCBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.chkLinkCBT.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.chkLinkCBT.Location = new System.Drawing.Point(89, 20);
		this.chkLinkCBT.Name = "chkLinkCBT";
		this.chkLinkCBT.Size = new System.Drawing.Size(50, 17);
		this.chkLinkCBT.TabIndex = 2;
		this.chkLinkCBT.Text = ".CBT";
		this.chkLinkCBT.UseVisualStyleBackColor = true;
		// 
		// chkLinkCBZ
		// 
		this.chkLinkCBZ.AutoSize = true;
		this.chkLinkCBZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.chkLinkCBZ.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.chkLinkCBZ.Location = new System.Drawing.Point(169, 20);
		this.chkLinkCBZ.Name = "chkLinkCBZ";
		this.chkLinkCBZ.Size = new System.Drawing.Size(50, 17);
		this.chkLinkCBZ.TabIndex = 1;
		this.chkLinkCBZ.Text = ".CBZ";
		this.chkLinkCBZ.UseVisualStyleBackColor = true;
		// 
		// chkLinkCBR
		// 
		this.chkLinkCBR.AutoSize = true;
		this.chkLinkCBR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.chkLinkCBR.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.chkLinkCBR.Location = new System.Drawing.Point(19, 20);
		this.chkLinkCBR.Name = "chkLinkCBR";
		this.chkLinkCBR.Size = new System.Drawing.Size(51, 17);
		this.chkLinkCBR.TabIndex = 0;
		this.chkLinkCBR.Text = ".CBR";
		this.chkLinkCBR.UseVisualStyleBackColor = true;
		// 
		// cmdAccept
		// 
		this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.cmdAccept.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Accept;
		this.cmdAccept.Location = new System.Drawing.Point(141, 419);
		this.cmdAccept.Name = "cmdAccept";
		this.cmdAccept.Size = new System.Drawing.Size(84, 25);
		this.cmdAccept.TabIndex = 3;
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
		this.cmdCancel.Location = new System.Drawing.Point(231, 419);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size(84, 25);
		this.cmdCancel.TabIndex = 4;
		this.cmdCancel.Text = "&Cancelar";
		this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.cmdCancel.UseVisualStyleBackColor = true;
		// 
		// groupBox2
		// 
		this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.groupBox2.Controls.Add(this.chkAddFiles);
		this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
		this.groupBox2.Location = new System.Drawing.Point(4, 3);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(311, 42);
		this.groupBox2.TabIndex = 0;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Biblioteca";
		// 
		// chkAddFiles
		// 
		this.chkAddFiles.AutoSize = true;
		this.chkAddFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.chkAddFiles.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.chkAddFiles.Location = new System.Drawing.Point(19, 18);
		this.chkAddFiles.Name = "chkAddFiles";
		this.chkAddFiles.Size = new System.Drawing.Size(223, 17);
		this.chkAddFiles.TabIndex = 0;
		this.chkAddFiles.Text = "Añadir a la biblioteca los archivos abiertos";
		this.chkAddFiles.UseVisualStyleBackColor = true;
		// 
		// groupBox3
		// 
		this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.groupBox3.Controls.Add(this.nudPort);
		this.groupBox3.Controls.Add(this.txtPassword);
		this.groupBox3.Controls.Add(this.txtUser);
		this.groupBox3.Controls.Add(this.txtServer);
		this.groupBox3.Controls.Add(this.label4);
		this.groupBox3.Controls.Add(this.label3);
		this.groupBox3.Controls.Add(this.label2);
		this.groupBox3.Controls.Add(this.label1);
		this.groupBox3.Controls.Add(this.chkUseProxy);
		this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
		this.groupBox3.Location = new System.Drawing.Point(4, 273);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(311, 141);
		this.groupBox3.TabIndex = 2;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Conexión a Internet";
		// 
		// nudPort
		// 
		this.nudPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.nudPort.Location = new System.Drawing.Point(127, 66);
		this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
		this.nudPort.Name = "nudPort";
		this.nudPort.Size = new System.Drawing.Size(92, 20);
		this.nudPort.TabIndex = 4;
		// 
		// txtPassword
		// 
		this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.txtPassword.Location = new System.Drawing.Point(127, 113);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = '*';
		this.txtPassword.Size = new System.Drawing.Size(139, 20);
		this.txtPassword.TabIndex = 8;
		this.txtPassword.UseSystemPasswordChar = true;
		// 
		// txtUser
		// 
		this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.txtUser.Location = new System.Drawing.Point(127, 90);
		this.txtUser.Name = "txtUser";
		this.txtUser.Size = new System.Drawing.Size(139, 20);
		this.txtUser.TabIndex = 6;
		// 
		// txtServer
		// 
		this.txtServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.txtServer.Location = new System.Drawing.Point(127, 43);
		this.txtServer.Name = "txtServer";
		this.txtServer.Size = new System.Drawing.Size(139, 20);
		this.txtServer.TabIndex = 2;
		// 
		// label4
		// 
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label4.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label4.Location = new System.Drawing.Point(30, 117);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(64, 13);
		this.label4.TabIndex = 7;
		this.label4.Text = "Contraseña:";
		// 
		// label3
		// 
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label3.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label3.Location = new System.Drawing.Point(30, 94);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(46, 13);
		this.label3.TabIndex = 5;
		this.label3.Text = "Usuario:";
		// 
		// label2
		// 
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label2.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label2.Location = new System.Drawing.Point(30, 70);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(41, 13);
		this.label2.TabIndex = 3;
		this.label2.Text = "Puerto:";
		// 
		// label1
		// 
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label1.Location = new System.Drawing.Point(30, 47);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(77, 13);
		this.label1.TabIndex = 1;
		this.label1.Text = "Servidor proxy:";
		// 
		// chkUseProxy
		// 
		this.chkUseProxy.AutoSize = true;
		this.chkUseProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.chkUseProxy.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.chkUseProxy.Location = new System.Drawing.Point(19, 20);
		this.chkUseProxy.Name = "chkUseProxy";
		this.chkUseProxy.Size = new System.Drawing.Size(85, 17);
		this.chkUseProxy.TabIndex = 0;
		this.chkUseProxy.Text = "Utilizar proxy";
		this.chkUseProxy.UseVisualStyleBackColor = true;
		this.chkUseProxy.CheckedChanged += new System.EventHandler(this.chkUseProxy_CheckedChanged);
		// 
		// groupBox4
		// 
		this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.groupBox4.Controls.Add(this.fnTemplateFeed);
		this.groupBox4.Controls.Add(this.nudMarkNotUpdated);
		this.groupBox4.Controls.Add(this.nudMarkRead);
		this.groupBox4.Controls.Add(this.nudDownloadInterval);
		this.groupBox4.Controls.Add(this.label12);
		this.groupBox4.Controls.Add(this.label10);
		this.groupBox4.Controls.Add(this.chkMarkReadAuto);
		this.groupBox4.Controls.Add(this.chkDownloadBlog);
		this.groupBox4.Controls.Add(this.label6);
		this.groupBox4.Controls.Add(this.label11);
		this.groupBox4.Controls.Add(this.label9);
		this.groupBox4.Controls.Add(this.label8);
		this.groupBox4.Controls.Add(this.label5);
		this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
		this.groupBox4.Location = new System.Drawing.Point(4, 97);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Size = new System.Drawing.Size(311, 172);
		this.groupBox4.TabIndex = 5;
		this.groupBox4.TabStop = false;
		this.groupBox4.Text = "Blogs";
		// 
		// fnTemplateFeed
		// 
		this.fnTemplateFeed.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.fnTemplateFeed.FileName = "";
		this.fnTemplateFeed.Filter = "Archivos XML|*.xml|Todos los archivos|*.*";
		this.fnTemplateFeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.fnTemplateFeed.ForeColor = System.Drawing.Color.Black;
		this.fnTemplateFeed.Location = new System.Drawing.Point(63, 20);
		this.fnTemplateFeed.MaximumSize = new System.Drawing.Size(11667, 20);
		this.fnTemplateFeed.MinimumSize = new System.Drawing.Size(233, 20);
		this.fnTemplateFeed.Name = "fnTemplateFeed";
		this.fnTemplateFeed.Size = new System.Drawing.Size(236, 20);
		this.fnTemplateFeed.TabIndex = 1;
		this.fnTemplateFeed.Type = Bau.Controls.Files.TextBoxSelectFile.FileSelectType.Load;
		// 
		// nudMarkNotUpdated
		// 
		this.nudMarkNotUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.nudMarkNotUpdated.Location = new System.Drawing.Point(169, 138);
		this.nudMarkNotUpdated.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
		this.nudMarkNotUpdated.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
		this.nudMarkNotUpdated.Name = "nudMarkNotUpdated";
		this.nudMarkNotUpdated.Size = new System.Drawing.Size(70, 20);
		this.nudMarkNotUpdated.TabIndex = 11;
		this.nudMarkNotUpdated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.nudMarkNotUpdated.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
		// 
		// nudMarkRead
		// 
		this.nudMarkRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.nudMarkRead.Location = new System.Drawing.Point(169, 115);
		this.nudMarkRead.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
		this.nudMarkRead.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
		this.nudMarkRead.Name = "nudMarkRead";
		this.nudMarkRead.Size = new System.Drawing.Size(70, 20);
		this.nudMarkRead.TabIndex = 8;
		this.nudMarkRead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.nudMarkRead.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
		// 
		// nudDownloadInterval
		// 
		this.nudDownloadInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.nudDownloadInterval.Location = new System.Drawing.Point(171, 68);
		this.nudDownloadInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
		this.nudDownloadInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
		this.nudDownloadInterval.Name = "nudDownloadInterval";
		this.nudDownloadInterval.Size = new System.Drawing.Size(70, 20);
		this.nudDownloadInterval.TabIndex = 4;
		this.nudDownloadInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.nudDownloadInterval.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
		// 
		// label12
		// 
		this.label12.AutoSize = true;
		this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label12.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label12.Location = new System.Drawing.Point(245, 142);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(28, 13);
		this.label12.TabIndex = 12;
		this.label12.Text = "días";
		// 
		// label10
		// 
		this.label10.AutoSize = true;
		this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label10.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label10.Location = new System.Drawing.Point(245, 119);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(53, 13);
		this.label10.TabIndex = 9;
		this.label10.Text = "segundos";
		// 
		// chkMarkReadAuto
		// 
		this.chkMarkReadAuto.AutoSize = true;
		this.chkMarkReadAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.chkMarkReadAuto.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.chkMarkReadAuto.Location = new System.Drawing.Point(11, 93);
		this.chkMarkReadAuto.Name = "chkMarkReadAuto";
		this.chkMarkReadAuto.Size = new System.Drawing.Size(192, 17);
		this.chkMarkReadAuto.TabIndex = 6;
		this.chkMarkReadAuto.Text = "Marcar como leídos al previsualizar";
		this.chkMarkReadAuto.UseVisualStyleBackColor = true;
		// 
		// chkDownloadBlog
		// 
		this.chkDownloadBlog.AutoSize = true;
		this.chkDownloadBlog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.chkDownloadBlog.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.chkDownloadBlog.Location = new System.Drawing.Point(11, 49);
		this.chkDownloadBlog.Name = "chkDownloadBlog";
		this.chkDownloadBlog.Size = new System.Drawing.Size(159, 17);
		this.chkDownloadBlog.TabIndex = 2;
		this.chkDownloadBlog.Text = "Descargar automáticamente";
		this.chkDownloadBlog.UseVisualStyleBackColor = true;
		// 
		// label6
		// 
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label6.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label6.Location = new System.Drawing.Point(247, 72);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(43, 13);
		this.label6.TabIndex = 5;
		this.label6.Text = "minutos";
		// 
		// label11
		// 
		this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label11.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label11.Location = new System.Drawing.Point(7, 137);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(160, 30);
		this.label11.TabIndex = 10;
		this.label11.Text = "Marcar como inactivos los blogs no modificados en";
		// 
		// label9
		// 
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label9.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label9.Location = new System.Drawing.Point(43, 119);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(124, 13);
		this.label9.TabIndex = 7;
		this.label9.Text = "Marcar como leídos tras ";
		// 
		// label8
		// 
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label8.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label8.Location = new System.Drawing.Point(8, 25);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(46, 13);
		this.label8.TabIndex = 0;
		this.label8.Text = "Plantilla:";
		// 
		// label5
		// 
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.label5.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (192)))));
		this.label5.Location = new System.Drawing.Point(45, 72);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(86, 13);
		this.label5.TabIndex = 3;
		this.label5.Text = "Descargar cada ";
		// 
		// frmConfiguration
		// 
		this.AcceptButton = this.cmdAccept;
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.CancelButton = this.cmdCancel;
		this.ClientSize = new System.Drawing.Size(321, 450);
		this.Controls.Add(this.groupBox4);
		this.Controls.Add(this.cmdCancel);
		this.Controls.Add(this.cmdAccept);
		this.Controls.Add(this.groupBox2);
		this.Controls.Add(this.groupBox3);
		this.Controls.Add(this.groupBox1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		this.Name = "frmConfiguration";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Configuración";
		this.Load += new System.EventHandler(this.frmConfiguration_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		((System.ComponentModel.ISupportInitialize) (this.nudPort)).EndInit();
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		((System.ComponentModel.ISupportInitialize) (this.nudMarkNotUpdated)).EndInit();
		((System.ComponentModel.ISupportInitialize) (this.nudMarkRead)).EndInit();
		((System.ComponentModel.ISupportInitialize) (this.nudDownloadInterval)).EndInit();
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkLinkCBZ;
		private System.Windows.Forms.CheckBox chkLinkCBR;
		private System.Windows.Forms.Button cmdAccept;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.CheckBox chkLinkCBT;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chkAddFiles;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkUseProxy;
		private System.Windows.Forms.NumericUpDown nudPort;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.CheckBox chkLinkEPub;
		private System.Windows.Forms.GroupBox groupBox4;
		private Bau.Controls.Files.TextBoxSelectFile fnTemplateFeed;
		private Bau.Controls.TextBox.NumericUpDowExtended nudMarkNotUpdated;
		private Bau.Controls.TextBox.NumericUpDowExtended nudMarkRead;
		private Bau.Controls.TextBox.NumericUpDowExtended nudDownloadInterval;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox chkMarkReadAuto;
		private System.Windows.Forms.CheckBox chkDownloadBlog;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
	}
}