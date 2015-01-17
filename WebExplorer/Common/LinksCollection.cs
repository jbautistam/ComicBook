using System;
using System.Collections.Generic;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Controls.WebExplorer.Common
{
	/// <summary>
	///		Colección de <see cref="Link"/>
	/// </summary>
	public class LinksCollection : List<Link>
	{ // Constantes privadas
			internal const string cnstStrTagRoot = "Links";
			
		/// <summary>
		///		Añade una URL a la colección
		/// </summary>
		public void Add(string strURL)
		{ // Si hay algún vínculo igual lo elimina
				Remove(strURL);
			// Añade el vínculo
				if (!strURL.StartsWith("res://", StringComparison.CurrentCultureIgnoreCase))
					Add(new Link(strURL));
		}

		/// <summary>
		///		Elimina una URL si existe
		/// </summary>
		public void Remove(string strURL)
		{ int intIndex = IndexOf(strURL);
		
				// Elimina la URL	
					if (intIndex >= 0)
						RemoveAt(intIndex);
		}
		
		/// <summary>
		///		Obtiene el índice de una URL
		/// </summary>
		public int IndexOf(string strURL)
		{ // Recorre la colección buscando el índice
				for (int intIndex = 0; intIndex < Count; intIndex++)
					if (strURL.Equals(this[intIndex].URL, StringComparison.CurrentCultureIgnoreCase))
						return intIndex;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return -1;
		}
		
		/// <summary>
		///		Carga los datos de un nodo
		/// </summary>
		internal void Load(MLNode objMLNode)
		{ if (objMLNode.Name == cnstStrTagRoot)
				foreach (MLNode objMLChild in objMLNode.Nodes)
					if (objMLChild.Name == Link.cnstStrTagRoot)
						{ Link objLink = new Link();
						
								// Carga los datos
									objLink.Load(objMLChild);
								// Añade el vínculo a la colección
									if (!string.IsNullOrEmpty(objLink.URL))
										Add(objLink);
						}
		}
		
		/// <summary>
		///		Obtiene el XML de la colección
		/// </summary>
		internal MLNode GetXML()
		{ MLNode objMLNode = new MLNode(cnstStrTagRoot);
		
				// Nodos
					foreach (Link objLink in this)
						objMLNode.Nodes.Add(objLink.GetXML());
				// Devuelve el nodo
					return objMLNode;
		}
	}
}
