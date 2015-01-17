using System;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Colección de <see cref="Thumbnail"/>
	/// </summary>
	public class ThumbnailsCollection : BaseCollectorCollection<Thumbnail>
	{ // Constantes privadas
			internal const string cnstStrXMLTagRoot = "Images";

		/// <summary>
		///		Carga las imágenes a partir del XML
		/// </summary>
		internal void LoadXML(MLNode objXMLNode)
		{ if (objXMLNode.Name == cnstStrXMLTagRoot)
				foreach (MLNode objXMLItem in objXMLNode.Nodes)
					if (objXMLItem.Name == Thumbnail.cnstStrXMLTagRoot)
						{ Thumbnail objThumbnail = new Thumbnail();
						
								// Carga el XML
									objThumbnail.LoadXML(objXMLItem);
								// Añade el objeto a la colección
									Add(objThumbnail);
						}
		}
			
		/// <summary>
		///		Obtiene el XML de la colección
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
