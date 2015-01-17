using System;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Colecci�n de valores de un par�metro
	/// </summary>
	public class ParameterValuesCollection : BaseCollectorCollection<ParameterValue>
	{ // Constantes privadas
			internal const string cnstStrXMLTagRoot = "ParameterValues";

		/// <summary>
		///		A�ade un elemento 
		/// </summary>
		public ParameterValue Add(string strValue)
		{ return SearchByValue(strValue);	
		}
		
		/// <summary>
		///		Busca un elemento si no lo encuentra, lo a�ade
		/// </summary>
		private ParameterValue SearchByValue(string strValue)
		{ // Recorre la colecci�n buscando el elemento
				foreach (ParameterValue objParameter in this)
					if (objParameter.Value.Equals(strValue, StringComparison.CurrentCultureIgnoreCase))
						return objParameter;
			// Crea un nuevo par�metro
				ParameterValue objNewParameter = new ParameterValue();
				
					objNewParameter.Value = strValue;
			// ... y lo a�ade a la colecci�n
				Add(objNewParameter);
			// Devuelve el par�metro
				return objNewParameter;
		}

		
		/// <summary>
		///		Busca un elemento por su ID
		/// </summary>
		private ParameterValue SearchByID(string strIDValue)
		{ // Recorre la colecci�n buscando el elemento
				foreach (ParameterValue objParameter in this)
					if (objParameter.ID.Equals(strIDValue, StringComparison.CurrentCultureIgnoreCase))
						return objParameter;
			// Si ha llegado hasta aqu� es porque no ha encontrado nada
				return null;
		}
		
		/// <summary>
		///		Carga los elementos de un nodo XML
		/// </summary>
		internal void LoadXML(MLNode objXMLNode)
		{ if (objXMLNode.Name == cnstStrXMLTagRoot)
				foreach (MLNode objXMLItem in objXMLNode.Nodes)
					if (objXMLItem.Name == ParameterValue.cnstStrXMLTagRoot)
						{ ParameterValue objValue = new ParameterValue();
						
								// Carga los datos
									objValue.LoadXML(objXMLItem);
								// A�ade el objeto a la colecci�n
									Add(objValue);
						}
		}
			
		/// <summary>
		///		Obtiene el XML de la colecci�n
		/// </summary>
		internal MLNode GetXML()
		{ MLNode objMLNode = new MLNode(cnstStrXMLTagRoot);

				// Elementos
					foreach (ParameterValue objValue in this)
						objMLNode.Nodes.Add(objValue.GetXML());
				// Devuelve el nodo
					return objMLNode;
		}		
		
		public ParameterValue this[string strIDValue]
		{ get { return SearchByID(strIDValue); }
		}
	}
}
