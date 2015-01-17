using System;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Colecci�n de <see cref="Thumbnail"/>
	/// </summary>
	public class ThumbnailsCollection : BaseCollectorCollection<Thumbnail>
	{ // Constantes privadas
			internal const string cnstStrXMLTagRoot = "Images";

		/// <summary>
		///		Carga las im�genes a partir del XML
		/// </summary>
		internal void LoadXML(MLNode objXMLNode)
		{ if (objXMLNode.Name == cnstStrXMLTagRoot)
				foreach (MLNode objXMLItem in objXMLNode.Nodes)
					if (objXMLItem.Name == Thumbnail.cnstStrXMLTagRoot)
						{ Thumbnail objThumbnail = new Thumbnail();
						
								// Carga el XML
									objThumbnail.LoadXML(objXMLItem);
								// A�ade el objeto a la colecci�n
									Add(objThumbnail);
						}
		}
			
		/// <summary>
		///		Obtiene el XML de la colecci�n
		/// </summary>
		internal MLNode GetXML()
		{ MLNode objMLNode = new MLNode(cnstStrXMLTagRoot);

				// Elementos
					foreach (Thumbnail objThumbnail in this)
						objMLNode.Nodes.Add(objThumbnail.GetXML());
			// Fin
				return objMLNode;
		}
	}
}
