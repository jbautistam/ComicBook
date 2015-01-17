using System;
using System.Windows.Forms;

namespace Bau.Controls.Files
{
	partial class ListFiles : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ImageList imlIcons;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListFiles));
			this.imlIcons = new System.Windows.Forms.ImageList(this.components);
			this.lswFiles = new Bau.Controls.Files.List.ListViewExtended();
			this.SuspendLayout();
			// 
			// imlIcons
			// 
			this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
			this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.imlIcons.Images.SetKeyName(0, "CLSDFOLD.ICO");
			this.imlIcons.Images.SetKeyName(1, "OPENFOLD.ICO");
			// 
			// lswFiles
			// 
			this.lswFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lswFiles.FullRowSelect = true;
			this.lswFiles.HideSelection = false;
			this.lswFiles.Location = new System.Drawing.Point(0, 0);
			this.lswFiles.Name = "lswFiles";
			this.lswFiles.SelectedKey = null;
			this.lswFiles.Size = new System.Drawing.Size(274, 298);
			this.lswFiles.TabIndex = 1;
			this.lswFiles.UseCompatibleStateImageBehavior = false;
			this.lswFiles.View = System.Windows.Forms.View.Details;
			this.lswFiles.SelectedIndexChanged += new System.EventHandler(this.lswFiles_SelectedIndexChanged);
			this.lswFiles.ItemDoubleClick += new Bau.Controls.Files.List.ListViewExtended.ItemDoubleClickHandler(this.lswFiles_ItemDoubleClick);
			// 
			// ListFiles
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lswFiles);
			this.Name = "ListFiles";
			this.Size = new System.Drawing.Size(274, 298);
			this.ResumeLayout(false);

		}

		private Bau.Controls.Files.List.ListViewExtended lswFiles;
	}
}
