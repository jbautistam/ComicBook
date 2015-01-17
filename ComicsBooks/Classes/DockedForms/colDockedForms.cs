using System;
using System.Collections.Generic;
using System.IO;

using WeifenLuo.WinFormsUI.Docking;

namespace Bau.Applications.ComicsBooks.Classes
{
	/// <summary>
	///		Colección de formularios fijos (o que pueden serlo)
	/// </summary>
	public class colDockedForms : List<clsDockedForm>
	{ // Constantes privadas
			private const string cnstStrFileConfig = "ComicBookWindows.config";
		// Enumerados públicos
			public enum FormType
				{ Unknown,
					Comic,
					ComicWeb,
					ePub,
					ePubCreator,
					Help
				}
		
		/// <summary>
		/// 	Carga la configuración de las ventanas
		/// </summary>
		public bool LoadDockConfiguration(string strPath, DockPanel dckMain)
		{ DeserializeDockContent objDockContent = new DeserializeDockContent(GetContentFromPersistString);
			string strFileName = Path.Combine(strPath, cnstStrFileConfig);
			bool blnLoad = false;

				// Carga la configuración de las ventanas
					if (File.Exists(strFileName))
						try
							{	// Carga la configuración
									dckMain.LoadFromXml(strFileName, objDockContent);
								// Indica que se ha cargado correctamente
									blnLoad = true;
							}
						catch (Exception objException)
							{ // Cuando no hay nada en el archivo XML saltan excepciones no controlables
									System.Diagnostics.Debug.WriteLine("colDockedForms: " + objException.Message);
							}
				// Devuelve el valor que indica si se ha cargado correctamente
					return blnLoad;
		}
		
		/// <summary>
		/// 	Obtiene la configuración de la ventana a partir de la cadena grabada en el archivo de configuración
		/// </summary>
		private IDockContent GetContentFromPersistString(string strConfiguration)
		{ IDockContent frmForm = null;
			
				// Recorre la colección buscando la ventana apropiada
					foreach (clsDockedForm objForm in this)
						if (strConfiguration == objForm.Form.GetType().ToString())
							{ // Abre la ventana
									objForm.Show();
								// ... y la guarda
									frmForm = objForm.Form;
							}
				// Devuelve el formulario
					return frmForm;
		}		

		/// <summary>
		/// 	Graba la configuración de las ventanas
		/// </summary>
		public void SaveConfiguration(string strPath, DockPanel dckMain)
		{	dckMain.SaveAsXml(Path.Combine(strPath, cnstStrFileConfig));
		}	
		
		/// <summary>
		///		Actualiza el árbol del explorador
		/// </summary>
		public void RefreshExplorerServices()
		{ foreach (clsDockedForm objForm in this)
				if (objForm.Form is Bau.Applications.ComicsBooks.Forms.Explorer.frmExplorerFiles)
					((Bau.Applications.ComicsBooks.Forms.Explorer.frmExplorerFiles) objForm.Form).RefreshForm();
		}
		
		/// <summary>
		///		Abre una ventana de búsqueda
		/// </summary>
		public System.Windows.Forms.Form OpenFormSearch<TypeData>(FormType intForm)
		{ return OpenForm<string>(intForm, true, null);
		}
		
		/// <summary>
		///		Abre una ventana de administración
		/// </summary>
		public System.Windows.Forms.Form OpenFormAdmon<TypeData>(FormType intForm, TypeData strID)
		{ return OpenForm<TypeData>(intForm, false, strID);
		}
		
		/// <summary>
		///		Abre una ventana dockada
		/// </summary>
		public System.Windows.Forms.Form OpenForm<TypeData>(FormType intForm)
		{ return OpenForm<string>(intForm, false, "");
		}

		/// <summary>
		///		Abre un formulario a partir del nombre de archivo
		/// </summary>
		internal void OpenForm(string strFileName)
		{ if (strFileName.EndsWith(".ePub", StringComparison.CurrentCultureIgnoreCase))
				OpenForm<string>(colDockedForms.FormType.ePub, false, strFileName);
			else if (Libraries.LibComicsBooks.ComicBook.IsComic(strFileName))
				OpenForm<string>(colDockedForms.FormType.Comic, false, strFileName);
		}
		
		/// <summary>
		///		Abre un formulario
		/// </summary>
		private System.Windows.Forms.Form OpenForm<TypeData>(FormType intForm, bool blnSearch, TypeData strID)
		{ DockContent frmDocument = GetForm(intForm, blnSearch);
		
				if (frmDocument == null)
					throw new Exception("No existe un formulario del tipo especificado");
				else
					{	// Pasa el código al formulario
							if (!blnSearch)
								((Classes.IFormAdmon<TypeData>) frmDocument).IDData = strID;
						// Cambia el tag del formulario
							if (blnSearch)
								frmDocument.Tag += "SEARCH_" + intForm.ToString();
							else
								frmDocument.Tag += GetTag(intForm, strID);
						// Abre el formulario
							Program.MainWindow.OpenWindowDocument(frmDocument);
						// Devuelve el formulario
							return frmDocument;
					}
		}
		
		/// <summary>
		///		Obtiene un formulario 
		/// </summary>
		private DockContent GetForm(FormType intForm, bool blnSearch)
		{ DockContent dckForm = null;
		
				// Obtiene el formulario
					switch (intForm)
						{	case FormType.Comic:
									if (!blnSearch)
										dckForm = new Forms.Comic.frmComic();
								break;
							case FormType.ComicWeb:
									if (!blnSearch)
										dckForm = new Forms.ComicWeb.frmWebComic();
								break;
							case FormType.ePub:
									if (!blnSearch)
										dckForm = new Forms.ePub.frmEPub();
								break;
							case FormType.ePubCreator:
									if (!blnSearch)
										dckForm = new Forms.ePub.frmEPubCreator();
								break;
							case FormType.Help:
									if (!blnSearch)
										dckForm = new Forms.Help.frmHelp();
								break;
						}
				// Devuelve el formulario
					return dckForm;
		}
		
		/// <summary>
		///		Obtiene el tag de un formulario
		/// </summary>
		internal static string GetTag<TypeData>(FormType intForm, TypeData strID)
		{ if (!(strID is string) || string.IsNullOrEmpty(strID as string))
				return intForm.ToString();
			else
				return intForm.ToString() + "_" + (strID as string);
		}
	}
}