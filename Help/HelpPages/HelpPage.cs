using System;
using System.Xml;

namespace Bau.Controls.Help.HelpPages
{
	/// <summary>
	///		Definición de una página de ayuda
	/// </summary>
	public class HelpPage
	{ // Constantes privadas
			private const string cnstStrTagName = "Name";
			private const string cnstStrTagDescription = "Description";
			private const string cnstStrTagFileName = "FileName";
			private const string cnstStrTagPages = "Pages";
		// Variables privadas
			private string strKey, strName, strDescription, strPath, strFileName;
			private HelpPage objParent;
			private HelpPagesCollection objColPages;
			
		public HelpPage(string strKey)
		{ Key = strKey;
			Pages = new HelpPagesCollection();
		}

		/// <summary>
		///		Carga los datos de una página
		/// </summary>
		internal void Load(XmlNode objXMLHelp, string strPath)
		{ // Guarda el directorio
				Path = strPath;
			// Carga los datos de los nodos XML
				foreach (XmlNode objXMLData in objXMLHelp.ChildNodes)
					switch (objXMLData.Name)
						{ case cnstStrTagName:
									Name = objXMLData.InnerText;
								break;
							case cnstStrTagDescription:
									Description = objXMLData.InnerText;
								break;
							case cnstStrTagFileName:
									FileName = objXMLData.InnerText;
								break;
							case cnstStrTagPages:
									Pages.Load(objXMLData.ChildNodes, Path);
								break;
						}
		}

		public string Key
		{ get { return strKey; }
			set { strKey = value; }
		}		
		
		public string Name
		{ get { return strName; }
			set { strName = value; }
		}
		
		public string Description
		{ get { return strDescription; }
			set { strDescription = value; }
		}
		
		public string Path
		{ get { return strPath; }
			set { strPath = value; }
		}
		
		public string FileName
		{ get { return strFileName; }
			set { strFileName = value; }
		}
		
		public HelpPage Parent
		{ get { return objParent; }
			set { objParent = value; }
		}
		
		public HelpPagesCollection Pages
		{ get { return objColPages; }
			set { objColPages = value; }
		}
		
		public string FullFileName
		{ get { return System.IO.Path.Combine(Path, FileName); }
		}
	}
}