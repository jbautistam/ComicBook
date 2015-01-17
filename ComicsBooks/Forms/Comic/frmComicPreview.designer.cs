namespace  Bau.Applications.ComicsBooks.Forms.Comic
{
	partial class frmComicPreview
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComicPreview));
			this.udtPreview = new Bau.Controls.ImageControls.Print.ImagePrinterPreview();
			this.SuspendLayout();
			// 
			// udtPreview
			// 
			this.udtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.udtPreview.Location = new System.Drawing.Point(0, 0);
			this.udtPreview.Name = "udtPreview";
			this.udtPreview.Size = new System.Drawing.Size(779, 613);
			this.udtPreview.TabIndex = 0;
			// 
			// frmReportPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(779, 613);
			this.Controls.Add(this.udtPreview);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmReportPreview";
			this.TabText = "Visor de informes";
			this.Text = "Visor de informes";
			this.Load += new System.EventHandler(this.frmReport_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private Bau.Controls.ImageControls.Print.ImagePrinterPreview udtPreview;

	}
}