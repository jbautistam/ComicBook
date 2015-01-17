using System;
using System.Collections.Generic;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Applications.ComicsBooks.Classes.ComicFiles
{
	/// <summary>
	///		Colecci�n de <see cref="clsComicFile"/>
	/// </summary>
	public class colComicLastOpenFiles : List<clsComicFile>
	{ // Constantes privadas
			private const string cnstStrFileName = "ComicBookLastFiles.xml";
			
		/// <summary>
		///		A�ade un archivo a la colecci�n
		/// </summary>
		public void Add(string strFileName, DateTime dtmOpen)
		{ int intLastPage = 0;
		
				// Elimina el archivo si exist�a
					for (int intIndex = Count - 1; intIndex >= 0; intIndex--)
						if (strFileName.Equals(this[intIndex].FileName, StringComparison.CurrentCultureIgnoreCase))
							{ // Antes de eliminar guarda la �ltima p�gina
									intLastPage = this[intIndex].Page;
								// Elimina la p�gina
									RemoveAt(intIndex);
							}
				// A�ade el archivo
					Add(new clsComicFile(strFileName, dtmOpen, intLastPage));
				// Ordena
					Sort();
				// Si hay m�s de diez, elimina el primero
					if (Count > 10)
						RemoveAt(0);
		}
		
		/// <summary>
		///		Carga los archivos abiertos
		/// </summary>
		public void Load(string strPath)
		{	if (System.IO.File.Exists(System.IO.Path.Combine(strPath, cnstStrFileName)))
				{ MLFile objMLFile = new XMLParser().Load(System.IO.Path.Combine(strPath, cnstStrFileName));

						// Carga los nodos
							foreach (MLNode objXMLRoot in objMLFile.Nodes)
								if (objXMLRoot.Name == "LastFiles")
									foreach (MLNode objXMLNode in objXMLRoot.Nodes)
										if (objXMLNode.Name == clsComicFile.cnstStrXMLTagRoot)
											{ clsComicFile objLastFile = new clsComicFile("", DateTime.Now, 0);
											
													// Carga los datos del nodo XML
														objLastFile.LoadXML(objXMLNode);
													// A�ade el archivo a la colecci�n
														if (!string.IsNullOrEmpty(objLastFile.FileName))
															Add(objLastFile);
											}
				}
		}
		
		/// <summary>
		///		Graba el archivo XML
		/// </summary>
		public void Save(string strPath)
		{ MLFile objMLFile = new MLFile();
			MLNode objMLRoot = objMLFile.Nodes.Add("LastFiles");

				// A�ade el XML de los nodos
					foreach (clsComicFile objLastFile in this)
						objMLRoot.Nodes.Add(objLastFile.GetXML());
				// Graba el archivo
					new XMLWriter().Save(objMLFile, System.IO.Path.Combine(strPath, cnstStrFileName));
		}
	
		/// <summary>
		///		Busca un archivo
		/// </summary>
		private clsComicFile	Search(string strFileName)
		{	// Obtiene el nombre de archivo (sin nombre del directorio)
				strFileName = System.IO.Path.GetFileName(strFileName);
			// Busca el archivo en la colecci�n
				foreach (clsComicFile objLastFile in this)
					if (System.IO.Path.GetFileName(objLastFile.FileName).Equals(strFileName, StringComparison.CurrentCultureIgnoreCase))
						return objLastFile;
			// Si ha llegado hasta aqu� es porque no ha encontrado nada
				return null;
		}
		
		/// <summary>
		///		Asigna la �ltima p�gina le�da
		/// </summary>
		public void SetLastPage(string strFileName, int intLastPage)
		{ clsComicFile objLastFile = Search(strFileName);
		
				if (objLastFile != null)
					objLastFile.Page = intLastPage;
		}
		
		/// <summary>
		///		Obtiene la �ltima p�gina le�da
		/// </summary>
		public int GetLastPage(string strFileName)
		{ clsComicFile objLastFile = Search(strFileName);
		
				if (objLastFile != null)
					return objLastFile.Page;
				else
					return 0;
		}
	}
}
