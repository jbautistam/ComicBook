using System.Windows.Forms;

namespace Bau.Controls.Files
{
	partial class TreePath : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ImageList imlIcons;
		private System.Windows.Forms.TreeView trvFiles;		
		
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreePath));
		this.trvFiles = new System.Windows.Forms.TreeView();
		this.imlIcons = new System.Windows.Forms.ImageList(this.components);
		this.SuspendLayout();
		// 
		// trvFiles
		// 
		this.trvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
		this.trvFiles.HideSelection = false;
		this.trvFiles.ImageIndex = 0;
		this.trvFiles.ImageList = this.imlIcons;
		this.trvFiles.Location = new System.Drawing.Point(0, 0);
		this.trvFiles.Name = "trvFiles";
		this.trvFiles.SelectedImageIndex = 0;
		this.trvFiles.Size = new System.Drawing.Size(292, 360);
		this.trvFiles.TabIndex = 0;
		this.trvFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TrvFilesNodeMouseDoubleClick);
		this.trvFiles.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TrvFilesAfterLabelEdit);
		this.trvFiles.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TrvFilesBeforeExpand);
		this.trvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.TrvFilesDragDrop);
		this.trvFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvFilesAfterSelect);
		this.trvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.TrvFilesDragEnter);
		this.trvFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TrvFilesItemDrag);
		this.trvFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.TrvFilesDragOver);
		// 
		// imlIcons
		// 
		this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imlIcons.ImageStream")));
		this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
		this.imlIcons.Images.SetKeyName(0, "");
		this.imlIcons.Images.SetKeyName(1, "");
		this.imlIcons.Images.SetKeyName(2, "");
		this.imlIcons.Images.SetKeyName(3, "");
		this.imlIcons.Images.SetKeyName(4, "");
		this.imlIcons.Images.SetKeyName(5, "");
		this.imlIcons.Images.SetKeyName(6, "");
		this.imlIcons.Images.SetKeyName(7, "");
		this.imlIcons.Images.SetKeyName(8, "");
		this.imlIcons.Images.SetKeyName(9, "");
		this.imlIcons.Images.SetKeyName(10, "");
		this.imlIcons.Images.SetKeyName(11, "");
		this.imlIcons.Images.SetKeyName(12, "");
		// 
		// TreePath
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.Controls.Add(this.trvFiles);
		this.Name = "TreePath";
		this.Size = new System.Drawing.Size(292, 360);
		this.ResumeLayout(false);

		}
		
		void TrvFilesBeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{ TreatNodeExpand(e.Node);
		}
		
		void TrvFilesAfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{ TreatNodeSelected(e.Node);			
		}
		
		void TrvFilesNodeMouseDoubleClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
		{ if (e.Button == MouseButtons.Left)
				TreatNodeDoubleClick(e.Node);
		}
		
		void TrvFilesItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{ if (e.Button == MouseButtons.Left)
				DoDragDrop(e.Item, DragDropEffects.Move);
		}
		
		void TrvFilesDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{ e.Effect = e.AllowedEffect;			
		}
		
		void TrvFilesDragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{ trvFiles.SelectedNode = GetNodeAt(e.X, e.Y);
		}
		
		void TrvFilesDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{ TreeNode trnTarget = GetNodeAt(e.X, e.Y);
			TreeNode trnSource = (TreeNode) e.Data.GetData(typeof(TreeNode));
			
				if ((e.KeyState & 8) != 0) // ... se está pulsando la tecla control
					MoveFiles(trnSource, trnTarget, DragDropEffects.Copy);
				else
					MoveFiles(trnSource, trnTarget, DragDropEffects.Move);					
		}
		
		void TrvFilesAfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{ e.CancelEdit = RenameFile(e.Node, e.Label);
		}
	}
}
