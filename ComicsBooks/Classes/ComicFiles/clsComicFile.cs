using System;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Applications.ComicsBooks.Classes.ComicFiles
{
	/// <summary>
	///		Clase con los datos del último archivo abierto
	/// </summary>
	public class clsComicFile : IComparable<clsComicFile>
	{ // Constantes internas
			internal const string cnstStrXMLTagRoot = "File";
			internal const string cnstStrXMLTagFileName = "FileName";
			internal const string cnstStrXMLTagDateOpen = "DateOpen";
			internal const string cnstStrXMLTagLastPage = "LastPage";
		// Variables privadas
			private string strFileName;
			private DateTime dtmOpen;
			private int intPage;
			
		public clsComicFile(string strFileName, DateTime dtmOpen, int intPage)
		{ FileName = strFileName;
			DateOpen = dtmOpen;
			Page = intPage;
		}

		/// <summary>
		///		Carga los datos de un nodo XML
		/// </summary>
		internal void LoadXML(MLNode objXMLNode)
		{	foreach (MLNode objXMLTag in objXMLNode.Nodes)
				switch (objXMLTag.Name)
					{ case cnstStrXMLTagFileName:
								FileName = objXMLTag.Value;
							break; 
						case cnstStrXMLTagDateOpen:
								DateOpen = objXMLTag.Value.GetDateTime() ?? DateTime.Now;
							break;
						case cnstStrXMLTagLastPage:
								Page = objXMLNode.Value.GetInt(0);
							break;
					}
		}
		
		/// <summary>
		///		Obtiene un nodo XML
		/// </summary>
		internal MLNode GetXML()
		{ MLNode objMLNode = new MLNode(cnstStrXMLTagRoot);

				// Elemento
					objMLNode.Nodes.Add(cnstStrXMLTagFileName, FileName);
					objMLNode.Nodes.Add(cnstStrXMLTagDateOpen,	DateOpen);
					objMLNode.Nodes.Add(cnstStrXMLTagLastPage, Page);
				// Devuelve el nodo XML
					return objMLNode;
		}
		
		public string FileName
		{ get { return strFileName; }
			set { strFileName = value; }
		}
		
		public DateTime DateOpen
		{ get { return dtmOpen; }
			set { dtmOpen = value; }
		}
		
		public int Page
		{ get { return intPage; }
			set { intPage = value; }
		}
		
		/// <summary>
		///		Implementación de IComparable
		/// </summary>
		public int CompareTo(clsComicFile objLastFile)
		{ return DateOpen.CompareTo(objLastFile.DateOpen);
		}
	}
}
