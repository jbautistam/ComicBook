using System;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Controls.WebExplorer.Common
{
	/// <summary>
	///		Datos de un vínculo
	/// </summary>
	public class Link
	{ // Constantes privadas
			internal const string cnstStrTagRoot = "Link";
			
		public Link() : this(null) {}
		
		public Link(string strURL)
		{ URL = strURL;
		}

		/// <summary>
		///		Carga los datos de un nodo
		/// </summary>
		internal void Load(MLNode objMLNode)
		{ if (objMLNode.Name == cnstStrTagRoot)
				URL = objMLNode.Value;
		}
		
		/// <summary>
		///		Obtiene el XML de un vínculo
		/// </summary>
		internal MLNode GetXML()
		{ return new MLNode(cnstStrTagRoot, URL);
		}
		
		/// <summary>
		///		URL a la que se asocia el vínculo
		/// </summary>
		public string URL { get; set; }
	}
}
