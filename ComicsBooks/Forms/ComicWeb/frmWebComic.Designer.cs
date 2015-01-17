namespace Bau.Applications.ComicsBooks.Forms.ComicWeb
{
	partial class frmWebComic
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWebComic));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.cmdGoFirstPage = new System.Windows.Forms.ToolStripButton();
			this.cmdGoPreviousPage = new System.Windows.Forms.ToolStripButton();
			this.cboPages = new System.Windows.Forms.ToolStripComboBox();
			this.cmdGoNextPage = new System.Windows.Forms.ToolStripButton();
			this.cmdGoLastPage = new System.Windows.Forms.ToolStripButton();
			this.imgPage = new Bau.Controls.ImageControls.Picture.PictureZoom();
			this.tableLayoutPanel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.imgPage, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(691, 583);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdGoFirstPage,
            this.cmdGoPreviousPage,
            this.cboPages,
            this.cmdGoNextPage,
            this.cmdGoLastPage});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(691, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// cmdGoFirstPage
			// 
			this.cmdGoFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdGoFirstPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowFirst;
			this.cmdGoFirstPage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdGoFirstPage.Name = "cmdGoFirstPage";
			this.cmdGoFirstPage.Size = new System.Drawing.Size(23, 22);
			this.cmdGoFirstPage.Text = "Primera página";
			this.cmdGoFirstPage.Click += new System.EventHandler(this.cmdGoFirstPage_Click);
			// 
			// cmdGoPreviousPage
			// 
			this.cmdGoPreviousPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdGoPreviousPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowLeft;
			this.cmdGoPreviousPage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdGoPreviousPage.Name = "cmdGoPreviousPage";
			this.cmdGoPreviousPage.Size = new System.Drawing.Size(23, 22);
			this.cmdGoPreviousPage.Text = "Página anterior";
			this.cmdGoPreviousPage.Click += new System.EventHandler(this.cmdGoPreviousPage_Click);
			// 
			// cboPages
			// 
			this.cboPages.Name = "cboPages";
			this.cboPages.Size = new System.Drawing.Size(100, 25);
			this.cboPages.TextUpdate += new System.EventHandler(this.cboPages_TextUpdate);
			this.cboPages.Click += new System.EventHandler(this.cboPages_TextUpdate);
			// 
			// cmdGoNextPage
			// 
			this.cmdGoNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdGoNextPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowRight;
			this.cmdGoNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdGoNextPage.Name = "cmdGoNextPage";
			this.cmdGoNextPage.Size = new System.Drawing.Size(23, 22);
			this.cmdGoNextPage.Text = "Página siguiente";
			this.cmdGoNextPage.Click += new System.EventHandler(this.cmdGoNextPage_Click);
			// 
			// cmdGoLastPage
			// 
			this.cmdGoLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdGoLastPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowLast;
			this.cmdGoLastPage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdGoLastPage.Name = "cmdGoLastPage";
			this.cmdGoLastPage.Size = new System.Drawing.Size(23, 22);
			this.cmdGoLastPage.Text = "Ultima página";
			this.cmdGoLastPage.Click += new System.EventHandler(this.cmdGoLastPage_Click);
			// 
			// imgPage
			// 
			this.imgPage.AutoScroll = true;
			this.imgPage.AutoScrollMinSize = new System.Drawing.Size(4000, 4000);
			this.imgPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imgPage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.imgPage.Location = new System.Drawing.Point(3, 28);
			this.imgPage.Name = "imgPage";
			this.imgPage.Picture = null;
			this.imgPage.Size = new System.Drawing.Size(685, 552);
			this.imgPage.TabIndex = 3;
			this.imgPage.Text = "pictureZoom1";
			this.imgPage.Zoom = 1;
			this.imgPage.ZoomView = Bau.Controls.ImageControls.Picture.PictureZoom.ZoomMode.Normal;
			// 
			// frmWebComic
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(691, 583);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmWebComic";
			this.TabText = "frmNewWebComic";
			this.Text = "frmNewWebComic";
			this.Load += new System.EventHandler(this.frmWebComic_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton cmdGoFirstPage;
		private System.Windows.Forms.ToolStripButton cmdGoPreviousPage;
		private System.Windows.Forms.ToolStripComboBox cboPages;
		private System.Windows.Forms.ToolStripButton cmdGoNextPage;
		private System.Windows.Forms.ToolStripButton cmdGoLastPage;
		private Bau.Controls.ImageControls.Picture.PictureZoom imgPage;
	}
}