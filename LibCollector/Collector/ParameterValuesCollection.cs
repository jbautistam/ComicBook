using System;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Colección de valores de un parámetro
	/// </summary>
	public class ParameterValuesCollection : BaseCollectorCollection<ParameterValue>
	{ // Constantes privadas
			internal const string cnstStrXMLTagRoot = "ParameterValues";

		/// <summary>
		///		Añade un elemento 
		/// </summary>
		public ParameterValue Add(string strValue)
		{ return SearchByValue(strValue);	
		}
		
		/// <summary>
		///		Busca un elemento si no lo encuentra, lo añade
		/// </summary>
		private ParameterValue SearchByValue(string strValue)
		{ // Recorre la colección buscando el elemento
				foreach (ParameterValue objParameter in this)
					if (objParameter.Value.Equals(strValue, StringComparison.CurrentCultureIgnoreCase))
						return objParameter;
			// Crea un nuevo parámetro
				ParameterValue objNewParameter = new ParameterValue();
				
					objNewParameter.Value = strValue;
			// ... y lo añade a la colección
				Add(objNewParameter);
			// Devuelve el parámetro
				return objNewParameter;
		}

		
		/// <summary>
		///		Busca un elemento por su ID
		/// </summary>
		private ParameterValue SearchByID(string strIDValue)
		{ // Recorre la colección buscando el elemento
				foreach (ParameterValue objParameter in this)
					if (objParameter.ID.Equals(strIDValue, StringComparison.CurrentCultureIgnoreCase))
						return objParameter;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
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
								// Añade el objeto a la colección
									Add(objValue);
						}
		}
			
		/// <summary>
		///		Obtiene el XML de la colección
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
