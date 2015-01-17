namespace Bau.Applications.ComicsBooks.Forms.Help
{
	partial class frmHelp
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelp));
			this.udtPage = new Bau.Controls.Help.HelpPageControl();
			this.SuspendLayout();
			// 
			// udtPage
			// 
			this.udtPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.udtPage.Location = new System.Drawing.Point(0, 0);
			this.udtPage.Name = "udtPage";
			this.udtPage.Size = new System.Drawing.Size(730, 615);
			this.udtPage.TabIndex = 0;
			// 
			// frmHelp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(730, 615);
			this.Controls.Add(this.udtPage);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmHelp";
			this.ShowInTaskbar = false;
			this.TabText = "Ayuda";
			this.Text = "Ayuda";
			this.Load += new System.EventHandler(this.frmHelp_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private Bau.Controls.Help.HelpPageControl udtPage;

	}
}