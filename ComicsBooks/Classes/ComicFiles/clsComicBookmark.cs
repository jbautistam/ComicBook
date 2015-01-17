using System;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Applications.ComicsBooks.Classes.ComicFiles
{
	/// <summary>
	///		Marcador de página
	/// </summary>
	public class clsComicBookmark : IComparable<clsComicBookmark>
	{ // Variables privadas
			internal const string cnstStrXMLTagRoot = "Bookmark";
			internal const string cnstStrXMLTagRemarks = "Remarks";
		// Variables privadas
			private clsComicFile objFile;
			private string strRemarks;
			
		public clsComicBookmark(string strFileName, DateTime dtmOpen, int intPage, string strRemarks) 
				: this(new clsComicFile(strFileName, dtmOpen, intPage), strRemarks) {}
		
		public clsComicBookmark(clsComicFile objFile, string strRemarks)
		{ File = objFile;
			Remarks = strRemarks;
		}

		/// <summary>
		///		Carga los datos de un nodo XML
		/// </summary>
		internal void LoadXML(MLNode objXMLTag)
		{	foreach (MLNode objXMLNode in objXMLTag.Nodes)
				switch (objXMLNode.Name)
					{ case clsComicFile.cnstStrXMLTagFileName:
								File.LoadXML(objXMLNode);
							break;
						case cnstStrXMLTagRemarks:
								Remarks = objXMLNode.Value;
							break;
					}
		}
		
		/// <summary>
		///		Obtiene el nodoXML
		/// </summary>
		internal MLNode GetXML()
		{ MLNode objMLNode = new MLNode(cnstStrXMLTagRoot);

				// Elemento
					objMLNode.Nodes.Add(File.GetXML());
					objMLNode.Nodes.Add(cnstStrXMLTagRemarks, Remarks);
				// Devuelve la cadena XML
					return objMLNode;
		}
		
		public clsComicFile File
		{ get 
				{ // Si no hay ningún archivo asociado, lo crea
						if (objFile == null)
							objFile = new clsComicFile("", DateTime.Now, 0);
					// Devuelve el archivo
						return objFile; 
				}
			set { objFile = value; }
		}
		
		public string Remarks
		{ get { return strRemarks; }
			set { strRemarks = value; }
		}
		
		/// <summary>
		///		Implementación de IComparable
		/// </summary>
		public int CompareTo(clsComicBookmark objFile)
		{ return File.CompareTo(objFile.File);
		}
	}
}
