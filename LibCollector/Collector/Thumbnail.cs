using System;
using System.Drawing;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Imagen asociada a un elemento
	/// </summary>
	public class Thumbnail : BaseCollector
	{ // Constantes privadas
			internal const string cnstStrXMLTagRoot = "Image";
			private const string cnstStrXMLTagThumbnail = "Thumb";

		/// <summary>
		///		Carga los datos de un nodo XML
		/// </summary>
		internal void LoadXML(MLNode objXMLNode)
		{ 
			//foreach (MLNode objMLChild in objXMLNode.Nodes)
			//	if (objMLChild.Name == cnstStrXMLTagThumbnail)
			//		Image = objMLChild.Value;
		}
		
		/// <summary>
		///		Obtiene el XML del elemento
		/// </summary>
		internal MLNode GetXML()
		{ MLNode objMLNode = new MLNode(cnstStrXMLTagRoot);

			// Cuerpo
				objMLNode.Nodes.Add(BaseCollector.cnstStrXMLTagID, base.ID);
				objMLNode.Nodes.Add(cnstStrXMLTagThumbnail, Image.ToString());
			// Cierre
				return objMLNode;
		}	
		
		public Image Image { get; set; }
	}
}
