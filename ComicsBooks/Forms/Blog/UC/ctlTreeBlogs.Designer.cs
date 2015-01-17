namespace Bau.Applications.ComicsBooks.Forms.Blog.UC
{
	partial class ctlTreeBlogs
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		this.trvFiles = new Bau.Controls.Tree.TreeViewExtended();
		this.SuspendLayout();
		// 
		// trvFiles
		// 
		this.trvFiles.CheckRecursive = false;
		this.trvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
		this.trvFiles.AllowDrop = true;
		this.trvFiles.HideSelection = false;
		this.trvFiles.Location = new System.Drawing.Point(0, 0);
		this.trvFiles.Name = "trvFiles";
		this.trvFiles.ShowNodeToolTips = true;
		this.trvFiles.Size = new System.Drawing.Size(342, 426);
		this.trvFiles.TabIndex = 0;
		this.trvFiles.DropItem += new Bau.Controls.Tree.TreeViewExtended.DropItemHandler(this.trvFiles_DropItem);
		this.trvFiles.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.trvFiles_AfterLabelEdit);
		this.trvFiles.NodeDoubleClick += new Bau.Controls.Tree.TreeViewExtended.NodeDoubleClickHandler(this.trvFiles_NodeDoubleClick);
		this.trvFiles.NodeDelete += new Bau.Controls.Tree.TreeViewExtended.NodeDeleteClickHandler(this.trvFiles_NodeDelete);
		// 
		// ctlTreeBlogs
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.Controls.Add(this.trvFiles);
		this.Name = "ctlTreeBlogs";
		this.Size = new System.Drawing.Size(342, 426);
		this.ResumeLayout(false);

		}

		#endregion

		private Bau.Controls.Tree.TreeViewExtended trvFiles;
	}
}
