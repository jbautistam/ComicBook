using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Applications.ComicsBooks.Classes;

namespace Bau.Applications.ComicsBooks.Forms.Explorer
{
	/// <summary>
	///		Formulario con el explorador de archivos
	/// </summary>
	public partial class frmExplorer : WeifenLuo.WinFormsUI.Docking.DockContent, IPluginDocument
	{
		public frmExplorer()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ udtFiles.Mask = "*.cbr;*.cbz;*.rar;*.zip;*.tar;*.cbt;*.jpg;*.gif;*.png;*.bmp;*.epub;*.pdf";
		}
		
		/// <summary>
		///		Actualiza el formulario (se llama desde el programa principal)
		/// </summary>
		public void RefreshForm()
		{ InitForm();
		}

		/// <summary>
		///		Comprueba si puede mostrar el menú
		/// </summary>
		private bool ShowMenu()
		{ if (udtFiles.SelectedFile != null)
				return true;
			else
				return false;
		}

		/// <summary>
		///		Carga un cómic
		/// </summary>
		private void LoadComic(Bau.Controls.Files.FilesInfo.clsFile objFile)
		{ if (objFile != null)
		    LoadComic(objFile.FullName);
		}
		
		/// <summary>
		///		Carga un cómic
		/// </summary>
		private void LoadComic(string strFileName)
		{ if (!string.IsNullOrEmpty(strFileName))
				{ // Abre el archivo
						Program.DockedForms.OpenForm(strFileName);
					// Añade el nombre de archivo a la lista de últimos archivos
						Program.MainWindow.AddLastFile(strFileName);
				}
		}
				
		/// <summary>
		///		Ejecuta una acción del programa principal
		/// </summary>
		public void ExecuteAction(clsEnums.TypeAction intAction)
		{	switch (intAction)
				{ case clsEnums.TypeAction.Open:
							LoadComic(udtFiles.SelectedFile);
						break;
					case clsEnums.TypeAction.Copy:
							udtFiles.Copy();
						break;
					case clsEnums.TypeAction.Cut:
							udtFiles.Cut();
						break;
					case clsEnums.TypeAction.Paste:
							udtFiles.Paste();
						break;
					case clsEnums.TypeAction.Remove:
							if (Bau.Controls.Forms.Helper.ShowQuestion(this, "¿Desea borrar este archivo?"))
								udtFiles.KillFile();
						break;
				}
		}

		/// <summary>
		///		Comprueba si el formulario puede realizar una acción
		/// </summary>
		public bool CanExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Open:
					case clsEnums.TypeAction.Cut:
					case clsEnums.TypeAction.Copy:
					case clsEnums.TypeAction.Remove:
						return udtFiles.SelectedFile != null;
					case clsEnums.TypeAction.Refresh:
						return true;
					default:
						return false;
				}
		}
		
		private void frmPluginsExplorer_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void udtFiles_FileDoubleClick(object objSender, Bau.Controls.Files.Events.clsFileEventArgs objFileEvent)
		{ LoadComic(objFileEvent.File.FullName);
		}

		private void mnuExplorerOpen_Click(object sender, EventArgs e)
		{ LoadComic(udtFiles.SelectedFile);
		}

		private void udtFiles_FileSelected(object objSender, Bau.Controls.Files.Events.clsFileEventArgs objFileEvent)
		{ Program.MainWindow.RefreshWindow();
		}

		private void mnuExplorerRename_Click(object sender, EventArgs e)
		{ udtFiles.Rename();
		}

		private void mnuExplorerCopy_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Copy);
		}

		private void mnuExplorerCut_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Cut);
		}

		private void mnuExplorerPaste_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Paste);
		}

		private void mnuExplorerDelete_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Remove);
		}

		private void ctxMnuExplorer_Opening(object sender, CancelEventArgs e)
		{ e.Cancel = !ShowMenu();
		}
	}
}