using System;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Elemento de la biblioteca
	/// </summary>
	public class LibraryItem : BaseCollector
	{ // Constantes privadas
			internal const string cnstStrFileExtension = "clml";
			private const string cnstStrXMLTagRoot = "LibratyItem";
			private const string cnstStrXMLTagRank = "Rank";
			private const string cnstStrXMLTagFileName = "FileName";
			private const string cnstStrXMLTagDateLastOpen = "DateLastOpen";
		
		public LibraryItem()
		{ Rank = 0;
			FileName = LibraryItem.StringNull;
			DateLastOpen = LibraryItem.DateNull;
			Thumbnails = new ThumbnailsCollection();
			Keys = new ParameterKeysCollection();
		}	

		/// <summary>
		///		Carga el XML de un archivo
		/// </summary>
		internal void LoadXML(string strFileName)
		{ MLFile objMLFile = new XMLParser().Load(strFileName);
		
				// Carga los nodos
					foreach (MLNode objXMLNode in objMLFile.Nodes)
						if (objXMLNode.Name == cnstStrXMLTagRoot)
							foreach (MLNode objXMLItem in objXMLNode.Nodes)
								switch (objXMLItem.Name)
									{ case BaseCollector.cnstStrXMLTagID:
												base.ID = objXMLItem.Value;
											break;
										case cnstStrXMLTagRank:
												Rank = objXMLItem.Value.GetInt(0);
											break;
										case cnstStrXMLTagFileName:
												FileName = objXMLItem.Value;
											break;
										case cnstStrXMLTagDateLastOpen:
												DateLastOpen = objXMLItem.Value.GetDateTime() ?? DateTime.Now;
											break;
										case ThumbnailsCollection.cnstStrXMLTagRoot:
												Thumbnails.LoadXML(objXMLItem);
											break;
										case ParameterKeysCollection.cnstStrXMLTagRoot:
												Keys.LoadXML(objXMLItem);
											break;
									}
		}
		
		/// <summary>
		///		Graba el archivo XML
		/// </summary>
		internal void Save(string strFileName)
		{ MLFile objMLFile = new MLFile();;
		
				// Genera el XML
					objMLFile.Nodes.Add(GetXML());
				// Graba el archivo
					try
						{ new XMLWriter().Save(objMLFile, strFileName);
						}
					catch {}
		}
		
		/// <summary>
		///		Obtiene una cadena XML con los datos
		/// </summary>
		internal MLNode GetXML()
		{ MLNode objMLNode = new MLNode(cnstStrXMLTagRoot);

				// Elementos
					objMLNode.Nodes.Add(cnstStrXMLTagRank, Rank);
					objMLNode.Nodes.Add(cnstStrXMLTagFileName, FileName);
					objMLNode.Nodes.Add(cnstStrXMLTagDateLastOpen, DateLastOpen);
				// Colecciones
					objMLNode.Nodes.Add(Thumbnails.GetXML());
					objMLNode.Nodes.Add(Keys.GetXML());
				// Devuelve el nodo
					return objMLNode;
		}
		
		public int Rank { get; set; }

		public string FileName { get; set; }

		public DateTime DateLastOpen { get; set; }
		
		public ThumbnailsCollection Thumbnails { get; set; }
		
		public ParameterKeysCollection Keys { get; set; }
	}
}
