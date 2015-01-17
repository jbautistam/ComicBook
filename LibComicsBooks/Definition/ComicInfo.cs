using System;
using System.Xml;

namespace Bau.Libraries.LibComicsBooks.Definition
{
	/// <summary>
	///		Información de un cómic
	/// </summary>
	public class ComicInfo
	{ // Constantes privadas
			private const string cnstStrTagRoot = "ComicBook";
		// Enumerados públicos
			public enum AgeRating
			{ Unknown,
				AllAges,
				Teens,
				ParentalAdvisory,
				ExplicitContent
			}

		public ComicInfo()
		{ Properties = new ComicInfoPropertiesCollection();
		}
		
		/// <summary>
		///		Carga la información de un cómic de un archivo
		/// </summary>
		public void Load(string strFileName)
		{ XmlDocument objXMLDocument = new XmlDocument();
		
				// Limpia el contenido
					Properties.Clear();
				// Carga el archivo
					objXMLDocument.Load(strFileName);
				// Carga el contenido del archivo
					foreach (XmlNode objXMLRoot in objXMLDocument.ChildNodes)
						if (objXMLRoot.Name == cnstStrTagRoot)
							foreach (XmlNode objXMLNode in objXMLRoot.ChildNodes)
								Properties.Add(objXMLNode.Name, objXMLNode.InnerText);
		}
		
		/// <summary>
		///		Graba la información en un archivo XML
		/// </summary>
		public void Save(string strFileName)
		{ XmlDocument objXMLDocument = new XmlDocument();
			string strXML = "";
			
				// Inicializa el nodo de propiedades
					strXML = "<?xml version='1.0' encoding='utf-8'?>\r\n";
					strXML += "<" + cnstStrTagRoot + ">\r\n";
				// Añade las propiedades
					foreach (ComicInfoProperty objProperty in Properties)
						{ strXML += "<" + objProperty.Name + ">\r\n";
							strXML += "<![CDATA[" + objProperty.Value + "]]>\r\n";
							strXML += "</" + objProperty.Name + ">\r\n";
						}
				// Cierra el nodo
					strXML += "</" + cnstStrTagRoot + ">\r\n";
				// Carga los nodos en el documento
					objXMLDocument.LoadXml(strXML);
				// Graba el documento
					objXMLDocument.Save(strFileName);
		}
		
		public ComicInfoPropertiesCollection Properties { get; set; }
		
		public string ComicFileName
		{ get { return Properties["FileName"].Value; }
			set { Properties["FileName"].Value = value; }
		}
		
		public string Title
		{ get { return Properties["Title"].Value; }
			set { Properties["Title"].Value = value; }
		}
		
		public string Summary
		{ get { return Properties["Summary"].Value; }
			set { Properties["Summary"].Value = value; }
		}
		
		public string Notes
		{ get { return Properties["Notes"].Value; }
			set { Properties["Notes"].Value = value; }
		}

		public string Serie
		{ get { return Properties["Serie"].Value; }
			set { Properties["Serie"].Value = value; }
		}
		
		public string Number
		{ get { return Properties["Number"].Value; }
			set { Properties["Number"].Value = value; }
		}
		
		public string NumberTotal
		{ get { return Properties["NumberTotal"].Value; }
			set { Properties["NumberTotal"].Value = value; }
		}
		
		public string DatePublish
		{ get { return Properties["DatePublish"].Value; }
			set { Properties["DatePublish"].Value = value; }
		}
		
		public string Genre
		{ get { return Properties["Genre"].Value; }
			set { Properties["Genre"].Value = value; }
		}
		
		public string Author
		{ get { return Properties["Author"].Value; }
			set { Properties["Author"].Value = value; }
		}
		
		public string Editorial
		{ get { return Properties["Editorial"].Value; }
			set { Properties["Editorial"].Value = value; }
		}
		
		public string Drawer
		{ get { return Properties["Drawer"].Value; }
			set { Properties["Drawer"].Value = value; }
		}
		
		public string Editor
		{ get { return Properties["Editor"].Value; }
			set { Properties["Editor"].Value = value; }
		}
		
		public string Categories
		{ get { return Properties["Categories"].Value; }
			set { Properties["Categories"].Value = value; }
		}
		
		internal string FileName
		{ get { return "ComicBookInfo.xcbml"; }
		}
	}
}
