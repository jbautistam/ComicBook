using System;
using System.Collections.Generic;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Applications.ComicsBooks.Classes.ComicFiles
{
	/// <summary>
	///		Colección de <see cref="clsComicFile"/>
	/// </summary>
	public class colComicBookmarks : List<clsComicBookmark>
	{ // Constantes privadas
			private const string cnstStrFileName = "ComicBookBookmarks.xml";
			private const int cnstIntMaxBookmarks = 200;
			
		/// <summary>
		///		Añade un marcador a la colección
		/// </summary>
		public void Add(string strFileName, DateTime dtmOpen, int intPage, string strRemarks)
		{ // Añade el marcador
				Add(new clsComicBookmark(strFileName, dtmOpen, intPage, strRemarks));
			// Ordena
				Sort();
			// Si hay más de x, elimina el primero
				if (Count > cnstIntMaxBookmarks)
					RemoveAt(0);
		}
		
		/// <summary>
		///		Carga los marcadores
		/// </summary>
		public void Load(string strPath)
		{ if (System.IO.File.Exists(System.IO.Path.Combine(strPath, cnstStrFileName)))
				{ MLFile objMLFile = new XMLParser().Load(System.IO.Path.Combine(strPath, cnstStrFileName));

						// Carga los nodos
							foreach (MLNode objXMLRoot in objMLFile.Nodes)
								if (objXMLRoot.Name == "Bookmarks")
									foreach (MLNode objXMLNode in objXMLRoot.Nodes)
										if (objXMLNode.Name == clsComicBookmark.cnstStrXMLTagRoot)
											{ clsComicBookmark objBookmark = new clsComicBookmark("", DateTime.Now, 0, null);
											
													// Carga los datos del nodo XML
														objBookmark.LoadXML(objXMLNode);
													// Añade el marcador a la colección
														if (!string.IsNullOrEmpty(objBookmark.File.FileName))
															Add(objBookmark);
											}
				}
		}
		
		/// <summary>
		///		Graba el archivo XML
		/// </summary>
		public void Save(string strPath)
		{ MLFile objMLFile = new MLFile();
			MLNode objMLRoot = objMLFile.Nodes.Add("Bookmarks");

				// Añade el XML de los nodos
					foreach (clsComicBookmark objBookmark in this)
						objMLRoot.Nodes.Add(objBookmark.GetXML());
				// Graba el archivo
					new XMLWriter().Save(objMLFile, System.IO.Path.Combine(strPath, cnstStrFileName));
		}
	
		/// <summary>
		///		Busca un marcador
		/// </summary>
		private clsComicBookmark Search(string strFileName)
		{	// Obtiene el nombre de archivo (sin nombre del directorio)
				strFileName = System.IO.Path.GetFileName(strFileName);
			// Busca el archivo en la colección
				foreach (clsComicBookmark objBookmark in this)
					if (System.IO.Path.GetFileName(objBookmark.File.FileName).Equals(strFileName, 
																																					 StringComparison.CurrentCultureIgnoreCase))
						return objBookmark;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}
	}
}
