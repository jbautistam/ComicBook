using System;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Valor de un parámetro
	/// </summary>
	public class ParameterValue : BaseCollector
	{ // Constantes privadas
			internal const string cnstStrXMLTagRoot = "ParameterValue";
			private const string cnstStrXMLTagValue = "Value";

		/// <summary>
		///		Carga los datos de un nodo XML
		/// </summary>
		internal void LoadXML(MLNode objXMLNode)
		{ if (objXMLNode.Name == cnstStrXMLTagRoot)
				foreach (MLNode objXMLItem in objXMLNode.Nodes)
					switch (objXMLItem.Name)
						{ case BaseCollector.cnstStrXMLTagID:
									base.ID = objXMLItem.Value;
								break;
							case cnstStrXMLTagValue:
									Value = objXMLItem.Value;
								break;
						}
		}

		/// <summary>
		///		Obtiene el XML del elemento
		/// </summary>
		internal MLNode GetXML()
		{ MLNode objMLNode = new MLNode(cnstStrXMLTagRoot);

				// Cuerpo
					objMLNode.Nodes.Add(cnstStrXMLTagID, base.ID);
					objMLNode.Nodes.Add(cnstStrXMLTagValue, Value);
				// Cierre
					return objMLNode;
		}
			
		public string Value { get; set; }
	}
}
