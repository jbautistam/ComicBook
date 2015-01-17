using System;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Clave asociada a un elemento de la biblioteca
	/// </summary>
	public class ParameterKey : BaseCollector
	{ // Constantes privadas
			internal const string cnstStrXMLTagRoot = "ParameterKey";
			private const string cnstStrXMLTagName = "IDParameterName";
			private const string cnstStrXMLTagValue = "IDParameterValue";
			
		public ParameterKey(string strIDParameterName, string strIDParameterValue)
		{ IDParameterName = strIDParameterName;
			IDParameterValue = strIDParameterValue;
		}

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
							case cnstStrXMLTagName:
									IDParameterName = objXMLItem.Value;
								break;
							case cnstStrXMLTagValue:
									IDParameterValue = objXMLItem.Value;
								break;
						}
		}
		
		/// <summary>
		///		Obtiene el XML del elemento
		/// </summary>
		internal MLNode GetXML()
		{ MLNode objMLNode = new MLNode(cnstStrXMLTagRoot);

				// Elementos
					objMLNode.Nodes.Add(cnstStrXMLTagName, IDParameterName);
					objMLNode.Nodes.Add(cnstStrXMLTagValue, IDParameterValue);
				// Cierre
					return objMLNode;
		}
		
		public string IDParameterName { get; set; }
		
		public string IDParameterValue { get; set; }
	}
}
