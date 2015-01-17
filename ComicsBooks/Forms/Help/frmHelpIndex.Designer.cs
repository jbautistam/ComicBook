namespace Bau.Applications.ComicsBooks.Forms.Help
{
	partial class frmHelpIndex
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelpIndex));
			this.udtHelpIndex = new Bau.Controls.Help.HelpIndex();
			this.SuspendLayout();
			// 
			// udtHelpIndex
			// 
			this.udtHelpIndex.Dock = System.Windows.Forms.DockStyle.Fill;
			this.udtHelpIndex.Location = new System.Drawing.Point(0, 0);
			this.udtHelpIndex.Name = "udtHelpIndex";
			this.udtHelpIndex.Size = new System.Drawing.Size(211, 325);
			this.udtHelpIndex.TabIndex = 0;
			this.udtHelpIndex.PageClick += new Bau.Controls.Help.HelpIndex.PageClickHandler(this.udtHelpIndex_PageClick);
			// 
			// frmHelpIndex
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(211, 325);
			this.Controls.Add(this.udtHelpIndex);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmHelpIndex";
			this.TabText = "Indice";
			this.Text = "Indice";
			this.Load += new System.EventHandler(this.frmHelpIndex_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private Bau.Controls.Help.HelpIndex udtHelpIndex;

	}
}