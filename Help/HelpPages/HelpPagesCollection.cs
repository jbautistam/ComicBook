using System;
using System.Xml;

namespace Bau.Controls.Help.HelpPages
{
	/// <summary>
	///		Colección de <see cref="HelpPage"/>
	/// </summary>
	public class HelpPagesCollection : System.Collections.Generic.List<HelpPage>
	{ // Constantes privadas
			private const string cnstStrTagRoot = "HelpPages";
			private const string cnstStrTagPage = "Page";
			
		/// <summary>
		///		Carga la colección de páginas de ayuda
		/// </summary>
		public void Load(string strFileName)
		{ XmlDocument objXMLDocument = new XmlDocument();
		
				// Carga el documento
					objXMLDocument.Load(strFileName);
				// Recorre los nodos del documento guardando las páginas
					foreach (XmlNode objXMLNode in objXMLDocument.ChildNodes)
						if (objXMLNode.Name == cnstStrTagRoot)
							Load(objXMLNode.ChildNodes, System.IO.Path.GetDirectoryName(strFileName));
		}

		/// <summary>
		///		Carga las páginas de una serie de nodos
		/// </summary>
		internal void Load(XmlNodeList objColXMLNodes, string strPath)
		{ foreach (XmlNode objXMLHelp in objColXMLNodes)
				if (objXMLHelp.Name == cnstStrTagPage)
					{ HelpPage objPage = new HelpPage(Guid.NewGuid().ToString());
					
							// Carga los datos
								objPage.Load(objXMLHelp, strPath);
							// Añade la página
								Add(objPage);
					}
		}
	}
}