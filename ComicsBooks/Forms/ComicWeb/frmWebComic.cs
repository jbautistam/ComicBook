using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Applications.ComicsBooks.Classes;
using Bau.Applications.ComicsBooks.Classes.ComicWeb;

namespace Bau.Applications.ComicsBooks.Forms.ComicWeb
{
	/// <summary>
	/// 	Formulario para descarga y visualización de cómics de UComics
	/// </summary>
	public partial class frmWebComic : WeifenLuo.WinFormsUI.Docking.DockContent, IFormAdmon<string>
	{ // Variables privadas
			private clsComicWeb objComicWeb = new clsComicWeb();
			
		public frmWebComic()
		{	InitializeComponent();
		}

		/// <summary>
		/// 	Inicializa el formulario
		/// </summary>
		private void InitForm()
		{	// Cambia el título del formulario
				TabText = Text = objComicWeb.Name;
			// Inicializa el combo con las fechas
				for (int intIndex = 0; intIndex < 20; intIndex++)
					cboPages.Items.Add(DateTime.Now.AddDays(-intIndex).ToShortDateString());
				cboPages.SelectedIndex = 0;
			// Muestra la imagen
				ShowPage(GetComboDate());
		}
		
		/// <summary>
		///		Obtiene el nombre de un archivo de cómic en local
		/// </summary>
		private string GetLocalFileName(clsComicWeb objComic, DateTime dtmDate)
		{ return System.IO.Path.Combine(System.IO.Path.Combine(clsConfiguration.PathBaseComicsWeb, 
																													 objComic.LocalPath),
																		string.Format("{0:yyyymmdd}", dtmDate) + "." + objComic.Extension);
		}
		
		/// <summary>
		///		Muestra una página de una fecha determinada (la fecha está en formato cadena)
		/// </summary>
		private DateTime GetComboDate()
		{ DateTime dtmDate;
		
				if (!DateTime.TryParse(cboPages.Text, out dtmDate))
					return dtmDate;
				else
					return DateTime.Now;
		}
		
		/// <summary>
		///		Muestra una página de una fecha determinada
		/// </summary>
		private void ShowPage(DateTime dtmDate)
		{ string strFileName;
		
				// Obtiene el nombre del cómic para esa fecha
					strFileName = GetLocalFileName(objComicWeb, dtmDate);
				// Si no existe el archivo lo descarga
					if (!System.IO.File.Exists(strFileName))
						{ // Crea el directorio de salida
								Bau.Libraries.LibHelper.Files.HelperFiles.MakePath(System.IO.Path.GetDirectoryName(strFileName));
							// Descarga el archivo
								try
									{	DownloadFile(objComicWeb.GetWebFileName(dtmDate), strFileName);
									}
								catch (Exception objException)
									{ // Elimina el archivo que se puede haber creado en la descarga
											Bau.Libraries.LibHelper.Files.HelperFiles.KillFile(strFileName);
										// Muestra el mensaje de error
											Bau.Controls.Forms.Helper.ShowMessage(this, 
																														"Error al descargar el archivo\n" + objException.Message);
									}
						}
				// Si existe el archivo, lo carga
					if (System.IO.File.Exists(strFileName))
						imgPage.Picture = Image.FromFile(strFileName);
					else
						Bau.Controls.Forms.Helper.ShowMessage(this, "No se puede encontrar ninguna imagen para ese día");
				// Muestra la fecha en el combo
					cboPages.Text = dtmDate.ToShortDateString();
		}
		
		/// <summary>
		///		Muestra la imagen en el control
		/// </summary>
		private void ShowPicture(string strFileName)
		{ try
				{ imgPage.Picture = Image.FromFile(strFileName);
				}
			catch (Exception objException)
				{ Bau.Controls.Forms.Helper.ShowMessage(this, "Error al mostrar la imagen del archivo " + strFileName +
																											"\n" + objException.Message);
				}
		}
		
		/// <summary>
		///		Descarga un archivo de la Web
		/// </summary>
		private void DownloadFile(string strWebFileName, string strLocalFileName)
		{ 
			//Bau.Libraries.LibHelper.Helper.Web.clsProxy objProxy = new Bau.Libraries.Helper.Web.clsProxy();
			//Bau.Libraries.Helper.Web.clsHTTP objHTTP = new Bau.Libraries.Helper.Web.clsHTTP();
		
			//  // Inicializa el proxy
			//    objProxy.Enabled = Properties.Settings.Default.UseProxy;
			//    objProxy.Server = Properties.Settings.Default.ProxyIP;
			//    objProxy.Port = Properties.Settings.Default.ProxyPort;
			//    objProxy.User = Properties.Settings.Default.ProxyUser;
			//    objProxy.Password = Properties.Settings.Default.ProxyPassword;
			//    objProxy.Type = Bau.Libraries.Helper.Web.clsProxy.TypeProxy.HTTP;			  
			//  // Descarga el archivo
			//    objHTTP.Download(objProxy, strWebFileName, strLocalFileName);
		}
		
		/// <summary>
		///		Ejecuta una acción desde el menú principal
		/// </summary>
		public void ExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Copy:
							Clipboard.SetImage(imgPage.Picture);
						break;
					case clsEnums.TypeAction.Cut:
						break;
					case clsEnums.TypeAction.Print:
					case clsEnums.TypeAction.PrintPreview:
					case clsEnums.TypeAction.PrintWithDialog:
						break;
					case clsEnums.TypeAction.Remove:
						break;
				}
		}

		/// <summary>
		///		Comprueba si el formulario puede realizar una acción
		/// </summary>
		public bool CanExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Copy:
					case clsEnums.TypeAction.Print:
					case clsEnums.TypeAction.PrintPreview:
					case clsEnums.TypeAction.PrintWithDialog:
					case clsEnums.TypeAction.Remove:
						return true;
					default:
						return false;
				}
		}

		/// <summary>
		///		Rutina de tratamiento del evento Changed de los controles
		/// </summary>
		public void Changed(object sender, EventArgs e)
		{ // ... no hace nada, se crea para soportar el interface
		}
		
		public string IDData
		{ get { return objComicWeb.ID; }
			set { objComicWeb = Program.ComicsWeb.SearchByID(value); }
		}

		private void frmWebComic_Load(object sender, EventArgs e)
		{ InitForm();		
		}

		private void cboPages_TextUpdate(object sender, EventArgs e)
		{ ShowPage(GetComboDate());
		}

		private void cmdGoPreviousPage_Click(object sender, EventArgs e)
		{ ShowPage(GetComboDate().AddDays(-1));
		}

		private void cmdGoFirstPage_Click(object sender, EventArgs e)
		{ ShowPage(GetComboDate().AddDays(-7));
		}

		private void cmdGoNextPage_Click(object sender, EventArgs e)
		{ ShowPage(GetComboDate().AddDays(1));
		}

		private void cmdGoLastPage_Click(object sender, EventArgs e)
		{ ShowPage(GetComboDate().AddDays(7));		
		}
	}
}
