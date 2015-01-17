namespace Bau.Controls.Help
{
	partial class HelpIndex
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

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.trvHelp = new System.Windows.Forms.TreeView();
			this.imlHelp = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// trvHelp
			// 
			this.trvHelp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trvHelp.HideSelection = false;
			this.trvHelp.Location = new System.Drawing.Point(0, 0);
			this.trvHelp.Name = "trvHelp";
			this.trvHelp.Size = new System.Drawing.Size(237, 255);
			this.trvHelp.TabIndex = 0;
			this.trvHelp.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvHelp_NodeMouseDoubleClick);
			// 
			// imlHelp
			// 
			this.imlHelp.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imlHelp.ImageSize = new System.Drawing.Size(16, 16);
			this.imlHelp.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// HelpIndex
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.trvHelp);
			this.Name = "HelpIndex";
			this.Size = new System.Drawing.Size(237, 255);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView trvHelp;
		private System.Windows.Forms.ImageList imlHelp;
	}
}
